using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Acute.DataServices.Interfaces.Models
{

    public class GetJsonTasklog
    {
        public GetData data { get; set; }
    }

    public class GetData
    {
        public string type { get; set; }
        public int id { get; set; }
        public GetAttributes attributes { get; set; }
        public GetRelationships relationships { get; set; }
    }

    public class GetAttributes
    {
        public int minutes { get; set; }
        public string date { get; set; }
        public string comment { get; set; }
        public int percentRnd { get; set; }
    }

    public class GetRelationships
    {
        public GetActivity activity { get; set; }
        public GetAttachments attachments { get; set; }
    }

    public class GetActivity
    {
        public GetData1 data { get; set; }
    }

    public class GetData1
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class GetAttachments
    {
        public object[] data { get; set; }
    }

}
