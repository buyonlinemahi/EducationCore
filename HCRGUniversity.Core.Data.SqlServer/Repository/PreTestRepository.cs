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
    public class PreTestRepository : BaseRepository<PreTest, HCRGUniversityDBContext>, IPreTestRepository
    {
        public PreTestRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        

        public IEnumerable<BLModel.PreTest> GetPreTestDetailsByClientID(string SearchText, int clientID,int orgID, int skip, int take)
        {

            SqlParameter _searchText = new SqlParameter("@SearchText", SearchText);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<BLModel.PreTest>(Constant.StoredProcedureConst.PreTestRepositoryProcedure.GetPreTestDetailsByClientID, _searchText, _clientID, _orgID, _skip, _take);
        }

        public int GetPreTestDetailsByClientIDCount(string SearchText, int clientID,int orgID)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", SearchText);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.PreTestRepositoryProcedure.GetPreTestDetailsByClientIDCount, _searchText,_clientID,_orgID).SingleOrDefault();
        }

        public IEnumerable<PreTest> GetAllActivePreTestByClientID(int clientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<PreTest>(Constant.StoredProcedureConst.PreTestRepositoryProcedure.GetAllActivePreTestByClientID, _clientID);
        }
    }
}
