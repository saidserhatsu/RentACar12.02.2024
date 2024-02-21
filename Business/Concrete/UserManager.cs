using Business.Abstract;
using Business.Requests.User;
using Core.Entities;
using Core.Entities.Utilities.Security.Hashing;
using Core.Entities.Utilities.Security.JWT;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserDAl _userDal;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUserDAl userDal)
        {
            _userDal = userDal;
        }

        public AccessToken Login(LoginRequest request)
        {
          User? user=_userDal.Get(i=>i.Email==request.Email);
            //business rules

            bool isPasswordCorrect=HashingHelper.VerifyPassword(request.Password,user.PasswordHash,user.PasswordSalt);
            if (!isPasswordCorrect)
                throw new Exception("şifre yanlış.");
            return _tokenHelper.CreateToken(user);
            
        }

        public void Register(RegisterRequest request)
        {
            //Manual Mapping
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);

            User user = new User();
            user.Email= request.Email;
            user.Approved = false;
            user.PasswordSalt= passwordSalt;
            user.PasswordHash= passwordHash;
            user.FirstName= request.FirstName;
            user.LastName= request.LastName;

            _userDal.Add(user);
        }
    }
}
