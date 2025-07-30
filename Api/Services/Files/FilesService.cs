
using System.IO;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;

namespace Api.Services.Files;

public class FilesService : IFilesService
{
  public async Task<ResultClass<byte[]>> AddFile(IFormFile uploadedPdf)
  {
    var result = new ResultClass<byte[]>
    {
      MessageKey = new List<string>(),
    };

    using var inputStream = uploadedPdf.OpenReadStream();
    var reader = new PdfReader(inputStream);

    using var outputStream = new MemoryStream();
    using var stamper = new PdfStamper(reader, outputStream);
    try
    {
      // var app = new Acrobat.AcroApp();
      // var avDoc = new Acrobat.AcroAVDoc();
      // bool opened = avDoc.Open(@"C:\Forms\form.pdf", "My PDF");
      // if (opened)
      // {
      //   var pdDoc = (Acrobat.AcroPDDoc)avDoc.GetPDDoc();
      //   var jsObject = (Acrobat.AcroJSObject)pdDoc.GetJSObject();

      //   // Run JavaScript to fill form
      //   jsObject.Run("this.getField('name').value = 'Farzin';");

      //   pdDoc.Save(1, @"C:\Forms\filled_form.pdf");

      //   avDoc.Close(true);
      //   app.Exit();
      //}
    }
    catch (System.Exception ex)
    {
      result.MessageKey.Add(ex.Message);
    }

    stamper.Close();
    reader.Close();

    return result;

  }
}