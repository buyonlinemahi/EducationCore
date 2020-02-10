using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
   public class PreTestQuestionRepository:BaseRepository<PreTestQuestion, HCRGUniversityDBContext>, IPreTestQuestionRepository
    {
       public PreTestQuestionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

       public IEnumerable<PreTestQuestion> GetAllPagedPreTestQuestionByPreTestID(System.Linq.Expressions.Expression<Func<PreTestQuestion, bool>> where, int skip, int take)
        {
            if (where != null)
                return dbset.Where(where).OrderByDescending(o => o.PreTestQuestionID).Skip(skip).Take(take);
            else
                return dbset.ToArray().OrderByDescending(o => o.PreTestQuestionID).Skip(skip).Take(take);
        }

       public int GetPreTestQuestionCountByPreTestID(System.Linq.Expressions.Expression<Func<PreTestQuestion, bool>> where)
        {
            return dbset.Where(where).Count();
        }

       public IEnumerable<PreTestQuestionDetail> GetAllPreTestQuestionDetailByEID(int educationID)
       {
           SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
           return Context.Database.SqlQuery<PreTestQuestionDetail>(Constant.StoredProcedureConst.PreTestQuestionRepositoryProcedure.GetAllPreTestQuestionDetailByEID, _educationID);
       }

    }
}
