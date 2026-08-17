// Decompiled with JetBrains decompiler
// Type: ADCPOSource.Extensions.DAC.ADCSOLineExt
// Assembly: ADCPOSource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12801FBE-42B3-408D-8920-F8FE91893630
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ADCPickPackProcessOrder[20260715] (1)\Bin\ADCPOSource.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.SO;
using System;

#nullable enable
namespace ADCPOSource.Extensions.DAC;

public sealed class ADCSOLineExt : PXCacheExtension<
#nullable disable
SOLine>
{
  public static bool IsActive() => true;

  [PXBool]
  [PXUnboundDefault(false)]
  [PXUIField(DisplayName = "Selected")]
  public bool? Selected { get; set; }

  [PXDBBool]
  [PXDefault(false)]
  [PXUIField(DisplayName = "Pack Printed Printed")]
  public bool? UsrPickPackPrinted { get; set; }

  [PXDBString(255 /*0xFF*/, IsUnicode = true)]
  [PXUIField(DisplayName = "User Name")]
  public string UsrUserName { get; set; }

  [PXDBDateAndTime(DisplayNameDate = "Processed Date", DisplayNameTime = "Log Time", UseTimeZone = true)]
  [PXUIField(DisplayName = "Processed Date")]
  public DateTime? UsrProcessedDate { get; set; }

  public abstract class selected : BqlType<
  #nullable enable
  IBqlBool, bool>.Field<
  #nullable disable
  ADCSOLineExt.selected>
  {
  }

  public abstract class usrPickPackPrinted : 
    BqlType<
    #nullable enable
    IBqlBool, bool>.Field<
    #nullable disable
    ADCSOLineExt.usrPickPackPrinted>
  {
  }

  public abstract class usrUserName : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ADCSOLineExt.usrUserName>
  {
  }

  public abstract class usrProcessedDate : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ADCSOLineExt.usrProcessedDate>
  {
  }
}
