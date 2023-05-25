using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Models;

namespace WebApplication.Infra.Interfaces.Repositories
{
    public interface IUserRepository
    {
        int CreateUser(User data);
        User GetUserById(int id);
    }
}
