using FastReport;
using FastReport.Export.Pdf;
using FastReport.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Helpers;
using WorkingHoursCalculation.Models;

namespace WorkingHoursCalculation.Bll
{
    /// <summary>
    /// 导出报表
    /// </summary>
    public class ReportBll
    {
        Report report = new Report();

        public ReportBll()
        {
            //加载模版
            report.Load(@"ReportsModels\report.frx");
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="dt">数据结果</param>
        /// <param name="userNamek">人员名称</param>
        /// <param name="timeLimit">时间范围</param>
        public bool RegisterData(DataTable dt, string userNamek, string dateLimit)
        {
            try
            {
                #region 获取人员信息
                string sql = "Select * from Personnel where enable='1' and name='" + DESJiaMi.Encrypt(userNamek) + "';";
                DataTable userUpdate = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
                if (userUpdate != null && userUpdate.Rows.Count > 0)
                {
                    //姓名
                    string workerName = userUpdate.Rows[0]["name"].ToString();
                    if (!string.IsNullOrEmpty(workerName))
                    {
                        workerName = DESJiaMi.Decrypt(workerName);
                        report.SetParameterValue("workername", workerName);
                    }
                    else
                    {
                        report.SetParameterValue("workername", "");
                    }

                    //性别
                    string xingbie = userUpdate.Rows[0]["gender"].ToString();
                    if (!string.IsNullOrEmpty(xingbie))
                    {
                        xingbie = DESJiaMi.Decrypt(xingbie);
                        report.SetParameterValue("gender", xingbie);
                    }
                    else
                    {
                        report.SetParameterValue("gender", "");
                    }

                    //联系电话
                    string lxdh = userUpdate.Rows[0]["lxdh"].ToString();
                    if (!string.IsNullOrEmpty(lxdh))
                    {
                        lxdh = DESJiaMi.Decrypt(lxdh);
                        report.SetParameterValue("lxdh", lxdh);
                    }
                    else
                    {
                        report.SetParameterValue("lxdh", "");
                    }

                    //主要工作
                    string mainwork = userUpdate.Rows[0]["mainwork"].ToString();
                    if (!string.IsNullOrEmpty(mainwork))
                    {
                        report.SetParameterValue("mainwork", mainwork);
                    }
                    else
                    {
                        report.SetParameterValue("mainwork", "");
                    }

                    //统计时间
                    report.SetParameterValue("dateLimit", dateLimit);

                    TableObject TableOfDay = report.FindObject("TableOfDay") as TableObject;      //每日统计表格
                    TableObject TableOfMonth = report.FindObject("TableOfMonth") as TableObject;  //每月统计表格
                    TableObject TableOfYear = report.FindObject("TableOfYear") as TableObject;    //每年统计表格
                    List<DataRow> drsDay = new List<DataRow>();     //每一天
                    List<DataRow> drsMonth = new List<DataRow>();   //每一月
                    List<DataRow> drsYear = new List<DataRow>();    //每一年
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string workdate = dt.Rows[i]["workdate"].ToString();

                        #region 天
                        if (drsDay.Count != 0)
                        {
                            if (drsDay[0]["workdate"].ToString() == workdate)
                            {
                                drsDay.Add(dt.Rows[i]);
                            }
                            else
                            {
                                TableAddRows(TableOfDay, drsDay.Count);
                                SetValueInReportOfDayInfo(TableOfDay, drsDay, i + 1 - drsDay.Count);
                                drsDay = new List<DataRow>();
                                drsDay.Add(dt.Rows[i]);
                            }
                        }
                        else
                        {
                            drsDay.Add(dt.Rows[i]);
                        }
                        #endregion

                        #region 月份
                        if (drsMonth.Count != 0)
                        {
                            if (drsMonth[0]["workdate"].ToString().Substring(0, 7) == workdate.Substring(0, 7))
                            {
                                drsMonth.Add(dt.Rows[i]);
                            }
                            else
                            {
                                TableAddRows(TableOfMonth, 1);
                                SetValueInReportOfMonthYearInfo(TableOfMonth, drsMonth, "Month");
                                drsMonth = new List<DataRow>();
                                drsMonth.Add(dt.Rows[i]);
                            }
                        }
                        else
                        {
                            drsMonth.Add(dt.Rows[i]);
                        }
                        #endregion

                        #region 年份
                        if (drsYear.Count != 0)
                        {
                            if (drsYear[0]["workdate"].ToString().Substring(0, 4) == workdate.Substring(0, 4))
                            {
                                drsYear.Add(dt.Rows[i]);
                            }
                            else
                            {
                                TableAddRows(TableOfYear, 1);
                                SetValueInReportOfMonthYearInfo(TableOfYear, drsYear, "Year");
                                drsYear = new List<DataRow>();
                                drsYear.Add(dt.Rows[i]);
                            }
                        }
                        else
                        {
                            drsYear.Add(dt.Rows[i]);
                        }
                        #endregion

                    }
                    TableAddRows(TableOfDay, drsDay.Count);
                    SetValueInReportOfDayInfo(TableOfDay, drsDay, dt.Rows.Count + 1 - drsDay.Count);

                    TableAddRows(TableOfMonth, 1);
                    SetValueInReportOfMonthYearInfo(TableOfMonth, drsMonth, "Month");

                    TableAddRows(TableOfYear, 1);
                    SetValueInReportOfMonthYearInfo(TableOfYear, drsYear, "Year");

                    //累计时长
                    List<DataRow> drs = new List<DataRow>();
                    foreach (DataRow item in dt.Rows)
                    {
                        drs.Add(item);
                    }
                    double SumTimes = GetCumulativeTime(drs);
                    if (!string.IsNullOrEmpty(SumTimes.ToString()))
                    {
                        report.SetParameterValue("timesSums", SumTimes.ToString("0.000"));
                    }
                    else
                    {
                        report.SetParameterValue("timesSums", "");
                    }

                }
                else
                {
                    return false;
                }
                #endregion

                DataSet FDataSet = new DataSet();
                report.RegisterData(FDataSet);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 给表格赋值-"日期"
        /// </summary>
        /// <param name="drs"></param>
        /// <param name="rowIndex"></param>
        private void SetValueInReportOfDayInfo(TableObject TableOfDa, List<DataRow> drs, int rowIndex)
        {
            if (drs != null && drs.Count > 0)
            {
                int num = 1;
                foreach (DataRow item in drs)
                {
                    if (num == 1)
                    {
                        TableOfDa.Rows[rowIndex][0].Text = item["workdate"].ToString();
                        TableOfDa.Rows[rowIndex][6].Text = GetCumulativeTime(drs).ToString("0.000");
                    }
                    TableOfDa.Rows[rowIndex][1].Text = item["starttime"].ToString();
                    TableOfDa.Rows[rowIndex][2].Text = item["endtime"].ToString();

                    //计算时长
                    string timeStart = item["starttime"].ToString();
                    string timeEnd = item["endtime"].ToString();
                    if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
                    {
                        DateTime dtStart = DateTime.Now;   //开始时间
                        DateTime dtEnd = DateTime.Now;     //结束时间
                        if (DateTime.TryParse(timeStart, out dtStart) && DateTime.TryParse(timeEnd, out dtEnd))
                        {
                            TableOfDa.Rows[rowIndex][3].Text = GetTimeDuration(dtStart, dtEnd).ToString("0.000");
                        }
                    }

                    TableOfDa.Rows[rowIndex][4].Text = item["deduct"].ToString();
                    TableOfDa.Rows[rowIndex][5].Text = item["deductreason"].ToString();
                    num++;
                    rowIndex++;
                }
            }
        }

        /// <summary>
        /// 给表格赋值-"月份","年份"
        /// </summary>
        /// <param name="TableOfDa"></param>
        /// <param name="drs"></param>
        /// <param name="type"></param>
        private void SetValueInReportOfMonthYearInfo(TableObject TableOfDa, List<DataRow> drs, string type)
        {
            if (drs != null && drs.Count > 0)
            {
                int index = TableOfDa.Rows.Count - 1;
                MonthYearPrintf monthYearPrintf = CalMonthYear(drs);
                if (monthYearPrintf != null && !string.IsNullOrEmpty(monthYearPrintf.date))
                {
                    if (type == "Month")
                    {
                        TableOfDa.Rows[index][0].Text = monthYearPrintf.date.Substring(0, 7);       //月份
                    }
                    else
                    {
                        TableOfDa.Rows[index][0].Text = monthYearPrintf.date.Substring(0, 4);       //年份
                    }
                    TableOfDa.Rows[index][1].Text = monthYearPrintf.dateSum;                        //出勤天数
                    TableOfDa.Rows[index][2].Text = monthYearPrintf.durationLow;                    //最短时长
                    TableOfDa.Rows[index][3].Text = monthYearPrintf.durationHeight;                 //最长时长
                    TableOfDa.Rows[index][4].Text = monthYearPrintf.duration;                       //时长
                    TableOfDa.Rows[index][5].Text = monthYearPrintf.deductDuration;                 //扣除时长
                    TableOfDa.Rows[index][6].Text = monthYearPrintf.avgDuration;                    //平均时长
                    TableOfDa.Rows[index][7].Text = monthYearPrintf.accumulativeTotalDuration;      //累计时长
                }
            }
        }
        /// <summary>
        /// 计算年份、月份时间信息
        /// </summary>
        /// <returns></returns>
        private MonthYearPrintf CalMonthYear(List<DataRow> drs)
        {
            try
            {
                MonthYearPrintf monthYearPrintf = new MonthYearPrintf();

                int sumDays = 0;                   //出勤天数
                double duration = 0;               //总时长
                double deductDuration = 0;         //总扣除时长

                if (drs != null && drs.Count > 0)
                {
                    monthYearPrintf.date = drs[0]["workdate"].ToString();
                    string workdate = "0000-00-01";

                    Dictionary<string, double> timeDic = new Dictionary<string, double>();
                    for (int i = 0; i < drs.Count; i++)
                    {
                        string timeStart = drs[i]["starttime"].ToString();
                        string timeEnd = drs[i]["endtime"].ToString();
                        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
                        {
                            DateTime dtStart = DateTime.Now;   //开始时间
                            DateTime dtEnd = DateTime.Now;     //结束时间
                            if (DateTime.TryParse(timeStart, out dtStart) && DateTime.TryParse(timeEnd, out dtEnd))
                            {
                                double time = GetTimeDuration(dtStart, dtEnd);

                                #region 
                                if (drs[i]["workdate"].ToString() == workdate)
                                {
                                    timeDic[workdate] += time;
                                }
                                else
                                {
                                    sumDays++;
                                    workdate = drs[i]["workdate"].ToString();
                                    timeDic.Add(workdate, time);
                                }
                                #endregion

                                duration += time;

                                string deductTime = drs[i]["deduct"].ToString();
                                if (!string.IsNullOrEmpty(deductTime))
                                {
                                    timeDic[workdate] -= double.Parse(deductTime);
                                    deductDuration += double.Parse(deductTime);
                                }
                            }
                        }
                    }

                    string valueLow = timeDic.OrderBy(d => d.Value).Select(d => d.Key).FirstOrDefault();
                    string valueHeight = timeDic.OrderBy(d => d.Value).Select(d => d.Key).LastOrDefault();

                    monthYearPrintf.dateSum = sumDays.ToString();
                    monthYearPrintf.durationLow = valueLow + ": " + timeDic[valueLow].ToString("0.000") + "h";
                    monthYearPrintf.durationHeight = valueHeight + ": " + timeDic[valueHeight].ToString("0.000") + "h";
                    monthYearPrintf.duration = duration.ToString("0.000");
                    monthYearPrintf.deductDuration = deductDuration.ToString("0.000");
                    monthYearPrintf.accumulativeTotalDuration = (duration - deductDuration).ToString("0.000");
                    monthYearPrintf.avgDuration = ((duration - deductDuration) / sumDays).ToString("0.000");
                }

                return monthYearPrintf;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary> 
        /// 获取累计时间 单位 小时  
        /// </summary>
        private double GetCumulativeTime(List<DataRow> drs)
        {
            try
            {
                double timeValue = 0.0;
                if (drs != null && drs.Count > 0)
                {
                    if (drs[0].Table.Columns.Contains("starttime") && drs[0].Table.Columns.Contains("endtime"))
                    {
                        foreach (DataRow item in drs)
                        {
                            string timeStart = item["starttime"].ToString();
                            string timeEnd = item["endtime"].ToString();
                            if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
                            {
                                DateTime dtStart = DateTime.Now;   //开始时间
                                DateTime dtEnd = DateTime.Now;     //结束时间
                                if (DateTime.TryParse(timeStart, out dtStart) && DateTime.TryParse(timeEnd, out dtEnd))
                                {
                                    double times = GetTimeDuration(dtStart, dtEnd);
                                    string deductTime = item["deduct"].ToString();
                                    if (!string.IsNullOrEmpty(deductTime))
                                    {
                                        timeValue += (times - double.Parse(deductTime));
                                    }
                                    else
                                    {
                                        timeValue += times;
                                    }
                                }
                            }
                        }
                    }
                }
                return timeValue;
            }
            catch (Exception)
            {
                return 0.0; ;
            }
        }

        /// <summary>
        /// 根据时间获取时间差
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        private double GetTimeDuration(DateTime dtStart, DateTime dtEnd)
        {
            TimeSpan ts1 = new TimeSpan(dtStart.Ticks);
            TimeSpan ts2 = new TimeSpan(dtEnd.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            return ts.TotalHours;
        }

        /// <summary>
        /// 设置单元格样式 及 文字样式
        /// </summary>
        private void SetCellStyles(TableCell tableCell)
        {
            //所有的边框
            tableCell.Border.Lines = BorderLines.All;
            //“文字”垂直位置
            tableCell.VertAlign = VertAlign.Center;
            //“文字”水平位置
            tableCell.HorzAlign = HorzAlign.Center;

            tableCell.Font = new Font("微软雅黑", 9);
        }

        /// <summary>
        /// 设置 单元格样式 及 文字样式
        /// </summary>
        private void TableAddRows(TableObject table, int rowNums)
        {
            int uniteStart = table.Rows.Count;
            int tableColumns = table.Columns.Count;
            if (rowNums > 0)
            {
                for (int i = 0; i < rowNums; i++)
                {
                    TableRow row = new TableRow();
                    table.Rows.Add(row);
                    row.Height = 28f;
                    for (int j = 0; j < table.ColumnCount; j++)
                    {
                        SetCellStyles(row[j]);
                    }
                }

                #region 合并单元格
                table.Rows[uniteStart][0].RowSpan = rowNums;
                table.Rows[uniteStart][tableColumns - 1].RowSpan = rowNums;
                #endregion
            }
        }

        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <param name="filesName">文件名</param>
        public bool ReportExport(string fileName)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //设置文件类型 
                sfd.Filter = "PDF（*.pdf）|*.pdf";
                //设置默认文件类型显示顺序 
                sfd.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录 
                sfd.RestoreDirectory = true;
                //文件的名字
                sfd.FileName = fileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = sfd.FileName.ToString(); //获得文件路径  
                    report.Prepare();

                    // create export instance
                    PDFExport export = new PDFExport();

                    // export the report
                    report.Export(export, localFilePath);

                    // free resources used by report
                    report.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                return false;
            }
        }
    }
}
