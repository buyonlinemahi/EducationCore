using HCRGUniversity.Core.Data;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class UserAllAccessPassImpl : IUserAllAccessPass
    {
        private readonly IUserAllAccessPassRepository _userAllAccessPassRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;


        public UserAllAccessPassImpl(IUserAllAccessPassRepository userAllAccessPassRepository, IUserRepository userRepository, IUserSubscriptionRepository userSubscriptionRepository)
        {
            _userAllAccessPassRepository = userAllAccessPassRepository;
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
        }


        public int addUserAllAccessPass(DLModel.UserAllAccessPass userAllAccessPass)
        {

            var _res = _userRepository.GetById(userAllAccessPass.UserID);

            userAllAccessPass.UserSubscriptionID = _userSubscriptionRepository.GetAll(rk => rk.OrganizationID == _res.OrganizationID).SingleOrDefault().UserSubscriptionID;
            int UserAllAccessPassID = _userAllAccessPassRepository.Add(userAllAccessPass).UserAllAccessPassID;
            // update the UserAllAccessPassID in user table against UserID
            DLModel.User _user = new DLModel.User();
            _user = _userRepository.GetById(userAllAccessPass.UserID);
            _user.IsAllAccessPricing = true;
            _user.UserAllAccessPassID= UserAllAccessPassID;
            _userRepository.Update(_user);
            return UserAllAccessPassID;
        }

        public int updateUserAllAccessPass(DLModel.UserAllAccessPass userAllAccessPass)
        {
            return _userAllAccessPassRepository.Update(userAllAccessPass);
        }

        public DLModel.UserAllAccessPass getUserAllAccessPassByID(int id)
        {
            return _userAllAccessPassRepository.GetById(id);
        }

        public DLModel.UserAllAccessPass getUserAllAccessPassByUserID(int UserID)
        {
            var _res = _userRepository.GetById(UserID);
            if (_res != null)
                return _userAllAccessPassRepository.GetAll(rk => rk.UserAllAccessPassID == _res.UserAllAccessPassID.Value).SingleOrDefault();
            else
                return null;
        }

        public int checkUserAllAccessPassByUserID(int userAllAccessPassID)
        {
            return _userAllAccessPassRepository.GetAll(rk => rk.UserAllAccessPassID == userAllAccessPassID && rk.AllAccessEndDate > System.DateTime.Now).Count();
        }


    }
}
