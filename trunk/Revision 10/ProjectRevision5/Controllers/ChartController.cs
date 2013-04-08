
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using ProjectRevision5.Models;
//using System.Web.UI.DataVisualization.Charting;
//using System.Text;
//using System.IO;
//using System.Drawing;

//namespace ProjectRevision5.Controllers
//{
//    public class ChartController : Controller
//    {
//        //
//        // GET: /Chart/

//        public ActionResult Index()
//        {
//            var chart1 = new Chart();

//            Title title = new Title();
//            title.Text = "Gantt Chart - 2013";
//            //title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
//            title.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
//            //title.ShadowOffset = 3;
//            title.ForeColor = Color.FromArgb(26, 59, 105);

//            chart1.Titles.Add(title);

//            chart1.Width = 1200;
//            chart1.Height = 700;

//            ChartArea chartArea = new ChartArea("chtArea");
//            chart1.ChartAreas.Add("chtArea");
//            ChartArea chartArea2 = new ChartArea("chtArea2");
//            chartArea.AlignWithChartArea = "chtArea2";
//            chart1.ChartAreas.Add("chtArea2");

//            chart1.ChartAreas[0].Position.X = 0;
//            chart1.ChartAreas[0].Position.Y = 15;
//            chart1.ChartAreas[0].Position.Width = 90;
//            chart1.ChartAreas[0].Position.Height = 80;

//            chart1.ChartAreas[1].Position.X = 0;
//            chart1.ChartAreas[1].Position.Y = 15;
//            chart1.ChartAreas[1].Position.Width = 90;
//            chart1.ChartAreas[1].Position.Height = 80;


//            chart1.ChartAreas[0].AxisY.Title = "Date";
//            chart1.ChartAreas[0].AxisY.TitleFont = new Font("TrebuchetMS", 10, FontStyle.Bold);
//            chart1.ChartAreas[0].Name = "Result Chart";
//            chart1.ChartAreas[0].BackColor = Color.Linen;
//            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;

//            chart1.ChartAreas[1].Name = "Result 2 Chart 2";
//            chart1.ChartAreas[1].BackColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisX.IsLabelAutoFit = false;

//            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;
//            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("TrebuchetMS", 10F, FontStyle.Bold);
//            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("TrebuchetMS", 10F, FontStyle.Bold);
//            chart1.ChartAreas[0].AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
//            chart1.ChartAreas[0].AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
//            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
//            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
//            chart1.ChartAreas[0].AxisX.Interval = 1;
//            chart1.ChartAreas[0].AxisY.Interval = 1;
//            chart1.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Months;

//            chart1.ChartAreas[1].AxisY.IsLabelAutoFit = false;
//            chart1.ChartAreas[1].AxisX.LabelStyle.ForeColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisY.LabelStyle.ForeColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisY.LineColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisX.LineColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisY.MajorGrid.LineColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisX.MajorGrid.LineColor = Color.Transparent;
//            chart1.ChartAreas[1].AxisX.Interval = 1;
//            chart1.ChartAreas[1].AxisY.Interval = 1;
//            chart1.ChartAreas[1].AxisX.IntervalType = DateTimeIntervalType.Months;


//            chart1.ChartAreas[0].AxisY.Minimum = (new DateTime(2013, 1, 1)).ToOADate();
//            chart1.ChartAreas[0].AxisY.Maximum = (new DateTime(2014, 1, 1)).ToOADate();
//            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "dd/MMM";

//            chart1.ChartAreas[1].AxisX.Minimum = (new DateTime(2013, 1, 1)).ToOADate();
//            chart1.ChartAreas[1].AxisX.Maximum = (new DateTime(2014, 1, 1)).ToOADate();
//            chart1.ChartAreas[1].AxisX.LabelStyle.Format = "dd/MMM";


//            // Dynamically checked against row total in database.
//            int numrows = DatabaseManager.RowNoRetrieval + 1;
//            chart1.ChartAreas[1].AxisY.Minimum = 0;
//            chart1.ChartAreas[1].AxisY.Maximum = numrows;

//            // January
//            var date1 = (new DateTime(2013, 1, 1)).ToOADate();
//            var date2 = (new DateTime(2013, 2, 1)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date1, date2, "Jan",
//                0, LabelMarkStyle.LineSideMark);                        // This 0 value will overlay original axis value
//            //chart1.ChartAreas[1].AxisY.CustomLabels.Add(date1, date2, "Jan",
//            //    0, LabelMarkStyle.LineSideMark);
//            // Result will be only months shown!

//            // February
//            var date3 = (new DateTime(2013, 3, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date2, date3, "Feb",
//                0, LabelMarkStyle.LineSideMark);

//            // March
//            var date4 = (new DateTime(2013, 4, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date3, date4, "Mar",
//                0, LabelMarkStyle.LineSideMark);

//            // April
//            var date5 = (new DateTime(2013, 5, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date4, date5, "Apr",
//                0, LabelMarkStyle.LineSideMark);

//            // May
//            var date6 = (new DateTime(2013, 6, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date5, date6, "May",
//                0, LabelMarkStyle.SideMark);

//            // June
//            var date7 = (new DateTime(2013, 7, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date6, date7, "June",
//                0, LabelMarkStyle.SideMark);

//            // July
//            var date8 = (new DateTime(2013, 8, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date7, date8, "July",
//                0, LabelMarkStyle.SideMark);

//            // August
//            var date9 = (new DateTime(2013, 9, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date8, date9, "Aug",
//                0, LabelMarkStyle.SideMark);

//            // September
//            var date10 = (new DateTime(2013, 10, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date9, date10, "Sep",
//                0, LabelMarkStyle.SideMark);

//            // October
//            var date11 = (new DateTime(2013, 11, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date10, date11, "Oct",
//                0, LabelMarkStyle.SideMark);

//            // November
//            var date12 = (new DateTime(2013, 12, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date11, date12, "Nov",
//                0, LabelMarkStyle.SideMark);

//            // December
//            var date13 = (new DateTime(2014, 1, 01)).ToOADate();
//            chart1.ChartAreas[0].AxisY.CustomLabels.Add(date12, date13, "Dec",
//                0, LabelMarkStyle.SideMark);
//            //chart1.ChartAreas[1].AxisY.CustomLabels.Add(date12, date13, "Dec",
//            //    0, LabelMarkStyle.SideMark);


//            Series startSeries = new Series();
//            startSeries.ChartArea = "Result Chart";
//            chart1.Series.Add(startSeries);
//            Series duration44 = new Series();
//            duration44.ChartArea = "Result Chart";
//            chart1.Series.Add(duration44);

//            Series linetest = new Series();
//            linetest.ChartArea = "Result 2 Chart 2";
//            chart1.Series.Add(linetest);

//            chart1.Series[0].ChartType = SeriesChartType.StackedBar;
//            chart1.Series[1].ChartType = SeriesChartType.StackedBar;

//            chart1.Series[2].ChartType = SeriesChartType.Line;

//            chart1.Series[0].Color = Color.Transparent;

//            var TaskList = new List<Task>();
//            TaskList = DatabaseManager.GetTasksToChart;
//            int TaskNumber = DatabaseManager.RowNoRetrieval;

//            foreach (Task tt in TaskList)
//            {
//                if (tt.Start_Time == null || tt.End_Time == null)
//                {
//                    tt.Start_Time = DateTime.Today;
//                    tt.End_Time = DateTime.Today;
//                }
//                chart1.Series[0].Points.AddXY(tt.Task_Name, tt.Start_Time);
//                DateTime d1 = Convert.ToDateTime(tt.End_Time);
//                DateTime d2 = Convert.ToDateTime(tt.Start_Time);
//                TimeSpan duration = d1 - d2;
//                double duration2 = duration.Days;

//                chart1.Series[1].Points.AddXY(tt.Task_Name, duration2);
//            }

//            int testName1 = 3;
//            //var testdate1 = (new DateTime(2013, 3, 31)).ToOADate();
//            double testdate1 = DateTime.Now.ToOADate();
//            //int testdate1 = 50;
//            chart1.Series[2].Points.AddXY(testdate1, testName1);
//            //chart1.Series[2].Points.AddXY(testdate1, testName1);

//            int testName2 = 6;
//            double testdate2 = (new DateTime(2013, 9, 30)).ToOADate();
//            //double testdate2 = (new DateTime(30/09/2013)).ToOADate();  // wont accept this format!!!
//            //double testdate2 = DateTime.Now.ToOADate();
//            //chart1.Series[2].Points.AddXY(testdate2, testName2);
//            //int testdate2 = 70;
//            chart1.Series[2].Points.AddXY(testdate2, testName2);

//            //int testName1 = 2;
//            //int testdate1 = 6;
//            //chart1.Series[2].Points.AddXY(testName1, testdate1);
//            ////chart1.Series[2].Points.AddXY(testdate1, testName1);

//            //int testName2 = 15;
//            //int testdate2 = 34;
//            ////chart1.Series[2].Points.AddXY(testdate2, testName2);
//            //chart1.Series[2].Points.AddXY(testName2, testdate2);

//            chart1.Series[1].Color = Color.MediumSeaGreen;
//            chart1.Series[2].Color = Color.Black;
//            chart1.Series[2].BorderWidth = 3;

//            chart1.Series[1].BackSecondaryColor = Color.Green;
//            chart1.Series[1].BackGradientStyle = GradientStyle.LeftRight;

//            chart1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1;
//            chart1.BackColor = Color.Linen;
//            chart1.BorderSkin.BackColor = Color.BlanchedAlmond;

//            chart1.ChartAreas["Result Chart"].AlignWithChartArea = "Result 2 Chart 2";
//            //chart1.ChartAreas["Result Chart"].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
//            chart1.ChartAreas["Result Chart"].AlignmentOrientation = AreaAlignmentOrientations.All;
//            chart1.ChartAreas["Result Chart"].AlignmentStyle = AreaAlignmentStyles.All;

//            StringBuilder result = new StringBuilder();
//            result.Append(getChartImage(chart1));
//            //result.Append(getChartImage(chart2));
//            result.Append(chart1.GetHtmlImageMap("ImageMap"));
//            //result.Append(chart2.GetHtmlImageMap("ImageMap"));
//            return Content(result.ToString());
//        }

//        private string getChartImage(Chart chart)
//        {
//            using (var stream = new MemoryStream())
//            {
//                string img = "<img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap'>";
//                chart.SaveImage(stream, ChartImageFormat.Png);
//                string encoded = Convert.ToBase64String(stream.ToArray());
//                return String.Format(img, encoded);
//            }
//        }
//    }
//}


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

            //chart1.ChartAreas[0].Name = "Result Chart";
            //chart1.ChartAreas[1].Name = "Result 2 Chart 2";

            Series startSeries = new Series();
            startSeries.ChartArea = "Result Chart";
            chart1.Series.Add(startSeries);
            Series duration44 = new Series();
            duration44.ChartArea = "Result Chart";
            chart1.Series.Add(duration44);

            Series linetest = new Series();
            linetest.ChartArea = "Result 2 Chart 2";
            chart1.Series.Add(linetest);

            //Series linetest2 = new Series();
            //linetest.ChartArea = "Result 2 Chart 2";
            //chart1.Series.Add(linetest2);

            chart1.Series[0].ChartType = SeriesChartType.StackedBar;
            chart1.Series[1].ChartType = SeriesChartType.StackedBar;

            chart1.Series[2].ChartType = SeriesChartType.Point;
            //chart1.Series[3].ChartType = SeriesChartType.Line;

            chart1.Series[0].Color = Color.Transparent;

            var TaskList = new List<Task>();
            TaskList = DatabaseManager.GetTasksToChart;
            int TaskNumber = DatabaseManager.RowNoRetrieval;

            foreach (Task tt in TaskList)
            {
                if (tt.Start_Time == null || tt.End_Time == null)
                {
                    tt.Start_Time = DateTime.Today;
                    tt.End_Time = DateTime.Today;
                }
                chart1.Series[0].Points.AddXY(tt.Task_Name, tt.Start_Time);
                DateTime d1 = Convert.ToDateTime(tt.End_Time);
                DateTime d2 = Convert.ToDateTime(tt.Start_Time);
                TimeSpan duration = d1 - d2;
                double duration2 = duration.Days;

                chart1.Series[1].Points.AddXY(tt.Task_Name, duration2);
            }

            int testName1 = 3;
            double testdate1 = DateTime.Now.ToOADate();
            chart1.Series[2].Points.AddXY(testdate1, testName1);

            int testName2 = 6;
            double testdate2 = (new DateTime(2013, 9, 30)).ToOADate();
            chart1.Series[2].Points.AddXY(testdate2, testName2);

            int testName3 = 7;
            double testdate3 = DateTime.Now.ToOADate();
            linetest.Points.AddXY(testdate3, testName3);

            int testName4 = 10;
            double testdate4 = (new DateTime(2013, 10, 30)).ToOADate();
            linetest.Points.AddXY(testdate4, testName4);

            chart1.Series[1].Color = Color.MediumSeaGreen;
            chart1.Series[2].Color = Color.Black;
            //chart1.Series[3].Color = Color.Black;
            chart1.Series[2].BorderWidth = 3;
            //chart1.Series[3].BorderWidth = 3;

            chart1.Series[1].BackSecondaryColor = Color.Green;
            chart1.Series[1].BackGradientStyle = GradientStyle.LeftRight;

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



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using ProjectRevision5.Models;
//using System.Web.UI.DataVisualization.Charting;
//using System.Text;
//using System.IO;
//using System.Drawing;

//namespace ProjectRevision5.Controllers
//{
//    public class ChartController : Controller
//    {
//        public ActionResult Index()
//        {
//            var chart1 = new Chart();

//            Title title = new Title();
//            title.Text = "Gantt Chart - 2013";
//            //title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
//            title.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
//            //title.ShadowOffset = 3;
//            title.ForeColor = Color.FromArgb(26, 59, 105);

//            chart1.Titles.Add(title);

//            chart1.Width = 1200;
//            chart1.Height = 700;

//            ChartArea[] chartArea = new ChartArea[3];


//            //chartArea[1] = new ChartArea();
//            chartArea[0] = ChartBuilder.CreateChartArea1();
//            chart1.ChartAreas.Add(chartArea[0]);

//            //ChartArea chartArea2 = new ChartArea("chtArea2");
//            chartArea[1] = ChartBuilder.CreateChartArea2();
//            chartArea[1].Name = "Result 2 Chart 2";
//            chart1.ChartAreas.Add(chartArea[1]);

//            chartArea[2] = ChartBuilder.CreateChartArea2();
//            chartArea[2].Name = "Result 3 Chart 3";
//            chart1.ChartAreas.Add(chartArea[2]);

//            //chart1.ChartAreas[0].Name = "Result Chart";
//            //chartArea[1].Name = "Result 2 Chart 2";
//            //chartArea[2].Name = "Result 3 Chart 3";

//            Series startSeries = new Series();
//            startSeries.ChartArea = "Result Chart";
//            chart1.Series.Add(startSeries);
//            Series duration44 = new Series();
//            duration44.ChartArea = "Result Chart";
//            chart1.Series.Add(duration44);

//            Series linetest = new Series();
//            linetest.ChartArea = "Result 2 Chart 2";
//            chart1.Series.Add(linetest);

//            Series linetest2 = new Series();
//            linetest.ChartArea = "Result 3 Chart 3";
//            chart1.Series.Add(linetest2);

//            chart1.Series[0].ChartType = SeriesChartType.StackedBar;
//            chart1.Series[1].ChartType = SeriesChartType.StackedBar;

//            chart1.Series[2].ChartType = SeriesChartType.Line;
//            chart1.Series[3].ChartType = SeriesChartType.Line;

//            chart1.Series[0].Color = Color.Transparent;

//            var TaskList = new List<Task>();
//            TaskList = DatabaseManager.GetTasksToChart;
//            int TaskNumber = DatabaseManager.RowNoRetrieval;

//            foreach (Task tt in TaskList)
//            {
//                if (tt.Start_Time == null || tt.End_Time == null)
//                {
//                    tt.Start_Time = DateTime.Today;
//                    tt.End_Time = DateTime.Today;
//                }
//                chart1.Series[0].Points.AddXY(tt.Task_Name, tt.Start_Time);
//                DateTime d1 = Convert.ToDateTime(tt.End_Time);
//                DateTime d2 = Convert.ToDateTime(tt.Start_Time);
//                TimeSpan duration = d1 - d2;
//                double duration2 = duration.Days;

//                chart1.Series[1].Points.AddXY(tt.Task_Name, duration2);
//            }

//            int testName1 = 3;
//            double testdate1 = DateTime.Now.ToOADate();
//            chart1.Series[2].Points.AddXY(testdate1, testName1);

//            int testName2 = 6;
//            double testdate2 = (new DateTime(2013, 9, 30)).ToOADate();
//            chart1.Series[2].Points.AddXY(testdate2, testName2);

//            int testName3 = 7;
//            double testdate3 = DateTime.Now.ToOADate();
//            chart1.Series[3].Points.AddXY(testdate3, testName3);

//            int testName4 = 10;
//            double testdate4 = (new DateTime(2013, 10, 30)).ToOADate();
//            chart1.Series[3].Points.AddXY(testdate4, testName4);

//            chart1.Series[1].Color = Color.MediumSeaGreen;
//            chart1.Series[2].Color = Color.Black;
//            chart1.Series[3].Color = Color.Black;
//            chart1.Series[2].BorderWidth = 3;
//            chart1.Series[3].BorderWidth = 3;

//            chart1.Series[1].BackSecondaryColor = Color.Green;
//            chart1.Series[1].BackGradientStyle = GradientStyle.LeftRight;

//            chart1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1;
//            chart1.BackColor = Color.Linen;
//            chart1.BorderSkin.BackColor = Color.BlanchedAlmond;

//            chart1.ChartAreas["Result Chart"].AlignWithChartArea = "Result 2 Chart 2";
//            chart1.ChartAreas["Result Chart"].AlignmentOrientation = AreaAlignmentOrientations.All;
//            chart1.ChartAreas["Result Chart"].AlignmentStyle = AreaAlignmentStyles.All;

//            //chart1.ChartAreas["Result 3 Chart 3"].AlignWithChartArea = "Result Chart";
//            //chart1.ChartAreas["Result 3 Chart 3"].AlignmentOrientation = AreaAlignmentOrientations.All;
//            //chart1.ChartAreas["Result 3 Chart 3"].AlignmentStyle = AreaAlignmentStyles.All;

//            StringBuilder result = new StringBuilder();
//            result.Append(getChartImage(chart1));
//            result.Append(chart1.GetHtmlImageMap("ImageMap"));
//            return Content(result.ToString());
//        }

//        private string getChartImage(Chart chart)
//        {
//            using (var stream = new MemoryStream())
//            {
//                string img = "<img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap'>";
//                chart.SaveImage(stream, ChartImageFormat.Png);
//                string encoded = Convert.ToBase64String(stream.ToArray());
//                return String.Format(img, encoded);
//            }
//        }
//    }
//}