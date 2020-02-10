using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HCRGUniversity.Core.Data 
{
    public interface IExamQuestionRepository : IBaseRepository<ExamQuestion>
    {
        IEnumerable<ExamQuestion> GetAllPagedPreTestQuestionByExamID(Expression<Func<ExamQuestion, bool>> where, int skip, int take);
        int GetExamQuestionCountByExamID(System.Linq.Expressions.Expression<Func<ExamQuestion, bool>> where);
        IEnumerable<ExamQuestionDetail> GetAllExamQuestionDetailByEID(int educationID);
        IEnumerable<ExamQuestion> GetExamQuestionWrongAnswered(int MEID);
    }
}
