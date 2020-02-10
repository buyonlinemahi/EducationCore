using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationDetailPageRepository : IBaseRepository<EducationDetailPage>
    {
        EducationDetailPageWithEducation GetEducationDetailPageContent(int educationID);
    }
}