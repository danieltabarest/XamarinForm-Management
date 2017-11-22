using System;
using MyLearn.Models;

namespace MyLearn.Dtos
{
    public class SelectedGradeDto
    {
        public Grade Grade
        {
            get;
            private set;   
        }

        public string CourseName
        {
            get;
            private set;
        }

        public SelectedGradeDto(string courseName, Grade grade)
        {
            CourseName = courseName;
            Grade = grade;
        }
    }
}
