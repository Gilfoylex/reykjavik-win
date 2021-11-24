using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;

namespace Reykjavik.view_models
{
    public partial class MainViewModel
    {
        private ObservableRangeCollection<string> _logList = new();

        public ObservableRangeCollection<string> LogList
        {
            get => _logList;
            set => SetProperty(ref _logList, value);
        }

        private void AddLogLine(string line)
        {
            UIBase.window.DispatchHelper.InvokeOnUIAsync(() =>
            {
                if (LogList.Count > 5000)
                {
                    LogList.Clear();
                }

                LogList.Add(line);
            });
        }
    }
}
