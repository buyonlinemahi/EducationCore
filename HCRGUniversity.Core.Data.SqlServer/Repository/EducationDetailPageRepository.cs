using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationDetailPageRepository : BaseRepository<EducationDetailPage, HCRGUniversityDBContext>, IEducationDetailPageRepository
    {
        public EducationDetailPageRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public EducationDetailPageWithEducation GetEducationDetailPageContent(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<EducationDetailPageWithEducation>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationDetailPageContentByEducationID, _educationID).Single(); ;
        }
    }
}