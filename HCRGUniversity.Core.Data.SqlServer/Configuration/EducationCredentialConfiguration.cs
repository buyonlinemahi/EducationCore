using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationCredentialConfiguration : EntityTypeConfiguration<EducationCredential>
    {
        public EducationCredentialConfiguration()
            : base()
        {
            ToTable("EducationCredentials", Constant.Consts.Schema.DBO);
            HasKey(educationCredential => educationCredential.CredentialID);
            Property(educationCredential => educationCredential.CredentialID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

        }
    }
}

