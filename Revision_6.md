**[Revision 6](https://code.google.com/p/operation-gantt/source/detail?r=6)**

For [Revision 6](https://code.google.com/p/operation-gantt/source/detail?r=6) the two main tasks achieved were
  1. Add a web role
  1. Connect Gantt Chart creator to the database


---

1. Add a web role:
  * A web role was added to the project before being packaged and launched on azure cloud.
URL: http://roisinsfavouriteproject.cloudapp.net/

---

2. Connect Gantt Chart creator to the database:
  * This was achieved by creating a 4th method in the "DatabaseManager" model called "GetDatabaseTasks" which pulls the list of tasks from the database and sends them to the chart controller. This list was then sent to the chart controller where another foreach loop was used to split the list into its seperate elements so they could be added to the chart.

---
