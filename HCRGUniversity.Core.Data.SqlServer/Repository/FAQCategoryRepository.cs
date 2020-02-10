using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class FAQCategoryRepository : BaseRepository<FAQCategory, HCRGUniversityDBContext>, IFAQCategoryRepository
    {
        public FAQCategoryRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<BLModel.FAQCategory> GetAllFAQCategoriesAccordingToOrganizationID(int OrganizationID, int ClientID)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrgID", OrganizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.FAQCategory>(Constant.StoredProcedureConst.FAQCategoriesRepositoryProcedure.GetAllFAQCategoriesAccordingToOrganizationID, _OrganizationID, _ClientID).ToList();
        }
    }
}
