using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer
{
    public class LogSessionConfiguration : EntityTypeConfiguration<LogSession>
    {
        public LogSessionConfiguration()
            : base()
        {
            ToTable(Tables.dbo.LogSessions, Constant.Consts.Schema.DBO);
            HasKey(p => p.LogSessionID);
        }
    }
}

