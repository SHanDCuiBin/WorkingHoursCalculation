using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Models
{
    class WorkingHours
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string workername { get; set; }
        /// <summary>
        /// 工作日期
        /// </summary>
        public string workdate { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string starttime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endtime { get; set; }
        /// <summary>
        /// 扣除时间
        /// </summary>
        public string deduct { get; set; }
        /// <summary>
        ///记录状态 1 正常；2 删除
        /// </summary>
        public string isdelete { get; set; }
    }
}
