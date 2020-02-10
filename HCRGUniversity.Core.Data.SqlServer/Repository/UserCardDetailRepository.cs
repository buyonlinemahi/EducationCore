using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class UserCardDetailRepository : BaseRepository<UserCardDetail, HCRGUniversityDBContext>, IUserCardDetailRepository
    {
        public UserCardDetailRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
    }
}
