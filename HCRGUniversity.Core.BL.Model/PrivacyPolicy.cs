
namespace HCRGUniversity.Core.BL.Model
{
    public class PrivacyPolicy
    {
        public int PrivacyPolicyID { get; set; }
        public string PrivacyPolicyContent { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
    }
}
