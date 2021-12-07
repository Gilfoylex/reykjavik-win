using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reykjavik.utils
{
    /// <summary>
    /// 根据前后两次的增量计算速度
    /// </summary>
    public class SpeedCalculator
    {
        private List<long> _counts = new() { 0, 0};
        private int _nextWriteIndex = -1;

        public void Clean()
        {
            _counts = new() { 0, 0 };
            _nextWriteIndex = -1;
        }

        public long CalculateIncrements(long newCount)
        {
            if (_nextWriteIndex == -1)
            { 
                _counts[0] = newCount;
                _nextWriteIndex = 1;
                return 0;
            }

            if (_nextWriteIndex == 0)
            {
                _counts[0] = newCount;
                _nextWriteIndex = 1;
                return Math.Abs(_counts[1] - _counts[0]);
            }

            if (_nextWriteIndex == 1)
            {
                _counts[1] = newCount;
                _nextWriteIndex = 0;
                return Math.Abs(_counts[1] - _counts[0]);
            }

            return 0;
        }
    }
}
