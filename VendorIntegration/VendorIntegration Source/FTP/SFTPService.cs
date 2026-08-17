// Decompiled with JetBrains decompiler
// Type: VendorIntegration.FTP.SFTPService
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.IO;
using System.Linq;
using System.Text;
using VendorIntegration.Exceptions;

#nullable disable
namespace VendorIntegration.FTP;

internal static class SFTPService
{
  public static SftpClient CreateNewSftpClient(FTPConnectionParameters connection)
  {
    return new SftpClient(connection.Host, connection.Port.Value, connection.Username, connection.Password);
  }

  public static string GetFile(FTPConnectionParameters connection, string fileFullName)
  {
    byte[] fileBytes = SFTPService.GetFileBytes(connection, fileFullName);
    return fileBytes == null ? string.Empty : Encoding.UTF8.GetString(fileBytes);
  }

  public static byte[] GetFileBytes(FTPConnectionParameters connection, string fileFullName)
  {
    if (connection.Host == "-")
      return (byte[]) null;
    string fileName = Path.GetFileName(fileFullName);
    string directoryName = Path.GetDirectoryName(fileFullName);
    string str;
    if (string.IsNullOrEmpty(directoryName))
    {
      str = "/";
    }
    else
    {
      str = directoryName.Replace("\\", "/");
      if (!str.StartsWith("/"))
        str = "/" + str;
    }
    using (SftpClient newSftpClient = SFTPService.CreateNewSftpClient(connection))
    {
      ((BaseClient) newSftpClient).Connect();
      return newSftpClient.ReadAllBytes((newSftpClient.ListDirectory(str, (Action<int>) null).Where<ISftpFile>((Func<ISftpFile, bool>) (x => x.Attributes.IsRegularFile)).ToList<ISftpFile>().FirstOrDefault<ISftpFile>((Func<ISftpFile, bool>) (x => string.Equals(x.Name, fileName, StringComparison.OrdinalIgnoreCase))) ?? throw new ACVIHandledException($"The {fileFullName} file does note exist")).FullName);
    }
  }
}
