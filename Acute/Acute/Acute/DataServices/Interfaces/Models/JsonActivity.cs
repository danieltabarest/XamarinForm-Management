using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Acute.DataServices.Interfaces.Models
{

    public class JsonActivity
    {
        public List<JsonDatum> data { get; set; }
        public List<JsonIncluded> included { get; set; }
    }
    public class JsonActivityEdit
    {
        public JsonDatumEdit data { get; set; }
    }


    public class JsonDatumEdit
    {
        public string type { get; set; }
        public int id { get; set; }
        public JsonAttributes attributes { get; set; }
    }


    public class JsonDatum
    {
        public string type { get; set; }
        [JsonIgnore]
        public int id { get; set; }
        public JsonAttributes attributes { get; set; }
        public JsonRelationships relationships { get; set; }
    }

    public class JsonAttributes
    {
        [JsonIgnore]
        public int idactivity { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool closed { get; set; }
        public string myValidation { get; set; }
    }

    public class JsonRelationships
    {
        public JsonChildActivity task { get; set; }
    }

    public class JsonChildActivity
    {
        public JsonChildActivityData data { get; set; }
    }

    public class JsonChildActivityData
    {
        public string type { get; set; }
        public int id { get; set; }
    }

    public class JsonIncluded
    {
        public string type { get; set; }
        public int id { get; set; }
        public JsonAttributesTask attributes { get; set; }
        public JsonRelationshipsTask relationships { get; set; }
    }

    public class JsonAttributesTask
    {
        public string name { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool closed { get; set; }
        public string analysis { get; set; }
        public string objectives { get; set; }
    }

    public class JsonRelationshipsTask
    {
        public JsonProject project { get; set; }
    }

    public class JsonProject
    {
        public JsonProjectData data { get; set; }
    }

    public class JsonProjectData
    {
        public string type { get; set; }
        public int id { get; set; }
    }

}
