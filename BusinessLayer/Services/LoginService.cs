using DataAccessLayer.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LoginService : ILoginServices
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<LoginClass> AuthenticateLoginAsync(LoginClass loginClass)
        {
            var user = await _loginRepository.GetLoginClassesAsync(loginClass);
            if (user == null)
            {
                return null;
            }
            else 
            {
                return user;
            }
        }
        public async Task<Result> RegisterAsync(LoginClass loginClass)
        {
            var existingUser = await _loginRepository.GetLoginClassesAsync(loginClass);

            if (existingUser == null)
            {
                var newUser = await _loginRepository.CreateUser(loginClass);
                return new Result { Success = true, Data = newUser };
            }
            else
            {
                return new Result { Success = false, ErrorMessage = "User already exists." };
            }
        }

    }
}
