using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.InputModels.User

{
    public class SignUpInputModel
    {
        [Required(ErrorMessage = "Login field is required.")] 
        public string Login { get; set; }

        [Required(ErrorMessage = "Email field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }


    }
}
