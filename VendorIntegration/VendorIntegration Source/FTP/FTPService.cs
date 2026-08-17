// Decompiled with JetBrains decompiler
// Type: VendorIntegration.FTP.FTPService
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using VendorIntegration.Exceptions;

#nullable disable
namespace VendorIntegration.FTP;

public static class FTPService
{
  public static string GetFile(FTPConnectionParameters connection, string fileFullName)
  {
    byte[] fileBytes = FTPService.GetFileBytes(connection, fileFullName);
    return fileBytes == null ? string.Empty : Encoding.UTF8.GetString(fileBytes);
  }

  public static byte[] GetFileBytes(FTPConnectionParameters connection, string fileFullName)
  {
    byte[] fileBytes = (byte[]) null;
    if (connection.Host != "-")
    {
      string fileName = Path.GetFileName(fileFullName);
      string directoryName = Path.GetDirectoryName(fileFullName);
      string requestUriString = $"ftp://{connection.Host}:{connection.Port.Value.ToString()}/";
      if (!string.IsNullOrEmpty(directoryName))
        requestUriString = $"{requestUriString}{directoryName}/";
      FtpWebRequest ftpWebRequest1 = (FtpWebRequest) WebRequest.Create(requestUriString);
      ftpWebRequest1.Method = "NLST";
      ftpWebRequest1.KeepAlive = true;
      ftpWebRequest1.Credentials = (ICredentials) new NetworkCredential(connection.Username, connection.Password);
      using (FtpWebResponse response = (FtpWebResponse) ftpWebRequest1.GetResponse())
      {
        using (Stream responseStream = response.GetResponseStream())
        {
          using (StreamReader streamReader = new StreamReader(responseStream))
          {
            if (!((IEnumerable<string>) streamReader.ReadToEnd().Split(new string[2]
            {
              "\r\n",
              "\n"
            }, StringSplitOptions.RemoveEmptyEntries)).Any<string>((Func<string, bool>) (x => string.Equals(Path.GetFileName(x), fileName, StringComparison.OrdinalIgnoreCase))))
              throw new ACVIHandledException($"The {fileFullName} file does note exist");
          }
        }
      }
      FtpWebRequest ftpWebRequest2 = (FtpWebRequest) WebRequest.Create(requestUriString + fileName);
      ftpWebRequest2.Method = "RETR";
      ftpWebRequest2.Credentials = (ICredentials) new NetworkCredential(connection.Username, connection.Password);
      ftpWebRequest2.KeepAlive = false;
      using (FtpWebResponse response = (FtpWebResponse) ftpWebRequest2.GetResponse())
      {
        using (Stream responseStream = response.GetResponseStream())
        {
          using (MemoryStream destination = new MemoryStream())
          {
            responseStream.CopyTo((Stream) destination);
            fileBytes = destination.ToArray();
          }
        }
      }
    }
    return fileBytes;
  }
}
