using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverDeRheinKraanKeuringen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OverDeRheinKraanKeuringen.Models.Assignment> Assignments { get; set; }

        public DbSet<OverDeRheinKraanKeuringen.Models.CableChecklist> cableCheckLists { get; set; }
        
        public DbSet<OverDeRheinKraanKeuringen.Models.DamageType> damageTypes { get; set; }


        
    }
}
