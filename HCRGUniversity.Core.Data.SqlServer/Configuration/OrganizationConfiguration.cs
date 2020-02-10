using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration(): base()
        {
            ToTable("Organizations", Constant.Consts.Schema.DBO);
            HasKey(organization => organization.OrganizationID);
        }
    }
}
