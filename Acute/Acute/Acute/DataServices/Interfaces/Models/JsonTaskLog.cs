using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Acute.DataServices.Interfaces.Models
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


    public class JsonTaskLog
    {
        public JsonDataTaskLog data { get; set; }
        [JsonIgnore]
        public List<object> included { get; set; }
    }

    public class JsonTaskLogEdit
    {
        public JsonDataTaskLogEdit data { get; set; }
        [JsonIgnore]
        public List<object> included { get; set; }
    }

    public class JsonDataTaskLog
    {
        public string type { get; set; }
        [JsonIgnore]
        public int id { get; set; }
        public JsonAttributesTaskLog attributes { get; set; }
        public JsonRelationshipsTaskLog relationships { get; set; }
    }

    public class JsonDataTaskLogEdit
    {
        public string type { get; set; }
        public int id { get; set; }
        public JsonAttributesTaskLog attributes { get; set; }
        [JsonIgnore]
        public JsonRelationshipsTaskLog relationships { get; set; }
    }

    public class JsonAttributesTaskLog
    {
        [JsonIgnore]
        public string idactivity { get; set; }
        public int minutes { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        public int percentRnd { get; set; }
        [JsonIgnore]
        public int idtasklog { get; set; }
    }

    public class JsonRelationshipsTaskLog
    {
        public JsonActivityTaskLog activity { get; set; }
        public JsonAttachments attachments { get; set; }
    }

    public class JsonActivityTaskLog
    {
        public JsonDataActivityTaskLog data { get; set; }
    }

    public class JsonDataActivityTaskLog
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class JsonAttachments
    {
        public List<DataAttach> data { get; set; }
    }

    public class JsonAttachmentsSave
    {
        public DataAttach data { get; set; }
    }

}
