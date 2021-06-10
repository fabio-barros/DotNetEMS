
using Microsoft.AspNetCore.Mvc;
using server.Filters;
using server.Models.InputModels.User;
using server.Models.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {

        [SwaggerResponse(statusCode: 200, description: "Authentication Success", Type = typeof(SignInInputModel))]
        //[SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(ValidateFieldViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Internal Error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("signin")]
        [ModelStateValidation]
        public IActionResult SignIn(SignInInputModel signInInInputModel)
        {
            return Ok(signInInInputModel);
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
