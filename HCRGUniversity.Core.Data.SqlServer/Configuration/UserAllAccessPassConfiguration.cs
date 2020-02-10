using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserAllAccessPassConfiguration : EntityTypeConfiguration<UserAllAccessPass>
    {
        public UserAllAccessPassConfiguration()
            : base()
        {
            ToTable(Tables.dbo.UserAllAccessPass, Constant.Consts.Schema.DBO);
            HasKey(userAAP => userAAP.UserAllAccessPassID);
            Property(userAAP => userAAP.UserAllAccessPassID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
