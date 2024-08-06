using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ILoginRepository
    {
        Task<LoginClass> GetLoginClassesAsync(LoginClass loginClass);
        Task<LoginClass> CreateUser(LoginClass loginClass);
    }
}
