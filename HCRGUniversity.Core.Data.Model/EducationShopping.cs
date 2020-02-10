using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class EducationShopping
    {
        public int EducationShoppingID { get; set; }
        public int UserID { get; set; }
        public int EducationID { get; set; }
        public int EducationTypeID { get; set; }
        public int Quantity { get; set; }
        public int? CoupanID { get; set; }
        public decimal Grandtotal { get; set; }
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public decimal? TaxPercentage { get; set; }
        public int? ShippingPaymentID { get; set; }
        public int? UserAllAccessPassID { get; set; }
    }
}
