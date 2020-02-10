using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;


namespace HCRGUniversity.Core.Data
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetPagedProductByProductName(string searchText, int skip, int take);
        int GetProductPurchaseDetailCount(int _skip, int _take, int organizationID);
        IEnumerable<ProductPurchase> GetProductPurchaseDetail(int _skip, int _take, int organizationID);
    }
}
