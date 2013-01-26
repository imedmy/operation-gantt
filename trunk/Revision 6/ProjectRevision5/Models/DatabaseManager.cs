using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                pen3.Tasks.DeleteObject(tempTask);
                pen3.Tasks.AddObject(transferTask);
                pen3.SaveChanges();
            }
        }

        public static List<Task> GetDatabaseTasks
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
                return TaskList;
            }
        }
    }
}