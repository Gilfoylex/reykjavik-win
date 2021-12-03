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
