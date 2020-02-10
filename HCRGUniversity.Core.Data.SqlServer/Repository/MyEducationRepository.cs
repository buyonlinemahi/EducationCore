using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class MyEducationRepository : BaseRepository<MyEducation, HCRGUniversityDBContext>, IMyEducationRepository
    {
        public MyEducationRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<MyEducationDetail> GetMyEducationCompletedByUserIDPaged(int userID, int skip, int take)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            return Context.Database.SqlQuery<MyEducationDetail>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationCompletedByUserIDPaged, _userID, _skip, _take);
        }

        public int GetMyEducationCompletedByUserIDPagedCount(int userID)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationCompletedByUserIDPagedCount, _userID).SingleOrDefault();
        }

        public IEnumerable<MyEducationDetail> GetMyEducationInProgressByUserIDPaged(int userID, int skip, int take)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            return Context.Database.SqlQuery<MyEducationDetail>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationInProgressByUserIDPaged, _userID, _skip, _take);
        }

        public int GetMyEducationInProgressByUserIDPagedCount(int userID)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationInProgressByUserIDPagedCount, _userID).SingleOrDefault();
        }
        public IEnumerable<MyEducationAccountHistory> GetMyEducationDetailByUserIDPaged(int userID, int skip, int take)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            return Context.Database.SqlQuery<MyEducationAccountHistory>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationDetailByUserIDPaged, _userID, _skip, _take);
        }

        public void UpdateMyEducationExpiredByUserID(int userID)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.UpdateMyEducationExpiredByUserID, _userID);
        }
        public int GetMyEducationCountByFilter(System.Linq.Expressions.Expression<Func<MyEducation, bool>> where)
        {
            return dbset.Where(where).Count();
        }

        public int GetMyEducationCountByFilterCount(int userID)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationDetailByUserIDPagedCOUNT, _userID).First();
        }

        public CertificateDetail GetCertificateDetailByMEID(int meID)
        {
            SqlParameter _meID = new SqlParameter("@MEID", meID);
            return Context.Database.SqlQuery<CertificateDetail>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetCertificateDetailByMEID, _meID).SingleOrDefault();
        }

        public int GetMyEducationByID(int MEID)
        {
            SqlParameter _meID = new SqlParameter("@MEID", MEID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationByID, _meID).First();
        }
    }
}