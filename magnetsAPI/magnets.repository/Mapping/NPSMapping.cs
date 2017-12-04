using magnetsEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnets.repository.Mapping
{
   public class NPSMapping : EntityTypeConfiguration<NPSModel>
    {
        public NPSMapping()
        {
            //Primary Key
            this.HasKey(x => x.ID);

            //Properties
            this.Property(x => x.IDLab).IsRequired();
            this.Property(x => x.FAP).IsRequired().HasMaxLength(12);
            this.Property(x => x.InstalacaoNota).IsRequired();
            this.Property(x => x.AtendimentoNota).IsRequired();
            this.Property(x => x.RecomendacaoNota).IsRequired();
            this.Property(x => x.Celular).IsRequired();


            //Table & Column Mappings
            this.ToTable("TB_NPS");
            this.Property(x => x.ID).HasColumnName("ID_NPS");
            this.Property(x => x.FAP).HasColumnName("NR_FAP");
            this.Property(x => x.InstalacaoNota).HasColumnName("NR_INSTALACAO_NOTA");
            this.Property(x => x.AtendimentoNota).HasColumnName("NR_ATENDIMENTO_NOTA");
            this.Property(x => x.RecomendacaoNota).HasColumnName("NR_RECOMENCADAO_NOTA");
            this.Property(x => x.Observacao).HasColumnName("DS_AVALIACAO");
            this.Property(x => x.IDLab).HasColumnName("ID_LAB");
            this.Property(x => x.Celular).HasColumnName("NR_CELULAR");


            // Relationships
            this.HasRequired(t => t.Laboratorio)
                .WithMany(t => t.NPSCollection)
                .HasForeignKey(d => d.IDLab);
        }
    }
}
