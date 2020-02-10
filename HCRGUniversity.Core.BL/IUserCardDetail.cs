using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IUserCardDetail
    {
        int addUserCardDetail(DLModel.UserCardDetail _userCardDetail);
        int updateUserCardDetail(DLModel.UserCardDetail _userCardDetail);
        DLModel.UserCardDetail getUserCardDetailByID(int id);
        BLModel.Paged.UserCardDetail getUserCardDetailByUserID(int userID, int skip, int take);
    }
}
