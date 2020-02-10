using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
            : base()
        {
            ToTable("Users", Constant.Consts.Schema.DBO);
            HasKey(user => user.UID);
            Property(user => user.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();            
        }
    }
}