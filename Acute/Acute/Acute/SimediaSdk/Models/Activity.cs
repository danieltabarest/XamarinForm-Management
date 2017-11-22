using System;
using System.Collections.Generic;

namespace Simedia.App.SDK.Models
{
    public class Activity : BaseModel
    {
        public Activity()
        {
            Tasklogs = new List<TaskLog>();
        }

        public int activity_id { get; set; }
        public int task_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool closed { get; set; }
        public string my_validation { get; set; }
        public List<TaskLog> Tasklogs { get; set; }
    }
}
