using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string  EventDescription { get; set; }
        public int? NewsID { get; set; }
        public int? EducationID { get; set; }
        public int OrganizationID { get; set; }
    }
}
