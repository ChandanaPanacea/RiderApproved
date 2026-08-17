// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIWarehousesStatus
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.PO;
using System;

#nullable enable
namespace VendorIntegration.DAC;

[PXProjection(typeof (SelectFromMirror<InventoryItem, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Cross<POSetup>>, FbqlJoins.Left<INSiteStatusByCostCenter1>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter1.inventoryID, Equal<InventoryItem.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter1.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite1ID>>>>, FbqlJoins.Left<INSiteStatusByCostCenter2>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter2.inventoryID, Equal<InventoryItem.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter2.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite2ID>>>>>.LeftJoin<INSiteStatusByCostCenter3>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INSiteStatusByCostCenter3.inventoryID, Equal<InventoryItem.inventoryID>>>>>.And<BqlOperand<INSiteStatusByCostCenter3.siteID, IBqlInt>.IsEqual<ACVIPOSetupExt.usrSite3ID>>>))]
public class ACVIWarehousesStatus : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXDBInt(BqlField = typeof (InventoryItem.inventoryID), IsKey = true)]
  public virtual int? InventoryID { get; set; }

  [PXDBDecimal(BqlField = typeof (INSiteStatusByCostCenter1.qtyAvail))]
  public virtual Decimal? UsrSite1QtyAvail { get; set; }

  [PXDBDecimal(BqlField = typeof (INSiteStatusByCostCenter2.qtyAvail))]
  public virtual Decimal? UsrSite2QtyAvail { get; set; }

  [PXDBDecimal(BqlField = typeof (INSiteStatusByCostCenter3.qtyAvail))]
  public virtual Decimal? UsrSite3QtyAvail { get; set; }

  [PXDBDecimal]
  [PXDBCalced(typeof (Add<Add<IsNull<INSiteStatusByCostCenter1.qtyAvail, decimal0>, IsNull<INSiteStatusByCostCenter2.qtyAvail, decimal0>>, IsNull<INSiteStatusByCostCenter3.qtyAvail, decimal0>>), typeof (Decimal))]
  public virtual Decimal? UsrAllQtyAvail { get; set; }

  public abstract class inventoryID : BqlType<IBqlInt, int>.Field<
  #nullable disable
  ACVIWarehousesStatus.inventoryID>
  {
  }

  public abstract class usrSite1QtyAvail : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIWarehousesStatus.usrSite1QtyAvail>
  {
  }

  public abstract class usrSite2QtyAvail : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIWarehousesStatus.usrSite2QtyAvail>
  {
  }

  public abstract class usrSite3QtyAvail : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIWarehousesStatus.usrSite3QtyAvail>
  {
  }

  public abstract class usrAllQtyAvail : 
    BqlType<
    #nullable enable
    IBqlDecimal, Decimal>.Field<
    #nullable disable
    ACVIWarehousesStatus.usrAllQtyAvail>
  {
  }
}
