// Decompiled with JetBrains decompiler
// Type: ADCPOSource.DAC.ADCSOPickPackFilter
// Assembly: ADCPOSource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12801FBE-42B3-408D-8920-F8FE91893630
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ADCPickPackProcessOrder[20260715] (1)\Bin\ADCPOSource.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.CS;

#nullable enable
namespace ADCPOSource.DAC;

public class ADCSOPickPackFilter : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXString(1, IsFixed = true)]
  [PXStringList(new string[] {"D", "L", "O", "B"}, new string[] {"Drop-Ship", "Blanket for Drop-Ship", "Purchase to Order", "Blanket for Normal"})]
  [PXUIField(DisplayName = "PO Source")]
  public virtual 
  #nullable disable
  string POSource { get; set; }

  [PXString(30)]
  [PXSelector(typeof (Search<Carrier.carrierID>))]
  [PXUIField(DisplayName = "Ship Via")]
  public virtual string ShipVia { get; set; }

  [PXBool]
  [PXUnboundDefault(false)]
  [PXUIField(DisplayName = "Show Printed")]
  public bool? IsPrintedReport { get; set; }

  public abstract class pOSource : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ADCSOPickPackFilter.pOSource>
  {
  }

  public abstract class shipVia : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ADCSOPickPackFilter.shipVia>
  {
  }

  public abstract class isPrintedReport : 
    BqlType<
    #nullable enable
    IBqlBool, bool>.Field<
    #nullable disable
    ADCSOPickPackFilter.isPrintedReport>
  {
  }
}
