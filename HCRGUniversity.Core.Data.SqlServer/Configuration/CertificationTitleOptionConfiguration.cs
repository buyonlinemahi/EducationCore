using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class CertificationTitleOptionConfiguration : EntityTypeConfiguration<CertificationTitleOption>
    {
        public CertificationTitleOptionConfiguration()
            : base()
        {
            ToTable("CertificationTitleOptions", Constant.Consts.Schema.DBO);
            HasKey(certificationOption => certificationOption.CertificationTitleOptionID);
            Property(certificationOption => certificationOption.CertificationTitleOptionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(certificationOption => certificationOption.CertificationTitle);
            Property(certificationOption => certificationOption.CertificationContent);
            Property(certificationOption => certificationOption.EducationId);
        }
    }
}
