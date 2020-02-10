using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ClientTypeConfiguration : EntityTypeConfiguration<ClientType>
    {
        public ClientTypeConfiguration()
            : base()
        {
            ToTable("ClientTypes", Constant.Consts.Schema.LOOKUP);
            HasKey(clienttype => clienttype.ClientTypeID);
        }
    }
}
