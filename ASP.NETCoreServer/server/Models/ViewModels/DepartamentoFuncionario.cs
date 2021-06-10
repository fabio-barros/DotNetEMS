using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class DepartamentoFuncionario
    {
        public string DepartamentoNumero { get; set; }
        public int FuncionarioNumero { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        public virtual Departamentos Departamentos { get; set; }
        public virtual Funcionario FunNumNavigation { get; set; }
    }
}
