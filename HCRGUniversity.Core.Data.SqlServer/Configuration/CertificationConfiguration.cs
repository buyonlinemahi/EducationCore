using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class CertificationConfiguration : EntityTypeConfiguration<Certification>
    {
        public CertificationConfiguration()
            : base()
        {
            ToTable("Certifications", Constant.Consts.Schema.DBO);
            HasKey(certification => certification.CertificationID);
            Property(certification => certification.CertificationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        
        }
    }
}
