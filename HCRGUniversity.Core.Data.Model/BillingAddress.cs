
namespace HCRGUniversity.Core.Data.Model
{
    public class BillingAddress
    {
        public int BillingAddressID { get; set; }

        public int BAUserID { get; set; }

        public string BAFirstName { get; set; }
        public string BALastName { get; set; }
        public string BAAddress { get; set; }
        public string BAAddress2 { get; set; }
        public string BACity { get; set; }
        public int BAStateID { get; set; }
        public string BAPostalCode { get; set; }
        public string BAPhone { get; set; }

 
    }
}
