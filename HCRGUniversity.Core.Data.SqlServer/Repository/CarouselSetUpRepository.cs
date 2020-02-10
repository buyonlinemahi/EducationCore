using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class CarouselSetUpRepository : BaseRepository<CarouselSetUp, HCRGUniversityDBContext>, ICarouselSetUpRepository
    {
        public CarouselSetUpRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<BLModel.CarouselSetUp> GetCarouselSetUpAll(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<BLModel.CarouselSetUp>(Constant.StoredProcedureConst.CarouselSetUpRepositoryProcedure.GetCarouselSetUpAll, _organizationID);
        }

        public IEnumerable<BLModel.CarouselSetUp> GetAllCarouselSetUp(int OrganizationID, int ClientID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrgID", OrganizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.CarouselSetUp>(Constant.StoredProcedureConst.CarouselSetUpRepositoryProcedure.GetAllCarouselSetUp, _organizationID, _ClientID);
        }
        
        public int UpdateCarouselSetUp(CarouselSetUp modelCarouselSetup)
        {
            SqlParameter _CarouselID = new SqlParameter("@CarouselID", modelCarouselSetup.CarouselID);
            SqlParameter _CarouselTitle = new SqlParameter("@CarouselTitle", modelCarouselSetup.CarouselTitle);
            SqlParameter _CarouselDescription = new SqlParameter("@CarouselDescription", modelCarouselSetup.CarouselDescription);
            SqlParameter _CarouselBgColor = new SqlParameter("@CarouselBgColor", modelCarouselSetup.CarouselBgColor);
            SqlParameter _NewsID = new SqlParameter("@NewsID", modelCarouselSetup.NewsID);
            return Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.CarouselSetUpRepositoryProcedure.UpdateCarouselSetUp, _CarouselID, _CarouselTitle, _CarouselDescription, _CarouselBgColor, _NewsID);
        }
       

    } 
}
