// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIInventoryItemExt
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.IN;
using System;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVIInventoryItemExt : PXCacheExtension<
#nullable disable
InventoryItem>
{
  [PXDBDecimal]
  [PXUIField(DisplayName = "Min.")]
  public virtual Decimal? UsrStkMin { get; set; }

  [PXDBDecimal]
  [PXUIField(DisplayName = "Max.")]
  public virtual Decimal? UsrStkMax { get; set; }

  public abstract class usrStkMin : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIInventoryItemExt.usrStkMin>
  {
  }

  public abstract class usrStkMax : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIInventoryItemExt.usrStkMax>
  {
  }
}
