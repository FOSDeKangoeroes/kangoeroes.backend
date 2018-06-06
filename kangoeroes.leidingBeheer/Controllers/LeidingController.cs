﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using AutoMapper;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Filters;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Responses;
using kangoeroes.leidingBeheer.Models.ViewModels.Leiding;
using kangoeroes.leidingBeheer.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;


namespace kangoeroes.leidingBeheer.Controllers
{
  [Route("/api/[controller]")]
  [ApiValidationFilter]
 [Authorize(Roles = "financieel_verantwoordelijke")]
  public class LeidingController : Controller
  {
    private readonly ILeidingRepository _leidingRepository;
    private readonly ITakRepository _takRepository;
    private readonly IMapper _mapper;
    private readonly IAuth0Service _auth0Service;
    private readonly IConfiguration _configuration;

    public LeidingController(ILeidingRepository leidingRepository, ITakRepository takRepository, IMapper mapper,
      IAuth0Service auth0Service, IConfiguration configuration)
    {
      _leidingRepository = leidingRepository;
      _takRepository = takRepository;
      _mapper = mapper;
       _auth0Service = auth0Service;
      _configuration = configuration;
    }

    /// <summary>
    /// Geeft alle leiding terug
    /// </summary>
    /// <returns></returns>
    [HttpGet] //GET /api/leiding
    public IActionResult Index([FromQuery] LeidingResourceParameters resourceParameters)
    {

      var leiding = _leidingRepository.FindAll(resourceParameters);

      var paginationMetaData = new
      {
        totalCount = leiding.TotalCount,
        pageSize = leiding.PageSize,
        currentPage = leiding.CurrentPage,
        totalPages = leiding.TotalPages,

      };

      Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(paginationMetaData));

      var viewModels = _mapper.Map<IEnumerable<BasicLeidingViewModel>>(leiding);
      return Ok(viewModels);

    }

    [HttpGet("{id}",Name = "GetLeidingById")] //GET /api/leiding/id
   // [Authorize(Roles = "financieel_verantwoordelijke")]
    public IActionResult GetById([FromRoute] int id)
    {


      var leiding = _leidingRepository.FindById(id);

      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Leiding met id {id} werd niet gevonden"));
      }

      return Ok(model);
    }

    [HttpPost] //POST api/leiding
    public IActionResult AddLeiding([FromBody] AddLeidingViewModel viewmodel)
    {
      var tak = _takRepository.FindById(viewmodel.TakId);
      if (tak == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven tak met id {viewmodel.TakId} werd niet gevonden"));
      }

      Leiding leiding = new Leiding();
      leiding = MapToLeiding(leiding, tak, viewmodel);
      _leidingRepository.Add(leiding);
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return CreatedAtRoute(leiding.Id, model);
    }

    [HttpPut] //PUT api/leiding
    [Route("{id}")]
    public IActionResult UpdateLeiding([FromRoute] int id, [FromBody] UpdateLeidingViewModel viewmodel)
    {
      var leiding = _leidingRepository.FindById(id);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {id} werd niet gevonden"));
      }

      leiding = _mapper.Map(viewmodel, leiding);
      leiding.DatumGestopt = viewmodel.DatumGestopt.ToLocalTime();
      leiding.LeidingSinds = viewmodel.LeidingSinds.ToLocalTime();
      _leidingRepository.Update(leiding);
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return Ok(model);
    }

    [Route("{leidingId}/tak")]
    [HttpPut]
    public IActionResult ChangeTak([FromRoute] int leidingId, [FromBody] ChangeTakViewModel viewModel)
    {
      var leiding = _leidingRepository.FindById(leidingId);
      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      var newTak = _takRepository.FindById(viewModel.NewTakId);
      if (newTak == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven tak met id {viewModel.NewTakId} werd niet gevonden"));

      }


      leiding.Tak = newTak;
      _leidingRepository.Update(leiding);
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);

      return Ok(model);
    }

    [Route("{leidingId}/user")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromRoute] int leidingId)
    {
      var leiding = _leidingRepository.FindById(leidingId);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "De gebruiker heeft geen emailadres. Kan geen gebruiker maken zonder email");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }



      try
      {
        var userModel = await _auth0Service.MakeNewUserFor(leiding.Email);
      leiding.Auth0Id = userModel.UserId;
      _leidingRepository.SaveChanges();
      var model = _mapper.Map<BasicLeidingViewModel>(leiding);
      return CreatedAtRoute("GetLeidingById",new {id = model.Id},model);
      }
      catch (ApiException ex)
      {
        ModelState.AddModelError("auth0Exception",ex.Message);
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

    }

    [HttpGet("{leidingId}/roles")]
    public IActionResult GetRolesForUser([FromRoute] int leidingId)
    {
      var leiding = _leidingRepository.FindById(leidingId);


      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoAccount",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      return Ok(_auth0Service.GetAllRolesForUser(leiding.Auth0Id));
    }

    [HttpPatch("{leidingId}/roles/{roleId}")]
    public IActionResult AddRoleToUser([FromRoute] int leidingId, [FromRoute] string roleId)
    {
      var leiding = _leidingRepository.FindById(leidingId);


      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoAccount",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

       var success = _auth0Service.AddRoleToUser(leiding.Auth0Id, roleId);

      return Ok(success);
    }

    [HttpDelete("{leidingId}/roles/{roleId}")]
    public IActionResult RemoveRoleFromUser([FromRoute] int leidingId, [FromRoute] string roleId)
    {
      var leiding = _leidingRepository.FindById(leidingId);

      if (leiding == null)
      {
        return NotFound(new ApiResponse(404, $"Opgegeven leiding met id {leidingId} werd niet gevonden"));
      }

      if (leiding.Email == null)
      {
        ModelState.AddModelError("NoEmail",
          "Deze leiding heeft geen emailadres. Deze gebruiker kan geen account hebben.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      if (string.IsNullOrEmpty(leiding.Auth0Id))
      {
        ModelState.AddModelError("NoAccount",
          "Deze leiding heeft nog geen account. Maak eerst een account aan.");
        return BadRequest(new ApiBadRequestResponse(ModelState));
      }

      var success = _auth0Service.RemoveRoleFromUser(leiding.Auth0Id, roleId);

      return Ok(success);
    }
    private static Leiding MapToLeiding(Leiding leiding, Tak tak, AddLeidingViewModel viewModel)
    {
      leiding.Auth0Id = viewModel.Auth0Id;
      leiding.DatumGestopt = viewModel.DatumGestopt.ToLocalTime();
      if (viewModel.Email != null && viewModel.Email.Trim() != "")
      {
        leiding.Email = viewModel.Email;
      }

      leiding.LeidingSinds = viewModel.LeidingSinds.ToLocalTime();
      leiding.Naam = viewModel.Naam;
      leiding.Voornaam = viewModel.Voornaam;
      leiding.Tak = tak;

      return leiding;

    }




  }
}
