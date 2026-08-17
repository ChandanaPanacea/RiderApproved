// Decompiled with JetBrains decompiler
// Type: VendorIntegration.Graph.ACVIPOOrderEntryExt
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;
using PX.Objects.CS;
using PX.Objects.Extensions.AddItemLookup;
using PX.Objects.IN;
using PX.Objects.PO;
using PX.Objects.PO.GraphExtensions.POOrderEntryExt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendorIntegration.DAC;

#nullable disable
namespace VendorIntegration.Graph;

public class ACVIPOOrderEntryExt : PXGraphExtension<POOrderSiteStatusLookupExt, POOrderEntry>
{
  [PXOverride]
  public virtual IEnumerable itemInfo(Func<IEnumerable> baseDelegate)
  {
    PXCache pxCache = (PXCache) GraphHelper.Caches<POSiteStatusFilter>((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base);
    BqlCommand bqlCommand = pxCache.Current == null || !((INSiteStatusFilter) pxCache.Current).OnlyAvailable.GetValueOrDefault() ? (BqlCommand) new Select2<POSiteStatusSelected, CrossJoin<POSetup, LeftJoin<INSiteStatusByCostCenter1, On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter1.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter1.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite1ID>>>, LeftJoin<INSiteStatusByCostCenter2, On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter2.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter2.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite2ID>>>, LeftJoin<INSiteStatusByCostCenter3, On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter3.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter3.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite3ID>>>>>>>, Where<ACVIPOSetupExt.usrSite1ID, Equal<POSiteStatusSelected.siteID>, And<Brackets<Where<BqlField<ACVIPOSiteStatusFilterExt.usrFilterByQty, IBqlBool>.FromCurrent, IsNull, Or<BqlField<ACVIPOSiteStatusFilterExt.usrFilterByQty, IBqlBool>.FromCurrent, Equal<False>, Or<ACVIPOSiteStatusSelectedExt.usrStkMin, Greater<Add<Add<IsNull<INSiteStatusByCostCenter1.qtyAvail, decimal0>, IsNull<INSiteStatusByCostCenter2.qtyAvail, decimal0>>, IsNull<INSiteStatusByCostCenter3.qtyAvail, decimal0>>>, And<Sub<ACVIPOSiteStatusSelectedExt.usrStkMax, Add<Add<IsNull<INSiteStatusByCostCenter1.qtyAvail, decimal0>, IsNull<INSiteStatusByCostCenter2.qtyAvail, decimal0>>, IsNull<INSiteStatusByCostCenter3.qtyAvail, decimal0>>>, Between<BqlField<ACVIPOSiteStatusFilterExt.usrMinQty, IBqlDecimal>.FromCurrent, BqlField<ACVIPOSiteStatusFilterExt.usrMaxQty, IBqlDecimal>.FromCurrent>>>>>>>>>() : (BqlCommand) new Select2<POSiteStatusSelected, InnerJoin<POVendorInventoryOnly, On<BqlChainableConditionMirror<TypeArrayOf<IBqlBinary>.Append<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<POVendorInventoryOnly.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>, And<BqlOperand<POVendorInventoryOnly.vendorID, IBqlInt>.IsEqual<BqlField<POSiteStatusFilter.vendorID, IBqlInt>.FromCurrent>>>>.And<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<POVendorInventoryOnly.subItemID, Equal<POSiteStatusSelected.subItemID>>>>>.Or<BqlOperand<POSiteStatusSelected.subItemID, IBqlInt>.IsNull>>>, CrossJoin<POSetup, LeftJoin<INSiteStatusByCostCenter1, On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter1.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter1.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite1ID>>>, LeftJoin<INSiteStatusByCostCenter2, On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter2.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter2.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite2ID>>>, LeftJoin<INSiteStatusByCostCenter3, On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter3.inventoryID, Equal<POSiteStatusSelected.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter3.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite3ID>>>>>>>>, Where<ACVIPOSetupExt.usrSite1ID, Equal<POSiteStatusSelected.siteID>, And<Brackets<Where<BqlField<ACVIPOSiteStatusFilterExt.usrFilterByQty, IBqlBool>.FromCurrent, IsNull, Or<BqlField<ACVIPOSiteStatusFilterExt.usrFilterByQty, IBqlBool>.FromCurrent, Equal<False>, Or<ACVIPOSiteStatusSelectedExt.usrStkMin, Greater<Add<Add<IsNull<INSiteStatusByCostCenter1.qtyAvail, decimal0>, IsNull<INSiteStatusByCostCenter2.qtyAvail, decimal0>>, IsNull<INSiteStatusByCostCenter3.qtyAvail, decimal0>>>, And<Sub<ACVIPOSiteStatusSelectedExt.usrStkMax, Add<Add<IsNull<INSiteStatusByCostCenter1.qtyAvail, decimal0>, IsNull<INSiteStatusByCostCenter2.qtyAvail, decimal0>>, IsNull<INSiteStatusByCostCenter3.qtyAvail, decimal0>>>, Between<BqlField<ACVIPOSiteStatusFilterExt.usrMinQty, IBqlDecimal>.FromCurrent, BqlField<ACVIPOSiteStatusFilterExt.usrMaxQty, IBqlDecimal>.FromCurrent>>>>>>>>>();
    ACVISetup acviSetup = PXResultset<ACVISetup>.op_Implicit(PXSelectBase<ACVISetup, PXViewOf<ACVISetup>.BasedOn<SelectFromBase<ACVISetup, TypeArrayOf<IFbqlJoin>.Empty>>.Config>.SelectWindowed((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base, 0, 1, Array.Empty<object>()));
    IEnumerable<ACVIFTPSetup> firstTableItems1 = PXSelectBase<ACVIFTPSetup, PXViewOf<ACVIFTPSetup>.BasedOn<SelectFromBase<ACVIFTPSetup, TypeArrayOf<IFbqlJoin>.Empty>>.Config>.Select((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base, Array.Empty<object>()).FirstTableItems;
    IEnumerable<ACVIWarehouseSetup> firstTableItems2 = PXSelectBase<ACVIWarehouseSetup, PXViewOf<ACVIWarehouseSetup>.BasedOn<SelectFromBase<ACVIWarehouseSetup, TypeArrayOf<IFbqlJoin>.Empty>>.Config>.Select((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base, Array.Empty<object>()).FirstTableItems;
    int? vendorID = (int?) ((PXSelectBase<POOrder>) ((PXGraphExtension<POOrderEntry>) this).Base.Document).Current?.VendorID;
    IEnumerable<int> ints = (IEnumerable<int>) new List<int>();
    if (vendorID.HasValue)
    {
      List<int> intList = new List<int>();
      string vendorType = string.Empty;
      ACVIFTPSetup acviftpSetup = firstTableItems1.FirstOrDefault<ACVIFTPSetup>((Func<ACVIFTPSetup, bool>) (x =>
      {
        int? vendorId = x.VendorID;
        int? nullable = vendorID;
        return vendorId.GetValueOrDefault() == nullable.GetValueOrDefault() & vendorId.HasValue == nullable.HasValue;
      }));
      if (acviftpSetup != null)
        vendorType = acviftpSetup.VendorType;
      else if (acviSetup != null)
      {
        int? nullable1 = vendorID;
        int? nullable2 = acviSetup.PUVendorID;
        if (nullable1.GetValueOrDefault() == nullable2.GetValueOrDefault() & nullable1.HasValue == nullable2.HasValue)
        {
          vendorType = "PU";
        }
        else
        {
          nullable2 = vendorID;
          int? wpsVendorId = acviSetup.WPSVendorID;
          if (nullable2.GetValueOrDefault() == wpsVendorId.GetValueOrDefault() & nullable2.HasValue == wpsVendorId.HasValue)
            vendorType = "WP";
        }
      }
      if (!string.IsNullOrEmpty(vendorType))
        ints = firstTableItems2.Where<ACVIWarehouseSetup>((Func<ACVIWarehouseSetup, bool>) (x => x.WarehouseType.StartsWith(vendorType))).Select<ACVIWarehouseSetup, int>((Func<ACVIWarehouseSetup, int>) (x => x.SiteID.Value));
    }
    AddItemLookupBaseExt<POOrderEntry, POOrder, POSiteStatusSelected, POSiteStatusFilter>.LookupView lookupView = new AddItemLookupBaseExt<POOrderEntry, POOrder, POSiteStatusSelected, POSiteStatusFilter>.LookupView((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base, bqlCommand.WhereAnd(((AddItemLookupBaseExt<POOrderEntry, POOrder, POSiteStatusSelected, POSiteStatusFilter>) this.Base1).CreateWhere()));
    int startRow = PXView.StartRow;
    int num1 = 0;
    PXDelegateResult pxDelegateResult = new PXDelegateResult();
    foreach (object obj in ((PXView) lookupView).Select((object[]) null, (object[]) null, PXView.Searches, PXView.SortColumns, PXView.Descendings, PXView.PXFilterRowCollection.op_Implicit(PXView.Filters), ref startRow, PXView.MaximumRows, ref num1))
    {
      POSiteStatusSelected originalItem = PXResult.Unwrap<POSiteStatusSelected>(obj);
      PXResult.Unwrap<POSetup>(obj);
      POSiteStatusSelected siteStatusSelected = originalItem;
      INSiteStatusByCostCenter1 statusByCostCenter1 = PXResult.Unwrap<INSiteStatusByCostCenter1>(obj);
      INSiteStatusByCostCenter2 statusByCostCenter2 = PXResult.Unwrap<INSiteStatusByCostCenter2>(obj);
      INSiteStatusByCostCenter3 statusByCostCenter3 = PXResult.Unwrap<INSiteStatusByCostCenter3>(obj);
      ACVIPOSiteStatusSelectedExt statusSelectedExt1 = PXCacheEx.GetExtension<ACVIPOSiteStatusSelectedExt>((IBqlTable) siteStatusSelected);
      ACVIPOSiteStatusSelectedExt statusSelectedExt2 = statusSelectedExt1;
      Decimal? nullable3 = (Decimal?) statusByCostCenter1?.QtyOnHand;
      Decimal valueOrDefault1 = nullable3.GetValueOrDefault();
      Decimal? nullable4;
      if (statusByCostCenter2 == null)
      {
        nullable3 = new Decimal?();
        nullable4 = nullable3;
      }
      else
        nullable4 = statusByCostCenter2.QtyOnHand;
      nullable3 = nullable4;
      Decimal valueOrDefault2 = nullable3.GetValueOrDefault();
      Decimal num2 = valueOrDefault1 + valueOrDefault2;
      Decimal? nullable5;
      if (statusByCostCenter3 == null)
      {
        nullable3 = new Decimal?();
        nullable5 = nullable3;
      }
      else
        nullable5 = statusByCostCenter3.QtyOnHand;
      nullable3 = nullable5;
      Decimal valueOrDefault3 = nullable3.GetValueOrDefault();
      Decimal? nullable6 = new Decimal?(num2 + valueOrDefault3);
      statusSelectedExt2.UsrTotalQtyOnHand = nullable6;
      ACVIPOSiteStatusSelectedExt statusSelectedExt3 = statusSelectedExt1;
      nullable3 = statusSelectedExt1.UsrStkMin;
      Decimal? nullable7 = new Decimal?(nullable3.GetValueOrDefault());
      statusSelectedExt3.UsrStkMin = nullable7;
      ACVIPOSiteStatusSelectedExt statusSelectedExt4 = statusSelectedExt1;
      nullable3 = statusSelectedExt1.UsrStkMax;
      Decimal? nullable8 = new Decimal?(nullable3.GetValueOrDefault());
      statusSelectedExt4.UsrStkMax = nullable8;
      ACVIPOSiteStatusSelectedExt statusSelectedExt5 = statusSelectedExt1;
      nullable3 = statusSelectedExt1.UsrStkMin;
      Decimal? nullable9 = statusSelectedExt1.UsrTotalQtyOnHand;
      Decimal num3;
      if (!(nullable3.GetValueOrDefault() <= nullable9.GetValueOrDefault() & nullable3.HasValue & nullable9.HasValue))
      {
        nullable9 = statusSelectedExt1.UsrStkMax;
        nullable3 = statusSelectedExt1.UsrTotalQtyOnHand;
        num3 = Math.Max((nullable9.HasValue & nullable3.HasValue ? new Decimal?(nullable9.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new Decimal?()).Value, 0M);
      }
      else
        num3 = 0M;
      Decimal? nullable10 = new Decimal?(num3);
      statusSelectedExt5.UsrDefaultQtyToOrder = nullable10;
      IEnumerable<ARTran> firstTableItems3 = PXSelectBase<ARTran, PXViewOf<ARTran>.BasedOn<SelectFromBase<ARTran, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlOperand<ARTran.inventoryID, IBqlInt>.IsEqual<P.AsInt>>>.Config>.Select((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base, new object[1]
      {
        (object) originalItem.InventoryID
      }).FirstTableItems;
      statusSelectedExt1.UsrS365 = firstTableItems3.Where<ARTran>((Func<ARTran, bool>) (x =>
      {
        DateTime? tranDate = x.TranDate;
        DateTime dateTime = DateTime.Now.AddYears(-1);
        return tranDate.HasValue && tranDate.GetValueOrDefault() > dateTime;
      })).Sum<ARTran>((Func<ARTran, Decimal?>) (x => x.Qty));
      statusSelectedExt1.UsrS30 = firstTableItems3.Where<ARTran>((Func<ARTran, bool>) (x =>
      {
        DateTime? tranDate = x.TranDate;
        DateTime dateTime = DateTime.Now.AddMonths(-1);
        return tranDate.HasValue && tranDate.GetValueOrDefault() > dateTime;
      })).Sum<ARTran>((Func<ARTran, Decimal?>) (x => x.Qty));
      Decimal num4 = 0M;
      foreach (int num5 in ints)
      {
        PXResultset<INSiteStatusByCostCenter> source = PXSelectBase<INSiteStatusByCostCenter, PXViewOf<INSiteStatusByCostCenter>.BasedOn<SelectFromBase<INSiteStatusByCostCenter, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter.siteID, Equal<P.AsInt>>>>>.And<BqlOperand<INSiteStatusByCostCenter.inventoryID, IBqlInt>.IsEqual<P.AsInt>>>>.Config>.SelectWindowed((PXGraph) ((PXGraphExtension<POOrderEntry>) this).Base, 0, 1, new object[2]
        {
          (object) num5,
          (object) originalItem.InventoryID
        });
        if (source != null && source.Count != 0)
        {
          INSiteStatusByCostCenter statusByCostCenter = ((PXResult) ((IQueryable<PXResult<INSiteStatusByCostCenter>>) source).First<PXResult<INSiteStatusByCostCenter>>()).GetItem<INSiteStatusByCostCenter>();
          if (statusByCostCenter != null)
          {
            nullable9 = statusByCostCenter.QtyOnHand;
            Decimal valueOrDefault4 = nullable9.GetValueOrDefault();
            num4 += valueOrDefault4;
          }
        }
      }
      statusSelectedExt1.UsrVendorStock = new Decimal?(num4);
      POSiteStatusSelected updatedItem = ((PXSelectBase<POSiteStatusSelected>) ((AddItemLookupBaseExt<POOrderEntry, POOrder, POSiteStatusSelected, POSiteStatusFilter>) this.Base1).ItemInfo).Locate(originalItem);
      if (updatedItem != null && updatedItem.Selected.GetValueOrDefault())
        siteStatusSelected = this.SetValuesOfSelectedRow(updatedItem, originalItem);
      ((List<object>) pxDelegateResult).Add((object) siteStatusSelected);
    }
    PXView.StartRow = 0;
    if (PXView.ReverseOrder)
      ((List<object>) pxDelegateResult).Reverse();
    pxDelegateResult.IsResultSorted = true;
    return (IEnumerable) pxDelegateResult;
  }

  protected virtual POSiteStatusSelected SetValuesOfSelectedRow(
    POSiteStatusSelected updatedItem,
    POSiteStatusSelected originalItem)
  {
    ((PXSelectBase) ((AddItemLookupBaseExt<POOrderEntry, POOrder, POSiteStatusSelected, POSiteStatusFilter>) this.Base1).ItemInfo).Cache.RestoreCopy((object) updatedItem, (object) originalItem);
    updatedItem.Selected = new bool?(true);
    return updatedItem;
  }
}
