using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EnterprisePackageRegisterConfiguration : EntityTypeConfiguration<EnterprisePackageRegister>
    {
        public EnterprisePackageRegisterConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.EnterprisePackageRegister, Constant.Consts.Schema.DBO);
            HasKey(userSub => userSub.EPRID);
            Property(userSub => userSub.EPRID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
