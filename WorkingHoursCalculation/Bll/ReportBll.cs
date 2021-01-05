using FastReport;
using FastReport.Export.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
        /// <param name="FDataSet"></param>
        public void RegisterData(DataSet FDataSet)
        {
            report.RegisterData(FDataSet);
        }

        /// <summary>
        /// 导出PDF
        /// </summary>
        public void ReportExport()
        {
            report.Prepare();

            // create export instance
            PDFExport export = new PDFExport();

            // export the report
            report.Export(export, "result.pdf");

            // free resources used by report
            report.Dispose();
        }
    }
}
