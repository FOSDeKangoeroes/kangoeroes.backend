﻿using System;
using System.ComponentModel.DataAnnotations;

namespace kangoeroes.core.DTOs.Leader
{
    public class CreateLeaderDTO
    {
        public CreateLeaderDTO(string naam, string voornaam, int takId)
        {
            Naam = naam;
            Voornaam = voornaam;
            TakId = takId;
        }

        [Required(ErrorMessage = "{0} is verplicht.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "{0} moet minstens {2} karakter(s) lang zijn.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "{0} is verplicht.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "{0} moet minstens {2} karakter(s) lang zijn.")]
        public string Voornaam { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "{0} moet een emailadres zijn")]
        public string Email { get; set; }

        [DataType(DataType.Date, ErrorMessage = "{0 moet een datum zijn.}")]
        public DateTime LeidingSinds { get; set; }

        [DataType(DataType.Date, ErrorMessage = "{0 moet een datum zijn.}")]
        public DateTime DatumGestopt { get; set; }

        [Display(Name = "Tak")]
        public int TakId { get; set; }

        [Display(Name = "Rekeningen maken")]
        public bool CreateAccounts { get; set; } = false;
    }
}
