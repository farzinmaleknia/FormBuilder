using Api.Services.Files;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
  private readonly FilesService _filesService;

  public FilesController(FilesService filesService)
  {
    _filesService = filesService;
  }

  [HttpPost]
  public async Task<ActionResult<ResultClass<bool>>> AddFile([FromBody]IFormFile file)
  {
    var result = await _filesService.AddFile(file);

    return Ok(result);
  }
}