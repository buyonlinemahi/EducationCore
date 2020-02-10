using HCRGUniversity.Core.BL.Model;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IUser
    {
        User GetUserByID(int userID);

        int AddUser(User user);

        int UpdateUser(User user);

        void UpdateUserPassword(int uid,string pwd);

        User GetUserByUserName(string userName);
        BLModel.User GetUserByEmailAndOrganizationId(string _userEmailID, int OrganizationID);

        IEnumerable<User> GetUsersAll(int OrganizationID);

        BLModel.Paged.User GetUsersByName(string name, int skip, int take, int OrganizationID);


        int ResetUserFailedAttemptCountAndLastLoginDate(BLModel.User user, int failedAttemptCount, DateTime? loginDate);

        int ResetUserFailedAttemptCount(BLModel.User user);

        int UpdateUserLock(BLModel.User user, bool locked);

        int UpdateUserFailedAttemptCount(BLModel.User user, int numberOfFailedLoginAttempts);

        int UpdateUserFailedAttemptCount(BLModel.User user);

        BLModel.Paged.User GetAllPagedUser(int skip, int take, int OrganizationID);

        //user reset temp password...hp
        int AddUserResetTempPassword(int uid, string tempPwd);
        void DeleteUserResetTempPassword(int uid, string tempPwd);
        bool matchUserResetTempPassword(int uid, string tempPwd);

        int UpdateUserVerification(int UserID, bool? _isVerified);
        int ClearedUserDetail(int UserID, bool? _isCleared);
        BLModel.Paged.User GetUserVerifiedDetails(int _skip, int _take, int OrganizationID);

        #region User Menu Group

        BLModel.Paged.UserMenuGroup GetUserMenuGroup(int OrganizationID);
        IEnumerable<DLModel.UserMenuGroup> GetAllUserMenuGroupByOrganizationID(int OrganizationID);
        int AddUserMenuGroup(DLModel.UserMenuGroup _userMenuGroup);
        int UpdateUserMenuGroup(DLModel.UserMenuGroup _userMenuGroup);
        DLModel.UserMenuGroup GetUserMenuGroupByID(int _userMenuGroupID);
        DLModel.UserMenuGroup GetUserMenuGroupByMenuIDs(string MenuIDs, int OrganizationID);
        DLModel.UserMenuGroup GetUserMenuGroupByGroupName(string GroupName, int OrganizationID);
        #endregion

        #region User Menu Permission
        int AddUserMenuPermission(DLModel.UserMenuPermission _userMenuPermission);
        int UpdateUserMenuPermission(DLModel.UserMenuPermission _userMenuPermission);
        DLModel.UserMenuPermission GetUserMenuPermissionByID(int _userMenuPermissionID);
        DLModel.UserMenuPermission GetUserMenuPermissionByUserMenuGroupID(int _userMenuGroupID);        
        #endregion
        IEnumerable<BLModel.User> GetUsersByPlanID(int planID);

        int GetDefaulClientAdminByOrganizationID(int _orgID);
        IEnumerable<DLModel.UserMenuGroupAndPermission> GetAllUserMenuGroupAndPremissionAccordingToOrganizationID(int OrganizationID);
        IEnumerable<DLModel.ClientAndUserbySearchCriterias> GetClientAndUserbySearchCriterias(int OrganizationID, int ClientTypeID, string SelectionTypeName, int SelectionClientTypeID, string SearchText);

        void UpdateUserSessionIDByUserID(int userId, string userSessionID);
        void ResetUserSessionID(int UserID);
    }
}