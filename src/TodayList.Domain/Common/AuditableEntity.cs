using System;

namespace TodayList.Domain.Common
{
    public class AuditableEntity 
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}