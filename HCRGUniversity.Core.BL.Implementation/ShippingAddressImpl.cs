using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ShippingAddressImpl : IShippingAddress
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        public ShippingAddressImpl(IShippingAddressRepository shippingAddressRepository)
        {
            _shippingAddressRepository = shippingAddressRepository;
        }

        public int addShippingAddress(DLModel.ShippingAddress billingAddress)
        {
            return _shippingAddressRepository.Add((DLModel.ShippingAddress)new DLModel.ShippingAddress().InjectFrom(billingAddress)).ShippingAddressID;
        }

        public int updateShippingAddress(DLModel.ShippingAddress billingAddress)
        {
            return _shippingAddressRepository.Update((DLModel.ShippingAddress)new DLModel.ShippingAddress().InjectFrom(billingAddress));
        }
        public void deleteShippingAddress(int id)
        {
            _shippingAddressRepository.Delete(getShippingAddressByID(id));
        }

        public DLModel.ShippingAddress getShippingAddressByID(int id)
        {
            return (DLModel.ShippingAddress)new DLModel.ShippingAddress().InjectFrom(_shippingAddressRepository.GetById(id));
        }

        public BLModel.Paged.ShippingAddress getAllShippingAddressByUserID(int UserID, int skip, int take)
        {
            return new BLModel.Paged.ShippingAddress
            {
                TotalCount = _shippingAddressRepository.GetAll(rk => rk.SAUserID == UserID).Count(),
                ShippingAddresses = _shippingAddressRepository.GetAll(rk => rk.SAUserID == UserID).Skip(skip).Take(take).Select(rk => (DLModel.ShippingAddress)new DLModel.ShippingAddress().InjectFrom(rk)).ToList()
            };
        }
        public DLModel.ShippingAddress getShippingAddressByUserID(int userID)
        {
            return _shippingAddressRepository.GetAll(rk => rk.SAUserID == userID).SingleOrDefault();
        }
    }
}
