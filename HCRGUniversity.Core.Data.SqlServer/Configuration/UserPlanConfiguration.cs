using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserPlanConfiguration : EntityTypeConfiguration<UserPlan>
    {
        public UserPlanConfiguration()
            : base()
        {
            ToTable("UserPlans", Constant.Consts.Schema.DBO);
            HasKey(userplan => userplan.UserPlanID);
            Property(userplan => userplan.UserPlanID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
