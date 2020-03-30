using OverDeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OverDeRheinKraanKeuringen.Models.Damage;

namespace OverDeRheinKraanKeuringen.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Delete database on initialization
            context.Database.EnsureDeleted(); 
            
            // Create database on initialization
            context.Database.EnsureCreated();

            // Look for any assignments
            if (context.Assignments.Any())
            {
                return; // DB has been seeded
            }

         
            // Add DamageTypes
            /*
            List<Damage> damageTypes01 = new List<Damage>
            {
                Types = { DamageType.H2O_Corrosion, DamageType.AcidCorrosion }
            };          
            foreach(Damage t in damageTypes01) 
            {
                context.DamageTypes.Add(t);
            }
            context.SaveChanges();
            */
           

            // Add CableChecklists
            var cableChecklists = new List<CableChecklist>
            {
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { Types = { DamageType.H2O_Corrosion } } },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { Types = { DamageType.H2O_Corrosion } } },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { Types = { DamageType.H2O_Corrosion } } },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { Types = { DamageType.H2O_Corrosion } } }
            };
            foreach (CableChecklist c in cableChecklists)
            {
                context.CableChecklists.Add(c);
            }
            context.SaveChanges();

            // Add Assignments
            var assignments = new List<Assignment>
            {
                new Assignment { Date = DateTime.Now, Observations = "Heel Mooi", CableSupplier = "Apeldoorn", CableChecklists = context.CableChecklists.ToList()}
            };
            foreach (Assignment s in assignments)
            {
                context.Assignments.Add(s);
            }
            context.SaveChanges();
        }
    }
}
