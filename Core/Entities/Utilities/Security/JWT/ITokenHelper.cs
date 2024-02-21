using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
