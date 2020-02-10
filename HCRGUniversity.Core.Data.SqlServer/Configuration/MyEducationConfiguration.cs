using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class MyEducationConfiguration : EntityTypeConfiguration<MyEducation>
    {
        public MyEducationConfiguration()
            : base()
        {
            ToTable("MyEducations", Constant.Consts.Schema.DBO);
            HasKey(table => table.MEID);
        }
    }
}