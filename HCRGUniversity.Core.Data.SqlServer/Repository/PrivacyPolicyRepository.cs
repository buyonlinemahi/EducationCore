﻿using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class PrivacyPolicyRepository : BaseRepository<PrivacyPolicy, HCRGUniversityDBContext>, IPrivacyPolicyRepository
    {
        public PrivacyPolicyRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<BLModel.PrivacyPolicy> GetAllPrivacyPolicyAccordingToOrganizationID(int OrganizationID, int ClientID)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrgID", OrganizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.PrivacyPolicy>(Constant.StoredProcedureConst.PrivacyPolicyRepositoryProcedure.GetAllPrivacyPolicyAccordingToOrganizationID, _OrganizationID, _ClientID).ToList();
        }
    }
}
