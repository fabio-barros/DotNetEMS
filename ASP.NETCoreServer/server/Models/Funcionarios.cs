using System;
using System.Collections.Generic;

#nullable disable

namespace server.Models
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            Cargos = new HashSet<Cargos>();
            DeparFuncs = new HashSet<DepartamentoFuncionario>();
            DeparGerens = new HashSet<DepartamentoGerencia>();
            Salarios = new HashSet<Salarios>();
        }

        public int Id { get; set; }
        public int FuncionarioNumero { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public DateTime DataContratacao { get; set; }

        public virtual ICollection<Cargos> Cargos { get; set; }
        public virtual ICollection<DepartamentoFuncionario> DeparFuncs { get; set; }
        public virtual ICollection<DepartamentoGerencia> DeparGerens { get; set; }
        public virtual ICollection<Salarios> Salarios { get; set; }
    }
}
