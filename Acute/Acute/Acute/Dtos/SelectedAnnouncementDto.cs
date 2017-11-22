using System;
using MyLearn.Models;

namespace MyLearn.Dtos
{
    public class SelectedAnnouncementDto
    {
        public Announcement Announcement
        {
            get;
            set;
        }

        public string CourseName
        {
            get;
            set;
        }
    }
}
