using OverDeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.ViewModels
{
    public class AssignmentViewModel
    {
        public Assignment AssignmentModel { get; set; }

        public List<CableChecklist> CableChecklists { get; set; }
    }
}
