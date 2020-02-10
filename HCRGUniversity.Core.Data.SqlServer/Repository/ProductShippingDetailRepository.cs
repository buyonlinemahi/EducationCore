using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class ProductShippingDetailRepository : BaseRepository<ProductShippingDetail, HCRGUniversityDBContext>, IProductShippingDetailRepository
    {
        public ProductShippingDetailRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public void UpdateProductShippingDetailByShippingPaymentID(ProductShippingDetail _productShippingDetail)
        {
            SqlParameter _shippingPaymentID = new SqlParameter("@ShippingPaymentID", _productShippingDetail.ShippingPaymentID);
            SqlParameter _createdBy = new SqlParameter("@CreatedBy", _productShippingDetail.CreatedBy);
            SqlParameter _productShippedOn = new SqlParameter("@ProductShippedOn", _productShippingDetail.ProductShippedOn);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ProductShippingDetailRepositoryProcedure.UpdateProductShippingDetailByShippingPaymentID, _shippingPaymentID, _createdBy, _productShippedOn);
        }
    }
}
