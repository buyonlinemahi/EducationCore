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
    public class ExamRepository : BaseRepository<Exam, HCRGUniversityDBContext>, IExamRepository
    {
        public ExamRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<BLModel.Exam> GetExamDetailsByClientID(string searchText, int clientID, int orgID,int skip, int take)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<BLModel.Exam>(Constant.StoredProcedureConst.ExamRepositoryProcedure.GetExamDetailsByClientID, _searchText, _clientID,_orgID,_skip, _take);
        }

        public int GetExamDetailsByClientIDCount(string searchText, int clientID,int orgID)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ExamRepositoryProcedure.GetExamDetailsByClientIDCount, _searchText, _clientID, _orgID).FirstOrDefault();
        }


        public IEnumerable<Exam> GetAllActiveExamByClientID(int clientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);

            return Context.Database.SqlQuery<Exam>(Constant.StoredProcedureConst.ExamRepositoryProcedure.GetAllActiveExamByClientID, _clientID);
        }
    }
}
