using HCRGUniversity.Core.BL.Model;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IShippingPayment
    {
        int addShippingPayment(ShippingPayment _shippingAddress);
        int updateShippingPayment(ShippingPayment _shippingAddress);
        void deleteShippingPayment(int id);
        ShippingPayment getShippingPaymentByID(int id);
        BLModel.Paged.ShippingPayment getAllShippingPaymentByUserID(int UserID, int skip, int take);
        ShippingPayment getPendingShippingPaymentByUserID(int UserID);
        void UpdateEducationShoppingCartTempByShippingPaymentID(int _educationShoppingTempID, int _shippingPaymentID,string PType);
        void addEducationShoppingRecordByShippingPaymentID(int _shippingPaymentID);
        ShippingPayment GetShippingPaymentByUserID(int uid);
    }
}
