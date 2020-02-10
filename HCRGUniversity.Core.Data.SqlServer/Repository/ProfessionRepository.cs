using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class ProfessionRepository : BaseRepository<Profession, HCRGUniversityDBContext>, IProfessionRepository
    {
        public ProfessionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<Profession> GetProfessionsByCollegeID(int collegeID)
        {
            SqlParameter _collegeID = new SqlParameter("@CollegeID", collegeID);
            return Context.Database.SqlQuery<Profession>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetProfessionsByCollegeID, _collegeID);
        }

        public IEnumerable<Profession> GetProfessionNotAssociateWithEducation(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<Profession>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetProfessionNotAssociateWithEducation, _educationID);
        }

        public IEnumerable<Profession> GetAllProfessionByClientID(int clientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<Profession>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetAllProfessionByClientID, _clientID);
        }

        public IEnumerable<HCRGUniversity.Core.BL.Model.Profession> GetAllPagedProfessionByClientID(int skip, int take, int clientID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.Profession>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetAllPagedProfessionByClientID, _skip, _take, _clientID);
        }
        public int GetAllPagedProfessionByClientIDCount(int clientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetAllPagedProfessionByClientIDCount, _clientID).SingleOrDefault();
        }


        public IEnumerable<Profession> GetAllProfessionWeb(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<Profession>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetAllProfessionByOrganizationID, _organizationID);
        }

        public IEnumerable<HCRGUniversity.Core.BL.Model.Profession> GetAllPagedProfessionByOrganizationID(int skip, int take, int organizationID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.Profession>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetAllPagedProfessionByOrganizationID, _skip, _take, _organizationID).ToList();
        }

        public int GetAllPagedProfessionByOrganizationIDCount(int organizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ProfessionRepositoryProcedure.GetAllPagedProfessionByOrganizationIDCount, _organizationID).First();
        } 
    }
}