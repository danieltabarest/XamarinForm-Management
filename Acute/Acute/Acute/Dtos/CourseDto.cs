using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Acute.Models;

namespace Acute.Dtos 
{
    [JsonObject]
    public class ProjectDto : Data.Base.JsonObject<Project>
    {
        public ProjectDto()
        {
        }

        [JsonProperty]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty]
        public string ProjectId
        {
            get;
            set;
        }

        [JsonProperty]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty]
        public string StartDate
        {
            get;
            set;
        }

        [JsonProperty]
        public string EndDate
        {
            get;
            set;
        }

        [JsonProperty]
        public string TermCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string SubjectCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string ProjectCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string SectionCode
        {
            get;
            set;
        }

        [JsonProperty]
        public string Crn
        {
            get;
            set;
        }

        [JsonProperty]
        public string ProjectType
        {
            get;
            set;
        }

        public override Project ToDomainModel()
        {
            throw new NotImplementedException();
        }

        //[JsonProperty]
        //public List<StaffDto> Staffs
        //{
        //    get;
        //    set;
        //}

        //public override Project ToDomainModel()
        //{
        //    return new Project(Id, Name, DateTime.Parse(StartDate), DateTime.Parse(EndDate), ProjectTypeConverter(ProjectType))
        //    {
        //        InstructorName = Staffs.Count > 0 ? Staffs[0].Name : string.Empty,
        //        Term = new Term
        //        {
        //            Code = TermCode,
        //            Status = TermStatus.current
        //        },
        //        ProjectId = ProjectId,
        //        SubjectCode = SubjectCode,
        //        ProjectCode = ProjectCode,
        //        SectionCode = SectionCode,
        //        CRN = Crn
        //    };
        //}

        //private ProjectType ProjectTypeConverter(string ProjectType)
        //{
        //    switch(ProjectType)
        //    {
        //        case "Banner":
        //            return Models.ProjectType.AcademicProject;

        //        case "Training":
        //            return Models.ProjectType.TrainingProject;

        //        default:
        //            return Models.ProjectType.Other;      
        //    }
        //}

    }
}
