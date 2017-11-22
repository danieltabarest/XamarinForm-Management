using System;
using MyLearn.Models;

namespace MyLearn.Dtos
{
    public class AssignmentDto : Data.Base.JsonObject<Assignment>
    {
        public string Id
        {
            get;
            set;
        }

        public string CourseId
        {
            get;
            set;
        }

        public string ColumnName
        {
            get;
            set;
        }

        public string ColumnDueDate
        {
            get;
            set;
        }

        public override Assignment ToDomainModel()
        {
            return new Assignment()
            {
                Id = Id,
                CourseId = CourseId,
                Name = ColumnName,
                DueDate = DateTime.Parse(ColumnDueDate)
            };
        }
    }
}
