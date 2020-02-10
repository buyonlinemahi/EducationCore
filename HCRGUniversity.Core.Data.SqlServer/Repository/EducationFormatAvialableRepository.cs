using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationFormatAvialableRepository : BaseRepository<EducationFormatAvailable, HCRGUniversityDBContext>, IEducationFormatAvailableRepository
    {
        public EducationFormatAvialableRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<EducationFormatDetail> GetEducationFormatsByEducationID(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<EducationFormatDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationFormatByEducationID, _educationID);
        }
    }
}