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
                    //int strlength = newtask.Task_Name.Length + ((newtask.Indent_Counter - 1) * 4);
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

                    if (taskAfterParent != null)        // Eliminates bug generated if task is very last task in list
                    {
                        if (taskAfterParent.Indent_Counter > Parent1.Indent_Counter)
                        {
                            //while (taskAfterParent.Indent_Counter > Parent1.Indent_Counter)
                            while (taskAfterParent.Indent_Counter == Parent1.Indent_Counter + 1)
                            {
                                //if (taskAfterParent.Indent_Counter == Parent1.Indent_Counter + 1)
                                //{
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
                                //}

                                nextRowId += 1;
                                ProjectEntities pen9 = new ProjectEntities();
                                taskAfterParent = pen9.Tasks
                                        .Where(Task => Task.Row_ID == nextRowId).First();
                            }   // close While Loop
                        }       // close IF Loop

                        DateTime tempArg = new DateTime(2099, 3, 01);
                        if (tempMin != tempArg)
                        {
                            Task Parent2 = new Task();
                            Parent2.Row_ID = Parent1.Row_ID;
                            Parent2.Task_Name = Parent1.Task_Name;
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
    }
}