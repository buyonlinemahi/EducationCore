using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
   public class EvaluationAnswerRepository: BaseRepository< EvaluationAnswer, HCRGUniversityDBContext>, IEvaluationAnswerRepository
    {
       public EvaluationAnswerRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
    }
}
