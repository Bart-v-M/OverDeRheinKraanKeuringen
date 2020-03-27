using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    public class DamageType
    {
        public int Id { get; set; }

        public Type Type { get; set; }
    }

    public enum Type
    {
        H2O_Corrosion,
        Pinched,
        ScrapingDamage,
        MetalFatigue,
        AcidCorrosion
    }
}
