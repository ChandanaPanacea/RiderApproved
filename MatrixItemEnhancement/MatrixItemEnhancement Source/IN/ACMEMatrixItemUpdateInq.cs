// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.ACMEMatrixItemUpdateInq
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using MatrixItemEnhancement.Helpers;
using MatrixItemEnhancement.IN.DAC;
using PX.Commerce.Objects;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AP;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.PO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace MatrixItemEnhancement.IN;

public class ACMEMatrixItemUpdateInq : PXGraph<
#nullable disable
ACMEMatrixItemUpdateInq>
{
  public PXFilter<ACMEMatrixItemUpdateInq.Filter> TemplateFilter;
  public PXSelect<MatrixInventoryItemForUpdate, Where<MatrixInventoryItemForUpdate.templateItemID, Equal<Current<ACMEMatrixItemUpdateInq.Filter.templateItemID>>>> Rows;
  public PXAction<ACMEMatrixItemUpdateInq.Filter> applyToItems;

  protected virtual void _(
    Events.FieldUpdated<ACMEMatrixItemUpdateInq.Filter, ACMEMatrixItemUpdateInq.Filter.dfltPrice> e)
  {
    if (e.Row == null)
      return;
    this.UpdateAllRows<MatrixInventoryItemForUpdate.basePrice>((object) e.Row.DfltPrice);
  }

  protected virtual void _(
    Events.FieldUpdated<ACMEMatrixItemUpdateInq.Filter, ACMEMatrixItemUpdateInq.Filter.dfltVendorPrice> e)
  {
    if (e.Row == null)
      return;
    this.UpdateAllRows<MatrixInventoryItemForUpdate.vendorPrice>((object) e.Row.DfltVendorPrice);
  }

  protected virtual void _(
    Events.FieldUpdated<ACMEMatrixItemUpdateInq.Filter, ACMEMatrixItemUpdateInq.Filter.min> e)
  {
    if (e.Row == null)
      return;
    this.UpdateAllRows<MatrixInventoryItemForUpdate.stkMin>((object) e.Row.Min);
  }

  protected virtual void _(
    Events.FieldUpdated<ACMEMatrixItemUpdateInq.Filter, ACMEMatrixItemUpdateInq.Filter.max> e)
  {
    if (e.Row == null)
      return;
    this.UpdateAllRows<MatrixInventoryItemForUpdate.stkMax>((object) e.Row.Max);
  }

  protected virtual void _(
    Events.FieldUpdated<ACMEMatrixItemUpdateInq.Filter, ACMEMatrixItemUpdateInq.Filter.visibility> e)
  {
    if (e.Row == null)
      return;
    this.UpdateAllRows<MatrixInventoryItemForUpdate.visibility>((object) e.Row.Visibility);
  }

  protected virtual void _(
    Events.FieldUpdated<ACMEMatrixItemUpdateInq.Filter, ACMEMatrixItemUpdateInq.Filter.availability> e)
  {
    if (e.Row == null)
      return;
    this.UpdateAllRows<MatrixInventoryItemForUpdate.availability>((object) e.Row.Availability);
  }

  private void UpdateAllRows<TField>(object value) where TField : IBqlField
  {
    foreach (MatrixInventoryItemForUpdate inventoryItemForUpdate in GraphHelper.RowCast<MatrixInventoryItemForUpdate>((IEnumerable) ((PXSelectBase<MatrixInventoryItemForUpdate>) this.Rows).Select(Array.Empty<object>())))
    {
      ((PXSelectBase) this.Rows).Cache.SetValueExt<TField>((object) inventoryItemForUpdate, value);
      ((PXSelectBase<MatrixInventoryItemForUpdate>) this.Rows).Update(inventoryItemForUpdate);
    }
    ((PXSelectBase) this.Rows).View.RequestRefresh();
  }

  public virtual void _(
    Events.RowSelecting<MatrixInventoryItemForUpdate> e)
  {
    if (e.Row == null || !e.Row.NoteID.HasValue)
      return;
    CSAnswers csAnswers1 = PXResultset<CSAnswers>.op_Implicit(PXSelectBase<CSAnswers, PXViewOf<CSAnswers>.BasedOn<SelectFromBase<CSAnswers, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<CSAnswers.refNoteID, Equal<P.AsGuid>>>>>.And<BqlOperand<CSAnswers.attributeID, IBqlString>.IsEqual<ACMEConstants.colorAttribute>>>>.Config>.SelectWindowed((PXGraph) this, 0, 1, new object[1]
    {
      (object) e.Row.NoteID
    }));
    CSAnswers csAnswers2 = PXResultset<CSAnswers>.op_Implicit(PXSelectBase<CSAnswers, PXViewOf<CSAnswers>.BasedOn<SelectFromBase<CSAnswers, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<CSAnswers.refNoteID, Equal<P.AsGuid>>>>>.And<BqlOperand<CSAnswers.attributeID, IBqlString>.IsEqual<ACMEConstants.sizeAttribute>>>>.Config>.SelectWindowed((PXGraph) this, 0, 1, new object[1]
    {
      (object) e.Row.NoteID
    }));
    APVendorPrice apVendorPrice = PXResultset<APVendorPrice>.op_Implicit(PXSelectBase<APVendorPrice, PXViewOf<APVendorPrice>.BasedOn<SelectFromBase<APVendorPrice, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<InventoryItemCurySettings>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<InventoryItemCurySettings.inventoryID, Equal<APVendorPrice.inventoryID>>>>>.And<BqlOperand<InventoryItemCurySettings.preferredVendorID, IBqlInt>.IsEqual<APVendorPrice.vendorID>>>>, FbqlJoins.Inner<POVendorInventory>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<POVendorInventory.inventoryID, Equal<APVendorPrice.inventoryID>>>>>.And<BqlOperand<POVendorInventory.vendorID, IBqlInt>.IsEqual<APVendorPrice.vendorID>>>>>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<APVendorPrice.expirationDate, IsNull>>>>.And<BqlOperand<APVendorPrice.inventoryID, IBqlInt>.IsEqual<P.AsInt>>>>.Config>.SelectWindowed((PXGraph) this, 0, 1, new object[1]
    {
      (object) e.Row.InventoryID
    }));
    e.Row.Color = csAnswers1?.Value;
    e.Row.Size = csAnswers2?.Value;
    e.Row.VendorPrice = new Decimal?(((Decimal?) apVendorPrice?.SalesPrice).GetValueOrDefault());
  }

  [PXUIField]
  [PXProcessButton(IsLockedOnToolbar = true)]
  public virtual IEnumerable ApplyToItems(PXAdapter adapter)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ACMEMatrixItemUpdateInq.\u003C\u003Ec__DisplayClass12_0 cDisplayClass120 = new ACMEMatrixItemUpdateInq.\u003C\u003Ec__DisplayClass12_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass120.\u003C\u003E4__this = this;
    // ISSUE: reference to a compiler-generated field
    cDisplayClass120.templateItem = InventoryItem.PK.Find((PXGraph) this, (int?) ((PXSelectBase<ACMEMatrixItemUpdateInq.Filter>) this.TemplateFilter)?.Current.TemplateItemID, (PKFindOptions) 0);
    // ISSUE: reference to a compiler-generated field
    if (cDisplayClass120.templateItem == null)
      return adapter.Get();
    IEnumerable<MatrixInventoryItemForUpdate> source = ((PXSelectBase) this.Rows).Cache.Cached.Cast<MatrixInventoryItemForUpdate>();
    MatrixInventoryItemForUpdate[] array;
    MatrixInventoryItemForUpdate[] inventoryItemForUpdateArray1 = array = source.Where<MatrixInventoryItemForUpdate>((Func<MatrixInventoryItemForUpdate, bool>) (i => i.Selected.GetValueOrDefault())).ToArray<MatrixInventoryItemForUpdate>();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass120.selectedItems = array;
    MatrixInventoryItemForUpdate[] inventoryItemForUpdateArray2 = inventoryItemForUpdateArray1;
    // ISSUE: reference to a compiler-generated field
    cDisplayClass120.selectedItems = inventoryItemForUpdateArray2;
    // ISSUE: method pointer
    PXLongOperation.StartOperation((PXGraph) this, new PXToggleAsyncDelegate((object) cDisplayClass120, __methodptr(\u003CApplyToItems\u003Eb__1)));
    return adapter.Get();
  }

  public void UpdateVendorPrice(MatrixInventoryItemForUpdate matrixII)
  {
    APVendorPriceMaint instance = PXGraph.CreateInstance<APVendorPriceMaint>();
    APVendorPrice apVendorPrice1 = PXResultset<APVendorPrice>.op_Implicit(PXSelectBase<APVendorPrice, PXViewOf<APVendorPrice>.BasedOn<SelectFromBase<APVendorPrice, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<InventoryItemCurySettings>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<InventoryItemCurySettings.inventoryID, Equal<APVendorPrice.inventoryID>>>>>.And<BqlOperand<InventoryItemCurySettings.preferredVendorID, IBqlInt>.IsEqual<APVendorPrice.vendorID>>>>, FbqlJoins.Inner<POVendorInventory>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<POVendorInventory.inventoryID, Equal<APVendorPrice.inventoryID>>>>>.And<BqlOperand<POVendorInventory.vendorID, IBqlInt>.IsEqual<APVendorPrice.vendorID>>>>>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<APVendorPrice.expirationDate, IsNull>>>>.And<BqlOperand<APVendorPrice.inventoryID, IBqlInt>.IsEqual<P.AsInt>>>>.Config>.SelectWindowed((PXGraph) instance, 0, 1, new object[1]
    {
      (object) matrixII.InventoryID
    }));
    int num;
    if (matrixII.VendorPrice.HasValue)
    {
      Decimal? nullable = matrixII.VendorPrice;
      if (nullable.Value != 0M)
      {
        if (apVendorPrice1 != null)
        {
          nullable = apVendorPrice1.SalesPrice;
          Decimal? vendorPrice = matrixII.VendorPrice;
          if (!(nullable.GetValueOrDefault() == vendorPrice.GetValueOrDefault() & nullable.HasValue == vendorPrice.HasValue))
          {
            num = 1;
            goto label_7;
          }
        }
        num = apVendorPrice1 == null ? 1 : 0;
        goto label_7;
      }
    }
    num = 0;
label_7:
    if (num == 0)
      return;
    POVendorInventory poVendorInventory = PXResultset<POVendorInventory>.op_Implicit(PXSelectBase<POVendorInventory, PXViewOf<POVendorInventory>.BasedOn<SelectFromBase<POVendorInventory, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<InventoryItemCurySettings>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<InventoryItemCurySettings.inventoryID, Equal<POVendorInventory.inventoryID>>>>>.And<BqlOperand<InventoryItemCurySettings.preferredVendorID, IBqlInt>.IsEqual<POVendorInventory.vendorID>>>>>.Where<BqlOperand<POVendorInventory.inventoryID, IBqlInt>.IsEqual<P.AsInt>>>.Config>.SelectWindowed((PXGraph) instance, 0, 1, new object[1]
    {
      (object) matrixII.InventoryID
    }));
    if (poVendorInventory == null)
      return;
    if (apVendorPrice1 != null)
    {
      DateTime? effectiveDate = apVendorPrice1.EffectiveDate;
      DateTime date = PXTimeZoneInfo.Now.Date;
      if (effectiveDate.HasValue && effectiveDate.GetValueOrDefault() == date)
      {
        apVendorPrice1.SalesPrice = matrixII.VendorPrice;
        ((PXSelectBase<APVendorPrice>) instance.Records).Update(apVendorPrice1);
        ((PXAction) instance.Save).Press();
        return;
      }
      APVendorPrice apVendorPrice2 = apVendorPrice1;
      DateTime dateTime = PXTimeZoneInfo.Now;
      dateTime = dateTime.Date;
      DateTime? nullable = new DateTime?(dateTime.AddDays(-1.0));
      apVendorPrice2.ExpirationDate = nullable;
      ((PXSelectBase<APVendorPrice>) instance.Records).Update(apVendorPrice1);
    }
    ((PXSelectBase<APVendorPrice>) instance.Records).Insert(new APVendorPrice()
    {
      InventoryID = matrixII.InventoryID,
      VendorID = poVendorInventory.VendorID,
      EffectiveDate = new DateTime?(PXTimeZoneInfo.Now.Date),
      SalesPrice = matrixII.VendorPrice
    });
    ((PXAction) instance.Save).Press();
  }

  public class Filter : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
  {
    [PXDBInt]
    [PXUIField(DisplayName = "Template Item")]
    [PXSelector(typeof (Search<InventoryItem.inventoryID, Where<BqlOperand<InventoryItem.isTemplate, IBqlBool>.IsEqual<True>>>), new Type[] {typeof (InventoryItem.inventoryCD), typeof (InventoryItem.descr)}, SubstituteKey = typeof (InventoryItem.inventoryCD))]
    public virtual int? TemplateItemID { get; set; }

    [PXDBDecimal]
    [PXUIField(DisplayName = "Default Price")]
    public virtual Decimal? DfltPrice { get; set; }

    [PXDBDecimal]
    [PXUIField(DisplayName = "Default Vendor Price")]
    public virtual Decimal? DfltVendorPrice { get; set; }

    [PXDBDecimal]
    [PXUIField(DisplayName = "Min")]
    public virtual Decimal? Min { get; set; }

    [PXDBDecimal]
    [PXUIField(DisplayName = "Max")]
    public virtual Decimal? Max { get; set; }

    [PXDBString]
    [PXUIField(DisplayName = "Visibility")]
    [BCItemVisibility.List]
    public virtual string Visibility { get; set; }

    [PXDBString]
    [PXUIField(DisplayName = "Availability")]
    [BCItemAvailabilities.ListDef]
    public virtual string Availability { get; set; }

    public abstract class templateItemID : 
      BqlType<
      #nullable enable
      IBqlInt, int>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.templateItemID>
    {
    }

    public abstract class dfltPrice : 
      BqlType<
      #nullable enable
      IBqlDecimal, Decimal>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.dfltPrice>
    {
    }

    public abstract class dfltVendorPrice : 
      BqlType<
      #nullable enable
      IBqlDecimal, Decimal>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.dfltVendorPrice>
    {
    }

    public abstract class min : 
      BqlType<
      #nullable enable
      IBqlDecimal, Decimal>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.min>
    {
    }

    public abstract class max : 
      BqlType<
      #nullable enable
      IBqlDecimal, Decimal>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.max>
    {
    }

    public abstract class visibility : 
      BqlType<
      #nullable enable
      IBqlString, string>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.visibility>
    {
    }

    public abstract class availability : 
      BqlType<
      #nullable enable
      IBqlString, string>.Field<
      #nullable disable
      ACMEMatrixItemUpdateInq.Filter.availability>
    {
    }
  }
}
