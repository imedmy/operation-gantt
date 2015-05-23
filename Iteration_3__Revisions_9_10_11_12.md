**Iteration 3**

For this third and final iteration the intention was to enable Predecessor relationships between tasks. While several user stories remained outstanding it was decided by the project team that this predecessor functionality would add more value to the overall project than completing the remaining user stories.

---

The Predecessor functionality was successfully achieved in this iteration through the following steps:

---


**1. Improve Text Alignment Display in Chart Tab**

Originally the code was counting the number of characters for each task and adding white spacing as required which proved inadequate as some characters took up more space on the screen than others. This made it necessary to find an alternative method of calculating string width which was found using an image width measurement built in method called "drawgraphics.measurestring". This method was put into a purpose built method that also converted each string into a bitmap image prior to calculating the pixel width and returning each value to the calling method.

In summary it involved replacing the "GetDatabaseTasks" method in the "DatabaseManager" controller with 3 new methods:
  1. The first method was called "GetTasksToIndex" and simply only has to worry about the prespace in the Tasks tab index page which was working fine anyway but is now cleaner and simpler. This method gets away with counting the number of characters the old way because it only works with the Index page in the Task tab.
  1. The second method created was called "GetTasksToChart" which deals with the text alignment in the Chart page and also calls on the third method to calculate the image pixel width of each         string.
  1. The third method created was called "MeasureText" which essentially converts each task name into an image and calculates how many pixel widths this task occupies on screen. It then sends this information back to the second method where the post spacing is added to the task name before sending to the chart.

---

**2. Debugging**

The following is a list of bugs that were fixed at this stage:

  1. The delete method now only allows deletion of Summary Tasks when all SubTasks are deleted first.
  1. The insert method gives the same indent counter value to the new task to ensure existing subtask groupings are not split into 2 groups.
  1. The summary task is now able to increase/decrease in size when subtasks are edited (Previously only increased).
  1. The summary task method "AssignSummaryDates" is now called upon for deletions, insertions and edits.
  1. TabLeft and TabRight can now only be called upon if the task is not linked with any summary task/subtask groupings.


---


**3. Simplify the Chart controller**

Since a lot of functionality is currently being added to the gantt chart display it was necessary to simplify the Chart controller. This was done by moving over half the Controller code into a ChartBuilder model and it is hoped to move over more by the end of the project.

---

**4. Overlay a basic point chart onto the Gantt Chart**

I had enabled the gantt chart to add lines between dependent tasks which works fine except it only works for one line in total and gives problems when trying to add more than one line.

I came up with a work-around solution whereby I will use a point chart and align points to create the same effect as a line. In this way I can add multiple points/predecessor lines. In summary the chart will work by combining a separate point chart and a stacked bar chart.

For this version four fixed points were coded into the solution to show the point overlay taking place successfully.



---

**5. AssignPredecessor Method**

This method is very similar to the AssignSummaryDates method because it manages the Start and End Dates for all tasks. However the AssignPredecessor method uses a different set of criteria which primarily check whether a task has a Predecessor task (value <> 0). If this is the case then that current task must start on or after the end date of the predecessor task. If it does not the method will change the current task start date to equal the predecessor end date and also change the current task end date while keeping the current task duration the same as before.

---

**6. Add predecessor field to TaskController/Task Page**

A Predecessor field was added throughout the TaskController/Task Page to allow the user to input a Predecessor relationship between tasks. Currently the application allows one Predecessor value to be entered which must be also be a previous row id.

---

**7. Update Database to include Predecessor field**

A new field was added to Azure Database called Predecessor. This field must be 0 if no value is required in order to support the application validation.
Once this was created the database model mapper was refreshed within the application.

---

**8. Update ChartBuilder to create Predecessor lines**

The ChartBuilder model was updated to create all the new points/lines necessary to properly display the predecessor relationship between tasks.


---

**9. Display Improvements**

To improve performance in the Task page I replaced  the indent left and right images with '<<<' and '>>>'. In the Chart page to improve the readability of the predecessor lines I added line branches to clearly show what task was connected to which predecessor line.

---

**10. Defect Fix**

A major defect that occured in the task page when the last task contained a predecessor value which caused the application to fall over was successfully fixed.

---

**11. Update Live Link**

The live link was updated to the final version.
URL: http://roisinsfavouriteproject.cloudapp.net/