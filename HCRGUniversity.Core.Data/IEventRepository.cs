using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        IEnumerable<EventDetail> GetEventsAllPaged(int skip, int take, int clientID,int orgID);
        int GetEventsAllPagedCount(int clientID, int orgID);
        IEnumerable<EventDetail> GetEventsByEventDateRange(DateTime startDate, DateTime endDate, int organizationID);
        IEnumerable<EventDetail> GetEventsUpcoming(int organizationID);
    }
}
