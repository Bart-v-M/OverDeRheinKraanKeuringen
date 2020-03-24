using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    public class AssignmentModel
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string WorkInstruction { get; set; }

        public DateTime? Date { get; set; }

        [MaxLength(250)]
        public string CableSupplier { get; set; }

        [MaxLength(500)]
        public string Observations { get; set; }

        public byte[] Signature { get; set; }

        public int OperatingHours { get; set; }

        public string Reason { get; set; }

        public List<CableChecklistModel> cableChecklists { get; set; }
    }
}
