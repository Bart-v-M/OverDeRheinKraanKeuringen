using OverDeRheinKraanKeuringen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //
            context.Database.EnsureDeleted();

            //
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Assignments.Any())
            {
                return; // DB has been seeded
            }


            var damageTypes = new List<DamageType>
            {
                 new DamageType { Type = DamnType.H2O_Corrosion }
            };
            foreach (var t in damageTypes)
            {
                context.DamageTypes.Add(t);
            }
            context.SaveChanges();


            /*
            var damageTypes = new List<DamageType>
            {
                new DamageType { Type = { DamageType.DamnType.H2O_Corrosion } }
            };
            foreach (DamageType t in damageTypes)
            {
                context.DamageTypes.Add(t);
            }
            context.SaveChanges();
            */

            //
            var cableChecklists = new List<CableChecklist>
            {
                new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes =  context.DamageTypes.ToList() },
                //new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { DamnType.H2O_Corrosion, DamnType.MetalFatigue } },
                //new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { DamnType.H2O_Corrosion, DamnType.MetalFatigue } },
                //new CableChecklist { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = { DamnType.H2O_Corrosion, DamnType.MetalFatigue } }
            };
            foreach (CableChecklist c in cableChecklists)
            {
                context.CableChecklists.Add(c);
            }
            context.SaveChanges();

            //
            var assignments = new List<Assignment>
            {
                new Assignment{ Date = DateTime.Now,Observations = "Heel Mooi", CableSupplier = "Apeldoorn", CableChecklists = context.CableChecklists.ToList()}
            };
            foreach (Assignment s in assignments)
            {
                context.Assignments.Add(s);
            }
            context.SaveChanges();

            //
            context.IdTrackers.Add(new IdTracker { LatestAssignmentId = 0, LatesCableChecklistId = 0 });
            context.SaveChanges();
        }
    }
}
