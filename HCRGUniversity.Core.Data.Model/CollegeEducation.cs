﻿namespace HCRGUniversity.Core.Data.Model
{
    public class CollegeEducation
    {
        public int CollegeCourseID { get; set; }

        public int CollegeID { get; set; }

        public int EducationID { get; set; }

        public bool IsActive { get; set; }
    }
}