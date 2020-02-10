using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationPreTestQuestionRepository : BaseRepository<EducationPreTestQuestion, HCRGUniversityDBContext>, IEducationPreTestQuestionRepository
    {
        public EducationPreTestQuestionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public void UpdateEducationPreTestQuestion(EducationPreTestQuestion educationPreTestQuestion)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationPreTestQuestion.EducationID);           
            SqlParameter _preTestID = new SqlParameter("@PreTestID", educationPreTestQuestion.PreTestID);
            SqlParameter _coursePreTestID = new SqlParameter("@CoursePreTestID", educationPreTestQuestion.CoursePreTestID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationPreTestQuestionRepository.UpdateEducationPreTestQuestion, _educationID, _preTestID, _coursePreTestID);
        }
    }
}
