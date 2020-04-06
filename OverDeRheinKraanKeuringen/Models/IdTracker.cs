using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    public class IdTracker
    {
        public int Id { get; set; } // Only one instance of IdTracker is needed
        public int LatestAssignmentId { get; set; }
        public int LatesCableChecklistId { get; set; }
    }
}
