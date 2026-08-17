// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.DAC.ACMEInventoryItemExt
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.IN;
using System;

#nullable enable
namespace MatrixItemEnhancement.IN.DAC;

public class ACMEInventoryItemExt : PXCacheExtension<
#nullable disable
InventoryItem>
{
  [PXMergeAttributes]
  public virtual Decimal? UsrStkMin { get; set; }

  [PXMergeAttributes]
  public virtual Decimal? UsrStkMax { get; set; }

  public abstract class usrStkMin : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACMEInventoryItemExt.usrStkMin>
  {
  }

  public abstract class usrStkMax : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACMEInventoryItemExt.usrStkMax>
  {
  }
}
