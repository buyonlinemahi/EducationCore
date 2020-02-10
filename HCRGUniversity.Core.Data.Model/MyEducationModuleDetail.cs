
using System;
using System.Collections.Generic;
namespace HCRGUniversity.Core.Data.Model
{
    public class MyEducationModuleDetail
    {
        public int EducationModuleID { get; set; }
        public int EducationID { get; set; }
        public int EducationModulePosition { get; set; }
        public int MEMID { get; set; }
        public int MEID { get; set; }
        public string CourseName { get; set; }
        public string CourseFile { get; set; }
        public string EducationModuleDescription { get; set; }
        public string EducationModuleName { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string FileTypeName { get; set; }
        public string ModuleFile { get; set; }
        public string TimeLeft { get; set; }
        public string EducationModuleTime { get; set; }
        public int? ExpireDaysLeft { get; set; }
        public bool? IsTimerRequired { get; set; }   
        public IEnumerable<EducationModuleFile> EducationModuleFileDetail { get; set; }
    }
}