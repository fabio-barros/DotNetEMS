
using System;
using Microsoft.AspNetCore.Mvc;
using server.Filters;
using server.Models.InputModels.User;
using server.Models.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using server.Models.ViewModels.Admin;
using server.Services;
using System.Threading.Tasks;
using server.Repositories;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AdminController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        //Auth
        [SwaggerResponse(statusCode: 200, description: "Authentication Success", Type = typeof(User))]
        [SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(ValidateModelFields))]
        [SwaggerResponse(statusCode: 500, description: "Internal Error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("signin")]
        [ModelStateValidation]
        public async Task<ActionResult<dynamic>> Auth([FromBody] User user)
        {
            var userEntity = UserRepo.Get(user.Username, user.Role);
            var token = _tokenService.GenerateToken(userEntity);
            userEntity.Password = "";
            return new
            {
                User = userEntity,
                Token = token
            };
        }

        [HttpPost]
        [Route("signup")]
        [ModelStateValidation]
        public IActionResult SignUp(SignUpInputModel signUpInputModel)
        {


            return Created("", signUpInputModel);
        }
    }
}
