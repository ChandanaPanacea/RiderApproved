// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIWarehouseSetup
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.IN;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVIWarehouseSetup : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXDBIdentity]
  public virtual int? SetupID { get; set; }

  [PXDBString(4, IsUnicode = true, InputMask = "", IsKey = true)]
  [PXUIField(DisplayName = "Type")]
  [PXStringList(new string[] {"HHW", "HHE", "KYT", "LEA", "LS2", "KLW", "KLE", "ON", "SMK", "PUCA", "PUNC", "PUNV", "PUNY", "PUTX", "PUWI", "WPCA", "WPGA", "WPID", "WPIN", "WPPA", "WPP2", "WPTX"}, new string[] {"Helmet House West", "Helmet House East", "Kyt Americas", "Leatt", "LS2 Dealers", "Klim West", "Klim East", "Oneal", "SMK Helmets", "Parts Unlimited CA", "Parts Unlimited NC", "Parts Unlimited NV", "Parts Unlimited NY", "Parts Unlimited TX", "Parts Unlimited WI", "Western Power Sports CA", "Western Power Sports GA", "Western Power Sports ID", "Western Power Sports IN", "Western Power Sports PA", "Western Power Sports PA2", "Western Power Sports TX"})]
  [PXDefault]
  public virtual 
  #nullable disable
  string WarehouseType { get; set; }

  [PXDefault]
  [Site]
  public virtual int? SiteID { get; set; }

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
  ACVIWarehouseSetup.setupID>
  {
  }

  public abstract class warehouseType : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIWarehouseSetup.warehouseType>
  {
  }

  public abstract class siteID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIWarehouseSetup.siteID>
  {
  }

  public abstract class createdByID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVIWarehouseSetup.createdByID>
  {
  }

  public abstract class createdByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIWarehouseSetup.createdByScreenID>
  {
  }

  public abstract class createdDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACVIWarehouseSetup.createdDateTime>
  {
  }

  public abstract class lastModifiedByID : 
    BqlType<
    #nullable enable
    IBqlGuid, Guid>.Field<
    #nullable disable
    ACVIWarehouseSetup.lastModifiedByID>
  {
  }

  public abstract class lastModifiedByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIWarehouseSetup.lastModifiedByScreenID>
  {
  }

  public abstract class lastModifiedDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACVIWarehouseSetup.lastModifiedDateTime>
  {
  }

  public abstract class tstamp : BqlType<
  #nullable enable
  IBqlByteArray, byte[]>.Field<
  #nullable disable
  ACVIWarehouseSetup.tstamp>
  {
  }

  public abstract class noteid : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVIWarehouseSetup.noteid>
  {
  }
}
