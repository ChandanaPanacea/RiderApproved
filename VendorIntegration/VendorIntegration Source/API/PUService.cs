// Decompiled with JetBrains decompiler
// Type: VendorIntegration.API.PUService
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using VendorIntegration.DAC;
using VendorIntegration.Exceptions;

#nullable disable
namespace VendorIntegration.API;

internal static class PUService
{
  public static Dictionary<string, string> GetFileContents(
    ACVIImportItemProcessRecords record,
    IEnumerable<string> fileNames)
  {
    RestClient restClient = new RestClient(new RestClientOptions(record.APIEndpoint)
    {
      MaxTimeout = 300000
    }, (Action<HttpRequestHeaders>) null);
    RestRequest restRequest = new RestRequest(string.Empty, (Method) 1);
    RestRequestExtensions.AddHeader(restRequest, "Content-Type", "application/json");
    string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{record.APIDealerNumber}/{record.APIUsername}:{record.APIPassword}"));
    RestRequestExtensions.AddHeader(restRequest, "Authorization", "Basic " + base64String);
    RestRequestExtensions.AddStringBody(restRequest, "{}", (DataFormat) 0);
    RestResponse restResponse = restClient.Execute(restRequest);
    byte[] buffer = ((RestResponseBase) restResponse).IsSuccessful ? ((RestResponseBase) restResponse).RawBytes : throw new ACVIHandledException($"API Error {(int) ((RestResponseBase) restResponse).StatusCode} - {((RestResponseBase) restResponse).Content}");
    if (buffer == null || buffer.Length == 0)
      throw new ACVIHandledException("Empty API response");
    Dictionary<string, string> fileContents = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    List<string> list = fileNames.ToList<string>();
    using (MemoryStream memoryStream = new MemoryStream(buffer))
    {
      using (ZipArchive zipArchive = new ZipArchive((Stream) memoryStream, ZipArchiveMode.Read))
      {
        foreach (string str in list)
        {
          string fileName = str;
          ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault<ZipArchiveEntry>((Func<ZipArchiveEntry, bool>) (entry => string.Equals(Path.GetFileName(entry.FullName), fileName, StringComparison.OrdinalIgnoreCase)));
          if (zipArchiveEntry == null)
            throw new ACVIHandledException($"The {fileName} file does note exist");
          using (Stream stream = zipArchiveEntry.Open())
          {
            using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
              fileContents[fileName] = streamReader.ReadToEnd();
          }
        }
      }
    }
    return fileContents;
  }
}
