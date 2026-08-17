// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVISetup
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.AP;
using PX.Objects.IN;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVISetup : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXDBInt]
  [PXUIField(DisplayName = "Default Item Class")]
  [PXSelector(typeof (INItemClass.itemClassID), SubstituteKey = typeof (INItemClass.itemClassCD))]
  [PXDefault]
  public virtual int? DefaultItemClassID { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Max number of lines to Treat")]
  [PXDefault]
  public virtual int? LineNbrToTreat { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "PU Vendor")]
  [PXSelector(typeof (Vendor.bAccountID), SubstituteKey = typeof (Vendor.acctCD))]
  [PXDefault]
  public virtual int? PUVendorID { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "PU Endpoint")]
  [PXDefault]
  public virtual 
  #nullable disable
  string PUEndpoint { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "PU Dealer Number")]
  [PXDefault]
  public virtual string PUDealerNumber { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "PU Username")]
  [PXDefault]
  public virtual string PUUsername { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "PU Password")]
  [PXDefault]
  public virtual string PUPassword { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "PU file name")]
  [PXDefault]
  public virtual string PUFileName { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "PU 2nd File Name")]
  [PXDefault]
  public virtual string PU2ndFileName { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "WPS Endpoint")]
  [PXDefault]
  public virtual string WPSEndpoint { get; set; }

  [PXDBString]
  [PXUIField(DisplayName = "WPS Token")]
  [PXDefault]
  public virtual string WPSToken { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "WPS Vendor")]
  [PXSelector(typeof (Vendor.bAccountID), SubstituteKey = typeof (Vendor.acctCD))]
  [PXDefault]
  public virtual int? WPSVendorID { get; set; }

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

  public abstract class defaultItemClassID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    ACVISetup.defaultItemClassID>
  {
  }

  public abstract class lineNbrToTreat : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.lineNbrToTreat>
  {
  }

  public abstract class pUVendorID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.pUVendorID>
  {
  }

  public abstract class pUEndpoint : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.pUEndpoint>
  {
  }

  public abstract class pUDealerNumber : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.pUDealerNumber>
  {
  }

  public abstract class pUUsername : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.pUUsername>
  {
  }

  public abstract class pUPassword : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.pUPassword>
  {
  }

  public abstract class pUFileName : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.pUFileName>
  {
  }

  public abstract class pU2ndFileName : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVISetup.pU2ndFileName>
  {
  }

  public abstract class wPSEndpoint : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.wPSEndpoint>
  {
  }

  public abstract class wPSToken : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.wPSToken>
  {
  }

  public abstract class wPSVendorID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVISetup.wPSVendorID>
  {
  }

  public abstract class createdByID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVISetup.createdByID>
  {
  }

  public abstract class createdByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVISetup.createdByScreenID>
  {
  }

  public abstract class createdDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACVISetup.createdDateTime>
  {
  }

  public abstract class lastModifiedByID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVISetup.lastModifiedByID>
  {
  }

  public abstract class lastModifiedByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVISetup.lastModifiedByScreenID>
  {
  }

  public abstract class lastModifiedDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACVISetup.lastModifiedDateTime>
  {
  }

  public abstract class tstamp : BqlType<
  #nullable enable
  IBqlByteArray, byte[]>.Field<
  #nullable disable
  ACVISetup.tstamp>
  {
  }

  public abstract class noteid : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACVISetup.noteid>
  {
  }
}
