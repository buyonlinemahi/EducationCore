using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class PrivacyPolicyConfiguration : EntityTypeConfiguration<PrivacyPolicy>
    {

        public PrivacyPolicyConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.PrivacyPolicy, Constant.Consts.Schema.DBO);
            HasKey(Privacy => Privacy.PrivacyPolicyID);
            Property(Privacy => Privacy.PrivacyPolicyID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(Privacy => Privacy.PrivacyPolicyContent).IsRequired();
        }



    }
}

