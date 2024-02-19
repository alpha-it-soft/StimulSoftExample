using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StimulSoftExample.Models
{    
    public class StiBusinessObject
    {
        public StiBusinessObject()
        {
            Info = new StiInfo();
            Summary = new List<CsvSummary>();
            ChartPages = new List<StiPage>();
            Table1 = new List<StiTable>();
            Table2 = new List<StiTable>();
            Table3 = new List<StiTable>();
            Table4 = new List<StiTable>();
        }
        public StiInfo Info { get; set; }
        public List<CsvSummary> Summary { get; set; }
        public List<StiPage> ChartPages { get; set; }
        public List<StiTable> Table1 { get; set; }
        public List<StiTable> Table2 { get; set; }
        public List<StiTable> Table3 { get; set; }
        public List<StiTable> Table4 { get; set; }
    }
    public class StiInfo
    {
        public string InspectionTask { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public DateTime StartReport { get; set; }
        public string ChangeStatus { get; set; }
        public int ControlLimit { get; set; }
        public string UserLabel { get; set; }
        public string ReportTypeISRA { get; set; }
        public int CountCsvReference { get; set; }
        public int CountCsv { get; set; }
        public int CountCharts { get; set; }
        public int CountQlv { get; set; }
        public string Template { get; set; }

        public StiInfo()
        {

        }
        
    }
    public class StiPage
    {
        public int PageNumber { get; set; }
        public bool Visible { get; set; }
        public string Base64 { get; set; }

        public StiPage()
        {
            /*this.PageNumber = PageNumber;
            this.Base64 = Base64;
            this.Visible = (this.Base64 != "");
            */
        }
    }

    public class StiTable
    {
        public string PointName { get; set; }
        public string Characteristic { get; set; }
        public string DisplayCharacteristic { get; set; }

        public string Selectedxis { get; set; }

        public double OT { get; set; }
        public double UT { get; set; }
        public double SW { get; set; }

        public string DisplayOT { get { return OT.ToString("0.00"); } }
        public string DisplayUT { get { return UT.ToString("0.00"); } }
        public string DisplaySW { get { return SW.ToString("0.00"); } }

        public double PointMin { get; set; }
        public double PointMax { get; set; }
        public double PointMed { get; set; }
        public double PointRange { get; set; }

        public double PointX { get; set; }
        public double PointY { get; set; }
        public double PointZ { get; set; }
        public string PointType { get; set; }

        public double? PointQlvL { get; set; }
        public double? PointQlvU { get; set; }

        public double DisplayMax { get; set; }
        public double DisplayMin { get; set; }

        public string BlueLimit { get; set; }
        public string BlueLimitComment { get; set; }
        public string QlvComment { get; set; }

        public bool LastPartIsNok { get; set; }
        public bool isBM { get; set; }

        public string ListValues_IO { get; set; }
        public string ListValues_NIO { get; set; }
        public string ListValues_Tags { get; set; }
        public string ListValues_NIO_Tags { get; set; }
        public string ListValues_NA { get; set; }
        public string ListComment_IO { get; set; }
        public string ListComment_NIO { get; set; }
        public string ListComment_NA { get; set; }

        public string LowerLimit { get; set; }
        public string UpperLimit { get; set; }

        public string LowerLimitComment { get; set; }
        public string UpperLimitComment { get; set; }

        public string ListArguments { get; set; }
        public string IdentRow { get; set; }

        public double? LastCsvDifference { get; set; }
        public double? LastCsvValue { get; set; }
        public double? TotalValue { get; set; }
        public double? TotalDifference { get; set; }

        public string DisplayPointAxisValue
        {
            get
            {
                return "  X " + PointX.ToString("0.00") + " Y " +
                    PointY.ToString("0.00") + " Z " +
                    PointZ.ToString("0.00") + "   /   " +
                    PointType;
            }
        }
        public string DisplayQlvValue
        {
            get
            {
                if (PointQlvL.HasValue & PointQlvU.HasValue)
                    return "Aktuelle QLV [" + PointQlvL.Value.ToString("0.00") + " -> " + PointQlvU.Value.ToString("0.00") + "]";
                else
                    return "";
            }
        }

        public string DisplaySummaryValue
        {
            get
            {
                List<string> ListParameter = new List<string>();
                ListParameter.Add("Min. " + PointMin.ToString("0.00"));
                ListParameter.Add("ø " + PointMed.ToString("0.00"));
                ListParameter.Add("Max. " + PointMax.ToString("0.00"));
                ListParameter.Add("R " + PointRange.ToString("0.00"));

                return string.Join("  ", ListParameter.ToArray());
            }
        }

        public string DisplaySummaryTotal
        {
            get
            {
                List<string> ListParameter = new List<string>();
                if (TotalValue.HasValue)
                    ListParameter.Add("Ist ø: " + TotalValue.Value.ToString("0.00"));
                else
                    ListParameter.Add("Ist ø: " + 0.ToString("0.00"));

                if (TotalDifference.HasValue)
                    ListParameter.Add("Abw: " + TotalDifference.Value.ToString("0.00"));
                else
                    ListParameter.Add("Ist: " + 0.ToString("0.00"));

                if (ListParameter.Count > 0)
                    return string.Join("\n", ListParameter.ToArray());

                return string.Empty;
            }
        }


        public string DisplaySummaryLastCsv
        {
            get
            {
                List<string> ListParameter = new List<string>();
                if (LastCsvValue.HasValue)
                    ListParameter.Add("Ist: " + LastCsvValue.Value.ToString("0.00"));
                else
                    ListParameter.Add("Ist: " + 0.ToString("0.00"));

                if (LastCsvDifference.HasValue)
                    ListParameter.Add("Abw: " + LastCsvDifference.Value.ToString("0.00"));
                else
                    ListParameter.Add("Ist: " + 0.ToString("0.00"));

                if (ListParameter.Count > 0)
                    return string.Join("\n", ListParameter.ToArray());

                return string.Empty;
            }
        }
    }

    public class CsvSummary
    {
        public string ComponentID { get; set; }
        public string Type { get; set; }
        public string ProductionLine { get; set; }
        public string InspectionCategories { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Description { get; set; }
        public string Messpoints { get; set; }
        public double PistResult { get; set; }
        public int Pos { get; set; }

        public override string ToString()
        {
            return this.Pos +
                " - " + this.ComponentID +
                 " - " + this.Type +
                  " - " + this.ProductionLine +
                   " - " + this.InspectionCategories +
                    " - " + this.InspectionDate +
                     " - " + this.Description +
                      " - " + this.Messpoints +
                       " - " + this.PistResult + "%";
        }
    }
}