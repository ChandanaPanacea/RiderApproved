// Decompiled with JetBrains decompiler
// Type: ADCPOSource.DAC.ADCSOPickPackProjection
// Assembly: ADCPOSource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12801FBE-42B3-408D-8920-F8FE91893630
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ADCPickPackProcessOrder[20260715] (1)\Bin\ADCPOSource.dll

using ADCPOSource.Extensions.DAC;
using PX.Data;
using PX.Data.BQL;
using PX.Objects.AR;
using PX.Objects.IN;
using PX.Objects.SO;
using System;

#nullable enable
namespace ADCPOSource.DAC;

[PXProjection(typeof (Select2<SOLine, InnerJoin<SOOrder, On<SOOrder.orderType, Equal<SOLine.orderType>, And<SOOrder.orderNbr, Equal<SOLine.orderNbr>>>>>), Persistent = false)]
[Serializable]
public class ADCSOPickPackProjection : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXBool]
  [PXUnboundDefault(false)]
  [PXUIField(DisplayName = "Selected")]
  public virtual bool? Selected { get; set; }

  [PXDBString(IsKey = true, BqlField = typeof (SOOrder.orderType))]
  [PXUIField(DisplayName = "Order Type")]
  public virtual 
  #nullable disable
  string OrderType { get; set; }

  [PXDBString(15, IsKey = true, BqlField = typeof (SOOrder.orderNbr))]
  [PXSelector(typeof (Search<SOOrder.orderNbr>))]
  [PXUIField(DisplayName = "Order Nbr")]
  public virtual string OrderNbr { get; set; }

  [PXDBInt(IsKey = true, BqlField = typeof (SOLine.lineNbr))]
  [PXUIField(DisplayName = "Line Nbr")]
  public virtual int? LineNbr { get; set; }

  [Inventory(BqlField = typeof (SOLine.inventoryID))]
  public virtual int? InventoryID { get; set; }

  [PXDBString(1, IsFixed = true, BqlField = typeof (SOLine.pOSource))]
  [PXStringList(new string[] {"D", "L", "O", "B", "W"}, new string[] {"Drop-Ship", "Blanket for Drop-Ship", "Purchase to Order", "Blanket for Normal", "Waiting On Order"})]
  [PXUIField(DisplayName = "PO Source")]
  public virtual string POSource { get; set; }

  [PXDBQuantity(BqlField = typeof (SOLine.orderQty))]
  [PXUIField(DisplayName = "Order Qty")]
  public virtual Decimal? OrderQty { get; set; }

  [PXDBPriceCost(BqlField = typeof (SOLine.curyUnitPrice))]
  [PXUIField(DisplayName = "Unit Price")]
  public virtual Decimal? CuryUnitPrice { get; set; }

  [PXDBString(BqlField = typeof (SOOrder.shipVia))]
  [PXUIField(DisplayName = "Ship Via")]
  public virtual string ShipVia { get; set; }

  [Customer(BqlField = typeof (SOOrder.customerID))]
  public virtual int? CustomerID { get; set; }

  [PXDBDate(BqlField = typeof (SOOrder.orderDate))]
  [PXUIField(DisplayName = "Order Date")]
  public virtual DateTime? OrderDate { get; set; }

  [PXDBString(BqlField = typeof (SOOrder.status))]
  [SOOrderStatus.List]
  [PXUIField(DisplayName = "Status")]
  public virtual string Status { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, BqlField = typeof (SOOrder.orderDesc))]
  [PXUIField(DisplayName = "Description")]
  public virtual string OrderDesc { get; set; }

  [PXDBString(40, IsUnicode = true, BqlField = typeof (SOOrder.customerOrderNbr))]
  [PXUIField(DisplayName = "Customer Order Nbr.")]
  public virtual string CustomerOrderNbr { get; set; }

  [PXDBBool(BqlField = typeof (ADCSOLineExt.usrPickPackPrinted))]
  [PXUIField(DisplayName = "Packing Slip Printed")]
  public virtual bool? PickPackPrinted { get; set; }

  [PXDBString(BqlField = typeof (ADCSOLineExt.usrUserName))]
  [PXUIField(DisplayName = "User Name")]
  public virtual string UserName { get; set; }

  [PXDBDateAndTime(DisplayNameDate = "Processed Date", DisplayNameTime = "Log Time", UseTimeZone = true, BqlField = typeof (ADCSOLineExt.usrProcessedDate))]
  [PXUIField(DisplayName = "Processed Date")]
  public DateTime? ProcessedDate { get; set; }

  [PXNote(BqlField = typeof (SOOrder.noteID))]
  public virtual Guid? NoteID { get; set; }

  public abstract class selected : BqlType<
  #nullable enable
  IBqlBool, bool>.Field<
  #nullable disable
  ADCSOPickPackProjection.selected>
  {
  }

  public abstract class orderType : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ADCSOPickPackProjection.orderType>
  {
  }

  public abstract class orderNbr : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ADCSOPickPackProjection.orderNbr>
  {
  }

  public abstract class lineNbr : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ADCSOPickPackProjection.lineNbr>
  {
  }

  public abstract class inventoryID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    ADCSOPickPackProjection.inventoryID>
  {
  }

  public abstract class pOSource : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ADCSOPickPackProjection.pOSource>
  {
  }

  public abstract class orderQty : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ADCSOPickPackProjection.orderQty>
  {
  }

  public abstract class curyUnitPrice : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ADCSOPickPackProjection.curyUnitPrice>
  {
  }

  public abstract class shipVia : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ADCSOPickPackProjection.shipVia>
  {
  }

  public abstract class customerID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ADCSOPickPackProjection.customerID>
  {
  }

  public abstract class orderDate : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ADCSOPickPackProjection.orderDate>
  {
  }

  public abstract class status : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ADCSOPickPackProjection.status>
  {
  }

  public abstract class orderDesc : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ADCSOPickPackProjection.orderDesc>
  {
  }

  public abstract class customerOrderNbr : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ADCSOPickPackProjection.customerOrderNbr>
  {
  }

  public abstract class pickPackPrinted : 
    BqlType<
    #nullable enable
    IBqlBool, bool>.Field<
    #nullable disable
    ADCSOPickPackProjection.pickPackPrinted>
  {
  }

  public abstract class userName : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ADCSOPickPackProjection.userName>
  {
  }

  public abstract class processedDate : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ADCSOPickPackProjection.processedDate>
  {
  }

  public abstract class noteID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ADCSOPickPackProjection.noteID>
  {
  }
}
