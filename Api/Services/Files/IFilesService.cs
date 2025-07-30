namespace Api.Services.Files;

public interface IFilesService
{
  public Task<ResultClass<byte[]>> AddFile(IFormFile file);
}