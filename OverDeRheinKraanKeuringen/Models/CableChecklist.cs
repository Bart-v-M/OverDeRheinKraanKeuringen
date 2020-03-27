using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    public class CableChecklist
    {
        public int Id { get; set; }

        public int Breakage_6D { get; set; }

        public int Breakage_30D { get; set; }

        public DamageLevel DamageOutside { get; set; }

        public DamageLevel DamageCorrosion { get; set; }

        public int ReducedCableDiameter { get; set; }

        public int PositionMeasuringPoints { get; set; }

        public DamageLevel DamageTotal { get; set; }
  
        public List<DamageType> DamageTypes { get; set; }
    }

    public enum DamageLevel
    {
        Minor,
        Average,
        High,
        VeryHigh
    }
}
