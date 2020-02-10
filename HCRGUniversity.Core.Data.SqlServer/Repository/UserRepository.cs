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
    public class UserRepository : BaseRepository<User, HCRGUniversityDBContext>, IUserRepository
    {
        public UserRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<User> GetAllPagedUser(int skip, int take, int clientID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<User>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetAllPagedUserByClientID, _skip, _take, _clientID).ToList();
        }
        public int GetUserCount(int OrganizationID)
        {
            return dbset.Where(rk=>rk.OrganizationID==OrganizationID).Count();
        }
        public IEnumerable<User> GetUserDetailByClientID(string searchText, int skip, int take, int clientID)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<User>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetUserDetailByClientID, _searchText, _skip, _take, _clientID).ToList();
        }

        public int GetUserDetailByClientIDCount(string searchText, int clientID)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetUserDetailByClientIDCount, _searchText, _clientID).SingleOrDefault();
        }
        public IEnumerable<BLModel.User> GetUsersByPlanID(int PlanID)
        {
            SqlParameter _PlanID = new SqlParameter("@PlanID", PlanID);
            return Context.Database.SqlQuery<BLModel.User>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetUsersByPlanID, _PlanID).ToList();
        }
        public UserMenuGroup GetUserMenuGroupByMenuIDs(string MenuIDs, int OrganizationID)
        {
            SqlParameter _MenuIDs = new SqlParameter("@MenuIDs", MenuIDs);
            SqlParameter _OrganizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<UserMenuGroup>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetUserMenuGroupByMenuIDs, _MenuIDs, _OrganizationID).SingleOrDefault();
        }
        public UserMenuGroup GetUserMenuGroupByGroupName(string GroupName, int OrganizationID)
        {
            SqlParameter _GroupName = new SqlParameter("@GroupName", GroupName);
            SqlParameter _OrganizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<UserMenuGroup>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetUserMenuGroupByGroupName, _GroupName, _OrganizationID).SingleOrDefault();
        }
        public int GetDefaulClientAdminByOrganizationID(int organizationID)
        {
            SqlParameter _orgID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetDefaulClientAdminByOrganizationID, _orgID).SingleOrDefault();
        }

        public IEnumerable<UserMenuGroupAndPermission> GetAllUserMenuGroupAndPremissionAccordingToOrganizationID(int organizationID)
        {
            SqlParameter _orgID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<UserMenuGroupAndPermission>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetAllUserMenuGroupAndPremissionAccordingToOrganizationID, _orgID).ToList();
        }

        public IEnumerable<ClientAndUserbySearchCriterias> GetClientAndUserbySearchCriterias(int OrganizationID, int ClientTypeID, string SelectionTypeName, int SelectionClientTypeID, string SearchText)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrganizationID", OrganizationID);
            SqlParameter _ClientTypeID = new SqlParameter("@ClientTypeID", ClientTypeID);
            SqlParameter _SelectionTypeName = new SqlParameter("@SelectionTypeName", SelectionTypeName);
            SqlParameter _SelectionClientTypeID = new SqlParameter("@SelectionClientTypeID", SelectionClientTypeID);
            SqlParameter _SearchText = new SqlParameter("@SearchText", SearchText);
            return Context.Database.SqlQuery<ClientAndUserbySearchCriterias>(Constant.StoredProcedureConst.UserRepositoryProcedure.GetClientAndUserbySearchCriterias, _OrganizationID, _ClientTypeID, _SelectionTypeName, _SelectionClientTypeID, _SearchText).ToList();
        }

        public void UpdateUserSessionIDByUserID(int userId, string userSessionID)
        {
            SqlParameter _userId = new SqlParameter("@UserID", userId);
            SqlParameter _userSessionID = new SqlParameter("@UserSessionID", userSessionID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.UserRepositoryProcedure.UpdateUserSessionIDByUserID, _userId, _userSessionID);
        }

        public void ResetUserSessionID(int UserID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", UserID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.UserRepositoryProcedure.ResetUserSessionID, _userID);
        }
    }
}