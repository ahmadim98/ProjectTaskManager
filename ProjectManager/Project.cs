using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    class Project
    {
        public string name;
        public DataTable TasksData;
        public DataTable ResourcesData;

        public Project(string name)
        {
            this.name = name;

            TasksData = new DataTable();
            TasksData.Columns.Add("Task ID", typeof(string));
            TasksData.Columns.Add("Task Name", typeof(string));
            TasksData.Columns.Add("Duration", typeof(string));
            TasksData.Columns.Add("Start (Date)", typeof(string));
            TasksData.Columns.Add("End (Date)", typeof(string));
            TasksData.Columns.Add("Resource Name", typeof(string));
            TasksData.Columns.Add("Total Cost", typeof(int));

            ResourcesData = new DataTable();
            ResourcesData.Columns.Add("Resource Name", typeof(string));
            ResourcesData.Columns.Add("Type", typeof(string));
            ResourcesData.Columns.Add("Material", typeof(bool));
            ResourcesData.Columns.Add("Max (No. of Resources)", typeof(int));
            ResourcesData.Columns.Add("St. Rate", typeof(int));
            ResourcesData.Columns.Add("Ovt.", typeof(int));
            ResourcesData.Columns.Add("Cost/Use", typeof(int));
        }

        public void createTask(Task task)
        {
            //Task task = new Task(id,taskname,startdate,enddate,null);
            DataRow NewRow = TasksData.NewRow();
            NewRow["Task ID"] = TasksData.Rows.Count.ToString();
            NewRow["Task Name"] = task.TaskName;
            NewRow["Duration"] = task.Duration.ToString();
            NewRow["Start (Date)"] = task.StartDate.ToString();
            NewRow["End (Date)"] = task.EndDate.ToString();
            NewRow["Resource Name"] = "";
            NewRow["Total Cost"] = 0;
            TasksData.Rows.Add(NewRow);
            TasksData.AcceptChanges();
        }

        public void createResources(Resources resource)
        {
            DataRow NewRow = ResourcesData.NewRow();
            NewRow["Resource Name"] = resource.ResourceName;
            NewRow["Type"] = resource.ResourceType;
            NewRow["Material"] = resource.Material;
            NewRow["Max (No. of Resources)"] = resource.Max;
            NewRow["St. Rate"] = resource.StandardRate;
            NewRow["Ovt."] = resource.OverTime;
            NewRow["Cost/Use"] = resource.Cost;
            ResourcesData.Rows.Add(NewRow);
            ResourcesData.AcceptChanges();
        }

        public void assignResources(int taskid,string resourcename)
        {
            if (TasksData.Rows[taskid][5] == "")
            {
                TasksData.Rows[taskid][5] = resourcename;
                TasksData.AcceptChanges();
            }
            else
            {
                TasksData.Rows[taskid][5] += "," + resourcename;
                TasksData.AcceptChanges();
            }
            
        }

        public void calculateCost(int taskid,string resources)
        {
            int cost = 0;
            string[] resourcelist = resources.Split(',');
            string last = resourcelist[resourcelist.Length - 1];
            foreach (string resourceitem in resourcelist)
            {
                for (int i = 0; i < ResourcesData.Rows.Count; i++)
                {
                    if (ResourcesData.Rows[i].Field<string>("Resource Name") == resourceitem)
                    {
                        if (ResourcesData.Rows[i].Field<string>("Type") == "Work")
                        {
                            cost += (Convert.ToInt32(TasksData.Rows[taskid].Field<string>("Duration")) * ResourcesData.Rows[i].Field<int>("St. Rate") * 8);
                        }
                        else
                        {
                            cost += ResourcesData.Rows[i].Field<int>("Cost/Use");
                        }
                    }
                }
            }
            TasksData.Rows[taskid][6] = cost;
        }

        public void totalCost()
        {
            for (int i = 0; i < TasksData.Rows.Count; i++)
            {
                if (TasksData.Rows[i].Field<string>("Task ID") == "Total Cost")
                {
                    TasksData.Rows[i].Delete();
                    TasksData.AcceptChanges();
                }
            }

            DataRow NewRow = TasksData.NewRow();
            NewRow["Task ID"] = "Total Cost";
            NewRow["Task Name"] = "";
            NewRow["Duration"] = null;
            NewRow["Start (Date)"] = null;
            NewRow["End (Date)"] = null;
            NewRow["Resource Name"] = "";
            int cost = 0;

            for (int i = 0; i < TasksData.Rows.Count; i++)
            {
                cost += TasksData.Rows[i].Field<int>("Total Cost");
            }

            NewRow["Total Cost"] = cost;

            TasksData.Rows.Add(NewRow);
            TasksData.AcceptChanges();
        }

        public void removeResources(int taskid, int resourceid)
        {

        }
    }
}
