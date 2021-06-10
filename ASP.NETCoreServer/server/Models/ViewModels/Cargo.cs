using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Cargo
    {
        public int FuncionarioNumero { get; set; }
        public string Titulo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Termino { get; set; }

        public virtual Funcionario FunNumNavigation { get; set; }
    }
}
