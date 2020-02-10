using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationFormatRepository : BaseRepository<EducationFormat, HCRGUniversityDBContext>, IEducationFormatRepository
    {
        public EducationFormatRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<EducationFormat> GetEducationFormatNotAssociateWithEducation(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<EducationFormat>(Constant.StoredProcedureConst.EducationFormatRepositoryProcedure.GetEducationFormatNotAssociateWithEducation, _educationID);
        }

        public IEnumerable<EducationFormat> GetAllPagedEducationFormat(int skip, int take)
        {
            SqlParameter _Skip = new SqlParameter("@Skip", skip);
            SqlParameter _Take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<EducationFormat>(Constant.StoredProcedureConst.EducationFormatRepositoryProcedure.GetAllPagedEducationFormat, _Skip, _Take);
        }

        public int GetEducationFormatCount()
        {
            return dbset.Count();
        }

        public IEnumerable<HCRGUniversity.Core.BL.Model.EducationFormat> GetEducationFormatByClientID(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.EducationFormat>(Constant.StoredProcedureConst.EducationFormatRepositoryProcedure.GetEducationFormatByClientID, _clientID);
        }
        public IEnumerable<HCRGUniversity.Core.BL.Model.EducationFormat> GetAllEducationFormatByOrganizationID(int _organizationID)
        {
            SqlParameter organizationID = new SqlParameter("@OrganizationID", _organizationID);
            return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.EducationFormat>(Constant.StoredProcedureConst.EducationFormatRepositoryProcedure.GetAllEducationFormatByOrganizationID, organizationID);
        }
        public IEnumerable<HCRGUniversity.Core.BL.Model.EducationFormat> GetAllEducationFormatByClientID(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.EducationFormat>(Constant.StoredProcedureConst.EducationFormatRepositoryProcedure.GetAllEducationFormatByClientID, _clientID);
        }
        
    }
}