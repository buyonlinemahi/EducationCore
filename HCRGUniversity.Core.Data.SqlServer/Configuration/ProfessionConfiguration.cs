using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ProfessionConfiguration : EntityTypeConfiguration<Profession>
    {
        public ProfessionConfiguration()
            : base()
        {
            ToTable("Professions", Constant.Consts.Schema.DBO);
            HasKey(table => table.ProfessionID);
        }
    }
}