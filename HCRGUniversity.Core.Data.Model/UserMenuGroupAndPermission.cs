
namespace HCRGUniversity.Core.Data.Model
{
    public class UserMenuGroupAndPermission
    {
       public int UserMenuPermissionID { get; set; }
       public int UserMenuGroupID { get; set; }
       public string UserMenuGroupName { get; set; }
       public string MenuIDs { get; set; }
       public int OrganizationID { get; set; }
    }
}
