using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class NewsSectionImpl : INewsSection
    {
        private readonly INewsSectionRepository _newsSectionRepository;

        public NewsSectionImpl(INewsSectionRepository newsSectionRepository)
        {
            _newsSectionRepository = newsSectionRepository;

        }

        public int AddNewsSection(DLModel.NewsSection newsSection)
        {
            return _newsSectionRepository.Add((DLModel.NewsSection)new DLModel.NewsSection().InjectFrom(newsSection)).NewsSectionID;

        }

        public int UpdateNewsSection(DLModel.NewsSection newsSection)
        {
            return _newsSectionRepository.Update((DLModel.NewsSection)new DLModel.NewsSection().InjectFrom(newsSection));
        }

        public void DeleteNewsSection(int newsSectionID)
        {
            _newsSectionRepository.Delete(_newsSectionRepository.GetById(newsSectionID));
        }

        public DLModel.NewsSection GetNewsSectionByID(int newsSectionID)
        {
            return (DLModel.NewsSection)new DLModel.NewsSection().InjectFrom(_newsSectionRepository.GetById(newsSectionID));
        }

        public IEnumerable<DLModel.NewsSection> getAllNewsSection(int OrganizationID)
        {
            IEnumerable<DLModel.NewsSection> _newsSection = _newsSectionRepository.GetAll(rk => rk.OrganizationID == OrganizationID).Select(newsSection => new DLModel.NewsSection().InjectFrom(newsSection)).Cast<DLModel.NewsSection>().OrderBy(newsSection => newsSection.NewsSectionID).ToList();
            return _newsSection;
        }

    }
}

