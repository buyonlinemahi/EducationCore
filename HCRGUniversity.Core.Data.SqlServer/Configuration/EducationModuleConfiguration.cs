using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
   public  class EducationModuleConfiguration  : EntityTypeConfiguration<EducationModule>
    {
       public EducationModuleConfiguration()
            : base()
        {
            ToTable("EducationModules", Constant.Consts.Schema.DBO);
            HasKey(table => table.EducationModuleID);
        }
    }
}
