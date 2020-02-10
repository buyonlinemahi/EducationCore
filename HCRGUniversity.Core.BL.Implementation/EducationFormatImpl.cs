using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationFormatImpl : IEducationFormat
    {
        private readonly IEducationFormatRepository _educationFormatRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public EducationFormatImpl(IEducationFormatRepository educationFormatRepository, IOrganizationRepository organizationRepository)
        {
            _educationFormatRepository = educationFormatRepository;
            _organizationRepository = organizationRepository;
        }

        public int AddEducationFormat(EducationFormat educationFormat)
        {
            return _educationFormatRepository.Add(educationFormat).EducationFormatID;
        }

        public int UpdateEducationFormat(EducationFormat educationFormat)
        {
            return _educationFormatRepository.Update(educationFormat);
        }

        public IEnumerable<EducationFormat> getAllEducationFormat(int _organizationID)
        {
           
            return _educationFormatRepository.GetAll().OrderBy(educationFormat => educationFormat.EducationFormatType).ToList();

        }

        public IEnumerable<BLModel.EducationFormat> GetAllEducationFormatByOrganizationID(int _organizationID)
        {
                return _educationFormatRepository.GetAllEducationFormatByOrganizationID(_organizationID).ToList();
        }
        public IEnumerable<BLModel.EducationFormat> GetEducationFormatByClientID(int ClientID)
        {
            return _educationFormatRepository.GetEducationFormatByClientID(ClientID).ToList();
        }
        public IEnumerable<BLModel.EducationFormat> GetAllEducationFormatByClientID(int ClientID)
        {

            return _educationFormatRepository.GetAllEducationFormatByClientID(ClientID).ToList();

        }

        public IEnumerable<EducationFormat> GetEducationFormatNotAssociateWithEducation(int educationID)
        {
            IEnumerable<EducationFormat> _educationFormat = _educationFormatRepository.GetEducationFormatNotAssociateWithEducation(educationID).OrderBy(hp => hp.EducationFormatType).ToList();
            return _educationFormat;
        }
               
        public BLModel.Paged.EducationFormat GetAllPagedEducationFormat(int skip, int take)
        {
            return new BLModel.Paged.EducationFormat
            {
                TotalCount = _educationFormatRepository.GetEducationFormatCount(),
                EducationFormats = _educationFormatRepository.GetAllPagedEducationFormat(skip, take).ToList()
            };
        }

       
    }
}