using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
            : base()
        {
            ToTable("Plans", Constant.Consts.Schema.DBO);
            HasKey(plan => plan.PlanID);
            Property(plan => plan.PlanID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(plan => plan.PlanName).IsRequired();
        }
    }
}
