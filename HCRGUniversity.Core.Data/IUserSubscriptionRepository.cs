using System.Collections.Generic;
using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IUserSubscriptionRepository : IBaseRepository<UserSubscription>
    {
        IEnumerable<BLModel.UserSubscription> GetAllUserSubscriptionByOrganizationID(int OrganizationID, int ClientID);

    }
}
