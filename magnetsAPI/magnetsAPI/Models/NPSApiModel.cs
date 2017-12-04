using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace magnetsAPI.Models
{
    public class NPSApiModel
    {
        public String FAP { get; set; }

        public String AtendimentoNota { get; set; }

        public String InstalacaoNota { get; set; }

        public String RecomendacaoNota { get; set; }

        public String Observacao { get; set; }

        public DateTime DataAvaliacao { get; set; }

        public String Celular { get; set; }

        public Int32 IDLab { get; set; }
    }
}