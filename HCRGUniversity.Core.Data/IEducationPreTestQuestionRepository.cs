
using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.Data
{
    public interface IEducationPreTestQuestionRepository : IBaseRepository<EducationPreTestQuestion>
    {
        void UpdateEducationPreTestQuestion(EducationPreTestQuestion educationPreTestQuestion);
    }
}
