using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class DiscountCouponRepository : BaseRepository<DiscountCoupon, HCRGUniversityDBContext>, IDiscountCouponRepository
    {
        public DiscountCouponRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public int UpdateDiscountCouponStatus(string couponCode, bool value)
        {
            SqlParameter _CouponCode = new SqlParameter("@CouponCode", couponCode);
            SqlParameter _CoupanValid = new SqlParameter("@CoupanValid", value);
            return Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.DiscountCouponRepositoryProcedure.UpdateDiscountCouponStatus, _CouponCode, _CoupanValid);
        }

        public IEnumerable<DiscountCouponForCourses> GetDiscountCouponForCourses(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<DiscountCouponForCourses>(Constant.StoredProcedureConst.DiscountCouponRepositoryProcedure.GetDiscountCouponForCourses, _clientID);
        }

        public IEnumerable<DiscountCouponForCourses> GetDiscountCouponForProducts(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<DiscountCouponForCourses>(Constant.StoredProcedureConst.DiscountCouponRepositoryProcedure.GetDiscountCouponForProducts, _clientID);
        }

        public IEnumerable<DiscountCoupon> GetAllPagedDiscountCoupon(int skip, int take)
        {
            SqlParameter _Skip = new SqlParameter("@Skip", skip);
            SqlParameter _Take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<DiscountCoupon>(Constant.StoredProcedureConst.DiscountCouponRepositoryProcedure.GetAllPagedDiscountCoupon,_Skip,_Take);           
        }
        public IEnumerable<DiscountCouponForCourses> GetAllPagedDiscountCouponForCourses(int skip, int take, int OrganizationID)
        {
            SqlParameter _Skip = new SqlParameter("@Skip", skip);
            SqlParameter _Take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<DiscountCouponForCourses>(Constant.StoredProcedureConst.DiscountCouponRepositoryProcedure.GetAllPagedDiscountCouponForCourse, _Skip, _Take, _organizationID);
        }
        public int GetDiscountCouponCount()
        {
            return dbset.Count();
        }
        public int GetDiscountCouponCountForCourse(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.DiscountCouponRepositoryProcedure.GetDiscountCouponCountForCourse, _clientID).SingleOrDefault();
        }  
        
    }
}