using System;
namespace Acute.Models
{
    public class Attachment
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal size { get; set; }
        public Attachment_Type description { get; set; }
        public  byte[] dataArray { get; set; }
        public string description_other { get; set; }
        public string path { get; set; }
        public string ext { get; set; }
        public bool new_object { get; set; }
    }
}
