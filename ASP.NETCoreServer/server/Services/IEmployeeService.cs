using server.Models;
using server.Models.InputModels.EmployeeInputModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IEmployeeService : IGeneralService<Funcionario>
    {
        Task<List<Funcionario>> GetAll();

        Task<Funcionario> Get(int id);

        Task<Funcionario> Add(Funcionario entity);

        Task Update(int id, EmployeeInputModel entity);

    }
}
