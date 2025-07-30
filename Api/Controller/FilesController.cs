using Api.Services.Files;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
  private readonly IFilesService _filesService;

  public FilesController(IFilesService filesService)
  {
    _filesService = filesService;
  }

  [HttpPost]
  public async Task<ActionResult<ResultClass<byte[]>>> AddFile(IFormFile file)
  {
    var result = await _filesService.AddFile(file);

    return Ok(result);
  }
}