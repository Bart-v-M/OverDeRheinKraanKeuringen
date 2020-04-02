using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Display(Name = "Werkinstructie(s)")]
        //[Required(ErrorMessage = "Voer werkinstructie(s) in")]
        [MaxLength(500)]
        public string WorkInstruction { get; set; }

        [Display(Name = "Datum")]
        //[Required(ErrorMessage = "Voer een datum in")]
        [DataType(DataType.Date)] // This DataAnnotation is added to be able to save Date to the database
        public DateTime? Date { get; set; }

        [Display(Name = "Kabelleverancier")]
        //[Required(ErrorMessage = "Voer een kabelleverancier in")]
        [MaxLength(250)]
        public string CableSupplier { get; set; }

        [Display(Name = "Overige waarnemingen")]
        //[Required(ErrorMessage = "Voer overige waarnemingen in")]
        [MaxLength(500)]
        public string Observations { get; set; }

        [NotMapped]
        public string SignatureDataUrl { get; set; }

        [Display(Name = "Handtekening")]
        //[Required(ErrorMessage = "Voer een handtekening in")]
        public byte[] Signature { get; set; }

        [Display(Name = "Aantal bedrijfsuren")]
        [Required(ErrorMessage = "Voer het aantal bedrijfsuren in")]
        public uint OperatingHours { get; set; }

        [Display(Name = "Redenen voor het afleggen")]
        //[Required(ErrorMessage = "Voer redenen voor het afleggen in")]
        public string Reason { get; set; }

        public List<CableChecklist> CableChecklists { get; set; }
    }
}
