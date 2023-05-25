using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Models;
using WebApplication.Infra.Interfaces;
using WebApplication.Infra.Interfaces.Repositories;

namespace WebApplication.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int CreateUser(User data)
        {
            try
            {
                using (var conn = _connectionFactory.GetConnection())
                {
                    conn.Open();

                    var qry = $@"INSERT INTO USERS (
                            email,
                            password,
                            name
                         ) 
                        VALUES (
                            @{nameof(data.Email)},
                            @{nameof(data.Password)},
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
                throw new Exception($"Não foi possível inserir o usuário. Error: {ex}");
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                using (var conn = _connectionFactory.GetConnection())
                {
                    conn.Open();

                    var qry = $@"SELECT * FROM USERS WHERE ID = @ID";

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
                throw new Exception($"Não foi possível obter o usuário. Error: {ex}");
            }
        }

    }
}
