using OverDeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.ViewModels
{
    public class CableCheckListViewModel
    {
        public CableChecklist CableChecklist { get; set; }
        public List<string> DamageTypeIds { get; set; }
    }
}
