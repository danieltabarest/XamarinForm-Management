using System;
using System.Collections.Generic;

namespace Acute.Models
{
    //public class Activity : BaseModel
    //{
    //    public Activity()
    //    {
    //        Tasklogs = new List<TaskLog>();
    //    }

    //    public int activity_id { get; set; }
    //    public int task_id { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public DateTime start_date { get; set; }
    //    public DateTime end_date { get; set; }
    //    public bool closed { get; set; }
    //    public string my_validation { get; set; }
    //    public List<TaskLog> Tasklogs { get; set; }
    //}

    public class Activity
    {
        public List<Datum> data { get; set; }
        public List<Included> included { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public int id { get; set; }
        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
    }

    public class Attributes
    {
        public int idactivity { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool closed { get; set; }
        public string myValidation { get; set; }
    }

    public class Relationships
    {
        public ChildActivity task { get; set; }
    }

    public class ChildActivity
    {
        public ChildActivityData data { get; set; }
    }

    public class ChildActivityData
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Included
    {
        public string type { get; set; }
        public int id { get; set; }
        public AttributesTask attributes { get; set; }
        public RelationshipsTask relationships { get; set; }
    }

    public class AttributesTask
    {
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool closed { get; set; }
        public string analysis { get; set; }
        public string objectives { get; set; }
    }

    public class RelationshipsTask
    {
        public Project project { get; set; }
    }

    public class Project
    {
        public ProjectData data { get; set; }
    }

    public class ProjectData
    {
        public string type { get; set; }
        public int id { get; set; }
    }

}
