﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Models.ViewModels.Adjectief;

namespace kangoeroes.leidingBeheer.Services.TotemServices
{
  public class AdjectiefService
  {
    public IAdjectiefRepository _adjectiefRepository;
    private readonly IMapper _mapper;

    public AdjectiefService(IAdjectiefRepository adjectiefRepository, IMapper mapper)
    {
      _adjectiefRepository = adjectiefRepository;
      _mapper = mapper;
    }

    public IEnumerable<BasicAdjectiefViewModel> FindAll()
    {
      var result = _adjectiefRepository.FindAll();

      return _mapper.Map<IEnumerable<BasicAdjectiefViewModel>>(result);
    }

    public async Task<BasicAdjectiefViewModel> FindByIdAsync(int id)
    {
      var result = await _adjectiefRepository.FindByIdAsync(id);

      if (result == null)
      {
        throw new EntityNotFoundException($"Adjectief met id {id} werd niet gevonden");

      }

      return _mapper.Map<BasicAdjectiefViewModel>(result);
    }
  }
}
