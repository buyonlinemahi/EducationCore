using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class TermsConditionConfiguration : EntityTypeConfiguration<TermsCondition>
    {
        public TermsConditionConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.TermsCondition, Constant.Consts.Schema.DBO);
            HasKey(TermsCondition => TermsCondition.TermsConditionID);
            Property(TermsCondition => TermsCondition.TermsConditionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(TermsCondition => TermsCondition.TermsConditionContent).IsRequired();
        }
    }
}
