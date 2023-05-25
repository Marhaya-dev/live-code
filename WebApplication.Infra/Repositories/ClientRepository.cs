using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Models;
using WebApplication.Infra.Interfaces;

namespace WebApplication.Infra.Repositories
{
    public class ClientRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public ClientRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int CreateClient(Client data)
        {
            try
            {
                using (var conn = _connectionFactory.GetConnection())
                {
                    conn.Open();

                    var qry = $@"INSERT INTO CLIENTS (
                            email,
                            name
                         ) 
                        VALUES (
                            @{nameof(data.Email)},
                            @{nameof(data.Name)}
                         );

                        SELECT SCOPE_IDENTITY() AS IdGerado;";

                    var response = conn.Execute(qry, data);

                    return response;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Database Error: {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir o cliente. Error: {ex}");
            }
        }

        public Client GetClientById(int id)
        {
            try
            {
                using (var conn = _connectionFactory.GetConnection())
                {
                    conn.Open();

                    var qry = $@"SELECT * FROM CLIENTS WHERE ID = @ID";

                    var response = conn.QueryFirst(qry, new
                    {
                        ID = id
                    });

                    return response;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Database Error: {ex}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível obter o cliente. Error: {ex}");
            }
        }
    }
}
