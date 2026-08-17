// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.INSiteStatusByCostCenter3
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data.BQL;
using PX.Objects.IN;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class INSiteStatusByCostCenter3 : INSiteStatusByCostCenter
{
  public abstract class siteID : BqlType<IBqlInt, int>.Field<
  #nullable disable
  INSiteStatusByCostCenter3.siteID>
  {
  }

  public abstract class inventoryID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    INSiteStatusByCostCenter3.inventoryID>
  {
  }

  public abstract class subItemID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  INSiteStatusByCostCenter3.subItemID>
  {
  }

  public abstract class costCenterID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    INSiteStatusByCostCenter3.costCenterID>
  {
  }

  public abstract class qtyAvail : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    INSiteStatusByCostCenter3.qtyAvail>
  {
  }

  public abstract class qtyOnHand : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    INSiteStatusByCostCenter3.qtyOnHand>
  {
  }
}
