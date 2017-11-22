using System;
using System.Collections.Generic;

namespace Simedia.App.SDK.Models
{
    public class TaskLog
    {
        public TaskLog()
        {
            attachments = new List<Attachment>();
        }
        public int tasklog_id { get; set; }
        public int activity_id { get; set; }
        public int minutes { get; set; }
        public DateTime date { get; set; }
        public string comment { get; set; }
        public int percentRnd { get; set; }
        public List<Attachment> attachments { get; set; }
    }
}
