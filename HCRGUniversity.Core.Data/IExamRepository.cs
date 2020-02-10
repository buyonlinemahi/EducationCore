using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IExamRepository : IBaseRepository<Exam>
    {
      //IEnumerable<Exam> GetAllPagedExamByFilter(Expression<Func<Exam, bool>> where, int skip, int take);
      //int GetExamCountByFilter(System.Linq.Expressions.Expression<Func<Exam, bool>> where);

        IEnumerable<BLModel.Exam> GetExamDetailsByClientID(string searchText, int clientID, int orgID,int skip, int take);
        int GetExamDetailsByClientIDCount(string searchText, int clientID,int orgID);
        IEnumerable<Exam> GetAllActiveExamByClientID(int clientID);
    }
}
