using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class IndustryConfiguration : EntityTypeConfiguration<Industry>
    {

        public IndustryConfiguration()
            : base()
        {
            ToTable("Industries", Constant.Consts.Schema.LOOKUP);
            HasKey(table => table.IndustryID);
        }
    }
}
