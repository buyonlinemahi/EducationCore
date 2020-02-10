
namespace HCRGUniversity.Core.Data.Model
{
    public class ShippingAddress
    {
        public int ShippingAddressID { get; set; }

        public int SAUserID { get; set; }

        public string SAFirstName { get; set; }
        public string SALastName { get; set; }
        public string SAAddress { get; set; }
        public string SAAddress2 { get; set; }
        public string SACity { get; set; }
        public int SAStateID { get; set; }
        public string SAPostalCode { get; set; }
        public string SAPhone { get; set; }
        public bool? SABillingAddressSame { get; set; }
    }
}
