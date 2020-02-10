
using System;
namespace HCRGUniversity.Core.Data.Model
{
    public class MyEducation
    {
        public int MEID { get; set; }
        public int UserID { get; set; }
        public int EducationID { get; set; }
        public int EducationTypeID { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool? Expired { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool? IsPassed { get; set; }
        public int? CredentialID { get; set; }
        public bool? CertificatePrinted { get; set; }
        public string CertificateURL { get; set; }
        public int PlanID { get; set; }
    }
}