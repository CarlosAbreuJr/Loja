using AutoMapper;
using Loja.Domain.Entities;
using Loja.Domain.Interface.Repositories;
using Loja.Domain.Interface.Service;
using Loja.Domain.Models;

namespace Loja.Service
{
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMapper _mapper;
        public GrupoService(IGrupoRepository grupoRepository, IMapper mapper)
        {
            _grupoRepository=grupoRepository;
            _mapper=mapper;
        }

        public void Add(GrupoModel model)
        {
            var grupo = _mapper.Map<Grupos>(model);

            _grupoRepository.AddAsync(grupo);
        }

        public async Task<IEnumerable<GrupoModel>> GetAll()
        {
            var grupos = await _grupoRepository.GetAsync();
            return _mapper.Map<IEnumerable<GrupoModel>>(grupos);
        }
    }
}