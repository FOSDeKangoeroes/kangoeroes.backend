﻿using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using kangoeroes.core.Models.Totems;
using kangoeroes.webUI.Data.Context;
using kangoeroes.webUI.Data.Repositories.TotemsRepositories.Interfaces;
using kangoeroes.webUI.Helpers;
using kangoeroes.webUI.Helpers.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.webUI.Data.Repositories.TotemsRepositories
{
  public class TotemRepository : BaseRepository<Totem>, ITotemRepository
  {
    private readonly DbSet<Totem> _totems;

    public TotemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _totems = dbContext.Totems;
    }

    public override PagedList<Totem> FindAll(ResourceParameters resourceParameters)
    {
      var result = GetAllWithAllIncluded();

      var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

      if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
        result = result.Where(x => x.Naam.Contains(resourceParameters.Query));


      if (!string.IsNullOrWhiteSpace(sortString)) result = result.OrderBy(sortString);

      var pagedList = PagedList<Totem>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

      return pagedList;
    }

    public override Task<Totem> FindByIdAsync(int id)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Totem> FindByNaamAsync(string naam)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Naam == naam);
    }

    public Task<Totem> TotemExists(string naam)
    {
      return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Matches(naam));
    }

    private IQueryable<Totem> GetAllWithAllIncluded()
    {
      return _totems;
    }
  }
}
