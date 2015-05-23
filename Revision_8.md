**[Revision 8](https://code.google.com/p/operation-gantt/source/detail?r=8)**

For [Revision 8](https://code.google.com/p/operation-gantt/source/detail?r=8) the main task achieved was to extract the minimum start time and maximum end time from all subtasks and insert them into the corresponding summary tasks.


---

1. Assign Summary Task Dates
  * This had to work for multiple subtask layers. Currently the code allows for infinite subtask layers. This code was placed in a new static method called AssignSummaryDates within the DatabaseManager.cs model file. Currently it is only implemented upon insertion of a new task at the end of the list (“Create New”). However it will also be implemented into the “Insert” and “Delete” options in the next revision.

---

2. Minor Alterations
  * The x axis labels were changed to better display each monthly breakdown of tasks using a custom label.

---