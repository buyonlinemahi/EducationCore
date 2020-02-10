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
    public class FAQRepository : BaseRepository<FAQ, HCRGUniversityDBContext>, IFAQRepository
    {
        public FAQRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {

        }
        public IEnumerable<FAQDetail> GetFAQByFaqCatID(int faqCatID)
        {
            SqlParameter _faqCatID = new SqlParameter("@FAQCatID", faqCatID);
            return Context.Database.SqlQuery<FAQDetail>(Constant.StoredProcedureConst.FAQRepositoryProcedure.Get_FAQByFaqCatIDAll, _faqCatID);
        }

        public IEnumerable<FAQDetail> GetFAQAll(int organizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<FAQDetail>(Constant.StoredProcedureConst.FAQRepositoryProcedure.Get_FAQAll, organizationID);
        }

        public IEnumerable<BLModel.FAQ> GetAllFAQAccordingToOrganizationID(int OrganizationID, int ClientID)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrgID", OrganizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.FAQ>(Constant.StoredProcedureConst.FAQRepositoryProcedure.GetAllFAQAccordingToOrganizationID, _OrganizationID, _ClientID).ToList();
        }

        public int GetFAQCount(int OrganizationID)
        {
            return dbset.Count();
        }

    }
}
