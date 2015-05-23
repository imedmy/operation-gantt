**[Revision 10](https://code.google.com/p/operation-gantt/source/detail?r=10)**

For [Revision 10](https://code.google.com/p/operation-gantt/source/detail?r=10) the 2 main tasks achieved were to simplify the Chart controller and to overlay a basic point chart onto the Gantt Chart.


---

**1. Simplify the Chart controller**

Since a lot of functionality is currently being added to the gantt chart display it was necessary to simplify the Chart controller. This was done by moving over half the Controller code into a ChartBuilder model and it is hoped to move over more by the end of the project.

---

**2. Overlay a basic point chart onto the Gantt Chart**

I had enabled the gantt chart to add lines between dependent tasks which works fine except it only works for one line in total and gives problems when trying to add more than one line.

I came up with a work-around solution whereby I will use a point chart and align points to create the same effect as a line. In this way I can add multiple points/predecessor lines. In summary the chart will work by combining a separate point chart and a stacked bar chart.

For this version four fixed points were coded into the solution to show the point overlay taking place successfully.

---