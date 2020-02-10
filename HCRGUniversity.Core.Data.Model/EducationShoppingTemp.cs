using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class EducationShoppingTemp
    {
        public int EducationShoppingTempID { get; set; }
        public int UserID { get; set; }
        public int EducationID { get; set; }
        public int EducationTypeID { get; set; }
        public int Quantity { get; set; }
        public int? CoupanID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int? CredentialID { get; set; }
        public int? ShippingPaymentID { get; set; }
        public int? UserAllAccessPassID { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public decimal? TaxPercentage { get; set; }
    }
}
