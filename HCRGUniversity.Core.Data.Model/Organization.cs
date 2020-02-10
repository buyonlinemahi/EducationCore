
namespace HCRGUniversity.Core.Data.Model
{
   public class Organization
    {
       public int OrganizationID { get; set; }
       public string OrganizationName { get; set; }
       public string WebsiteName { get; set; }
       public int? ThemeID { get; set; }
       public string LogoImage { get; set; }
       public bool IsOrganizationAdmin { get; set; }
       public bool? IsCertificate { get; set; }
       public bool? IsWebPortal { get; set; }
       public string RegisteredPaypalEmailID { get; set; }
       public string FaviconImage { get; set; }
       public string MenuIDs { get; set; }
    }
}
