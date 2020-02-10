using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace HCRGUniversity.Core.Data
{
    public interface IEvaluationQuestionRepository : IBaseRepository<EvaluationQuestion>
    {
        IEnumerable<EvaluationQuestion> GetAllPagedEvaluationQuestionByPreTestID(Expression<Func<EvaluationQuestion, bool>> where, int skip, int take);
        int GetEvaluationQuestionCountByEvaluationID(System.Linq.Expressions.Expression<Func<EvaluationQuestion, bool>> where);
        IEnumerable<EvaluationQuestionDetail> GetAllEvaluationQuestionDetailByEID(int educationID);
        int AddEvaluationQuestionsFromEvaluationPredefinedQuestions(int EvaluationID);
    }
}
