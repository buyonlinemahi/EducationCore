using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class MyEducationModuleConfiguration : EntityTypeConfiguration<MyEducationModule>
    {
        public MyEducationModuleConfiguration()
            : base()
        {
            ToTable("MyEducationModules", Constant.Consts.Schema.DBO);
            HasKey(table => table.MEMID);
        }
    }
}