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
   public class HomeContentRepository: BaseRepository<HomeContent, HCRGUniversityDBContext>,IHomeContentRepository
    {
       public HomeContentRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

       public IEnumerable<BLModel.HomeContent> GetAllHomeContentByOrganizationID(int clientID,int orgID)
       {
           SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
           SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
           return Context.Database.SqlQuery<BLModel.HomeContent>(Constant.StoredProcedureConst.HomeContentRepositoryProcedure.GetAllHomeContentByOrganizationID, _clientID,_orgID).ToList();
       }
    }
}
