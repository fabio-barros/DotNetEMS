using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.InputModels.EmployeeInputModel
{
    public class EmployeeInputModel
    {
        public EmployeeInputModel()
        {
            Cargos = new HashSet<Cargo>();
            DeparFuncs = new HashSet<DepartamentoFuncionario>();
            DeparGerens = new HashSet<DepartamentoGerencia>();
            Salarios = new HashSet<Salarios>();
        }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Name length must be up to 15 characters long")]
        public string Nome { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Sobrenome length must be up to 15 characters long")]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cpf length must be 11 characters long")]
        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Genero length must be 1 character long")]
        public string Genero { get; set; }
        public DateTime DataContratacao { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<DepartamentoFuncionario> DeparFuncs { get; set; }
        public virtual ICollection<DepartamentoGerencia> DeparGerens { get; set; }
        public virtual ICollection<Salarios> Salarios { get; set; }
    }
}
