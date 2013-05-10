using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProjectRevision5.Models
{
    public static class DatabaseManager
    {
        public static int RowNoRetrieval
        {
            get
            {
                ProjectEntities pen = new ProjectEntities();
                var listQry2 = pen.Tasks.Select(Task => Task.Row_ID).Count();
                if (listQry2 == 0)
                {
                    return 0;
                }
                else
                {
                    int listQry = pen.Tasks.OrderByDescending(Task => Task.Row_ID).Select(Task => Task.Row_ID).First();
                    return listQry;
                } 
            }
        }

        public static void RowSortAfterDelete(int RowId)
        {
            ProjectEntities pen2 = new ProjectEntities();
            int count = pen2.Tasks.Select(Task => Task.Row_ID).Count();
            if (count != 0)
            {
                int RowIdMax = pen2.Tasks.OrderByDescending(Task => Task.Row_ID).Select(Task => Task.Row_ID).First();

                for (int i = RowId; i < RowIdMax; i++)
                {
                    Task tempTask = pen2.Tasks.Where(Task => Task.Row_ID == i + 1).Single();
                    Task transferTask = new Task();
                    transferTask.Row_ID = i;
                    transferTask.Task_Name = tempTask.Task_Name;
                    transferTask.Start_Time = tempTask.Start_Time;
                    transferTask.End_Time = tempTask.End_Time;
                    transferTask.Indent_Counter = tempTask.Indent_Counter;
                    transferTask.Predecessor = tempTask.Predecessor;
                    pen2.Tasks.AddObject(transferTask);
                    pen2.Tasks.DeleteObject(tempTask);
                    pen2.SaveChanges();
                }
            }
        }

        public static void RowSortPreInsert(int id)
        {
            ProjectEntities pen3 = new ProjectEntities();
            int RowId = id;
            int RowIdMax = pen3.Tasks.OrderByDescending(Task => Task.Row_ID).Select(Task => Task.Row_ID).FirstOrDefault();
            int Range = RowIdMax - RowId;

            for (int i = 0; i <= Range; i++)
            {
                Task tempTask = pen3.Tasks.Where(Task => Task.Row_ID == RowIdMax - i).Single();
                Task transferTask = new Task();
                int j = RowIdMax + 1 - i;
                transferTask.Row_ID = j;
                transferTask.Task_Name = tempTask.Task_Name;
                transferTask.Start_Time = tempTask.Start_Time;
                transferTask.End_Time = tempTask.End_Time;
                transferTask.Indent_Counter = tempTask.Indent_Counter;
                transferTask.Predecessor = tempTask.Predecessor;
                pen3.Tasks.DeleteObject(tempTask);
                pen3.Tasks.AddObject(transferTask);
                pen3.SaveChanges();
            }
        }


        public static List<Task> GetTasksToIndex       // For output to index
        {                               
            get
            {
                ProjectEntities pen4 = new ProjectEntities();
                var TaskList = new List<Task>();
                var ListQry = pen4.Tasks.OrderByDescending(Task => Task.Row_ID);
                foreach (var taskdetails in ListQry)
                {
                    TaskList.Add(taskdetails);
                }

                // Add pre space to show task as appropriate subtask
                foreach (var newtask in TaskList)
                {
                    string prespace = "";
                    for (int i = 1; i < newtask.Indent_Counter; i++)
                    {
                        prespace += " " + " " + " ";
                    }
                    newtask.Task_Name = prespace + newtask.Task_Name;
                }
                return TaskList;
            }
        }

        public static List<Task> GetTasksToChart       // For output to chart
        {
            get
            {
                ProjectEntities pen4 = new ProjectEntities();
                var TaskList = new List<Task>();
                var ListQry = pen4.Tasks.OrderByDescending(Task => Task.Row_ID);
                foreach (var taskdetails in ListQry)
                {
                    TaskList.Add(taskdetails);
                }

                // Find task that uses most space (string and prespace) 
                // and give this information to next foreach loop (to add postspace)
                double k = 1;
                foreach (var newtask in TaskList)
                {
                    int newstring = MeasureText(newtask.Task_Name);
                    double prespace = 4.4 * ((newtask.Indent_Counter - 1) * 8);
                    double strlength = newstring + prespace;
                    if (strlength > k)
                    {
                        k = strlength;
                    }
                }

                // Add post space to align all tasks for chart
                foreach (var newtask in TaskList)
                {
                    double newlength = MeasureText(newtask.Task_Name) + ((newtask.Indent_Counter - 1) * 4.4 * 8);
                    double postspacecount = (k - newlength)/4.4;
                    string postspace = "";
                    for (int m = 0; m < postspacecount; m++)
                    {
                        postspace += " ";
                    }
                    newtask.Task_Name += postspace + ".";
                }

                return TaskList;
            }
        }

        public static int MeasureText(string newText)
        {
            Font DrawFont = null;
            Graphics DrawGraphics = null;
            Bitmap TextBitmap = null;

            TextBitmap = new Bitmap(1, 1);
            DrawGraphics = Graphics.FromImage(TextBitmap);
            DrawFont = new Font("TrebuchetMS Bold", 11);
            String TheText = newText;

            int Width = (int)DrawGraphics.MeasureString(TheText, DrawFont).Width;

            DrawFont.Dispose();
            DrawGraphics.Dispose();
            TextBitmap.Dispose();

            return Width;
        }

        public static List<Task> TrimEnding(List<Task> templist)  // For output to index page
        {
            foreach (var newtask in templist)
            {
                newtask.Task_Name = newtask.Task_Name.Replace(".", " ");
                newtask.Task_Name = newtask.Task_Name.TrimEnd();
            }
            templist.Reverse();
            return templist;
        }

        //public static List<Task> AssignSummaryDates         // Create dates in summary tasks
                                                               // Dependent on subtask dates
        public static void AssignSummaryDates()
        {    
            ProjectEntities pen5 = new ProjectEntities();
            int ICMax = pen5.Tasks.OrderByDescending(Task => Task.Indent_Counter)
                .Select(Task => Task.Indent_Counter).FirstOrDefault();
                
            for (int i = 1; ICMax - i >= 1; i++)
            {
                int tempint = ICMax - i;
                var TaskList = new List<Task>();
                var ListQry = pen5.Tasks.OrderByDescending(Task => Task.Row_ID)
                                .Where(Task => Task.Indent_Counter == tempint);
                    
                foreach (Task newTask in ListQry)
                {
                    Task Parent1 = new Task();
                    int j = newTask.Row_ID;
                    ProjectEntities pen6 = new ProjectEntities();
                    Parent1 = pen6.Tasks.Where(Task => Task.Row_ID == j).SingleOrDefault();
                    DateTime tempMin = new DateTime(2099, 3, 01);
                    DateTime tempMax = new DateTime(2000, 3, 01);    

                    int nextRowId = Parent1.Row_ID + 1;
                    Task taskAfterParent = new Task();
                    ProjectEntities pen7 = new ProjectEntities();
                    taskAfterParent = pen7.Tasks.Where(Task => Task.Row_ID == nextRowId).SingleOrDefault();

                    if (taskAfterParent != null)       
                    {
                        while (taskAfterParent.Indent_Counter > Parent1.Indent_Counter) 
                        {
                            if (taskAfterParent.Indent_Counter == Parent1.Indent_Counter + 1)  
                            {
                                    Task nextTask = new Task();
                                    ProjectEntities pen8 = new ProjectEntities();
                                    nextTask = pen8.Tasks.Where(Task => Task.Row_ID == nextRowId)
                                        .First();
                                    DateTime tempStart = nextTask.Start_Time;

                                    if (tempStart < tempMin)
                                    {
                                        tempMin = nextTask.Start_Time;
                                    }

                                    DateTime tempEnd = nextTask.End_Time;

                                    if (tempEnd > tempMax)
                                    {
                                        tempMax = nextTask.End_Time;
                                    }
                            } 

                            nextRowId += 1;
                            int rownum = DatabaseManager.RowNoRetrieval;

                            if (nextRowId > rownum)          // stops at last row otherwise null row error occurs
                            {
                                break;
                            }

                            ProjectEntities pen9 = new ProjectEntities();
                            taskAfterParent = pen9.Tasks.Where(Task => Task.Row_ID == nextRowId).First();
                        }      

                        DateTime tempArg = new DateTime(2099, 3, 01);
                        if (tempMin != tempArg)
                        {
                            Task Parent2 = new Task();
                            Parent2.Row_ID = Parent1.Row_ID;
                            Parent2.Task_Name = Parent1.Task_Name;
                            Parent2.Predecessor = Parent1.Predecessor;      
                            Parent2.Start_Time = tempMin;
                            Parent2.End_Time = tempMax;
                            Parent2.Indent_Counter = Parent1.Indent_Counter;
                            pen6.Tasks.DeleteObject(Parent1);
                            pen6.Tasks.AddObject(Parent2);
                            pen6.SaveChanges();
                        }
                    }
                }
            }
        }

        public static void AssignPredecessor(int PreTaskId, int PostTaskId)
        {
                Task PredecessorTask = new Task();
                Task MasterTask = new Task();
                Task TaskAfterMaster = new Task();
                ProjectEntities pen7 = new ProjectEntities();
                int rownum = DatabaseManager.RowNoRetrieval;
                PredecessorTask = pen7.Tasks.Where(Task => Task.Row_ID == PreTaskId).First();
                MasterTask = pen7.Tasks.Where(Task => Task.Row_ID == PostTaskId).First();
                if (PostTaskId != rownum)
                {
                    TaskAfterMaster = pen7.Tasks.Where(Task => Task.Row_ID == PostTaskId + 1).First();
                }

                // if task is not a summary task and is the last task on list can change just this 1 task
                if (PostTaskId == rownum)
                {
                    Task Parent3 = new Task();
                    Parent3.Row_ID = MasterTask.Row_ID;
                    Parent3.Task_Name = MasterTask.Task_Name;
                    Parent3.Predecessor = MasterTask.Predecessor;
                    Parent3.Indent_Counter = MasterTask.Indent_Counter;
                    Parent3.Start_Time = PredecessorTask.End_Time;
                    TimeSpan duration = MasterTask.End_Time - MasterTask.Start_Time;
                    Parent3.End_Time = PredecessorTask.End_Time + duration;
                    pen7.Tasks.DeleteObject(MasterTask);
                    pen7.Tasks.AddObject(Parent3);
                    pen7.SaveChanges();
                }

                // if task is not a summary task can change just this 1 task
                else if (TaskAfterMaster.Indent_Counter == MasterTask.Indent_Counter)
                {
                    if (MasterTask.Start_Time < PredecessorTask.End_Time)
                    {
                        Task Parent3 = new Task();
                        Parent3.Row_ID = MasterTask.Row_ID;
                        Parent3.Task_Name = MasterTask.Task_Name;
                        Parent3.Predecessor = MasterTask.Predecessor;
                        Parent3.Indent_Counter = MasterTask.Indent_Counter;
                        Parent3.Start_Time = PredecessorTask.End_Time;
                        TimeSpan duration = MasterTask.End_Time - MasterTask.Start_Time;
                        Parent3.End_Time = PredecessorTask.End_Time + duration;
                        pen7.Tasks.DeleteObject(MasterTask);
                        pen7.Tasks.AddObject(Parent3);
                        pen7.SaveChanges();
                    }
                }

                // if task is a summary task must inspect "influential" tasks (non summary tasks) 
                else
                {
                    Task currentTask = new Task();
                    Task nextTask = new Task();
                    currentTask = pen7.Tasks.Where(Task => Task.Row_ID == PostTaskId).First();
                    nextTask = pen7.Tasks.Where(Task => Task.Row_ID == PostTaskId + 1).First();

                    int tempRowId = PostTaskId;
                    var TaskList = new List<Task>();
                    while ((nextTask.Indent_Counter != MasterTask.Indent_Counter) &&
                        (nextTask.Indent_Counter != 1))
                    {
                        tempRowId += 1;

                        if (currentTask.Indent_Counter == nextTask.Indent_Counter)
                        {
                            TaskList.Add(currentTask);
                        }

                        if (nextTask.Row_ID == rownum)          // stops at last row otherwise null row error occurs
                        {
                            TaskList.Add(nextTask);
                            break;
                        }

                        if (currentTask.Indent_Counter > nextTask.Indent_Counter)
                        {
                            TaskList.Add(currentTask);
                        }
                        currentTask = pen7.Tasks.Where(Task => Task.Row_ID == tempRowId).First();
                        nextTask = pen7.Tasks.Where(Task => Task.Row_ID == tempRowId + 1).First();

                        if (nextTask.Indent_Counter == 1)
                        {
                            TaskList.Add(currentTask);
                        }
                    }

                    foreach (Task infTasks in TaskList)
                    {
                        if (infTasks.Start_Time < PredecessorTask.End_Time)
                        {
                            Task Parent3 = new Task();
                            Parent3.Row_ID = infTasks.Row_ID;
                            Parent3.Task_Name = infTasks.Task_Name;
                            Parent3.Predecessor = infTasks.Predecessor;
                            Parent3.Indent_Counter = infTasks.Indent_Counter;
                            Parent3.Start_Time = PredecessorTask.End_Time;
                            TimeSpan duration = infTasks.End_Time - infTasks.Start_Time;
                            Parent3.End_Time = PredecessorTask.End_Time + duration;
                            pen7.Tasks.DeleteObject(infTasks);
                            pen7.Tasks.AddObject(Parent3);
                            pen7.SaveChanges();
                        }
                    }
                }
        }
    }
}