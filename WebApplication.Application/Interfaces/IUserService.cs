using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Models;

namespace WebApplication.Application.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User user);
    }
}
