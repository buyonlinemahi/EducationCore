using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class MyEducationAccountHistory
    {
        public int MEID { get; set; }
        public int UserID { get; set; }
        public int EducationID { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string CourseName { get; set; }
        public decimal? Price { get; set; }
        public int? UserAllAccessPassID { get; set; }
        public string TransactionNumber { get; set; }
        public string PaymentStatus { get; set; }    

    }
}