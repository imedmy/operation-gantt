using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.DataVisualization.Charting;


namespace ProjectRevision5.Models
{
    public static class ChartBuilder
    {
        public static ChartArea CreateChartArea1()
        {
            ChartArea chartArea = new ChartArea();

            chartArea.Position.X = 0;
            chartArea.Position.Y = 15;
            chartArea.Position.Width = 90;
            chartArea.Position.Height = 80;

            chartArea.AxisY.Title = "Date";
            chartArea.AxisY.TitleFont = new Font("TrebuchetMS", 10, FontStyle.Bold);
            chartArea.Name = "Result Chart";
            chartArea.BackColor = Color.Linen;
            chartArea.AxisX.IsLabelAutoFit = false;

            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new Font("TrebuchetMS", 10F, FontStyle.Bold);
            chartArea.AxisY.LabelStyle.Font = new Font("TrebuchetMS", 10F, FontStyle.Bold);
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 1;
            chartArea.AxisY.IntervalType = DateTimeIntervalType.Months;

            chartArea.AxisY.Minimum = (new DateTime(2013, 1, 1)).ToOADate();
            chartArea.AxisY.Maximum = (new DateTime(2014, 1, 1)).ToOADate();
            chartArea.AxisY.LabelStyle.Format = "dd/MMM";

            // January
            var date1 = (new DateTime(2013, 1, 1)).ToOADate();
            var date2 = (new DateTime(2013, 2, 1)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date1, date2, "Jan",
                0, LabelMarkStyle.LineSideMark);

            // February
            var date3 = (new DateTime(2013, 3, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date2, date3, "Feb",
                0, LabelMarkStyle.LineSideMark);

            // March
            var date4 = (new DateTime(2013, 4, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date3, date4, "Mar",
                0, LabelMarkStyle.LineSideMark);

            // April
            var date5 = (new DateTime(2013, 5, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date4, date5, "Apr",
                0, LabelMarkStyle.LineSideMark);

            // May
            var date6 = (new DateTime(2013, 6, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date5, date6, "May",
                0, LabelMarkStyle.SideMark);

            // June
            var date7 = (new DateTime(2013, 7, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date6, date7, "June",
                0, LabelMarkStyle.SideMark);

            // July
            var date8 = (new DateTime(2013, 8, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date7, date8, "July",
                0, LabelMarkStyle.SideMark);

            // August
            var date9 = (new DateTime(2013, 9, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date8, date9, "Aug",
                0, LabelMarkStyle.SideMark);

            // September
            var date10 = (new DateTime(2013, 10, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date9, date10, "Sep",
                0, LabelMarkStyle.SideMark);

            // October
            var date11 = (new DateTime(2013, 11, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date10, date11, "Oct",
                0, LabelMarkStyle.SideMark);

            // November
            var date12 = (new DateTime(2013, 12, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date11, date12, "Nov",
                0, LabelMarkStyle.SideMark);

            // December
            var date13 = (new DateTime(2014, 1, 01)).ToOADate();
            chartArea.AxisY.CustomLabels.Add(date12, date13, "Dec",
                0, LabelMarkStyle.SideMark);

            return chartArea;
        }

        // Creates 2nd graph with lines to show predecessors
        public static ChartArea CreateChartArea2()
        {
            ChartArea chartArea = new ChartArea();

            chartArea.Position.X = 0;
            chartArea.Position.Y = 15;
            chartArea.Position.Width = 90;
            chartArea.Position.Height = 80;

            chartArea.Name = "Result 2 Chart 2";
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.IsLabelAutoFit = false;

            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.ForeColor = Color.Transparent;
            chartArea.AxisY.LabelStyle.ForeColor = Color.Transparent;
            chartArea.AxisY.LineColor = Color.Transparent;
            chartArea.AxisX.LineColor = Color.Transparent;
            chartArea.AxisY.MajorGrid.LineColor = Color.Transparent;
            chartArea.AxisX.MajorGrid.LineColor = Color.Transparent;
            chartArea.AxisX.Interval = 1;    
            chartArea.AxisY.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Months;

            chartArea.AxisX.Minimum = (new DateTime(2013, 1, 1)).ToOADate();
            chartArea.AxisX.Maximum = (new DateTime(2014, 1, 1)).ToOADate();
            chartArea.AxisX.LabelStyle.Format = "dd/MMM";

            // Dynamically checked against row total in database.
            int numrows = DatabaseManager.RowNoRetrieval + 1;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = numrows;
            
            return chartArea;
        }

        public static List<Series> CreateSeries()
        {
            var SeriesList = new List<Series>();
            Series startSeries = new Series();
            startSeries.ChartArea = "Result Chart";
            //chart1.Series.Add(startSeries);
            Series duration44 = new Series();
            duration44.ChartArea = "Result Chart";
            //chart1.Series.Add(duration44);

            Series linetest = new Series();
            linetest.ChartArea = "Result 2 Chart 2";
            //chart1.Series.Add(linetest);

            startSeries.ChartType = SeriesChartType.StackedBar;
            duration44.ChartType = SeriesChartType.StackedBar;

            linetest.ChartType = SeriesChartType.Point;

            startSeries.Color = Color.Transparent;

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
                startSeries.Points.AddXY(tt.Task_Name, tt.Start_Time);
                DateTime d1 = Convert.ToDateTime(tt.End_Time);
                DateTime d2 = Convert.ToDateTime(tt.Start_Time);
                TimeSpan duration = d1 - d2;
                double duration2 = duration.Days;

                duration44.Points.AddXY(tt.Task_Name, duration2);
            }

            ////////// start of point chart code creator  ///////////////////////////

            ProjectEntities pen4 = new ProjectEntities();
            var TaskList2 = new List<Task>();
            var ListQry = pen4.Tasks.Where(Task => Task.Predecessor != 0);
            foreach (var taskdetails in ListQry)
            {
                Task preTask = new Task();
                preTask = pen4.Tasks.Where(Task => Task.Row_ID == taskdetails.Predecessor).SingleOrDefault();

                if (preTask.End_Time > taskdetails.Start_Time)
                {
                    DatabaseManager.AssignPredecessor(taskdetails.Predecessor, taskdetails.Row_ID);
                }

                if (preTask.End_Time == taskdetails.Start_Time)
                {
                    double date1 = preTask.End_Time.ToOADate();
                    int numrows = DatabaseManager.RowNoRetrieval + 1;
                    int axisYStart = numrows - taskdetails.Row_ID;
                    int axisYFinish = numrows - preTask.Row_ID;

                    DateTime date2 = preTask.End_Time;
                    date2 = date2.AddDays(-2);
                    linetest.Points.AddXY(date2, axisYFinish);

                    DateTime date3 = taskdetails.Start_Time;
                    date3 = date3.AddDays(2);
                    linetest.Points.AddXY(date3, axisYStart);

                    //DateTime date4 = preTask.End_Time;
                    //linetest.Points.AddXY(date4, axisYFinish);

                    for (double i = axisYStart; i < axisYFinish; i = i + 0.2)
                    {
                        linetest.Points.AddXY(date1, i);
                    }
                }

                if (preTask.End_Time < taskdetails.Start_Time)
                {
                    double date1 = taskdetails.Start_Time.ToOADate();
                    int numrows = DatabaseManager.RowNoRetrieval + 1;
                    int axisYStart = numrows - taskdetails.Row_ID;
                    int axisYFinish = numrows - preTask.Row_ID;

                    DateTime date2 = preTask.End_Time;
                    date2 = date2.AddDays(-2);
                    linetest.Points.AddXY(date2, axisYFinish);

                    DateTime date3 = taskdetails.Start_Time;
                    date3 = date3.AddDays(2);
                    linetest.Points.AddXY(date3, axisYStart);

                    for (double i = axisYStart; i < axisYFinish; i = i + 0.2)
                    {
                        linetest.Points.AddXY(date1, i);
                    }

                    DateTime axisXStart = preTask.End_Time;
                    DateTime axisXFinish = taskdetails.Start_Time;
                    DateTime j = axisXStart;
                    
                    while (j < axisXFinish)
                    {
                        linetest.Points.AddXY(j, axisYFinish);
                        j = j.AddDays(2);
                    }
                }
            }

            ////////// End of point chart code creator  ///////////////////////////

            duration44.Color = Color.MediumSeaGreen;
            linetest.Color = Color.Black;
            linetest.BorderWidth = 1;

            duration44.BackSecondaryColor = Color.Green;
            duration44.BackGradientStyle = GradientStyle.LeftRight;

            SeriesList.Add(startSeries);
            SeriesList.Add(duration44);
            SeriesList.Add(linetest);
            return SeriesList;
        }
    }
}



