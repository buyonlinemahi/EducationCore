namespace HCRGUniversity.Core.BL.Model
{
    public class Client
    {
        public int ClientID { get; set; }
        public int ClientTypeID { get; set; }
        public int OrganizationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public string RegisteredPaypalEmailID { get; set; }
        public string ClientSessionID { get; set; }
    }
}
