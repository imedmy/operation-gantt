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
        //public static Chart BuildChart()
        //{
        //    var chart1 = new Chart();
        //    return chart1;
        //}

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

        public static Series CreateSeries()
        {
            Series series1 = new Series();
            return series1;
        }
    }
}



