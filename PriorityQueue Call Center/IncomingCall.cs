using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue_Call_Center
{
    public class IncomingCall
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Consultant { get; set; } = "Consultant";
        public bool IsPriority { get; set; }

        public override string ToString()
        {
            return $"CALL ID:{Id} CLIENT ID:{ClientId} Is priority:{IsPriority}";
        }
    }
}
