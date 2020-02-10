using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class FacultyConfiguration : EntityTypeConfiguration<Faculty>
    {
        public FacultyConfiguration()
            : base()
        {
            ToTable(Tables.dbo.Faculty, Constant.Consts.Schema.DBO);
            HasKey(table => table.FacultyID);
        }
    }
}
