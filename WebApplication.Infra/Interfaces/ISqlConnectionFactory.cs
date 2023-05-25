using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Infra.Interfaces
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
