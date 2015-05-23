**[Revision 5](https://code.google.com/p/operation-gantt/source/detail?r=5)**

For [Revision 5](https://code.google.com/p/operation-gantt/source/detail?r=5) the two main tasks achieved were
  1. Clean up previous source code to date
  1. Set up a Database Manager Model


---

Clean up previous source code:
  * 1.	Project was reconstructed from beginning. The Ado.Net Entity Data Model replaced the NuGet 3rd party software previously used. This made the code cleaner and smaller.

  * 2.   Reconstructed JQuery datepicker. Previously had two methods combined and only 1 worked. Rebuilt just 1 method so code is now cleaner and smaller.

---

Set up a Database Manager Model:
  * The new model contained 3 essential methods:
    1. RowNoRetrieval
    1. RowSortPreInsert
    1. RowSortAfterDelete

  * 1. RowNoRetrieval is called when creating a new task. First a query is sent to the database to find the last existing row id and then the new task is given the next ascending row id.
  * 2. RowSortPreInsert is called if a user wants to put a new task in a row id other than the last row. This method is called when "Insert" is selected. Tasks are renumbered to create a space within the database list for the new task before it is created.
  * 3. RowSortAfterDelete is called upon after a task is deleted. It will renumber all tasks so all row ids are in sequence and have no gaps after a task delete.


---
