using OverDeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = OverDeRheinKraanKeuringen.Models.Type;

namespace OverDeRheinKraanKeuringen.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted(); 
            
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Assignments.Any())
            {
                return;   // DB has been seeded
            }

            List<DamageType> damageTypes01 = new List<DamageType>
            {
                new DamageType { Type = Type.H2O_Corrosion },
                new DamageType { Type = Type.MetalFatigue }
            };

            
            foreach(DamageType t in damageTypes01) 
            {
                context.DamageTypes.Add(t);
            }
            

            context.SaveChanges();

            var cableCheckLists = new List<CableChecklist>
            {
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes01 },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes01 },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes01 },
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes01 }
            };

            foreach (CableChecklist c in cableCheckLists)
            {
                context.CableCheckLists.Add(c);
            }

            context.SaveChanges();

            var assignments = new List<Assignment>
            {
                new Assignment { Date = DateTime.Now,Observations = "Heel Mooi", CableSupplier = "Apeldoorn", CableChecklists = context.CableCheckLists.ToList()}
            };

            foreach (Assignment s in assignments)
            {
                context.Assignments.Add(s);
            }

            context.SaveChanges();

        }
    }
}
