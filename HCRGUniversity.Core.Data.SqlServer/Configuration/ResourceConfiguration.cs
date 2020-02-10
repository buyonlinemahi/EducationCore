using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ResourceConfiguration : EntityTypeConfiguration<Resource>
    {
        public ResourceConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.Resource, Constant.Consts.Schema.DBO);
            HasKey(resourse => resourse.ResourceID);
        }
    }
}


