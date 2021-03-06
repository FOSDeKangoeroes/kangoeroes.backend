﻿using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Tab.DrinkType
{
  /// <summary>
  /// Representatie van data nodig om een nieuw dranktype aan te maken.
  /// </summary>
  public class UpdateDrinkTypeDTO
  {
    /// <summary>
    /// Naam van het toe te voegen type
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public string Naam { get; set; }
  }
}
