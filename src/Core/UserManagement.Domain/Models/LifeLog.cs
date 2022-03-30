using System;

namespace UserManagement.Domain.Models
{
    public class LifeLog : BaseModel
    {
        public int TagId { get; set; }
        public int ViewCount { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalTime { get; set; }
        public LogTag Tag { get; set; }
    }
}
