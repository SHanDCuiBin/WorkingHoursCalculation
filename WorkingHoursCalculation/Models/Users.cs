using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Models
{
    public class Users
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 创建账号时间
        /// </summary>
        public string createtime { get; set; }
        /// <summary>
        /// 账号可用状态
        /// </summary>
        public string enable { get; set; }
    }
}
