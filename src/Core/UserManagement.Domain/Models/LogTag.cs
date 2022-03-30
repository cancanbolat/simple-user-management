using System.Collections.Generic;

namespace UserManagement.Domain.Models
{
    public class LogTag : BaseModel
    {
        public string Name { get; set; }
        public List<LifeLog> LifeLogs { get; set; }
    }
}
