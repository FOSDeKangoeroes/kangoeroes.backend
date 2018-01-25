﻿using System;

namespace kangoeroes.leidingBeheer.Models.ViewModels.Leiding
{
  public class BasicLeidingViewModel
  {
    public int Id { get; set; }

    public string Auth0Id { get; set; }

    public string Naam { get; set; }

    public string Voornaam { get; set; }

    public string Email { get; set; }

    public DateTime LeidingSinds { get; set; }

    public DateTime DatumGestopt { get; set; }

    public string TakNaam { get; set; }

    public int TakId { get; set; }
  }
}
