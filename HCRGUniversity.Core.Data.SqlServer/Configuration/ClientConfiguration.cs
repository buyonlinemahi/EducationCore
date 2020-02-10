using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
   public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
       public ClientConfiguration()
            : base()
        {
            ToTable("Clients", Constant.Consts.Schema.DBO);
            HasKey(client => client.ClientID);
        }
    }
}
