using MvvmHelpers;
using MvvmHelpers.Commands;
using Reykjavik.models.XRayConfigDefine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using firework;
using Reykjavik.models;

namespace Reykjavik.view_models
{
    public partial class MainViewModel : BaseViewModel
    {
        private static readonly Lazy<MainViewModel> Lazy = new(() => new MainViewModel());
        public static MainViewModel Instance => Lazy.Value;

        private MainViewModel()
        {
            Init();
        }

        public string AppDataPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "reykjavik");
        public string TempPath = Path.Combine(Path.GetTempPath(), "reykjavik");

        public const string ConfigFileName = "reykjavikconfig.json";

        private LocalConfig _localConfig = new LocalConfig();

        private string _currentTab = "home";
        public string CurrentTab
        {
            get => _currentTab;
            set => SetProperty(ref _currentTab, value);
        }

        private Command? _tabCommand;
        public Command TabCommand => _tabCommand ??= new Command((param) =>
        {
            if (param is not string tabName) return;

            CurrentTab = tabName;
        });

        private utils.PacHttpServer _pacHttpServer = new ();

        private async void Init()
        {
            await InitLocalConfigAsync();
            InitHomeSetting();
            InitProxySetting();
            ReadPacContent();
        }

        private object localConfigLock = new object();
        private Task InitLocalConfigAsync()
        {
            return Task.Run(() =>
            {
                var configFullPath = Path.Join(AppDataPath, ConfigFileName);
                if (File.Exists(configFullPath))
                {
                    try
                    {
                        var jsonStr = "";

                        lock (localConfigLock)
                        {
                            using var rs = new StreamReader(configFullPath);
                            jsonStr = rs.ReadToEnd();
                        }

                        if (string.IsNullOrEmpty(jsonStr))
                            return;

                        var localJson = JsonSerializer.Deserialize<LocalConfig>(jsonStr);
                        if (localJson != null)
                            _localConfig = localJson;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            });
        }

        private string _pacContent = "";
        public string PacContent 
        { 
            get
            {
                lock(_pacContent)
                {
                    var length = _pacContent.Length;
                    if (length > 500)
                    {
                        var header = _pacContent[..500];
                        header = header.Replace("__PROXY__", @$"""PROXY 127.0.0.1:{HttpPort};""");
                        var body = _pacContent.Substring(500, length - 500);
                        return header + body;
                    }
                    else
                    {
                        return _pacContent;
                    }
                }
            }
            set
            {
                lock(_pacContent)
                {
                    _pacContent = value;
                }
            }
        }

        private void ReadPacContent()
        {
            Task.Run(() =>
            {
                try
                {
                    var currentPath = Environment.CurrentDirectory;
                    var pacPath = Path.Combine(currentPath, DefaultXRayConfig.PacProxyFileName);
                    var strContent = "";
                    if (File.Exists(pacPath))
                    {
                        using var rs = new StreamReader(pacPath);
                        strContent = rs.ReadToEnd();
                    }

                    PacContent = strContent;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }

        private void SaveLocalConfig()
        {
            Task.Run(() =>
            {
                var jsonStr = JsonSerializer.Serialize(_localConfig, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                if (!Directory.Exists(AppDataPath))
                    Directory.CreateDirectory(AppDataPath);

                var configFullPath = Path.Join(AppDataPath, ConfigFileName);
                lock (localConfigLock)
                {
                    using var sw = new StreamWriter(configFullPath);
                    sw.Write(jsonStr);
                }
            });
        }

    }
}
