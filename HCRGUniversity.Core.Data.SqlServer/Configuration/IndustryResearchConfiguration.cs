using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class IndustryResearchConfiguration : EntityTypeConfiguration<IndustryResearch>
    {
        public IndustryResearchConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.IndustryResearch, Constant.Consts.Schema.DBO);
            HasKey(table => table.IndustryResearchID);
            Property(table => table.IndustryResearchID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}