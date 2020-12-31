using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Models
{
    public class termList
    {
        /// <summary>
        /// 数据库操作参数类
        /// </summary>
        /// <param name="fieldName">列名</param>
        /// <param name="paramName">列别名</param>
        /// <param name="fieldResult">列值</param>
        /// <param name="k">0=，1>=,2<=,3 like,4 <> ,5 in 6 is not null 7 is null 8> 9< </param>
        public termList(string fieldName, string paramName, string fieldResult, int k)
        {
            this.FieldName = fieldName;
            this.ParamName = paramName;

            this.FieldResult = fieldResult;
            this.K = k;
        }
        string fieldName;
        string paramName;
        string fieldResult;
        int k;

        /// <summary>
        /// 列名
        /// </summary>
        public string FieldName { get => fieldName; set => fieldName = value; }
        /// <summary>
        /// 列 别名
        /// </summary>
        public string ParamName { get => paramName; set => paramName = value; }
        /// <summary>
        /// 值
        /// </summary>
        public string FieldResult { get => fieldResult; set => fieldResult = value; }
        /// <summary>
        /// 比较操作符
        /// </summary>
        public int K { get => k; set => k = value; }
    }
}
