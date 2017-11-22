using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Simedia.App.SDK.Models
{
    public partial class TaskObject :BaseModel
    {
        

        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool closed { get; set; }

    }
}
