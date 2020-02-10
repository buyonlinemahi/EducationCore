using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class OrderRepository : BaseRepository<Order, HCRGUniversityDBContext>, IOrderRepository
    {
        public OrderRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
    }
}
