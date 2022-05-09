using AutoMapper;
using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;

namespace Loja.Service
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        public FabricanteService(IFabricanteRepository fabricanteRepository, IMapper mapper)
        {
            _fabricanteRepository=fabricanteRepository;
            _mapper=mapper;
        }

        public async void Add(FabricanteModel model)
        {
            var fabricante = _mapper.Map<Fabricantes>(model);
            await _fabricanteRepository.AddAsync(fabricante);
        }

        public async Task<IEnumerable<FabricanteModel>> GetAllAsync()
        {
            var fabricantes = await _fabricanteRepository.GetAsync();
            return _mapper.Map<IEnumerable<FabricanteModel>>(fabricantes);
            

        }
    }
}