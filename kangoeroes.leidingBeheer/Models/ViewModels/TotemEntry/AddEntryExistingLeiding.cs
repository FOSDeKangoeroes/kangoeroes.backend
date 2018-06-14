﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.leidingBeheer.Models.ViewModels.TotemEntry
{
  public class AddEntryExistingLeiding
  {
    [Required]
    public int LeidingId { get; set; }
    [Required]
    public int TotemId { get; set; }
    [Required]
    public int AdjectiefId { get; set; }

    public DateTime DatumGegeven { get; set; }

    public int VoorouderId { get; set; }
  }
}
