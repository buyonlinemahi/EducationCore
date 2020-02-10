using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class BillingAddressImpl : IBillingAddress
    {
        private readonly IBillingAddressRepository _billingAddressRepository;
        public BillingAddressImpl(IBillingAddressRepository billingAddressRepository)
        {
            _billingAddressRepository = billingAddressRepository;
        }

        public int addBillingAddress(DLModel.BillingAddress billingAddress)
        {
            return _billingAddressRepository.Add((DLModel.BillingAddress)new DLModel.BillingAddress().InjectFrom(billingAddress)).BillingAddressID;
        }

        public int updateBillingAddress(DLModel.BillingAddress billingAddress)
        {
            return _billingAddressRepository.Update((DLModel.BillingAddress)new DLModel.BillingAddress().InjectFrom(billingAddress));
        }
        public void deleteBillingAddress(int id)
        {
            _billingAddressRepository.Delete(getBillingAddressByID(id));
        }

        public DLModel.BillingAddress getBillingAddressByID(int id)
        {
            return (DLModel.BillingAddress)new DLModel.BillingAddress().InjectFrom(_billingAddressRepository.GetById(id));
        }

        public BLModel.Paged.BillingAddress getAllBillingAddressByUserID(int UserID, int skip, int take)
        {
            return new BLModel.Paged.BillingAddress
            {
                TotalCount = _billingAddressRepository.GetAll(rk => rk.BAUserID == UserID).Count(),
                BillingAddresses = _billingAddressRepository.GetAll(rk => rk.BAUserID == UserID).Skip(skip).Take(take).Select(rk => (DLModel.BillingAddress)new DLModel.BillingAddress().InjectFrom(rk)).ToList()
            };
        }
        public DLModel.BillingAddress getBillingAddressByUserID(int userID)
        {
            return _billingAddressRepository.GetAll(rk => rk.BAUserID == userID).OrderByDescending(rk => rk.BillingAddressID).Take(1).SingleOrDefault();
        }
    }
}
