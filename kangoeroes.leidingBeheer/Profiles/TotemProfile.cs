﻿using AutoMapper;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.ViewModels.TotemViewModels;

namespace kangoeroes.leidingBeheer.Profiles
{
  public class TotemProfile : Profile
  {
    public TotemProfile()
    {
      CreateMap<Totem, BasicTotemViewModel>();
      CreateMap<AddTotemViewModel, Totem>();
    }
  }
}