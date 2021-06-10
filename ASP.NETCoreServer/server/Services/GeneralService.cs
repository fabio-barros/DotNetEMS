using Microsoft.EntityFrameworkCore;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class GeneralService<TEntity> : IGeneralService<TEntity> where TEntity : class
    {
        protected readonly EmsContext Context;

        public GeneralService(EmsContext context)
        {
            this.Context = context;
        }

        //public void Update(int id, TEntity entity)
        //{

        //    _context.Entry(funcionario).State = EntityState.Modified;
        //    Context.Entry(entity).cur
        //    Context.Set<TEntity>().upda
        //}

        public async Task Delete(int id)
        {

            var entity = await Context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                throw new Exception();
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        
    }
}
