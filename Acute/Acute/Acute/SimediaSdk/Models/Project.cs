using System;
namespace Simedia.App.SDK.Models
{
    public class Project
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

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
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
