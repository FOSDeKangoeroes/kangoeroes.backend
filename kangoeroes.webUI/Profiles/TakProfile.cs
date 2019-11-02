﻿using AutoMapper;
using kangoeroes.core.Models;
using kangoeroes.webUI.DTOs.TakViewModels;

namespace kangoeroes.webUI.Profiles
{
  public class TakProfile : Profile
  {
    public TakProfile()
    {
      CreateMap<AddTakViewModel, Tak>();
      CreateMap<UpdateTakViewModel, Tak>();
      CreateMap<Tak, BasicTakViewModel>();
    }
  }
}
