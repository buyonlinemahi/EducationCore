using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEvaluationRepository : IBaseRepository<Evaluation>
    {
        //IEnumerable<Evaluation> GetAllPagedExamByFilter(Expression<Func<Evaluation, bool>> where, int skip, int take);
        //int GetExamCountByFilter(System.Linq.Expressions.Expression<Func<Evaluation, bool>> where);
        IEnumerable<HCRGUniversity.Core.BL.Model.Evaluation> GetEvaluationDetailsByClientID(string searchtext, int clientID, int orgID, int skip, int take);
        int GetEvaluationDetailsByClientIDCount(string searchtext, int clientID,int orgID);
        IEnumerable<Evaluation> GetAllActiveEvaluationByClientID(int clientID);
    }
}
