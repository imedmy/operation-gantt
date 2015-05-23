**Iteration 2**

For the second iteration the intention as stated in the Analysis  Document was to implement the following:
  1. User Story 7: Add New Summary Task
  1. User Story 8: Edit Existing Summary Task
  1. User Story 9: Save and Logout
  1. User Story 10: Save and Create New Project

---

User Stories 7 and 8 were successfully implemented in this iteration. This was achieved through the following steps:


---

**1.  Clean up previous source code:
  * Project was reconstructed from beginning. The Ado.Net Entity Data Model replaced the NuGet 3rd party software previously used. This made the code cleaner and smaller.**

  * Reconstructed JQuery datepicker. Previously had two methods combined and only 1 worked. Rebuilt just 1 method so code is now cleaner and smaller.

---

**2.   Set up a Database Manager Model:
  * The new model contained 3 essential methods:
    1. RowNoRetrieval
    1. RowSortPreInsert
    1. RowSortAfterDelete**

  * 1. RowNoRetrieval is called when creating a new task. First a query is sent to the database to find the last existing row id and then the new task is given the next ascending row id.
  * 2. RowSortPreInsert is called if a user wants to put a new task in a row id other than the last row. This method is called when "Insert" is selected. Tasks are renumbered to create a space within the database list for the new task before it is created.
  * 3. RowSortAfterDelete is called upon after a task is deleted. It will renumber all tasks so all row ids are in sequence and have no gaps after a task delete.

---

3. Add a web role:
    * A web role was added to the project before being packaged and launched on azure cloud.
URL: http://roisinsfavouriteproject.cloudapp.net/

---

4. Connect Gantt Chart creator to the database:
    * This was achieved by creating a 4th method in the "DatabaseManager" model called "GetDatabaseTasks" which pulls the list of tasks from the database and sends them to the chart controller. The chart controller then uses another foreach loop to split the list into its seperate elements so they can be added to the chart.

---

5. Extended SQL table
    * An extra column was added to the task table called Indent\_Counter. This was an integer variable that helps record a task as either a summary task or a subtask and assists with the tab positioning of this task in both the task list and gantt chart.

---

6. Added functionality to create Subtasks and Summary Tasks
    * This was achieved by creating 2 action results in the Task controller called "TabLeft" and "TabRight" as well as extending the functionality within the DatabaseManager model by extending the GetDatabaseTasks method and adding a TrimEnding method. Together they can change tasks into summary or subtasks or vice versa. Boundary limits exist in these methods so a subtask can only indent by 1 at each root change. To manage these tabs/spaces it was necessary to insert a PRE wrapper to preserve this spacing in Html. Additional spacing was also created after each task name in order to align tasks within the chart creator itself.

---

7. Assign Summary Task Dates
    * For [Revision 8](https://code.google.com/p/operation-gantt/source/detail?r=8) the main task achieved was to extract the minimum start time and maximum end time from all subtasks and insert them into the corresponding summary tasks. This had to work for multiple subtask layers. Currently the code allows for infinite subtask layers. This code was placed in a new method called AssignSummaryDates within the DatabaseManager.cs model file.

---

8. Minor Alterations
    * The X - axis labels were changed to better display each monthly breakdown of tasks using a custom label in the gantt chart display.

---

User Stories 9 and 10 were not implemented in this iteration as intended due to the large time over-run in getting the AssignSummaryDates method implemented. These will now be implemented in the next iteration.