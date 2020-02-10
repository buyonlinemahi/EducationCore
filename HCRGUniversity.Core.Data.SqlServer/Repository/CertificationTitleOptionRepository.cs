using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class CertificationTitleOptionRepository : BaseRepository<CertificationTitleOption,HCRGUniversityDBContext>,ICertificationTitleOptionRepository
    {
        public CertificationTitleOptionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<CourseNameDropDownList> GetCourseNameDropDownList(int organizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<CourseNameDropDownList>(Constant.StoredProcedureConst.CertificationTitleOptionProcedure.GETCourseNameDropDownList, _organizationID).ToList();
        }      
    }
}
