using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models.ViewModels.Admin;

namespace server.Repositories
{
    public class UserRepo
    {
        public static User Get(string username, string role)
        {
            var users = new List<User>();
            users.Add(new User {Id = 1, Username = "jorge", Role = "employee"});
            users.Add(new User {Id = 1, Username = "luiz", Role = "admin"});
            return users.Where(x => x.Username.ToLower() == username && x.Role.ToLower() == role).First();
        }

    }
}
