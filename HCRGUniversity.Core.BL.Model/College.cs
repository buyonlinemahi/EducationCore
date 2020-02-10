﻿
namespace HCRGUniversity.Core.BL.Model
{
    public class College  : Base.BaseClientColumn
    {
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public bool? IsActive { get; set; }
        public string Abbreviation { get; set; }
        public string StartNumber { get; set; }
        public string OrganizationName { get; set; }
    }
}