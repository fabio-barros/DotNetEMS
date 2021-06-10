using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Models.InputModels.EmployeeInputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class EmployeeService : GeneralService<Funcionario>, IEmployeeService
    {

        public EmployeeService(EmsContext context) : base(context)
        {
        }

        public  async Task<List<Funcionario>> GetAll()
        {
            var res = await Context.Funcionarios.OrderByDescending(funcionario => funcionario.Id).ToListAsync();
            foreach (var funcionario in res)
            {
                funcionario.Salarios = await Context.Salarios.Where(x => x.FuncionarioNumero == funcionario.Id).ToListAsync();
                funcionario.Cargos = await Context.Cargos.Where(x => x.FuncionarioNumero == funcionario.Id).ToListAsync();
                Context.DeparFuncs.Include(dp => dp.Departamentos);
                //funcionario.DeparFuncs = await Context.DeparFuncs.Where(x => x.FuncionarioNumero == funcionario.Id).ToListAsync();

            }

            return res;
        }

        public  async Task<Funcionario> Get(int id)
        {
            var funcionario = await Context.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Id == id);
            funcionario.Salarios = await Context.Salarios.Where(x => x.FuncionarioNumero == id).ToListAsync();
            funcionario.Cargos = await Context.Cargos.Where(x => x.FuncionarioNumero == id).ToListAsync();

            return funcionario;
        }

        public  async Task<Funcionario> Add(Funcionario funcionario)
        {
            var entity =  Context.Funcionarios.Any(e => e.Cpf == funcionario.Cpf);

            if (entity)
            {
                throw new Exception("Employee already exists");
            }

            Context.Funcionarios.Add(funcionario);
            
            await Context.SaveChangesAsync();

            return await Context.Funcionarios.FirstOrDefaultAsync(x => x.Cpf == funcionario.Cpf);
        }

        public async Task Update(int id, EmployeeInputModel funcionario)
        {
            var entity = await Context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception("Employee does not exist");
            }



            Context.Entry(entity).CurrentValues.SetValues(funcionario);

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException )
            {
                throw;
            }
        }

        private bool EmployeeExists(int id)
        {
           return Context.Funcionarios.Any(e => e.FuncionarioNumero == id);
        }

        //public EmsContext EmsContext
        //{
        //    get { return Context; }
        //}

    }


}
