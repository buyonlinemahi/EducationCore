using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEducationProfession
    {
        int AddEducationProfession(EducationProfession educationProfession);
        int UpdateEducationProfession(EducationProfession educationProfession);
    }
}