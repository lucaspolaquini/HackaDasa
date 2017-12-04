using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnets.repository.Mapping
{
    public class LaboratorioMapping : EntityTypeConfiguration<magnetsEntity.LaboratorioModel>
    {
        public LaboratorioMapping()
        {
            //Primary key
            this.HasKey(x => x.ID);

            //Properties
            this.Property(x => x.Nome).IsRequired().HasMaxLength(100);

            //Table & Column Mappings
            this.ToTable("TB_LABORATORIO");
            this.Property(x => x.ID).HasColumnName("ID_LAB");
            this.Property(x => x.Nome).HasColumnName("NM_LAB");
        }
    }
}
