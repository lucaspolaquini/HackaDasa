using magnetsEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnetsEntity
{
    public class NPSModel : Entity
    {
        public String FAP { get; set; }

        public String AtendimentoNota { get; set; }

        public String InstalacaoNota { get; set; }

        public String RecomendacaoNota { get; set; }

        public String Observacao { get; set; }

        public DateTime DataAvaliacao { get; set; }

        public String Celular { get; set; }

        public Int32 IDLab { get; set; }

        public virtual LaboratorioModel Laboratorio { get; set; }
    }
}
