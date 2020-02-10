using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface ICarouselSetUpRepository : IBaseRepository<CarouselSetUp>
    {
        IEnumerable<BLModel.CarouselSetUp> GetCarouselSetUpAll(int OrganizationID);
        IEnumerable<BLModel.CarouselSetUp> GetAllCarouselSetUp(int OrganizationID, int ClientID);        
        int UpdateCarouselSetUp(CarouselSetUp modelCarouselSetup);
    }
}
