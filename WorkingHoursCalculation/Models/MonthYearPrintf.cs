using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Models
{
    /// <summary>
    /// 月份、年份打印
    /// </summary>
    public class MonthYearPrintf
    {
        /// <summary>
        /// 月份、年份
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 出勤天数
        /// </summary>
        public string dateSum { get; set; }

        /// <summary>
        /// 时长- 最短
        /// </summary>
        public string durationLow { get; set; }

        /// <summary>
        /// 时长- 最长
        /// </summary>
        public string durationHeight { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public string duration { get; set; }
        /// <summary>
        /// 扣除时长
        /// </summary>
        public string deductDuration { get; set; }

        /// <summary>
        /// 平均
        /// </summary>
        public string avgDuration { get; set; }

        /// <summary>
        /// 累计时长
        /// </summary>
        public string accumulativeTotalDuration { get; set; }
    }
}
