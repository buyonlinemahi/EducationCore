using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class CoursePlanConfiguration: EntityTypeConfiguration<CoursePlan>
    {
        public CoursePlanConfiguration()
            : base()
        {
            ToTable("CoursePlans", Constant.Consts.Schema.DBO);
            HasKey(coursePlan => coursePlan.CoursePlanID);
            Property(coursePlan => coursePlan.CoursePlanID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
