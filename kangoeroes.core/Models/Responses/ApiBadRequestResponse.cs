﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace kangoeroes.core.Models.Responses
{
  public class ApiBadRequestResponse {
    public IEnumerable<string> Errors { get; }

    public ApiBadRequestResponse(ModelStateDictionary modelState) 
    {
      if (modelState.IsValid)
      {
        throw  new ArgumentException("ModelState must be invalid.",nameof(modelState));
      }

      Errors = modelState.SelectMany(x => x.Value.Errors).Select(x =>  x.ErrorMessage
        ).ToArray();

    }
  }
}
