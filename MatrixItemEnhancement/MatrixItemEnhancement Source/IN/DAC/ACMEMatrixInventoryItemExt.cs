// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.ACMEMatrixInventoryItemExt
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.IN.Matrix.DAC.Unbound;
using System;

#nullable enable
namespace MatrixItemEnhancement.IN;

public class ACMEMatrixInventoryItemExt : PXCacheExtension<
#nullable disable
MatrixInventoryItem>
{
  [PXDecimal]
  [PXUIField(DisplayName = "Min")]
  public virtual Decimal? UsrStkMin { get; set; }

  [PXDecimal]
  [PXUIField(DisplayName = "Dflt Vendor Price")]
  public virtual Decimal? VendorPrice { get; set; }

  [PXDecimal]
  [PXUIField(DisplayName = "Max")]
  public virtual Decimal? UsrStkMax { get; set; }

  [PXString]
  [PXUIField(DisplayName = "Visibility")]
  public virtual string Visibility { get; set; }

  [PXString]
  [PXUIField(DisplayName = "Availability")]
  public virtual string Availability { get; set; }

  public abstract class usrStkMin : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACMEMatrixInventoryItemExt.usrStkMin>
  {
  }

  public abstract class vendorPrice : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACMEMatrixInventoryItemExt.vendorPrice>
  {
  }

  public abstract class usrStkMax : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACMEMatrixInventoryItemExt.usrStkMax>
  {
  }

  public abstract class visibility : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACMEMatrixInventoryItemExt.visibility>
  {
  }

  public abstract class availability : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACMEMatrixInventoryItemExt.availability>
  {
  }
}
