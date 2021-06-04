using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            DeparFuncs = new HashSet<DepartamentoFuncionario>();
            DeparGerens = new HashSet<DepartamentoGerencia>();
        }

        public string DepartamentoNumero { get; set; }
        public string DepartamentoNome { get; set; }

        public virtual ICollection<DepartamentoFuncionario> DeparFuncs { get; set; }
        public virtual ICollection<DepartamentoGerencia> DeparGerens { get; set; }
    }
}
