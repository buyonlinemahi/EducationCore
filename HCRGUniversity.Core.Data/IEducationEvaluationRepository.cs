using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationEvaluationRepository : IBaseRepository<EducationEvaluation>
    {
        void UpdateEducationEvaluation(EducationEvaluation educationEvaluation);
    }
}
