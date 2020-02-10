using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface ICarouselSetUp
    {
        int AddCarouselSetup(DLModel.CarouselSetUp carouselSetUpModel);
        IEnumerable<BLModel.CarouselSetUp> GetCarouselSetUpAll(int OrganizationID);
        IEnumerable<BLModel.CarouselSetUp> GetAllCarouselSetUp(int OrganizationID, int ClientID);        
        IEnumerable<BLModel.CarouselSetUp> GetCarouselNewsDetail(int OrganizationID);
        int UpdateCarouselSetUp(DLModel.CarouselSetUp modelCarouselSetUp);
      
        //HomeContent...      
        int AddHomeContent(DLModel.HomeContent homeContent);
        int UpdateHomeContent(DLModel.HomeContent homeContent);
        DLModel.HomeContent GetHomeContent(int OrganizationID);
        IEnumerable<BLModel.HomeContent> GetAllHomeContentByOrganizationID(int clientID,int orgID);

        //IndustryResearch...
        int AddIndustryResearchContent(DLModel.IndustryResearch industryResearchContent);
        int UpdateIndustryResearchContent(DLModel.IndustryResearch industryResearchContent);
        DLModel.IndustryResearch GetIndustryResearchContent(int OrganizationID);
        IEnumerable<BLModel.IndustryResearch> GetAllIndustryResearchesByOrganizationID(int OrganizationID, int ClientID);

    }
}