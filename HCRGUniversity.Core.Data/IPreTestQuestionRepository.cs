using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HCRGUniversity.Core.Data
{
    public interface IPreTestQuestionRepository : IBaseRepository<PreTestQuestion>
    {
        IEnumerable<PreTestQuestion> GetAllPagedPreTestQuestionByPreTestID(Expression<Func<PreTestQuestion, bool>> where, int skip, int take);
        int GetPreTestQuestionCountByPreTestID(System.Linq.Expressions.Expression<Func<PreTestQuestion, bool>> where);
        IEnumerable<PreTestQuestionDetail> GetAllPreTestQuestionDetailByEID(int educationID);
    }
}
