using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
   public class EducationEvaluationRepository: BaseRepository<EducationEvaluation, HCRGUniversityDBContext>, IEducationEvaluationRepository
    {
       public EducationEvaluationRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

       public void UpdateEducationEvaluation(EducationEvaluation educationEvaluation)
       {
           SqlParameter _educationID = new SqlParameter("@EducationID", educationEvaluation.EducationID);
           SqlParameter _evaluationID = new SqlParameter("@EvaluationID", educationEvaluation.EvaluationID);
           SqlParameter _courseEvaluationID = new SqlParameter("@CourseEvaluationID", educationEvaluation.CourseEvaluationID);
           Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationEvaluationRepositoryProcedure.UpdateEducationEvaluation, _educationID, _evaluationID, _courseEvaluationID);
       }
    }
}
