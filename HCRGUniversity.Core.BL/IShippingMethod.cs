using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL
{
    public interface IShippingMethod
    {
        IEnumerable<ShippingMethod> getAllShippingMethod();
    }
}
