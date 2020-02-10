using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class CollegeEducationConfiguration : EntityTypeConfiguration<CollegeEducation>
    {
        public CollegeEducationConfiguration()
            : base()
        {
            ToTable("CollegeEducations", Constant.Consts.Schema.LINK);
            HasKey(table => table.CollegeCourseID);
        }
    }
}