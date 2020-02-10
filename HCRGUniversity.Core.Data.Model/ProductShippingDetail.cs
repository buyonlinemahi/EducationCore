using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class ProductShippingDetail
    {
        public int ProductShippingDetailID { get; set; }
        public DateTime ProductShippedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ShippingPaymentID { get; set; }
    }
}
