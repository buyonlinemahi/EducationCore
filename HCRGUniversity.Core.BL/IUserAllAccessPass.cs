using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IUserAllAccessPass
    {
        int addUserAllAccessPass(DLModel.UserAllAccessPass userSubscription);
        int updateUserAllAccessPass(DLModel.UserAllAccessPass userSubscription);
        DLModel.UserAllAccessPass getUserAllAccessPassByID(int ID);
        DLModel.UserAllAccessPass getUserAllAccessPassByUserID(int UserID);
        int checkUserAllAccessPassByUserID(int userAllAccessPassID);
    }
}
