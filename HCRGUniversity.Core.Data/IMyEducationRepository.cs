using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IMyEducationRepository : IBaseRepository<MyEducation>
    {
        IEnumerable<MyEducationDetail> GetMyEducationCompletedByUserIDPaged(int userID,int skip,int take);
        IEnumerable<MyEducationDetail> GetMyEducationInProgressByUserIDPaged(int userID, int skip, int take);
        IEnumerable<MyEducationAccountHistory> GetMyEducationDetailByUserIDPaged(int userID, int skip, int take);
        void UpdateMyEducationExpiredByUserID(int userID);
        int GetMyEducationCountByFilter(System.Linq.Expressions.Expression<Func<MyEducation, bool>> where);
        CertificateDetail GetCertificateDetailByMEID(int meID);
        int GetMyEducationCountByFilterCount(int userID);
        int GetMyEducationByID(int MEID);
        int GetMyEducationInProgressByUserIDPagedCount(int userID);

        int GetMyEducationCompletedByUserIDPagedCount(int userID);
    }
}