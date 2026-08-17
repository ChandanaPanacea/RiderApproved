// Decompiled with JetBrains decompiler
// Type: VendorIntegration.FTP.FTPConnectionParameters
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

#nullable disable
namespace VendorIntegration.FTP;

public struct FTPConnectionParameters
{
  public string Username { get; set; }

  public string Password { get; set; }

  public string Host { get; set; }

  public int? Port { get; set; }
}
