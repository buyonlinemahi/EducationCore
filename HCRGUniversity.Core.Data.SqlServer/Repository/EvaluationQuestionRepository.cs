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
    public class EvaluationQuestionRepository : BaseRepository<EvaluationQuestion, HCRGUniversityDBContext>, IEvaluationQuestionRepository
    {
      public EvaluationQuestionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
      public IEnumerable<EvaluationQuestion> GetAllPagedEvaluationQuestionByPreTestID(System.Linq.Expressions.Expression<Func<EvaluationQuestion, bool>> where, int skip, int take)
        {
            if (where != null)
                return dbset.Where(where).OrderByDescending(o => o.EvaluationQuestionID).Skip(skip).Take(take);
            else
                return dbset.ToArray().OrderByDescending(o => o.EvaluationQuestionID).Skip(skip).Take(take);
        }

      public int GetEvaluationQuestionCountByEvaluationID(System.Linq.Expressions.Expression<Func<EvaluationQuestion, bool>> where)
        {
            return dbset.Where(where).Count();
        }

      public IEnumerable<EvaluationQuestionDetail> GetAllEvaluationQuestionDetailByEID(int educationID)
      {
          SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
          return Context.Database.SqlQuery<EvaluationQuestionDetail>(Constant.StoredProcedureConst.EvaluationQuestionRepositoryProcedure.GetAllEvaluationQuestionDetailByEID, _educationID);
      }

      public int AddEvaluationQuestionsFromEvaluationPredefinedQuestions(int EvaluationID)
      {
          SqlParameter _evaluationID = new SqlParameter("@EvaluationID", EvaluationID);
          return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EvaluationQuestionRepositoryProcedure.AddEvaluationQuestionsFromEvaluationPredefinedQuestions, _evaluationID).FirstOrDefault();
      }
    }
}
