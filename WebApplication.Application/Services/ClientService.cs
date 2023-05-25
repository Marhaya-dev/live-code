using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Models;
using WebApplication.Infra.Interfaces.Repositories;

namespace WebApplication.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client CreateClient(Client data)
        {
            var id = _clientRepository.CreateClient(data);

            var client = _clientRepository.GetClientById(id);

            return client;
        }


    }
}
