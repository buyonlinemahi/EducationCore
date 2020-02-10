using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationDetailPageConfiguration : EntityTypeConfiguration<EducationDetailPage>
    {
        public EducationDetailPageConfiguration()
            : base()
        {
            ToTable("EducationDetailPages", Constant.Consts.Schema.DBO);
            HasKey(table => table.EPageID);
        }
    }
}