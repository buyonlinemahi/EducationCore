using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;


namespace HCRGUniversity.Core.BL
{
    public interface IUserSubscription
    {
        int AddUserSubscription(DLModel.UserSubscription userSubscription);
        int UpdateUserSubscription(DLModel.UserSubscription userSubscription);
        DLModel.UserSubscription GetUserSubscriptionDetails();
        IEnumerable<BLModel.UserSubscription> GetAllUserSubscriptionByOrganizationID(int OrganizationID, int ClientID);
        DLModel.UserSubscription GetUserSubscriptionByID(int userSubscriptionID);
    }
}
