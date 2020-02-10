using System;

namespace HCRGUniversity.Core.Data.Model
{
 public  class ProductShoppingCart
    {
        public int ProductShoppingTempID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public int? CoupanID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }     
        public decimal Price { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? ShippingPaymentID { get; set; }
        public decimal? TaxPercentage { get; set; }
    }
}
