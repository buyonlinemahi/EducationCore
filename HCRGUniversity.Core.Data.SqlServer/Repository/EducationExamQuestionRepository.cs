using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationExamQuestionRepository : BaseRepository<EducationExamQuestion, HCRGUniversityDBContext>, IEducationExamQuestionRepository
    {
        public EducationExamQuestionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public void UpdateEducationExamQuestion(EducationExamQuestion educationExamQuestion)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationExamQuestion.EducationID);
            SqlParameter _examID = new SqlParameter("@ExamID", educationExamQuestion.ExamID);
            SqlParameter _courseExamID = new SqlParameter("@CourseExamID", educationExamQuestion.CourseExamID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationExamQuestionRepository.UpdateEducationExamQuestion, _educationID, _examID, _courseExamID);
        }
    }
}
