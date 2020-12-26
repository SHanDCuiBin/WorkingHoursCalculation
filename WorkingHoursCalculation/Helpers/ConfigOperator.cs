using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Helpers
{
    class ConfigOperator
    {
        #region 从配置文件获取Value
        /// <summary>
        /// 从配置文件获取Value
        /// </summary>
        /// <param name="key">配置文件中key字符串</param>
        /// <returns></returns>
        public static string GetValueFromConfig(string key)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //获取AppSettings的节点 
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                return appsection.Settings[key].Value;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 设置配置文件
        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="key">配置文件中key字符串</param>
        /// <param name="value">配置文件中value字符串</param>
        /// <returns></returns>
        public static bool SetValueFromConfig(string key, string value)
        {
            try
            {
                //打开配置文件 
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //获取AppSettings的节点 
                AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");
                appsection.Settings[key].Value = value;
                config.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
