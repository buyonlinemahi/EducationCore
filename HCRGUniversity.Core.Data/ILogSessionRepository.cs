using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
namespace HCRGUniversity.Core.Data
{
    public interface ILogSessionRepository : IBaseRepository<LogSession>
    {
        IEnumerable<LogSessionDetail> GetLogSessionByUserName(string username, int skip, int take, int organizationId);
        int GetLogSessionByUserNameCount(string username, int organizationId);
    }
}
