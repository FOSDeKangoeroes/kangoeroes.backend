﻿using System;

namespace kangoeroes.core.DTOs.TotemEntry
{
  public class UpdateTotemEntryDTO
  {
    public int AdjectiefId { get; set; }
    public int TotemId { get; set; }
    public DateTime DatumGegeven { get; set; }
    public int VoorouderId { get; set; }
  }
}
