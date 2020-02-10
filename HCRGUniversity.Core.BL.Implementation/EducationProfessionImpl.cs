using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationProfessionImpl : IEducationProfession
    {
        private readonly IEducationProfessionRepository _educationProfessionRepository;
        public EducationProfessionImpl(IEducationProfessionRepository educationProfessionRepository)
        {
            _educationProfessionRepository = educationProfessionRepository;
        }
        public int AddEducationProfession(EducationProfession EducationProfession)
        {
            return _educationProfessionRepository.Add(EducationProfession).EducationProfessionID;
        }

        public int UpdateEducationProfession(EducationProfession educationProfession)
        {
            return _educationProfessionRepository.Update(educationProfession);
        }
    }
}