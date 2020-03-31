using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    public class CableChecklist
    {
        public int Id { get; set; }

        [Display(Name = "Aantal zichtbare draadbreuken (lengte 6d)")]
        [Required(ErrorMessage = "Voer het aantal zichtbare draadbreuken (lengte 6d) in")]
        [Range(0, short.MaxValue, ErrorMessage = "Alleen positieve getallen zijn mogelijk")]
        public short Breakage_6D { get; set; }

        [Display(Name = "Aantal zichtbare draadbreuken (lengte 30d)")]
        [Required(ErrorMessage = "Voer het aantal zichtbare draadbreuken (lengte 30d) in")]
        [Range(0, short.MaxValue, ErrorMessage = "Alleen positieve getallen zijn mogelijk")]
        public short Breakage_30D { get; set; }

        [Display(Name = "Afslijping draden buitenzijde (mate van beschadiging)")]
        [Required(ErrorMessage = "Voer afslijping draden buitenzijde (mate van beschadiging) in")]
        public DamageLevel DamageOutside { get; set; }

        [Display(Name = "Roest en corrosie (mate van beschadiging)")]
        [Required(ErrorMessage = "Voer roest en corrosie (mate van beschadiging) in")]
        public DamageLevel DamageCorrosion { get; set; }

        [Display(Name = "Verminderde kabeldiameter")]
        [Required(ErrorMessage = "Voer verminderde kabeldiameter in")]
        [Range(0, short.MaxValue, ErrorMessage = "Alleen positieve getallen zijn mogelijk")]
        public short ReducedCableDiameter { get; set; }

        [Display(Name = "Positie van de meetpunten")]
        [Required(ErrorMessage = "Voer positie van de meetpunten in")]
        [Range(0, short.MaxValue, ErrorMessage = "Alleen positieve getallen zijn mogelijk")]
        public short PositionMeasuringPoints { get; set; }

        [Display(Name = "Totale beoordeling (mate van beschadiging)")]
        [Required(ErrorMessage = "Voer totale beoordeling (mate van beschadiging) in")]
        public virtual DamageLevel DamageTotal { get; set; }


        [Display(Name = "Typen beschadiging en roestvorming")]
        //[Required(ErrorMessage = "Voer één of meer typen beschadiging en roestvorming in")]

        //public List<DamageType> DamageTypes { get; set; }

        public List<DamnType> DamageTypes { get; set; }
    }

    // List with possible damage levels
    public enum DamageLevel
    {
        [Display(Name = "Geen")]
        None = 0,

        [Display(Name = "Minimaal")]
        Minor,

        [Display(Name = "Gemiddeld")]
        Average,

        [Display(Name = "Hoog")]
        High,

        [Display(Name = "Zeer hoog")]
        VeryHigh
    }

    public enum DamnType
    {
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

   
