using Microsoft.EntityFrameworkCore;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class PositionService : GeneralService<Cargo>, IPositionService
    {

        public PositionService(EmsContext context) : base(context)
        {
        }

        //public override async Task<List<Cargo>> GetAll()
        //{
        //    //var res = await Context.Funcionarios.OrderByDescending(funcionario => funcionario.Id).ToListAsync();
        //    //foreach (var funcionario in res)
        //    //{
        //    //    funcionario.Salarios = await Context.Salarios.Where(x => x.FuncionarioNumero == funcionario.FuncionarioNumero).ToListAsync();
        //    //    funcionario.Cargos = await Context.Cargos.Where(x => x.FuncionarioNumero == funcionario.FuncionarioNumero).ToListAsync();
        //    //    funcionario.DeparFuncs = await Context.DeparFuncs.Where(x => x.FuncionarioNumero == funcionario.FuncionarioNumero).ToListAsync();

        //    //}

        //    //return res;
        //}

        //public EmsContext EmsContext
        //{
        //    get { return Context; }
        //}

    }


}