using HCRGUniversity.Core.BL.Model;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IShippingAddress
    {
        int addShippingAddress(ShippingAddress _shippingAddress);
        int updateShippingAddress(ShippingAddress _shippingAddress);
        void deleteShippingAddress(int id);
        ShippingAddress getShippingAddressByID(int id);
        BLModel.Paged.ShippingAddress getAllShippingAddressByUserID(int UserID, int skip, int take);
        ShippingAddress getShippingAddressByUserID(int userID);
    }
}
