using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class SuggestCourseConfiguration : EntityTypeConfiguration<SuggestCourse>
    {
        public SuggestCourseConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.SuggestCourse, Constant.Consts.Schema.DBO);
            HasKey(sc => sc.SuggestCourseID);
            Property(sc => sc.SuggestCourseID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
