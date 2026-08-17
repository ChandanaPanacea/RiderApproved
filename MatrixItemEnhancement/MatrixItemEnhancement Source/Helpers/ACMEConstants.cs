// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.Helpers.ACMEConstants
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using PX.Data.BQL;

#nullable enable
namespace MatrixItemEnhancement.Helpers;

public static class ACMEConstants
{
  public const 
  #nullable disable
  string ColorAttribute = "COLORS";
  public const string SizeAttribute = "SIZE";

  public class colorAttribute : BqlType<
  #nullable enable
  IBqlString, string>.Constant<
  #nullable disable
  ACMEConstants.colorAttribute>
  {
    public colorAttribute()
      : base("COLORS")
    {
    }
  }

  public class sizeAttribute : BqlType<
  #nullable enable
  IBqlString, string>.Constant<
  #nullable disable
  ACMEConstants.sizeAttribute>
  {
    public sizeAttribute()
      : base("SIZE")
    {
    }
  }
}
