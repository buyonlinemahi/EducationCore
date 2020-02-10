using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
  public class EvaluationQuestionResultRepository: BaseRepository< EvaluationQuestionResult, HCRGUniversityDBContext>, IEvaluationQuestionResultRepository
    {
      public EvaluationQuestionResultRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
    }
}
