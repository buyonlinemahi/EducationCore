using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class IndustryImpl : IIndustry
    {
        private readonly IIndustryRepository _iindustryRepository;

        public IndustryImpl(IIndustryRepository iindustryRepository)
        {
            _iindustryRepository = iindustryRepository;
        }

        public IEnumerable<DLModel.Industry> getAllIndustry()
        {
            IEnumerable<DLModel.Industry> _industry = _iindustryRepository.GetAll().Select(s => new DLModel.Industry().InjectFrom(s)).Cast<DLModel.Industry>().OrderBy(s => s.IndustryName).ToList();
            return _industry;
        }
    }
}
