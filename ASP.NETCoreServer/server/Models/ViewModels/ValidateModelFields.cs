using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.ViewModels
{
    public class ValidateModelFields
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidateModelFields(IEnumerable<string> errors)
        {
            Errors = errors;
        }
        
    }

}
