using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class UserImpl : IUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientTypeRepository _clientUserRepository;
        private readonly IUserResetPasswordRepository _userResetPasswordRepository;

        private readonly IUserMenuGroupRepository _userMenuGroupRepository;

        private readonly IUserMenuPermissionRepository _userMenuPermissionRepository;


        public UserImpl(IUserRepository userRepository, IUserResetPasswordRepository userResetPasswordRepository, IClientTypeRepository clientUserRepository, IUserMenuGroupRepository userMenuGroupRepository, IUserMenuPermissionRepository userMenuPermissionRepository)
        {
            _userRepository = userRepository;
            _userResetPasswordRepository = userResetPasswordRepository;
            _clientUserRepository = clientUserRepository;
            _userMenuGroupRepository = userMenuGroupRepository;
            _userMenuPermissionRepository = userMenuPermissionRepository;
        }

        public BLModel.User GetUserByID(int userID)
        {
            return (BLModel.User)new BLModel.User().InjectFrom(_userRepository.GetById(userID));
        }

        public int AddUser(BLModel.User user)
        {
            return _userRepository.Add((DLModel.User)new DLModel.User().InjectFrom(user)).UID;
        }
        
        public void UpdateUserPassword(int uid, string pwd)
        {
            DLModel.User s = new DLModel.User
            {
                UID = uid,
                FirstName = "",
                LastName = "",
                Password = pwd,
                EmailID = "",
                Company = "",
                Phone = "",
                ProfessionalTitle = "",
                IsActive = true,
                IsLocked = false,
                FailedAttemptCount = 0,
                LastLoginDate = System.DateTime.Now.Date.AddDays(1)
            };

            _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(s), hp => hp.Password, hp => hp.IsLocked, hp => hp.FailedAttemptCount);
        }

        public int UpdateUser(BLModel.User user)
        {
            return _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(user));
        }

        public BLModel.User GetUserByUserName(string userName)
        {
            var User = _userRepository.GetAll(user => user.EmailID == userName).FirstOrDefault();
            return User != null ? (BLModel.User)new BLModel.User().InjectFrom(User) : null;
        }

        public BLModel.User GetUserByEmailAndOrganizationId(string _userEmailID, int OrganizationID)
        {
            var User = _userRepository.GetAll(user => user.EmailID == _userEmailID && user.OrganizationID == OrganizationID).FirstOrDefault();
            return User != null ? (BLModel.User)new BLModel.User().InjectFrom(User) : null;
        }

        public IEnumerable<BLModel.User> GetUsersAll(int OrganizationID)
        {
            return _userRepository.GetAll(rk => rk.OrganizationID == OrganizationID).Select(user => new BLModel.User().InjectFrom(user)).Cast<BLModel.User>().ToList();
        }

        public BLModel.Paged.User GetUsersByName(string name, int skip, int take, int _clientID)
        {
            return new BLModel.Paged.User
            {
                TotalCount = _userRepository.GetUserDetailByClientIDCount(name,_clientID),
                Users = _userRepository.GetUserDetailByClientID(name, skip, take, _clientID).Select(user => (BLModel.User)new BLModel.User().InjectFrom(user)).ToList()
            };
        }

        public int ResetUserFailedAttemptCountAndLastLoginDate(BLModel.User user, int failedAttemptCount, DateTime? loginDate)
        {
            user.FailedAttemptCount = failedAttemptCount;
            user.LastLoginDate = loginDate;
            user.IsLocked = false;
            return _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(user),
                   u => u.FailedAttemptCount, u => u.LastLoginDate, u => u.IsLocked);
        }

        public int ResetUserFailedAttemptCount(BLModel.User user)
        {
            return ResetUserFailedAttemptCountAndLastLoginDate(user, 0, System.DateTime.Now);
        }

        public int UpdateUserFailedAttemptCount(BLModel.User user)
        {
            int numberOfFailedLoginAttempts = user.FailedAttemptCount;
            numberOfFailedLoginAttempts++;

            if (numberOfFailedLoginAttempts >= Global.GlobalConst.AppSetting.FAILEDATTEMPTCOUNT)
            {
                user.FailedAttemptCount = numberOfFailedLoginAttempts;
                return UpdateUserLock(user, true);
            }
            else { return UpdateUserFailedAttemptCount(user, numberOfFailedLoginAttempts); }
        }

        public int UpdateUserFailedAttemptCount(BLModel.User user, int numberOfFailedLoginAttempts)
        {
            user.FailedAttemptCount = numberOfFailedLoginAttempts;

            return _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(user),
                  u => u.FailedAttemptCount);
        }

        public int UpdateUserLock(BLModel.User user, bool locked)
        {
            user.IsLocked = locked;
            return _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(user),
        u => u.IsLocked, u => u.FailedAttemptCount);
        }

        //*******************Lazy binding
        public BLModel.Paged.User GetAllPagedUser(int skip, int take, int clientID)
        {
            return new BLModel.Paged.User
            {
                TotalCount = _userRepository.GetUserCount(clientID),
                Users = _userRepository.GetAllPagedUser(skip, take, clientID).Select(user => (BLModel.User)new BLModel.User().InjectFrom(user)).ToList()
            };
        }

        //user reset temp password...hp
        public int AddUserResetTempPassword(int uid, string tempPwd)
        {
            var UserTempPwd = _userResetPasswordRepository.GetAll(hp => hp.UID == uid);
            if (UserTempPwd.Count() > 0)
                return _userResetPasswordRepository.Update(new DLModel.UserResetPassword { UTempPwdID = UserTempPwd.FirstOrDefault().UTempPwdID, UID = uid, TempPwd = tempPwd });
            else
                return _userResetPasswordRepository.Add(new DLModel.UserResetPassword { UID = uid, TempPwd = tempPwd }).UTempPwdID;
        }
        public void DeleteUserResetTempPassword(int uid, string tempPwd)
        {
            _userResetPasswordRepository.Delete(hp => (hp.TempPwd == tempPwd) && (hp.UID == uid));
        }

        public bool matchUserResetTempPassword(int uid, string tempPwd)
        {
            return (_userResetPasswordRepository.GetAll(hp => (hp.TempPwd == tempPwd) && (hp.UID == uid)).Count() > 0);
        }

        public int UpdateUserVerification(int UserID, bool? _isVerified)
        {
            DLModel.User _user = new DLModel.User
            {
                FirstName = "",
                LastName = "",
                Password = "",
                EmailID = "",
                Company = "",
                Phone = "",
                ProfessionalTitle = "",
                IsActive = true,
                IsLocked = false,
                FailedAttemptCount = 0,
                LastLoginDate = System.DateTime.Now.Date.AddDays(1),
                UID = UserID,
                IsVerified = _isVerified,
                VerifiedOn = System.DateTime.Now
            };
            return _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(_user), hp => hp.IsVerified, hp => hp.VerifiedOn);
        }
        
        public int ClearedUserDetail(int UserID, bool? _isCleared)
        {
            DLModel.User _user = new DLModel.User
            {
                FirstName = "",
                LastName = "",
                Password = "",
                EmailID = "",
                Company = "",
                Phone = "",
                ProfessionalTitle = "",
                IsActive = true,
                IsLocked = false,
                FailedAttemptCount = 0,
                LastLoginDate = System.DateTime.Now.Date.AddDays(1),
                UID = UserID,
                IsCleared = _isCleared,
                ClearedBy = UserID,
            };
            return _userRepository.Update((DLModel.User)new DLModel.User().InjectFrom(_user), hp => hp.IsCleared);
        }

        public BLModel.Paged.User GetUserVerifiedDetails(int _skip, int _take, int OrganizationID)
        {
            return new BLModel.Paged.User
            {
                TotalCount = _userRepository.GetAll(rk => rk.IsVerified.Value == true && rk.OrganizationID == OrganizationID && rk.IsCleared.Value == null).Select(user => (BLModel.User)new BLModel.User().InjectFrom(user)).Count(),
                Users = _userRepository.GetAll(rk => rk.IsVerified.Value == true && rk.OrganizationID == OrganizationID && rk.IsCleared.Value == null).OrderByDescending(user => user.UID).Skip(_skip).Take(_take).Select(user => (BLModel.User)new BLModel.User().InjectFrom(user)).ToList()
            };
        }

        #region User Menu Group

        public BLModel.Paged.UserMenuGroup GetUserMenuGroup(int OrganizationID)
        {
            return new BLModel.Paged.UserMenuGroup
            {
                TotalCount = _userMenuGroupRepository.GetAll(rk=>rk.OrganizationID ==OrganizationID).ToList().Count(),
                UserMenuGroupDetails = _userMenuGroupRepository.GetAll(rk => rk.OrganizationID == OrganizationID).ToList().Select(user => (DLModel.UserMenuGroup)new DLModel.UserMenuGroup().InjectFrom(user)).ToList()
            };
        }

        public IEnumerable<DLModel.UserMenuGroup> GetAllUserMenuGroupByOrganizationID(int OrganizationID)
        {
            return _userMenuGroupRepository.GetAll(rk => rk.OrganizationID == OrganizationID).ToList().Select(user => (DLModel.UserMenuGroup)new DLModel.UserMenuGroup().InjectFrom(user)).ToList();
        }

        public int AddUserMenuGroup(DLModel.UserMenuGroup _userMenuGroup)
        {
            return _userMenuGroupRepository.Add((DLModel.UserMenuGroup)new DLModel.UserMenuGroup().InjectFrom(_userMenuGroup)).UserMenuGroupID;
        }

        public int UpdateUserMenuGroup(DLModel.UserMenuGroup _userMenuGroup)
        {
            return _userMenuGroupRepository.Update((DLModel.UserMenuGroup)new DLModel.UserMenuGroup().InjectFrom(_userMenuGroup));
        }

        public DLModel.UserMenuGroup GetUserMenuGroupByID(int _userMenuGroupID)
        {
            return _userMenuGroupRepository.GetById(_userMenuGroupID);
        }

        #endregion

        #region User Menu Permission
        
        public int AddUserMenuPermission(DLModel.UserMenuPermission _userMenuPermission)
        {
            return _userMenuPermissionRepository.Add((DLModel.UserMenuPermission)new DLModel.UserMenuPermission().InjectFrom(_userMenuPermission)).UserMenuGroupID;
        }

        public int UpdateUserMenuPermission(DLModel.UserMenuPermission _userMenuPermission)
        {
            return _userMenuPermissionRepository.Update((DLModel.UserMenuPermission)new DLModel.UserMenuPermission().InjectFrom(_userMenuPermission));
        }

        public DLModel.UserMenuPermission GetUserMenuPermissionByID(int _userMenuPermissionID)
        {
            return _userMenuPermissionRepository.GetById(_userMenuPermissionID);
        }

        public DLModel.UserMenuPermission GetUserMenuPermissionByUserMenuGroupID(int _userMenuGroupID)
        {
            return _userMenuPermissionRepository.GetAll(rk => rk.UserMenuGroupID == _userMenuGroupID).FirstOrDefault();
        }
        
        #endregion
        public IEnumerable<BLModel.User> GetUsersByPlanID(int planID)
        {
            return _userRepository.GetUsersByPlanID(planID);
        }

        public UserMenuGroup GetUserMenuGroupByMenuIDs(string MenuIDs, int OrganizationID)
        {
            return _userRepository.GetUserMenuGroupByMenuIDs(MenuIDs, OrganizationID);
        }

        public UserMenuGroup GetUserMenuGroupByGroupName(string GroupName, int OrganizationID)
        {
            return _userRepository.GetUserMenuGroupByGroupName(GroupName, OrganizationID);
        }

        public int GetDefaulClientAdminByOrganizationID(int _orgID)
        {
            return _userRepository.GetDefaulClientAdminByOrganizationID(_orgID);
        }

        public IEnumerable<DLModel.UserMenuGroupAndPermission> GetAllUserMenuGroupAndPremissionAccordingToOrganizationID(int OrganizationID)
        {
            return _userRepository.GetAllUserMenuGroupAndPremissionAccordingToOrganizationID(OrganizationID);
        }
        public IEnumerable<DLModel.ClientAndUserbySearchCriterias> GetClientAndUserbySearchCriterias(int OrganizationID, int ClientTypeID, string SelectionTypeName, int SelectionClientTypeID, string SearchText)
        {
            return _userRepository.GetClientAndUserbySearchCriterias(OrganizationID, ClientTypeID, SelectionTypeName, SelectionClientTypeID, SearchText);
        }

        public void UpdateUserSessionIDByUserID(int userId, string userSessionID)
        {
            _userRepository.UpdateUserSessionIDByUserID(userId, userSessionID);
        }

        public void ResetUserSessionID(int UserID)
        {
            _userRepository.ResetUserSessionID(UserID);
        }
    }
}