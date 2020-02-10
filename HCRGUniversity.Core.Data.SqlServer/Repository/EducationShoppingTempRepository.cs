using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationShoppingTempRepository : BaseRepository<EducationShoppingTemp, HCRGUniversityDBContext>, IEducationShoppingTempRepository
    {
        public EducationShoppingTempRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<EducationShoppingCart> GetEducationShoppingCartByUserID(int userID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<EducationShoppingCart>(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.GetEducationShoppingCartByUserID, _userID);
        }

        public IEnumerable<EducationShoppingCart> GetShoppingDetailsByShippingPaymentID(int shippingPaymentID)
        {
            SqlParameter _ShippingPaymentID = new SqlParameter("@ShippingPaymentID", shippingPaymentID);
            return Context.Database.SqlQuery<EducationShoppingCart>(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.GetShoppingDetailsByShippingPaymentID, _ShippingPaymentID).ToList();
        }

        public IEnumerable<EducationShoppingCart> GetEducationShoppingTempByShippingPaymentID(int shippingPaymentID)
        {
            SqlParameter _shippingPaymentID = new SqlParameter("@ShippingPaymentID", shippingPaymentID);
            return Context.Database.SqlQuery<EducationShoppingCart>(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.GetEducationShoppingTempByShippingPaymentID, _shippingPaymentID);
        }

        public int DeleteEducationFromShoppingCart(int educationShoppingTempID)
        {
            SqlParameter _educationShoppingTempID = new SqlParameter("@EducationShoppingTempID", educationShoppingTempID);
            return Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.DeleteEducationFromShoppingCart, _educationShoppingTempID);
        }

        public int DeleteEducationFromShoppingCartByUserID(int userID)
        {
            SqlParameter _userID = new SqlParameter("@userID", userID);
            return Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.DeleteEducationFromShoppingCartByUserID, _userID);
        }

        public void DeleteEducationShoppingCartByShippingPaymentID(int shippingPaymentID)
        {
            SqlParameter _shippingPaymentID = new SqlParameter("@ShippingPaymentID", shippingPaymentID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.DeleteEducationShoppingCartByShippingPaymentID, _shippingPaymentID);
        }
        public int CheckAnyProductsIsOutOfStock(int userID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.CheckAnyProductsIsOutOfStock, _userID).SingleOrDefault();
        }

        public string GetShoppingCartCoursesByUserID(int userID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<string>(Constant.StoredProcedureConst.ShoppingRepositoryProcedure.GetShoppingCartCoursesByUserID, _userID).SingleOrDefault();
        }
    }
}