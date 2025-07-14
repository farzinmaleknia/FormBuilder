using Api.Models.ResultClass;
using Api.Services.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ResourcesController : ControllerBase
{
  private readonly ResourcesService _resourcesService;

  public ResourcesController(ResourcesService resourcesService)
  {
    _resourcesService = resourcesService;
  }

  [HttpGet]
  public async Task<ActionResult<ResultClass<string>>> GetResources()
  {
    var result = await _resourcesService.GetResources();

    return Ok(result);
  }
}