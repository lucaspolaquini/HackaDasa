using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnetsEntity
{
    public class LaboratorioModel : Base.Entity
    {
        public String Nome { get; set; }

        public virtual ICollection<NPSModel> NPSCollection { get; set; }
    }
}
