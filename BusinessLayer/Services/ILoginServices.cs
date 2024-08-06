using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ILoginServices
    {
        Task<LoginClass> AuthenticateLoginAsync(LoginClass loginClass);
        Task<Result> RegisterAsync(LoginClass loginClass);
    }
}
