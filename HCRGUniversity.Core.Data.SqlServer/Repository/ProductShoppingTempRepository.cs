using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class ProductShoppingTempRepository : BaseRepository<ProductShoppingTemp, HCRGUniversityDBContext>, IProductShoppingTempRepository
    {
      public ProductShoppingTempRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

     
      public int DeleteProductFromShoppingCart(int productShoppingTempID)
      {
          SqlParameter _productShoppingTempID = new SqlParameter("@ProductShoppingTempID", productShoppingTempID);
          return Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.DeleteProductFromShoppingCart, _productShoppingTempID);
      }

      public int DeleteProductFromShoppingCartByUserID(int userID)
      {
          SqlParameter _userID = new SqlParameter("@userID", userID);
          return Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.DeleteProductFromShoppingCartByUserID, _userID);
      }

      public ProductShoppingTemp getProductShoppingTempByID(int _id)
      {
          SqlParameter _productShoppingTempID = new SqlParameter("@ProductShoppingTempID", _id);
          return Context.Database.SqlQuery<ProductShoppingTemp>(Constant.StoredProcedureConst.ProductRepositoryProcedure.GetProductShoppingTempByID, _productShoppingTempID).SingleOrDefault();
      }
    }
}
