using System;
using MyLearn.Models;

namespace MyLearn.Dtos
{
    public class GradeDto : Data.Base.JsonObject<Grade>
    {
        
        public string ColumnId
        {
            get;
            set;
        }

        public string CourseId
        {
            get;
            set;
        }

        public string ColumnContentId
        {
            get;
            set;
        }

        public string ColumnNameDisplay
        {
            get;
            set;
        }

        public string ActualGrade
        {
            get;
            set;
        }

        public string PossibleGrade
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }

        public override Grade ToDomainModel()
        {
            return new Grade(ColumnId, 
                             CourseId, 
                             ColumnContentId, 
                             ColumnNameDisplay, 
                             ConvertGradePoint(ActualGrade),
                             ConvertGradePoint(PossibleGrade),
                             Status);
        }

        private double ConvertGradePoint(string pointText)
        {
            double convertedPoint;

            try
            {
                convertedPoint = Convert.ToDouble(pointText);    
            }
			catch (Exception)
			{
                convertedPoint = 0.0;
			}

            return convertedPoint;
        }
    }
}
