using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //IEnumerable<User> GetAllPagedUser(int skip, int take, int OrganizationID);

        IEnumerable<User> GetAllPagedUser(int skip, int take, int clientID);

        int GetUserCount(int OrganizationID);
        //IEnumerable<User> GetAllPagedUserByFilter(Expression<Func<User, bool>> where, int skip, int take);

        //int GetUserCountByFilter(System.Linq.Expressions.Expression<Func<User, bool>> where);

        IEnumerable<User> GetUserDetailByClientID(string searchText, int skip, int take, int clientID);
        int GetUserDetailByClientIDCount(string searchText, int clientID);
        IEnumerable<BLModel.User> GetUsersByPlanID(int PlanID);

        UserMenuGroup GetUserMenuGroupByMenuIDs(string MenuIDs, int OrganizationID);
        UserMenuGroup GetUserMenuGroupByGroupName(string GroupName, int OrganizationID);
        int GetDefaulClientAdminByOrganizationID(int organizationID);

        IEnumerable<UserMenuGroupAndPermission> GetAllUserMenuGroupAndPremissionAccordingToOrganizationID(int organizationID);
        IEnumerable<ClientAndUserbySearchCriterias> GetClientAndUserbySearchCriterias(int OrganizationID, int ClientTypeID, string SelectionTypeName, int SelectionClientTypeID, string SearchText);
        void UpdateUserSessionIDByUserID(int userId, string userSessionID);
        void ResetUserSessionID(int UserID);
    }
}
