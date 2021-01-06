using FastReport;
using FastReport.Export.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkingHoursCalculation.Bll
{
    /// <summary>
    /// 导出报表
    /// </summary>
    public class ReportBll
    {
        private DataSet FDataSet;

        Report report = new Report();

        public ReportBll()
        {
            //加载模版
            report.Load(@"ReportsModels\report.frx");

            FDataSet = new DataSet();

            DataTable table = new DataTable();
            table.TableName = "Employees";
            FDataSet.Tables.Add(table);

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));

            table.Rows.Add(1, "Andrew Fuller");
            table.Rows.Add(2, "Nancy Davolio");
            table.Rows.Add(3, "Margaret Peacock");
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="FDataSet"></param>
        public void RegisterData(DataSet FDataSet)
        {
            report.RegisterData(FDataSet);
        }

        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <param name="filesPath">文件夹名字</param>
        /// <param name="filesName">文件名</param>
        public void ReportExport(string filesPath)
        {
            report.Prepare();

            // create export instance
            PDFExport export = new PDFExport();

            // export the report
            report.Export(export, filesPath);

            // free resources used by report
            report.Dispose();

        }
    }
}
