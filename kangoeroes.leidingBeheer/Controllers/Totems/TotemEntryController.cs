﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Exceptions;
using kangoeroes.leidingBeheer.Models.ViewModels.TotemEntry;
using kangoeroes.leidingBeheer.Services.TotemServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer.Controllers.Totems
{
  [Route("api/[controller]")]
  public class TotemEntryController : ControllerBase
  {
    private readonly ITotemEntryService _totemEntryService;
    private readonly IMapper _mapper;

    public TotemEntryController(ITotemEntryService totemEntryService, IMapper mapper)
    {
      _totemEntryService = totemEntryService;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll(ResourceParameters resourceParameters)
    {
      var totemEntries = _totemEntryService.FindAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = totemEntries.TotalCount,
        pageSize = totemEntries.PageSize,
        currentPage = totemEntries.CurrentPage,
        totalPages = totemEntries.TotalPages,

      };

      var model = _mapper.Map<IEnumerable<BasicTotemEntryViewModel>>(totemEntries);

      Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(paginationMetaData));
      return Ok(model);
    }

    [HttpGet("{id}", Name = "GetEntryById")]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {
      try
      {
        var entry = await _totemEntryService.FindByIdAsync(id);
        return Ok(entry);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
    }


    [HttpPost]
    public async Task<IActionResult> AddEntry([FromBody] AddEntryExistingLeiding viewmodel)
    {
      try
      {
        var newEntry = await _totemEntryService.AddEntryAsync(viewmodel);

        return CreatedAtRoute("GetEntryById", new {id = newEntry.Id}, newEntry);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }
      catch (EntityExistsException e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost("{totemEntryId}/parent/{voorouderEntryId}")]
    public async Task<IActionResult> AddVoorouder(int totemEntryId, int voorouderEntryId)
    {
      try
      {
        var model = await _totemEntryService.AddVoorOuderAsync(totemEntryId, voorouderEntryId);
        return Ok(model);
      }
      catch (EntityNotFoundException e)
      {
        return NotFound(e.Message);
      }

    }
  }
}