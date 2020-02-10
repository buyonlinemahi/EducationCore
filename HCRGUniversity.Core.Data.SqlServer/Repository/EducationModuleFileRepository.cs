using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;
namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationModuleFileRepository : BaseRepository<EducationModuleFile, HCRGUniversityDBContext>, IEducationModuleFileRepository
    {
        public EducationModuleFileRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public void DeleteEducationModuleFile(int EducationModuleFileID, int FileTypeID)
        {
            SqlParameter _EducationModuleFileID = new SqlParameter("@EducationModuleFileID", EducationModuleFileID);
            SqlParameter _FileTypeID = new SqlParameter("@FileTypeID", FileTypeID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationModuleFileRepositoryProcedure.DeleteEducationModuleFilesByFileTypeIdAndEducationModuleID, _EducationModuleFileID, _FileTypeID);
        }
    }
}
