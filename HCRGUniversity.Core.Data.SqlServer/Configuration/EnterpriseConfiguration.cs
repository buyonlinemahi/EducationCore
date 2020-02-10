using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EnterpriseConfiguration : EntityTypeConfiguration<Enterprise>
    {
        public EnterpriseConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.Enterprise, Constant.Consts.Schema.DBO);
            HasKey(ent => ent.EnterpriseID);
            Property(ent => ent.EnterpriseID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
    
        }
    }
}
