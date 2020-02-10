using System;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data.Model
{
    public class EducationModuleFile
    {
        public int EducationModuleFileID { get; set; }
        public int EducationModuleID { get; set; }
        public string ModuleFile { get; set; }
        public int FileTypeID { get; set; }
        public string DocumentName { get; set; }
        public DateTime? DocumentUploadedDate { get; set; }
        public int? UserID { get; set; } 
    }
}
