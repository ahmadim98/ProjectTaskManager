using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    class Task
    {
        public string ID;
        public string TaskName;
        public int Duration;
        public DateTime StartDate;
        public DateTime EndDate;
        public List<Resources> TaskResources;

        public Task(string id,string taskname,DateTime startdate,DateTime enddate,List<Resources> taskresources)
        {
            ID = id;
            TaskName = taskname;
            StartDate = startdate;
            EndDate = enddate;
            Duration = Convert.ToInt32((enddate - startdate).TotalDays);
            TaskResources = taskresources;
        }
    }
}
