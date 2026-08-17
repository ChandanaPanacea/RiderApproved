// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIPOSiteStatusSelectedExt
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.PO;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVIPOSiteStatusSelectedExt : PXCacheExtension<
#nullable disable
POSiteStatusSelected>
{
  [PXDBDecimal(BqlField = typeof (ACVIInventoryItemExt.usrStkMin))]
  [PXUIField(DisplayName = "Min.")]
  public virtual Decimal? UsrStkMin { get; set; }

  [PXDBDecimal(BqlField = typeof (ACVIInventoryItemExt.usrStkMax))]
  [PXUIField(DisplayName = "Max.")]
  public virtual Decimal? UsrStkMax { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "On Hand across warehouses")]
  public virtual Decimal? UsrTotalQtyOnHand { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "Default qty to order")]
  public virtual Decimal? UsrDefaultQtyToOrder { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "S365")]
  public virtual Decimal? UsrS365 { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "S30")]
  public virtual Decimal? UsrS30 { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "Vendor stock")]
  public virtual Decimal? UsrVendorStock { get; set; }

  public abstract class usrStkMin : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrStkMin>
  {
  }

  public abstract class usrStkMax : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrStkMax>
  {
  }

  public abstract class usrTotalQtyOnHand : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrTotalQtyOnHand>
  {
  }

  public abstract class usrDefaultQtyToOrder : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrDefaultQtyToOrder>
  {
  }

  public abstract class usrS365 : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrS365>
  {
  }

  public abstract class usrS30 : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrS30>
  {
  }

  public abstract class usrVendorStock : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusSelectedExt.usrVendorStock>
  {
  }
}
