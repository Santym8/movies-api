using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.api.Models;

namespace Movies.api.Auth
{
    public interface IJwtUtils
    {
        string CreateToken(User user);
        int? ValidateToken(string token);

    }
}