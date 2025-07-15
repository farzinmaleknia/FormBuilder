


namespace Api.Services.Files;

public class FilesService : IFilesService
{
  public async Task<ResultClass<bool>> AddFile(IFormFile file)
  {
    var result = new ResultClass<bool>
    {
      MessageKey = new List<string>(),
    };

    Console.WriteLine(file.FileName);

    return result;
    
  }
}