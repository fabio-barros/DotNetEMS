
using System.ComponentModel.DataAnnotations;

namespace server.Models.InputModels.User

{
    public class SignInInputModel
    {
        [Required(ErrorMessage = "Login field is required.", AllowEmptyStrings = false)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }

    }
}
