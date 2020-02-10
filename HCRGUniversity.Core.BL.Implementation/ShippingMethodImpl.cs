using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ShippingMethodImpl : IShippingMethod
    {
        private readonly IShippingMethodRepository _shippingMethodRepository;

        public ShippingMethodImpl(IShippingMethodRepository shippingMethodRepository)
        {
            _shippingMethodRepository = shippingMethodRepository;
        }
        public IEnumerable<DLModel.ShippingMethod> getAllShippingMethod()
        {
            IEnumerable<DLModel.ShippingMethod> _shippingMethod = _shippingMethodRepository.GetAll().Select(rk => new DLModel.ShippingMethod().InjectFrom(rk)).Cast<DLModel.ShippingMethod>().OrderBy(rk => rk.ShippingMethodName).ToList();
            return _shippingMethod;
        }
    }
}
