using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectRevision5.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using System.IO;
using System.Drawing;

namespace ProjectRevision5.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            var chart1 = new Chart();

            Title title = new Title();
            title.Text = "Gantt Chart - 2013";
            //title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            title.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
            //title.ShadowOffset = 3;
            title.ForeColor = Color.FromArgb(26, 59, 105);

            chart1.Titles.Add(title);

            chart1.Width = 1200;
            chart1.Height = 700;


            ChartArea chartArea = new ChartArea("chtArea");
            chartArea = ChartBuilder.CreateChartArea1();
            chart1.ChartAreas.Add(chartArea);

            ChartArea chartArea2 = new ChartArea("chtArea2");
            chartArea2 = ChartBuilder.CreateChartArea2();
            chart1.ChartAreas.Add(chartArea2);

            var SeriesList = new List<Series>();
            SeriesList = ChartBuilder.CreateSeries();

            foreach (Series srs in SeriesList)
            {
                chart1.Series.Add(srs);
            }

            chart1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1;
            chart1.BackColor = Color.Linen;
            chart1.BorderSkin.BackColor = Color.BlanchedAlmond;

            chart1.ChartAreas["Result 2 Chart 2"].AlignWithChartArea = "Result Chart";
            chart1.ChartAreas["Result 2 Chart 2"].AlignmentOrientation = AreaAlignmentOrientations.All;
            chart1.ChartAreas["Result 2 Chart 2"].AlignmentStyle = AreaAlignmentStyles.All;

            StringBuilder result = new StringBuilder();
            result.Append(getChartImage(chart1));
            result.Append(chart1.GetHtmlImageMap("ImageMap"));
            return Content(result.ToString());
        }

        private string getChartImage(Chart chart)
        {
            using (var stream = new MemoryStream())
            {
                string img = "<img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap'>";
                chart.SaveImage(stream, ChartImageFormat.Png);
                string encoded = Convert.ToBase64String(stream.ToArray());
                return String.Format(img, encoded);
            }
        }
    }
}


