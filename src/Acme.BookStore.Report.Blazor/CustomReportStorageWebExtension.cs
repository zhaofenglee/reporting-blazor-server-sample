using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Drawing;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.ClientControls;
using Microsoft.AspNetCore.Hosting;

namespace Acme.BookStore.Report.Blazor
{
    public class CustomReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        readonly string ReportDirectory;
        const string FileExtension = ".repx";
        public CustomReportStorageWebExtension(IWebHostEnvironment env)
        {
            ReportDirectory = Path.Combine(env.ContentRootPath, "Reports");
            if (!Directory.Exists(ReportDirectory))
            {
                Directory.CreateDirectory(ReportDirectory);
            }
        }

        private bool IsWithinReportsFolder(string url, string folder)
        {
            var rootDirectory = new DirectoryInfo(folder);
            var fileInfo = new FileInfo(Path.Combine(folder, url));
            return fileInfo.Directory.FullName.ToLower().StartsWith(rootDirectory.FullName.ToLower());
        }

        public override bool CanSetData(string url)
        {
            // Determines whether it is possible to store a report by a given URL. 
            // For instance, make the CanSetData method return false for reports that should be read-only in your storage. 
            // This method is called only for valid URLs (for example, if the IsValidUrl method returns true) before the SetData method is called.

            return true;
        }

        public override bool IsValidUrl(string url)
        {
            // Determines whether the URL passed to the current Report Storage is valid. 
            // For instance, implement your own logic to prohibit URLs that contain white spaces or other special characters. 
            // This method is called before the CanSetData and GetData methods.

            return Path.GetFileName(url) == url;
        }

        public override byte[] GetData(string url)
        {
           // Returns report layout data stored in a Report Storage using the specified URL. 
            // This method is called only for valid URLs after the IsValidUrl method is called.
            try
            {
                /*if (Directory.EnumerateFiles(ReportDirectory).Select(Path.GetFileNameWithoutExtension).Contains(url))
                {
                    return File.ReadAllBytes(Path.Combine(ReportDirectory, url + FileExtension));
                }*/
                string reportName = url.Substring(0, url.IndexOf("?") == -1 ? url.Length : url.IndexOf("?"));
                int paramIndex = url.IndexOf("?") == -1 ? 0 : url.IndexOf("?");
                // var collection = HttpUtility.ParseQueryString(reportEntry.Substring(paramIndex, reportEntry.Length - paramIndex));
                // var reportLayout = reportStorageWebExtension.GetData(reportEntry);
                var query = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(url.Substring(url.IndexOf("?") + 1));
                IEnumerable<KeyValuePair<string, string>> parameterDictionary = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value));

                using (MemoryStream ms = new MemoryStream())
                {
                    XtraReport report = XtraReport.FromXmlFile(Path.Combine(ReportDirectory, reportName + FileExtension));
                    report.DataSource = CreateObjectDataSource(reportName,parameterDictionary);
                    report.RequestParameters = false;
                    //report.Font =  new DXFont("SimSun", 10, DXFontStyle.Regular, DXGraphicsUnit.Point);
                    report.SaveLayoutToXml(ms);
                    return ms.ToArray();
                }
                

                
            }
            catch (Exception ex)
            {
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException("Could not get report data.", ex);
            }
            throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", url));
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

        public override Dictionary<string, string> GetUrls()
        {
            // Returns a dictionary of the existing report URLs and display names. 
            // This method is called when running the Report Designer, 
            // before the Open Report and Save Report dialogs are shown and after a new report is saved to storage.

            return Directory.GetFiles(ReportDirectory, "*" + FileExtension)
                                     .Select(Path.GetFileNameWithoutExtension)
                                     .ToDictionary(x => x);
        }

        public override void SetData(XtraReport report, string url)
        {
            // Stores the specified report to a Report Storage using the specified URL. 
            // This method is called only after the IsValidUrl and CanSetData methods are called.
            if (!IsWithinReportsFolder(url, ReportDirectory))
                throw new FaultException("Invalid report name.");
            report.SaveLayoutToXml(Path.Combine(ReportDirectory, url + FileExtension));
        }

        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            // Stores the specified report using a new URL. 
            // The IsValidUrl and CanSetData methods are never called before this method. 
            // You can validate and correct the specified URL directly in the SetNewData method implementation 
            // and return the resulting URL used to save a report in your storage.
            SetData(report, defaultUrl);
            return defaultUrl;
        }
    }
}
