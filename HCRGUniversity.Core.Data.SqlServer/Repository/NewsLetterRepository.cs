using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
  public  class NewsLetterRepository: BaseRepository<NewsLetter, HCRGUniversityDBContext>, INewsLetterRepository
    {
      public NewsLetterRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

      public IEnumerable<BLModel.NewsLetter> GetNewsLetterByClientID(int clientID, int orgID)
      {
          SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
          SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
          return Context.Database.SqlQuery<BLModel.NewsLetter>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetNewsLetterByClientID, _clientID, _orgID).ToList();
      }
    }
}
