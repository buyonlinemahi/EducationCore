using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EvaluationRepository : BaseRepository<Evaluation, HCRGUniversityDBContext>, IEvaluationRepository
    {
       public EvaluationRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
       public IEnumerable<HCRGUniversity.Core.BL.Model.Evaluation> GetEvaluationDetailsByClientID(string Searchtext,int clientID, int orgID,int skip, int take)
       {
           SqlParameter _searchText = new SqlParameter("@SearchText", Searchtext);
           SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
           SqlParameter _orgID = new SqlParameter("@orgID", orgID);
           SqlParameter _skip = new SqlParameter("@Skip", skip);
           SqlParameter _take = new SqlParameter("@Take", take);
           return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.Evaluation>(Constant.StoredProcedureConst.EvaluationRepositoryProcedure.GetEvaluationDetailsByClientID, _searchText, _clientID,_orgID, _skip, _take).ToList();
       }

       public int GetEvaluationDetailsByClientIDCount(string Searchtext, int clientID,int orgID)
       {
           SqlParameter _searchText = new SqlParameter("@SearchText", Searchtext);
           SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
           SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
           return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EvaluationRepositoryProcedure.GetEvaluationDetailsByClientIDCount, _searchText, _clientID,_orgID).SingleOrDefault();
       }

       public IEnumerable<Evaluation> GetAllActiveEvaluationByClientID(int clientID)
       {
           SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
           return Context.Database.SqlQuery<Evaluation>(Constant.StoredProcedureConst.EvaluationRepositoryProcedure.GetAllActiveEvaluationByClientID, _clientID);
       }

    }
}
