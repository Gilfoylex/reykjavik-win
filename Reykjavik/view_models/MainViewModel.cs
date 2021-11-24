using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reykjavik.view_models
{
    public class MainViewModel : BaseViewModel
    {
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
    }
}
