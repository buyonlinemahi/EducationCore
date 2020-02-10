using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationFormatAvialableImpl : IEducationFormatAvailable
    {
        private readonly IEducationFormatAvailableRepository _educationFormatAvailableRepository;
        public EducationFormatAvialableImpl(IEducationFormatAvailableRepository educationFormatAvailableRepository)
        {
            _educationFormatAvailableRepository = educationFormatAvailableRepository;
        }

        public int AddEducationFormatAvailable(EducationFormatAvailable educationFormatAvailable)
        {
            return _educationFormatAvailableRepository.Add(educationFormatAvailable).EducationAvailableID;
        }

        public int UpdateEducationFormatAvailable(EducationFormatAvailable educationFormatAvailable)
        {
            return _educationFormatAvailableRepository.Update(educationFormatAvailable);
        }

        public IEnumerable<EducationFormatDetail> GetEducationFormatsByEducationID(int educationID)
        {
            return _educationFormatAvailableRepository.GetEducationFormatsByEducationID(educationID);
        }
    }
}