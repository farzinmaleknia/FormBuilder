namespace Api.Services.Files;

public interface IFilesService
{
  public Task<ResultClass<bool>> AddFile(IFormFile file);
}