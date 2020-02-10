using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class OrganizationContactConfiguration : EntityTypeConfiguration<OrganizationContact>
    {

        public OrganizationContactConfiguration()
            : base()
        {
            ToTable("OrganizationContacts", Constant.Consts.Schema.DBO);
            HasKey(OrganizationContact => OrganizationContact.OrganizationContactID);
        }
    }
}
