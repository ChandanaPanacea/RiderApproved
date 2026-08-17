// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.DAC.MatrixInventoryItemForUpdate
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using PX.Commerce.Objects;
using PX.Common;
using PX.CS;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;
using PX.Objects.TX;
using System;

#nullable enable
namespace MatrixItemEnhancement.IN.DAC;

[PXProjection(typeof (SelectFromBase<InventoryItem, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Left<InventoryItemCurySettings>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<InventoryItemCurySettings.curyID, Equal<BqlField<AccessInfo.baseCuryID, IBqlString>.FromCurrent.Value>>>>>.And<InventoryItemCurySettings.FK.Inventory>>>, FbqlJoins.Left<INItemCost>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INItemCost.curyID, Equal<BqlField<AccessInfo.baseCuryID, IBqlString>.FromCurrent.Value>>>>>.And<INItemCost.FK.InventoryItem>>>>.OrderBy<Asc<InventoryItem.inventoryCD>>), Persistent = false)]
public class MatrixInventoryItemForUpdate : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXDefault]
  [InventoryRaw(DisplayName = "Inventory ID", IsKey = true, BqlField = typeof (InventoryItem.inventoryCD), Enabled = false)]
  public 
  #nullable disable
  string InventoryCD { get; set; }

  [AnyInventory(Visible = true, DisplayName = "Inventory ID", IsKey = true, BqlField = typeof (InventoryItem.inventoryID), Enabled = false)]
  public int? InventoryID { get; set; }

  [PXDBInt(BqlField = typeof (InventoryItem.templateItemID))]
  [PXUIField(DisplayName = "Template ID")]
  public int? TemplateItemID { get; set; }

  [PXDBString(IsUnicode = true, BqlField = typeof (InventoryItem.descr))]
  [PXUIField(DisplayName = "Description", Enabled = false)]
  public virtual string Descr { get; set; }

  [PXDBDecimal(BqlField = typeof (INItemCost.lastCost))]
  [PXUIField(DisplayName = "Last Cost", Enabled = false)]
  public virtual Decimal? LastCost { get; set; }

  [PXDBDecimal(BqlField = typeof (InventoryItemCurySettings.basePrice))]
  [PXUIField(DisplayName = "Default Price")]
  public virtual Decimal? BasePrice { get; set; }

  [PXDBInt(BqlField = typeof (InventoryItemCurySettings.dfltSiteID))]
  [PXUIField(DisplayName = "Default Warehouse")]
  [PXSelector(typeof (INSite.siteID), new Type[] {typeof (INSite.siteCD), typeof (INSite.descr)}, SubstituteKey = typeof (INSite.siteCD))]
  public virtual int? DfltSiteID { get; set; }

  [PXDBInt(BqlField = typeof (InventoryItem.itemClassID))]
  [PXUIField(DisplayName = "Item Class", Enabled = false)]
  [PXSelector(typeof (INItemClass.itemClassID), new Type[] {typeof (INItemClass.itemClassCD), typeof (INItemClass.descr)}, SubstituteKey = typeof (INItemClass.itemClassCD))]
  public virtual int? ItemClassID { get; set; }

  [PXDBGuid(false, BqlField = typeof (InventoryItem.noteID))]
  [PXUIField(DisplayName = "Note ID", Visible = false)]
  public virtual Guid? NoteID { get; set; }

  [PXDBString(IsUnicode = true, BqlField = typeof (InventoryItem.taxCategoryID))]
  [PXSelector(typeof (TaxCategory.taxCategoryID), DescriptionField = typeof (TaxCategory.descr))]
  [PXUIField(DisplayName = "Tax Category")]
  public virtual string TaxCategoryID { get; set; }

  [PXBool]
  [PXUIField(DisplayName = "Selected")]
  public virtual bool? Selected { get; set; }

  [PXDBBool(BqlField = typeof (InventoryItem.stkItem))]
  [PXUIField(DisplayName = "StkItem", Visible = false)]
  public virtual bool? StkItem { get; set; }

  [PXDBDecimal(BqlField = typeof (ACMEInventoryItemExt.usrStkMin))]
  [PXUIField(DisplayName = "Min")]
  public virtual Decimal? StkMin { get; set; }

  [PXDecimal]
  [PXUIField(DisplayName = "Dflt Vendor Price")]
  public virtual Decimal? VendorPrice { get; set; }

  [PXDBDecimal(BqlField = typeof (ACMEInventoryItemExt.usrStkMax))]
  [PXUIField(DisplayName = "Max")]
  public virtual Decimal? StkMax { get; set; }

  [PXDBString(BqlField = typeof (InventoryItem.visibility))]
  [PXUIField(DisplayName = "Visibility")]
  [BCItemVisibility.List]
  public virtual string Visibility { get; set; }

  [PXDBString(BqlField = typeof (InventoryItem.availability))]
  [PXUIField(DisplayName = "Availability")]
  [BCItemAvailabilities.ListDef]
  public virtual string Availability { get; set; }

  [PXString]
  [PXUIField(DisplayName = "Color", Enabled = false)]
  [PXSelector(typeof (Search<CSAttributeDetail.valueID>), SubstituteKey = typeof (CSAttributeDetail.description))]
  public virtual string Color { get; set; }

  [PXString]
  [PXUIField(DisplayName = "Size", Enabled = false)]
  [PXSelector(typeof (Search<CSAttributeDetail.valueID>), SubstituteKey = typeof (CSAttributeDetail.description))]
  public virtual string Size { get; set; }

  public abstract class inventoryCD : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.inventoryCD>
  {
  }

  public abstract class inventoryID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.inventoryID>
  {
  }

  public abstract class templateItemID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.templateItemID>
  {
  }

  public abstract class descr : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  MatrixInventoryItemForUpdate.descr>
  {
  }

  public abstract class lastCost : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.lastCost>
  {
  }

  public abstract class basePrice : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.basePrice>
  {
  }

  public abstract class dfltSiteID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.dfltSiteID>
  {
  }

  public abstract class itemClassID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.itemClassID>
  {
  }

  public abstract class noteID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  MatrixInventoryItemForUpdate.noteID>
  {
  }

  public abstract class taxCategoryID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.taxCategoryID>
  {
  }

  public abstract class selected : 
    BqlType<
    #nullable enable
    IBqlBool, bool>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.selected>
  {
  }

  public abstract class stkItem : BqlType<
  #nullable enable
  IBqlBool, bool>.Field<
  #nullable disable
  MatrixInventoryItemForUpdate.stkItem>
  {
  }

  public abstract class stkMin : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.stkMin>
  {
  }

  public abstract class vendorPrice : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.vendorPrice>
  {
  }

  public abstract class stkMax : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.stkMax>
  {
  }

  public abstract class visibility : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.visibility>
  {
  }

  public abstract class availability : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    MatrixInventoryItemForUpdate.availability>
  {
  }

  public abstract class color : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  MatrixInventoryItemForUpdate.color>
  {
  }

  public abstract class size : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  MatrixInventoryItemForUpdate.size>
  {
  }
}
