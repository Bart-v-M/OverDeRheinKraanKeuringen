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
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Assignments.Any())
            {
                return;   // DB has been seeded
            }

            var damageTypes = new List<DamageType>
            {
                new DamageType { Type = Models.Type.H2O_Corrosion }
            };

            foreach(DamageType t in damageTypes)
            {
                context.damageTypes.Add(t);
            }

            context.SaveChanges();

            var cableCheckLists = new List<CableChecklistModel>
            {
                new CableChecklistModel { DamageCorrosion = DamageLevel.Average, Breakage_30D = 2, DamageTotal = DamageLevel.High, Breakage_6D = 1, DamageOutside = DamageLevel.Minor, ReducedCableDiameter = 3, DamageTypes = damageTypes  }
            };

            foreach (CableChecklistModel c in cableCheckLists)
            {
                context.cableCheckLists.Add(c);
            }

            context.SaveChanges();

            var assignments = new List<AssignmentModel>
            {
                new AssignmentModel{ Date = DateTime.Now,Observations = "Heel Mooi", CableSupplier = "Apeldoorn"}
            };
            foreach (AssignmentModel s in assignments)
            {
                context.Assignments.Add(s);
            }
            context.SaveChanges();

        }
    }
}
