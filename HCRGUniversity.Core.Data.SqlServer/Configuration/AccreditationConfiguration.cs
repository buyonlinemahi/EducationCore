using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class AccreditationConfiguration: EntityTypeConfiguration<Accreditation>
    {
        public AccreditationConfiguration()
            : base()
        {
            ToTable("Accreditations", Constant.Consts.Schema.DBO);
            HasKey(accreditor => accreditor.AccreditationID);
            Property(accreditor => accreditor.AccreditationID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        
        }
    }
}
