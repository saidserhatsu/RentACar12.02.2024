using Azure.Core;
using Business.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {

        void Register(RegisterRequest request);
        AccessToken Login(LoginRequest request); // Todo:return type:JWT
    }
}
