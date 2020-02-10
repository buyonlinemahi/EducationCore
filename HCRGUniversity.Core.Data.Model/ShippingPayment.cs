using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class ShippingPayment
    {
        public int ShippingPaymentID { get; set; }
        public int? UserID { get; set; }
        public int? BillingAddressID { get; set; }
        public int? ShippingAddressID { get; set; }
        public int? ShippingMethodID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsPaymentRecevied { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime? TransactionDatetime { get; set; }
        public string PaymentStatus { get; set; }
    }
}
