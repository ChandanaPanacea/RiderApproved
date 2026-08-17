// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIPOSiteStatusFilterExt
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.PO;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVIPOSiteStatusFilterExt : PXCacheExtension<
#nullable disable
POSiteStatusFilter>
{
  [PXDBBool]
  [PXUIField(DisplayName = "Filter by qty to process")]
  [PXDefault(false)]
  public virtual bool? UsrFilterByQty { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "from")]
  [PXDefault(TypeCode.Decimal, "0.00")]
  [PXUIEnabled(typeof (ACVIPOSiteStatusFilterExt.usrFilterByQty))]
  public virtual Decimal? UsrMinQty { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "to")]
  [PXDefault(TypeCode.Decimal, "0.00")]
  [PXUIEnabled(typeof (ACVIPOSiteStatusFilterExt.usrFilterByQty))]
  public virtual Decimal? UsrMaxQty { get; set; }

  public abstract class usrFilterByQty : 
    BqlType<
    #nullable enable
    IBqlBool, bool>.Field<
    #nullable disable
    ACVIPOSiteStatusFilterExt.usrFilterByQty>
  {
  }

  public abstract class usrMinQty : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusFilterExt.usrMinQty>
  {
  }

  public abstract class usrMaxQty : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIPOSiteStatusFilterExt.usrMaxQty>
  {
  }
}
