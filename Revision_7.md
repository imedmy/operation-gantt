**[Revision 7](https://code.google.com/p/operation-gantt/source/detail?r=7)**

For [Revision 7](https://code.google.com/p/operation-gantt/source/detail?r=7) the two main tasks achieved were
  1. Extended SQL table
  1. Added functionality to create Subtasks and Summary Tasks


---

1. Extended SQL table
  * An extra column was added to the task table called Indent\_Counter. This is an integer variable that helps record a task as either a summary task or a subtask and how to position this task (how many tabs) for clearer user display

---

2. Added functionality to create Subtasks and Summary Tasks
  * This was achieved by creating 2 action results in the Task controller called "TabLeft" and "TabRight" as well as extending the functionality within the DatabaseManager model by extending the GetDatabaseTasks method and adding a TrimEnding method. Together they can change tasks into summary or subtasks or vice versa. Boundary limits exist in these methods so a subtask can only indent by 1 at each root change. To manage these tabs/spaces it was necessary to insert a PRE wrapper to preserve this spacing in Html. Additional spacing was also created after each task name in order to align tasks within the chart creator itself.

---