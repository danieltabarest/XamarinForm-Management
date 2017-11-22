using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Acute.DataServices.Interfaces.Models
{
    public class JsonAttach
    {
        public DataAttach data { get; set; }
    }

    public class DataAttach
    {
        public string type { get; set; }
        public int id { get; set; }
        [JsonIgnore]
        public AttributesAttach attributes { get; set; }
    }
    public class DataAttachGet
    {
        public string type { get; set; }
        public int id { get; set; }
        public AttributesAttach attributes { get; set; }
    }


    public class AttributesAttach
    {
        public string name { get; set; }
        public int size { get; set; }
        public int description { get; set; }
        public string descriptionOther { get; set; }
    }


}
