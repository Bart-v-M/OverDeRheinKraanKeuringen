using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    // List with possible damage types
    public class Damage
    {
        public int Id { get; set; }

        public virtual List<DamageType> Types { get; set; }

        public enum DamageType
        {
            [Display(Name = "Geen")]
            None = 1,

            [Display(Name = "Watercorrosie")]
            H2O_Corrosion,

            [Display(Name = "Knelling")]
            Pinched,

            [Display(Name = "Schaafschade")]
            ScrapingDamage,

            [Display(Name = "Metaalmoeheid")]
            MetalFatigue,

            [Display(Name = "Zuurcorrosie")]
            AcidCorrosion
        }
    }    
}
