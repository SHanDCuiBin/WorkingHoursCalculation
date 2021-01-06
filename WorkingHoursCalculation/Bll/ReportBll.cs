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

                    //性别
                    string xingbie = userUpdate.Rows[0]["gender"].ToString();
                    if (!string.IsNullOrEmpty(xingbie))
                    {
                        xingbie = DESJiaMi.Decrypt(xingbie);
                        report.SetParameterValue("gender", xingbie);
                    }

                    //联系电话
                    string lxdh = userUpdate.Rows[0]["lxdh"].ToString();
                    if (!string.IsNullOrEmpty(lxdh))
                    {
                        lxdh = DESJiaMi.Decrypt(lxdh);
                        report.SetParameterValue("lxdh", lxdh);
                    }

                    //主要工作
                    string mainwork = userUpdate.Rows[0]["mainwork"].ToString();
                    if (!string.IsNullOrEmpty(mainwork))
                    {
                        report.SetParameterValue("mainwork", mainwork);
                    }
                    //统计时间
                    report.SetParameterValue("dateLimit", dateLimit);


                    TableObject TableOfDay = report.FindObject("TableOfDay") as TableObject;
                    List<DataRow> drs = new List<DataRow>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (drs.Count != 0)
                        {
                            string workdate = dt.Rows[i]["workdate"].ToString();
                            if (drs[0]["workdate"].ToString() == workdate)
                            {
                                drs.Add(dt.Rows[i]);
                                continue;
                            }
                            else
                            {
                                TableAddRows(TableOfDay, drs.Count);
                                SetValueInReportOfDayInfo(TableOfDay, drs, i + 1 - drs.Count);
                                drs = new List<DataRow>();
                                drs.Add(dt.Rows[i]);
                            }
                        }
                        else
                        {
                            drs.Add(dt.Rows[i]);
                            continue;
                        }
                    }

                    TableAddRows(TableOfDay, drs.Count);
                    SetValueInReportOfDayInfo(TableOfDay, drs, dt.Rows.Count + 1 - drs.Count);
                    drs = new List<DataRow>();

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
        /// 给表格赋值
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
                    row.Height =28f ;
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
        /// <param name="filesPath">文件夹名字</param>
        /// <param name="filesName">文件名</param>
        public bool ReportExport()
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
