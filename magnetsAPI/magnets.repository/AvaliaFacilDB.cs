using magnets.repository.Mapping;
using magnetsEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnets.repository
{
    public class AvaliaFacilDB : DbContext
    {
        public AvaliaFacilDB():base("Name = AvaliaDB") {}

        public DbSet<NPSModel> NPS { get; set; }
        public DbSet<LaboratorioModel> Lab { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NPSMapping());
            modelBuilder.Configurations.Add(new LaboratorioMapping());
        }
    }
}
