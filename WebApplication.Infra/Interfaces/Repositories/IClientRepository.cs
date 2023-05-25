using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Models;

namespace WebApplication.Infra.Interfaces.Repositories
{
    public interface IClientRepository
    {
        int CreateClient(Client data);
        Client GetClientById(int id);
    }
}
