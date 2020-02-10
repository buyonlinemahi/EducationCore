using System;

namespace HCRGUniversity.Core.Data.Model
{
   public  class EducationDetailPageWithEducation
    {
        public int EPageID { get; set; }
        public int EducationID { get; set; }
        public string PContent { get; set; }
        public DateTime PDate { get; set; }
        public string CourseName { get; set; }
    }
}
