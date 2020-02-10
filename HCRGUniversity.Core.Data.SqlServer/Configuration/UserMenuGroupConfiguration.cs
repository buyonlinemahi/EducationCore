using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserMenuGroupConfiguration : EntityTypeConfiguration<UserMenuGroup>
    {
        public UserMenuGroupConfiguration()
            : base()
        {
            ToTable("UserMenuGroups", Constant.Consts.Schema.DBO);
            HasKey(userMenuGroup => userMenuGroup.UserMenuGroupID);
        }
    }
}
