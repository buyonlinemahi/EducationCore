using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
   public class EventRepository: BaseRepository<Event, HCRGUniversityDBContext>,IEventRepository
    {
       public EventRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
       public IEnumerable<EventDetail> GetEventsAllPaged(int skip, int take, int clientID, int orgID)
       {
           SqlParameter _skip = new SqlParameter("@skip", skip);
           SqlParameter _take = new SqlParameter("@take", take);
           SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
           SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
           return Context.Database.SqlQuery<EventDetail>(Constant.StoredProcedureConst.EventsRepositoryProcedure.GetEventsAllPaged, _skip, _take, _clientID, _orgID);
       }
       public IEnumerable<EventDetail> GetEventsByEventDateRange(DateTime startDate, DateTime endDate, int organizationID)
       {
           SqlParameter _startDate = new SqlParameter("@startDate", startDate);
           SqlParameter _endDate = new SqlParameter("@endDate", endDate);
           SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
           return Context.Database.SqlQuery<EventDetail>(Constant.StoredProcedureConst.EventsRepositoryProcedure.GetEventsByEventDateRange, _startDate, _endDate, _organizationID);
       }

       public IEnumerable<EventDetail> GetEventsUpcoming(int organizationID)
       {
           SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
           return Context.Database.SqlQuery<EventDetail>(Constant.StoredProcedureConst.EventsRepositoryProcedure.GetEventsUpcoming, _organizationID);
       }

       public int GetEventsAllPagedCount(int clientID, int orgID)
       {
           SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
           SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
           return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EventsRepositoryProcedure.GetEventsAllPagedCount, _clientID, _orgID).FirstOrDefault();
       }
    }
}
