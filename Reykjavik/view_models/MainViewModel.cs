using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reykjavik.view_models
{
    public partial class MainViewModel : BaseViewModel
    {
        private static readonly Lazy<MainViewModel> Lazy = new(() => new MainViewModel());
        public static MainViewModel Instance => Lazy.Value;

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

        private readonly XrayServer.XRayProcessHelper _xRayProcessHelper = new();

        private void StartXray()
        {
            _xRayProcessHelper.OutputLineAction += AddLogLine;
            _xRayProcessHelper.Start();
        }

        private void StopXray()
        {
            _xRayProcessHelper.OutputLineAction -= AddLogLine;
            _xRayProcessHelper.Stop();
        }

        private Command? _testStart;

        public Command TestStartCommand => _testStart ??= new Command((param) =>
        {
            StartXray();
        });

        private Command? _testStop;

        public Command TestStopCommand => _testStop ??= new Command((param) =>
        {
            StopXray();
        });
    }
}
