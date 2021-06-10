using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Filters;
using server.Models;
using server.Models.InputModels.EmployeeInputModel;
using server.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using server.Models.ViewModels.Admin;
using server.Repositories;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;



        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
           
        }


        // GET: api/Funcionarios
        [EnableCors("ReactAdmin")]
        [HttpGet]
        [Route("list_employees")]
        [Authorize(Roles = "employee, admin")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetEmployees()
        {

            var res = await _employeeService.GetAll();

            if (res.Count == 0)
            {
                return NoContent();
            }

            Response.Headers.Add("Content-Range", $"funcionarios 0-24/{res.Count}");

            return Ok(res);

        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}", Name ="GetFuncionario")]
        [EnableCors("ReactAdmin")]
        public async Task<ActionResult<Funcionario>> GetEmployee(int id)
        {

            var employee = await _employeeService.Get(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("ReactAdmin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ModelStateValidation]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario employee)
        {
            if (employee is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var employeeEntity = await _employeeService.Add(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = employeeEntity.Id }, employeeEntity);

            }
            //GameAlreadyExistsException
            catch (Exception e)
            {

                return UnprocessableEntity(e.Message);
            }

        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("ReactAdmin")]
        [ModelStateValidation]
        public async Task<IActionResult> PutFuncionario(int id, EmployeeInputModel employee)
        {
   
            try
            {
                await _employeeService.Update(id, employee);
                return Ok();

            }
            //GameDoesNotExistException
            catch (Exception e)
            {
                return NotFound(e);
            }

        }  

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {

            try
            {
                await _employeeService.Delete(id);
                return Ok();
            }

            //GameDoesNotExist
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

    }
}
