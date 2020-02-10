using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserResetPasswordConfiguration : EntityTypeConfiguration<UserResetPassword>
    {
        public UserResetPasswordConfiguration()
            : base()
        {
            ToTable(Tables.dbo.UserResetPassword, Constant.Consts.Schema.DBO);
            HasKey(table => table.UTempPwdID);
            Property(user => user.UTempPwdID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
