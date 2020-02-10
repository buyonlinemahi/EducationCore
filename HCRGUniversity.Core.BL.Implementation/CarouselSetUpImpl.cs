using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class CarouselSetUpImpl : ICarouselSetUp
    {
        private readonly ICarouselSetUpRepository _carouselSetUpRepository;
        private readonly INewsPhotoRepository _newsPhotoRepository;
        private readonly IHomeContentRepository _homeContentRepository;
        private readonly IIndustryResearchRepository _industryResearchRepository;

        public CarouselSetUpImpl(ICarouselSetUpRepository carouselSetUpRepository, INewsPhotoRepository newsPhotoRepository, IHomeContentRepository homeContentRepository, IIndustryResearchRepository industryResearchRepository)
        {
            _carouselSetUpRepository = carouselSetUpRepository;
            _newsPhotoRepository = newsPhotoRepository;
            _homeContentRepository = homeContentRepository;
            _industryResearchRepository = industryResearchRepository;
        }

        public int AddCarouselSetup(DLModel.CarouselSetUp carouselSetUpModel)
        {
            return _carouselSetUpRepository.Add((DLModel.CarouselSetUp)new DLModel.CarouselSetUp().InjectFrom(carouselSetUpModel)).CarouselID;
        }

        public IEnumerable<BLModel.CarouselSetUp> GetCarouselSetUpAll(int OrganizationID)
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselData = _carouselSetUpRepository.GetCarouselSetUpAll(OrganizationID).Select(carousel => new BLModel.CarouselSetUp().InjectFrom(carousel)).Cast<BLModel.CarouselSetUp>().ToList();
            return _carouselData;
        }

        public IEnumerable<BLModel.CarouselSetUp> GetAllCarouselSetUp(int OrganizationID, int ClientID)
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselData = _carouselSetUpRepository.GetAllCarouselSetUp(OrganizationID, ClientID).Select(carousel => new BLModel.CarouselSetUp().InjectFrom(carousel)).Cast<BLModel.CarouselSetUp>().ToList();
            return _carouselData;
        }        

        public IEnumerable<BLModel.CarouselSetUp> GetCarouselNewsDetail(int OrganizationID)
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselData = _carouselSetUpRepository.GetCarouselSetUpAll(OrganizationID).ToList();
            foreach (var hp in _carouselData)
            {
                var _newsPh = _newsPhotoRepository.GetAll(hp1 => hp1.NewsID == hp.NewsID).OrderBy(_newsPhoto => _newsPhoto.NewsPhotoID).FirstOrDefault();
                if (_newsPh != null)
                    hp.NewsPhotoUrl = _newsPh.NewsPhotos;
            }

            return _carouselData;
        }

        public int UpdateCarouselSetUp(DLModel.CarouselSetUp modelCarouselSetUp)
        {
            return _carouselSetUpRepository.UpdateCarouselSetUp(modelCarouselSetUp);
        }

       


        //HomeContent
        public int AddHomeContent(DLModel.HomeContent homeContent)
        {
            return _homeContentRepository.Add((DLModel.HomeContent)new DLModel.HomeContent().InjectFrom(homeContent)).HomeContentID;
        }

        public int UpdateHomeContent(DLModel.HomeContent homeContent)
        {
            return _homeContentRepository.Update((DLModel.HomeContent)new DLModel.HomeContent().InjectFrom(homeContent));
        }

        public DLModel.HomeContent GetHomeContent(int _OrganizationID)
        {           
            if (_homeContentRepository.GetAll(rk => rk.OrganizationID == _OrganizationID).Count() != 0)
            {
                return (DLModel.HomeContent)new DLModel.HomeContent().InjectFrom(_homeContentRepository.GetAll(rk => rk.OrganizationID == _OrganizationID).SingleOrDefault());
            }
            else
            {
                DLModel.HomeContent homecontent = new DLModel.HomeContent();
                return homecontent;
            }
        }

        public IEnumerable<BLModel.HomeContent> GetAllHomeContentByOrganizationID(int clientID, int orgID)
        {
            return _homeContentRepository.GetAllHomeContentByOrganizationID(clientID,orgID);
        }

        //Industry research
        public int AddIndustryResearchContent(DLModel.IndustryResearch industryResearchContent)
        {
            return _industryResearchRepository.Add(industryResearchContent).IndustryResearchID;
        }

        public int UpdateIndustryResearchContent(DLModel.IndustryResearch industryResearchContent)
        {
            return _industryResearchRepository.Update(industryResearchContent);
        }

        public DLModel.IndustryResearch GetIndustryResearchContent(int OrganizationID)
        {
            var industryRes = _industryResearchRepository.GetAll(rk => rk.OrganizationID == OrganizationID);
            if (industryRes.Count() > 0)
                return industryRes.FirstOrDefault();
            else
                return new DLModel.IndustryResearch();
        }

        public IEnumerable<BLModel.IndustryResearch> GetAllIndustryResearchesByOrganizationID(int OrganizationID, int ClientID)
        {
            return _industryResearchRepository.GetAllIndustryResearchesByOrganizationID(OrganizationID, ClientID);
        }
    }
}