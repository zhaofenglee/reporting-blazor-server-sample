using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Drawing;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Hosting;

namespace Acme.BookStore.Report.Blazor
{
    public class CustomWebDocumentViewerReportResolver : IWebDocumentViewerReportResolver
    {
        readonly string ReportDirectory;
        const string FileExtension = ".repx";
        
        public CustomWebDocumentViewerReportResolver(IWebHostEnvironment env)
        {
           
            ReportDirectory = Path.Combine(env.ContentRootPath, "Reports");
            if (!Directory.Exists(ReportDirectory))
            {
                Directory.CreateDirectory(ReportDirectory);
            }
        }
        public XtraReport Resolve(string reportEntry)
        {
            string reportName = reportEntry.Substring(0, reportEntry.IndexOf("?") == -1 ? reportEntry.Length : reportEntry.IndexOf("?"));
            int paramIndex = reportEntry.IndexOf("?") == -1 ? 0 : reportEntry.IndexOf("?");
            var collection = HttpUtility.ParseQueryString(reportEntry.Substring(paramIndex, reportEntry.Length - paramIndex));
           
            var query = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(reportEntry.Substring(reportEntry.IndexOf("?") + 1));
            IEnumerable<KeyValuePair<string, string>> parameterDictionary = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value));

            using (var ms = new MemoryStream())
            {
                XtraReport report = XtraReport.FromXmlFile(Path.Combine(ReportDirectory, reportName + FileExtension));
                report.Font =  new DXFont("SimSun", 10, DXFontStyle.Regular, DXGraphicsUnit.Point);
                report.DataSource = CreateObjectDataSource(reportName, parameterDictionary);
                return report;
            }
        }

        private object CreateObjectDataSource(string reportName, IEnumerable<KeyValuePair<string, string>> parameterDictionary)
        {
            ObjectDataSource dataSource = new ObjectDataSource();
            dataSource.Name = "WeatherForecast";
            dataSource.DataSource = typeof(WeatherForecastDto);
            dataSource.Constructor = ObjectConstructorInfo.Default;
            // var parameter = new Parameter()
            // {
            //     Name = "sampleAppService",
            //     Type = typeof(ISampleAppService),
            //     Value = SampleAppService
            // };
            //dataSource.Constructor = new ObjectConstructorInfo(parameter);
            dataSource.DataMember = "Items";
            return dataSource;
            }
        }

    
}
