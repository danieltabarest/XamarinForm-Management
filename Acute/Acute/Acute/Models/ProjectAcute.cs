using System;
namespace Acute.Models
{
    public class ProjectAcute
    {
        public int project_id { get; set; }
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string EndDate
        {
            get;
            set;
        }

        public bool Closed
        {
            get;
            set;
        }
    }
}
