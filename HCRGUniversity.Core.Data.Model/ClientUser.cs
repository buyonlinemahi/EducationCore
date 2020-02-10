
namespace HCRGUniversity.Core.Data.Model
{
    public class ClientUser : Base.BaseOrganizationColumn
    {
        public int ClientUserID { get; set; }
        
        public int? UserID { get; set; }
    }
}
