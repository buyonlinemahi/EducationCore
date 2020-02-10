using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserMenuPermissionConfiguration : EntityTypeConfiguration<UserMenuPermission>
    {
        public UserMenuPermissionConfiguration()
            : base()
        {
            ToTable("UserMenuPermissions", Constant.Consts.Schema.DBO);
            HasKey(userMenuPermission => userMenuPermission.UserMenuPermissionID);
        }
    }
}
