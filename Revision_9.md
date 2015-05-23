**[Revision 9](https://code.google.com/p/operation-gantt/source/detail?r=9)**

For [Revision 9](https://code.google.com/p/operation-gantt/source/detail?r=9) the 2 main tasks achieved were to improve the display problem of the text alignment in the chart tab and also to get rid of several bugs in the code.


---

**1. Improve Text Alignment Display in Chart Tab**

Originally the code was counting the number of characters for each task and adding white spacing as required which proved inadequate as some characters took up more space on the screen than others. This made it necessary to find an alternative method of calculating string width which was found using an image width measurement built in method called "drawgraphics.measurestring". This method was put into a purpose built method that also converted each string into a bitmap image prior to calculating the pixel width and returning each value to the calling method.

In summary it involved replacing the "GetDatabaseTasks" method in the "DatabaseManager" controller with 3 new methods:
  1. The first method was called "GetTasksToIndex" and simply only has to worry about the prespace in the Tasks tab index page which was working fine anyway but is now cleaner and simpler. This method gets away with counting the number of characters the old way because it only works with the Index page in the Task tab.
  1. The second method created was called "GetTasksToChart" which deals with the text alignment in the Chart page and also calls on the third method to calculate the image pixel width of each         string.
  1. The third method created was called "MeasureText" which essentially converts each task name into an image and calculates how many pixel widths this task occupies on screen. It then sends this information back to the second method where the post spacing is added to the task name before sending to the chart.

---

**2. Debugging**

The following is a list of bugs that were fixed:

  1. The delete method now only allows deletion of Summary Tasks when all SubTasks are deleted first.
  1. The insert method gives the same indent counter value to the new task to ensure existing subtask groupings are not split into 2 groups.
  1. The summary task is now able to increase/decrease in size when subtasks are edited (Previously only increased).
  1. The summary task method "AssignSummaryDates" is now called upon for deletions, insertions and edits.
  1. TabLeft and TabRight can now only be called upon if the task is not linked with any summary task/subtask groupings.

---