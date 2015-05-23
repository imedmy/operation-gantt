**[Revision 11](https://code.google.com/p/operation-gantt/source/detail?r=11)**

For [Revision 11](https://code.google.com/p/operation-gantt/source/detail?r=11) the main tasks achieved were:
  1. Create a new method in the DatabaseManager Model called AssignPredecessor.
  1. Add predecessor field to all areas of the TaskController/Task Page
  1. Update Database to include Predecessor field
  1. Update ChartBuilder to create Predecessor lines


---

**1. AssignPredecessor Method**

This method is very similar to the AssignSummaryDates method because it manages the Start and End Dates for all tasks. However the AssignPredecessor method uses a different set of criteria which primarily check whether a task has a Predecessor task (value <> 0). If this is the case then that current task must start on or after the end date of the predecessor task. If it does not the method will change the current task start date to equal the predecessor end date and also change the current task end date while keeping the current task duration the same as before.

---

**2. Add predecessor field to TaskController/Task Page**

A Predecessor field was added throughout the TaskController/Task Page to allow the user to input a Predecessor relationship between tasks. Currently the application allows one Predecessor value to be entered which must be also be a previous row id.

---

**3. Update Database to include Predecessor field**

A new field was added to Azure Database called Predecessor. This field must be 0 if no value is required in order to support the application validation.
Once this was created the database model mapper was refreshed within the application.

---

**4. Update ChartBuilder to create Predecessor lines**

The ChartBuilder model was updated to create all the new points/lines necessary to properly display the predecessor relationship between tasks.

---
