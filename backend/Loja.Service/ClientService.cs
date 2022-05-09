using AutoMapper;
using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;
using Loja.Infra.Data.Repository;

namespace Loja.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository=clientRepository;
            _mapper=mapper;
        }

        public async void Add(ClientModel model)
        {
            var client = _mapper.Map<Clients>(model);
            await _clientRepository.AddAsync(client);
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAsync();
            return _mapper.Map<IEnumerable<ClientModel>>(clients);

        }
    }
}
