// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIFTPSetup
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.AP;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVIFTPSetup : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXDBIdentity]
  public virtual int? SetupID { get; set; }

  [PXDBString(3, IsUnicode = true, InputMask = "", IsKey = true)]
  [PXUIField(DisplayName = "Vendor")]
  [PXStringList(new string[] {"HH", "KL", "KYT", "LEA", "LS2", "ON", "SMK"}, new string[] {"Helmet House", "Klim", "Kyt Americas", "Leatt", "LS2 Dealers", "Oneal", "SMK Helmets"})]
  [PXDefault]
  public virtual 
  #nullable disable
  string VendorType { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Vendor ID")]
  [PXSelector(typeof (Vendor.bAccountID), SubstituteKey = typeof (Vendor.acctCD))]
  [PXDefault]
  public virtual int? VendorID { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Host")]
  [PXDefault]
  public virtual string Host { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Username")]
  [PXDefault]
  public virtual string Username { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Password")]
  [PXDefault]
  public virtual string Password { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Port")]
  [PXDefault]
  public virtual int? Port { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "File full name")]
  [PXDefault]
  public virtual string FileName { get; set; }

  [PXDBCreatedByID]
  public virtual Guid? CreatedByID { get; set; }

  [PXDBCreatedByScreenID]
  public virtual string CreatedByScreenID { get; set; }

  [PXDBCreatedDateTime]
  public virtual DateTime? CreatedDateTime { get; set; }

  [PXDBLastModifiedByID]
  public virtual Guid? LastModifiedByID { get; set; }

  [PXDBLastModifiedByScreenID]
  public virtual string LastModifiedByScreenID { get; set; }

  [PXDBLastModifiedDateTime]
  public virtual DateTime? LastModifiedDateTime { get; set; }

  [PXDBTimestamp]
  [PXUIField(DisplayName = "Tstamp")]
  public virtual byte[] Tstamp { get; set; }

  [PXNote]
  public virtual Guid? Noteid { get; set; }

  public abstract class setupID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIFTPSetup.setupID>
  {
  }

  public abstract class vendorType : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVIFTPSetup.vendorType>
  {
  }

  public abstract class vendorID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIFTPSetup.vendorID>
  {
  }

  public abstract class host : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVIFTPSetup.host>
  {
  }

  public abstract class username : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVIFTPSetup.username>
  {
  }

  public abstract class password : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVIFTPSetup.password>
  {
  }

  public abstract class port : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIFTPSetup.port>
  {
  }

  public abstract class fileName : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVIFTPSetup.fileName>
  {
  }

  public abstract class createdByID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVIFTPSetup.createdByID>
  {
  }

  public abstract class createdByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIFTPSetup.createdByScreenID>
  {
  }

  public abstract class createdDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACVIFTPSetup.createdDateTime>
  {
  }

  public abstract class lastModifiedByID : 
    BqlType<
    #nullable enable
    IBqlGuid, Guid>.Field<
    #nullable disable
    ACVIFTPSetup.lastModifiedByID>
  {
  }

  public abstract class lastModifiedByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIFTPSetup.lastModifiedByScreenID>
  {
  }

  public abstract class lastModifiedDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACVIFTPSetup.lastModifiedDateTime>
  {
  }

  public abstract class tstamp : BqlType<
  #nullable enable
  IBqlByteArray, byte[]>.Field<
  #nullable disable
  ACVIFTPSetup.tstamp>
  {
  }

  public abstract class noteid : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVIFTPSetup.noteid>
  {
  }
}
