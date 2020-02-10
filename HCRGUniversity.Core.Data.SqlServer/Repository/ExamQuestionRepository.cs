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
    public class ExamQuestionRepository : BaseRepository<ExamQuestion, HCRGUniversityDBContext>, IExamQuestionRepository
    {
        public ExamQuestionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<ExamQuestion> GetAllPagedPreTestQuestionByExamID(System.Linq.Expressions.Expression<Func<ExamQuestion, bool>> where, int skip, int take)
        {
            if (where != null)
                return dbset.Where(where).OrderByDescending(o => o.ExamQuestionID).Skip(skip).Take(take);
            else
                return dbset.ToArray().OrderByDescending(o => o.ExamQuestionID).Skip(skip).Take(take);           
        }

        public int GetExamQuestionCountByExamID(System.Linq.Expressions.Expression<Func<ExamQuestion, bool>> where)
        {
            return dbset.Where(where).Count();
        }

        public IEnumerable<ExamQuestionDetail> GetAllExamQuestionDetailByEID(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<ExamQuestionDetail>(Constant.StoredProcedureConst.ExamQuestionRepositoryProcedure.GetAllExamQuestionDetailByEID, _educationID);
        }

        public IEnumerable<ExamQuestion> GetExamQuestionWrongAnswered(int MEID)
        {
            SqlParameter _meID = new SqlParameter("@MEID", MEID);
            return Context.Database.SqlQuery<ExamQuestion>(Constant.StoredProcedureConst.ExamQuestionRepositoryProcedure.GetExamQuestionWrongAnswered, _meID).ToList();
        }
    }
}
