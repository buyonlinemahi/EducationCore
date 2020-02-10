using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IBillingAddress
    {
        int addBillingAddress(BillingAddress _billingAddress);
        int updateBillingAddress(BillingAddress _billingAddress);
        void deleteBillingAddress(int id);
        BillingAddress getBillingAddressByID(int id);
        BLModel.Paged.BillingAddress getAllBillingAddressByUserID(int UserID, int skip, int take);
        BillingAddress getBillingAddressByUserID(int userID);
    }
}
