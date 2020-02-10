using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class ProductRepository : BaseRepository<Product, HCRGUniversityDBContext>, IProductRepository
    {
        public ProductRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<Product> GetPagedProductByProductName(string searchText, int skip, int take)
        {
            SqlParameter _searchText = new SqlParameter("@searchText", searchText);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<Product>(Constant.StoredProcedureConst.ProductRepositoryProcedure.GetPagedProductByProductName, _searchText, _skip, _take);
        }

        public int GetProductPurchaseDetailCount(int skip, int take, int organization)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organization = new SqlParameter("@OrganizationID", organization);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ProductRepositoryProcedure.GetProductPurchaseDetailCount, _skip, _take, _organization).SingleOrDefault();
        }

        public IEnumerable<ProductPurchase> GetProductPurchaseDetail(int skip, int take, int organizationID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<ProductPurchase>(Constant.StoredProcedureConst.ProductRepositoryProcedure.GetProductPurchaseDetail, _skip, _take, _organizationID);
        }
    }
}
