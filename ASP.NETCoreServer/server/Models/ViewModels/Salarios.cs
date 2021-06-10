using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Salarios
    {
        
        public int FuncionarioNumero { get; set; }
        public decimal Salario { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        public virtual Funcionario FunNumNavigation { get; set; }
    }
}
