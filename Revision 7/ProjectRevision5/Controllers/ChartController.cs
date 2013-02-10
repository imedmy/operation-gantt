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
        //
        // GET: /Chart/

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

            chart1.Width = 1100;
            chart1.Height = 700;

            //ChartArea chartArea = new ChartArea("chtArea");
            chart1.ChartAreas.Add("chtArea");
            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Y = 15;
            chart1.ChartAreas[0].Position.Width = 95;
            chart1.ChartAreas[0].Position.Height = 80;
            //chart2.ChartAreas.Add("chtArea");
            chart1.ChartAreas[0].AxisY.Title = "Date";
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("TrebuchetMS", 10, FontStyle.Bold);
            chart1.ChartAreas[0].Name = "Result Chart";
            chart1.ChartAreas[0].BackColor = Color.Linen;
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 10F, FontStyle.Bold);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 10F, FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("TrebuchetMS", 10F, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("TrebuchetMS", 10F, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chart1.ChartAreas[0].AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.ChartAreas[0].AxisY.Interval = 30.3;
            chart1.ChartAreas[0].AxisY.Interval = 30;
            chart1.ChartAreas[0].AxisY.Minimum = (new DateTime(2013, 1, 1)).ToOADate();
            chart1.ChartAreas[0].AxisY.Maximum = (new DateTime(2013, 12, 31)).ToOADate();
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "dd/MMM";
            //chart1.ChartAreas[0].AxisY.AxisName
            
            chart1.Series.Add("startSeries");
            chart1.Series.Add("duration");
            //chart1.Series.Add("showyear");
            //chart1.Series.Add("linkline");
            chart1.Series[0].ChartType = SeriesChartType.StackedBar;
            chart1.Series[1].ChartType = SeriesChartType.StackedBar;
            //chart1.Series[2].ChartType = SeriesChartType.StackedBar;
            //chart1.Series[3].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Transparent;
            //chart1.Series[2].Color = Color.Transparent;
            //chart1.Series[3].Color = Color.Black;

            var TaskList = new List<Task>();
            TaskList = DatabaseManager.GetDatabaseTasks;
            int TaskNumber = DatabaseManager.RowNoRetrieval;

            foreach (Task tt in TaskList)
            {
                if (tt.Start_Time == null || tt.End_Time == null )
                {
                    tt.Start_Time = DateTime.Today;
                    tt.End_Time = DateTime.Today;
                }
                //chart1.Series[0].Points.AddXY(tt.Row_ID + " " + tt.Task_Name + "      >", tt.Start_Time);
                chart1.Series[0].Points.AddXY(tt.Task_Name, tt.Start_Time);
                // chart1.Series[0].Points.AddXY(tt.Task_Name, tt.Start_Time);
                //var end = TaskList[i].End_Time;
                DateTime d1 = Convert.ToDateTime(tt.End_Time);
                DateTime d2 = Convert.ToDateTime(tt.Start_Time);
                TimeSpan duration = d1 - d2;
                double duration2 = duration.Days;
                
                chart1.Series[1].Points.AddXY(tt.Task_Name, duration2);
            }

            chart1.Series[1].Color = Color.MediumSeaGreen;
            chart1.Series[1].BackSecondaryColor = Color.Green;
            chart1.Series[1].BackGradientStyle = GradientStyle.LeftRight;

            chart1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1;
            chart1.BackColor = Color.Linen;
            chart1.BorderSkin.BackColor = Color.BlanchedAlmond;

            StringBuilder result = new StringBuilder();
            result.Append(getChartImage(chart1));
            //result.Append(getChartImage(chart2));
            result.Append(chart1.GetHtmlImageMap("ImageMap"));
            //result.Append(chart2.GetHtmlImageMap("ImageMap"));
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
