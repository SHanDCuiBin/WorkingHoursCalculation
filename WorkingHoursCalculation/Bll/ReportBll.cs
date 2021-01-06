using FastReport;
using FastReport.Export.Pdf;
using FastReport.Table;
using System;
using System.Collections.Generic;
using System.Data;
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

                    FastReport.Table.TableObject TableOfDay = report.FindObject("TableOfDay") as FastReport.Table.TableObject;
                    TableOfDay.Rows.Add(new TableRow());
                    TableOfDay.Rows.Add(new TableRow());
                    TableOfDay.Rows.Add(new TableRow());

                    TableOfDay.Rows[1][1].Text = "123456";
                    TableOfDay.Rows[4][1].Border.Lines = BorderLines.All;

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
        }

        /// <summary>
        /// 设置 单元格样式 及 文字样式
        /// </summary>
        private void TableAddRows(TableObject table, int rowNums)
        {
            if (rowNums > 0)
            {
                for (int i = 0; i < rowNums; i++)
                {
                    table.Rows.Add(new TableRow());
                }
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
