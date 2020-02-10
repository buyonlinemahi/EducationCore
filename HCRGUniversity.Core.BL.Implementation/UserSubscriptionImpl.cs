using HCRGUniversity.Core.Data;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class UserSubscriptionImpl : IUserSubscription
    {
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;

        public UserSubscriptionImpl(IUserSubscriptionRepository userSubscriptionRepository)
        {
            _userSubscriptionRepository = userSubscriptionRepository;
        }

        public int AddUserSubscription(DLModel.UserSubscription userSubscription)
        {
            return _userSubscriptionRepository.Add(userSubscription).UserSubscriptionID;
        }

        public int UpdateUserSubscription(DLModel.UserSubscription userSubscription)
        {
            return _userSubscriptionRepository.Update(userSubscription);
        }

        public DLModel.UserSubscription GetUserSubscriptionDetails()
        {
            return _userSubscriptionRepository.GetAll().OrderByDescending(rk => rk.UserSubscriptionID).Take(1).SingleOrDefault();
        }
        public IEnumerable<BLModel.UserSubscription> GetAllUserSubscriptionByOrganizationID(int OrganizationID, int ClientID)
        {
            return _userSubscriptionRepository.GetAllUserSubscriptionByOrganizationID(OrganizationID, ClientID);
        }

        public DLModel.UserSubscription GetUserSubscriptionByID(int userSubscriptionID)
        {
            return _userSubscriptionRepository.GetById(userSubscriptionID);
        }

    }
}
