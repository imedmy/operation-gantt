**Iteration 1**

For the first iteration the intention as stated in the Analysis  Document was to implement the following:
  1. User Story 5: Add New Task
  1. User Story 6: Edit Existing Task


---

Both User Stories were successfully implemented within the context of Entity Framework. This was achieved by the following:
  * A Windows Azure Database called Project was created
  * One table called Task was created with 4 fields:
    1. Row\_ID
    1. Task\_Name
    1. Start\_Time
    1. End\_Time
  * A new web page called Task was created that used CRUD and Entity Framework to manage all tasks within Azure Database.
  * A dropdown JQuery datepicker was also used to ensure validation of Start and End times.
One outstanding issue in this area (to be implemented in Iteration 2) is to automatically increment the Row\_ID as each task is added (or decremented on delete). Currently it allows the Row\_ID to be manually inserted.


---

An additional web page was then created called MyChart with the intention of displaying all previous tasks in a Gantt chart. This will now be completed in Iteration 2. However Iteration 1 did successfully display a Gantt Chart from hard coded data using in built charting controls within the .Net Framework. Deciding on how best to create the Gantt Chart took up the most time for this iteration. Alternatives that were researched at length included various Jquery libraries and raw JavaScript. It was finally decided to use the .Net Framework because it makes it easier to follow an MVC approach and keep the majority of code towards the Model side of the application. With this in mind there is code within the Controller classes that will be transferred to the Model Classes in Iteration 2.

Unit testing of the Task Webpage/CRUD was successfully achieved.