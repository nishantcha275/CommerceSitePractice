using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public readonly ApplicationDbContext _Context;
        public LoginRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<LoginClass> GetLoginClassesAsync(LoginClass loginClass)
        {
            return await _Context.LoginClasses.FirstOrDefaultAsync(x => x.Username == loginClass.Username && x.Password == loginClass.Password);
        }
        public async Task<LoginClass> CreateUser(LoginClass loginClass)
        {
            await _Context.AddAsync(loginClass);
            await _Context.SaveChangesAsync();
            return loginClass;
        }


    }
}
