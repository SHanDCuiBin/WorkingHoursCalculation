using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Models
{
    class Personnel
    { 
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string lxdh { get; set; }
        /// <summary>
        /// 主要工作
        /// </summary>
        public string mainwork { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createtime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string createusername { get; set; }
        /// <summary>
        /// 状态 1 启用；2 禁用
        /// </summary>
        public string enable { get; set; }
    }
}
