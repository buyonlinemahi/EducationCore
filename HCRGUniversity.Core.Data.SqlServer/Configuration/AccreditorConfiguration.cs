using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer
{
    public class AccreditorConfiguration : EntityTypeConfiguration<Accreditor>
    {
       public AccreditorConfiguration()
            : base()
        {
            ToTable("Accreditors", Constant.Consts.Schema.DBO);
            HasKey(accreditor => accreditor.AccreditorID);
            Property(accreditor => accreditor.AccreditorID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        
        }
    }
}
