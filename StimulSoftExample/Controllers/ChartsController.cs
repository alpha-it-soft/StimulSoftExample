using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using static Stimulsoft.Base.Drawing.StiFontReader;
using System.Text;

namespace StimulSoftExample.Controllers
{
    public class ChartsController : Controller
    {
       
        static ChartsController()
        {
            // How to Activate
            Stimulsoft.Base.StiLicense.Key = ConfigurationManager.AppSettings["StiLicenseKey"];
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport()
        {
          
     

                    // Create the report object
                    var report = new StiReport();
                  
                    report.Load(Server.MapPath("~/Reports/Barchart.mrt"));
 
                    //set report name
                    report.ReportName = "Balkendiagramm_" + DateTime.Now.ToString("yyyy_MM_dd HH_mm");
 
                    
           

            // Remove all connections from the report template
            report.Dictionary.Databases.Clear();

            // Register DataSet object
            int busobjLevel = 1;

            StimulSoftExample.Models.StiBusinessObject stiObj = new StimulSoftExample.Models.StiBusinessObject();
            string path = Server.MapPath("~/Data/Data.txt");
            string text=System.IO.File.ReadAllText(path, Encoding.UTF8);
            try
            {
                stiObj=Newtonsoft.Json.JsonConvert.DeserializeObject<StimulSoftExample.Models.StiBusinessObject>(text);
            }
            catch (Exception x)
            {
                stiObj = new StimulSoftExample.Models.StiBusinessObject();
            }    
            report.RegBusinessObject("Data", stiObj);
            //string json=Newtonsoft.Json.JsonConvert.SerializeObject(stiObj);
            //string path = "C:\\temp\\Data.txt";
            //System.IO.File.WriteAllText(path, json, Encoding.UTF8);
            report.Dictionary.SynchronizeBusinessObjects(busobjLevel);

            return StiMvcViewer.GetReportResult(report);

        }

        public ActionResult ViewerEvent()
        {
            return StiMvcViewer.ViewerEventResult();
        }
    }
}