using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IGeneralService<TEntity> where TEntity : class
    {

        Task Delete(int id);

    }
}
