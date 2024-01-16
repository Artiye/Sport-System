using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Utility.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateJwtToken(IdentityUser user, List<string> roles);
    }
}
