using Acute.DataServices.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Acute.Models
{
    //public class TaskLog
    //{
    //    public TaskLog()
    //    {
    //        attachments = new List<Attachment>();
    //    }
    //    public int tasklog_id { get; set; }
    //    public int activity_id { get; set; }
    //    public int minutes { get; set; }
    //    public DateTime date { get; set; }
    //    public string comment { get; set; }
    //    public int percentRnd { get; set; }
    //    public List<Attachment> attachments { get; set; }
    //}


    public class TaskLog
    {
        public List<DataTaskLog> data { get; set; }
        //public List<DataAttach> included { get; set; }
        public List<DataAttachGet> included { get; set; }
    }

    public class DataTaskLog
    {
        public string type { get; set; }
        public int id { get; set; }
        public AttributesTaskLog attributes { get; set; }
        public RelationshipsTaskLog relationships { get; set; }
    }

    public class AttributesTaskLog
    {
        public string idactivity   { get; set; }
        public int minutes { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        public int percentRnd { get; set; }
        public int idtasklog { get;  set; }
    }

    public class RelationshipsTaskLog
    {
        public ActivityTaskLog activity { get; set; }
        public Attachments attachments { get; set; }
    }

    public class ActivityTaskLog
    {
        public DataActivityTaskLog data { get; set; }
    }

    public class DataActivityTaskLog
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class Attachments
    {
        public List<DataAttachGet> data { get; set; }
    }

}
