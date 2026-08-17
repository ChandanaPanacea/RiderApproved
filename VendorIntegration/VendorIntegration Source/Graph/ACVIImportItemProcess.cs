// Decompiled with JetBrains decompiler
// Type: VendorIntegration.Graph.ACVIImportItemProcess
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using CsvHelper;
using CsvHelper.Configuration;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AP;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.PO;
using PX.TM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using VendorIntegration.API;
using VendorIntegration.CSV;
using VendorIntegration.DAC;
using VendorIntegration.Exceptions;
using VendorIntegration.FTP;
using VendorIntegration.XSLX;

#nullable disable
namespace VendorIntegration.Graph;

public class ACVIImportItemProcess : PXGraph<ACVIImportItemProcess>
{
  [PXVirtualDAC]
  public PXProcessing<ACVIImportItemProcessRecords> Records;

  public ACVIImportItemProcess()
  {
    // ISSUE: method pointer
    ((PXProcessingBase<ACVIImportItemProcessRecords>) this.Records).SetProcessDelegate(new PXProcessingBase<ACVIImportItemProcessRecords>.ProcessListDelegate((object) null, __methodptr(ProcessRecords)));
    this.Records.SetProcessCaption("Import");
    this.Records.SetProcessAllCaption("Import all");
  }

  public virtual IEnumerable records()
  {
    ACVISetup setup = PXResultset<ACVISetup>.op_Implicit(PXSelectBase<ACVISetup, PXViewOf<ACVISetup>.BasedOn<SelectFromBase<ACVISetup, TypeArrayOf<IFbqlJoin>.Empty>>.Config>.SelectWindowed((PXGraph) this, 0, 1, Array.Empty<object>()));
    IEnumerable<ACVIFTPSetup> ftps = PXSelectBase<ACVIFTPSetup, PXViewOf<ACVIFTPSetup>.BasedOn<SelectFromBase<ACVIFTPSetup, TypeArrayOf<IFbqlJoin>.Empty>>.Config>.Select((PXGraph) this, Array.Empty<object>()).FirstTableItems;
    foreach (ACVIFTPSetup acviftpSetup in ftps)
    {
      ACVIFTPSetup f = acviftpSetup;
      Vendor vendor = Vendor.PK.Find((PXGraph) this, f.VendorID, (PKFindOptions) 0);
      if (vendor != null)
      {
        ACVIImportItemProcessRecords toInsert = new ACVIImportItemProcessRecords()
        {
          Type = "FTP",
          VendorID = f.VendorID,
          VendorType = f.VendorType,
          FTPHost = f.Host,
          FTPPort = f.Port,
          FTPUsername = f.Username,
          FTPPassword = f.Password,
          FTPFileName = f.FileName,
          LineNbrToTreat = setup.LineNbrToTreat,
          VendorCD = ((BAccount) vendor).AcctCD,
          DefaultItemClassID = setup.DefaultItemClassID
        };
        GraphHelper.Hold(((PXSelectBase) this.Records).Cache, (object) toInsert);
        yield return (object) toInsert;
        vendor = (Vendor) null;
        toInsert = (ACVIImportItemProcessRecords) null;
        f = (ACVIFTPSetup) null;
      }
    }
    if (!string.IsNullOrEmpty(setup.PUEndpoint))
    {
      Vendor vendor = Vendor.PK.Find((PXGraph) this, setup.PUVendorID, (PKFindOptions) 0);
      if (vendor != null)
      {
        ACVIImportItemProcessRecords puRecord = new ACVIImportItemProcessRecords()
        {
          Type = "API",
          VendorID = setup.PUVendorID,
          VendorType = "PU",
          APIDealerNumber = setup.PUDealerNumber,
          APIEndpoint = setup.PUEndpoint,
          APIUsername = setup.PUUsername,
          APIPassword = setup.PUPassword,
          APIFileName = setup.PUFileName,
          API2ndFileName = setup.PU2ndFileName,
          LineNbrToTreat = setup.LineNbrToTreat,
          VendorCD = ((BAccount) vendor).AcctCD,
          DefaultItemClassID = setup.DefaultItemClassID
        };
        GraphHelper.Hold(((PXSelectBase) this.Records).Cache, (object) puRecord);
        yield return (object) puRecord;
        puRecord = (ACVIImportItemProcessRecords) null;
      }
      vendor = (Vendor) null;
    }
    if (!string.IsNullOrEmpty(setup.WPSEndpoint))
    {
      Vendor vendor = Vendor.PK.Find((PXGraph) this, setup.WPSVendorID, (PKFindOptions) 0);
      if (vendor != null)
      {
        ACVIImportItemProcessRecords puRecord = new ACVIImportItemProcessRecords()
        {
          Type = "API",
          VendorID = setup.WPSVendorID,
          VendorType = "WP",
          APIEndpoint = setup.WPSEndpoint,
          APIPassword = setup.WPSToken,
          LineNbrToTreat = setup.LineNbrToTreat,
          DefaultItemClassID = setup.DefaultItemClassID,
          VendorCD = ((BAccount) vendor).AcctCD
        };
        GraphHelper.Hold(((PXSelectBase) this.Records).Cache, (object) puRecord);
        yield return (object) puRecord;
        puRecord = (ACVIImportItemProcessRecords) null;
      }
      vendor = (Vendor) null;
    }
  }

  public static void ProcessRecords(List<ACVIImportItemProcessRecords> records)
  {
    foreach (ACVIImportItemProcessRecords record in records)
    {
      PXProcessing.SetCurrentItem((object) record);
      try
      {
        ACVIImportItemProcess.HandleRecord(record);
        PXProcessing.SetProcessed();
      }
      catch (Exception ex)
      {
        PXProcessing.SetError(ex);
      }
    }
  }

  private static void HandleRecord(ACVIImportItemProcessRecords record)
  {
    INReceiptEntry instance = PXGraph.CreateInstance<INReceiptEntry>();
    List<ItemRecord> itemRecordList = new List<ItemRecord>();
    IEnumerable<ACVIWarehouseSetup> firstTableItems = PXSelectBase<ACVIWarehouseSetup, PXViewOf<ACVIWarehouseSetup>.BasedOn<SelectFromBase<ACVIWarehouseSetup, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlOperand<ACVIWarehouseSetup.warehouseType, IBqlString>.StartsWith<P.AsString>>>.Config>.Select((PXGraph) instance, new object[1]
    {
      (object) record.VendorType
    }).FirstTableItems;
    List<ItemRecord> itemRecords;
    switch (record.VendorType)
    {
      case "HH":
        ClassMap<ItemRecord> classMap1 = (ClassMap<ItemRecord>) new HelmetHouseRecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "HHW"), ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "HHE"));
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap1);
        break;
      case "KL":
        string specificFileName1 = ACVIImportItemProcess.AddSuffixBeforeExtension(record.FTPFileName, "_West");
        string specificFileName2 = ACVIImportItemProcess.AddSuffixBeforeExtension(record.FTPFileName, "_East");
        ClassMap<ItemRecord> classMap2 = (ClassMap<ItemRecord>) new KlimRecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "KLW"));
        ClassMap<ItemRecord> classMap3 = (ClassMap<ItemRecord>) new KlimRecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "KLE"));
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap2, specificFileName1).Concat<ItemRecord>((IEnumerable<ItemRecord>) ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap3, specificFileName2)).GroupBy<ItemRecord, string>((Func<ItemRecord, string>) (x => x.InventoryCD)).Select<IGrouping<string, ItemRecord>, ItemRecord>((Func<IGrouping<string, ItemRecord>, ItemRecord>) (x =>
        {
          ItemRecord itemRecord = x.First<ItemRecord>();
          return new ItemRecord()
          {
            InventoryCD = itemRecord.InventoryCD,
            Description = itemRecord.Description,
            Dealer = itemRecord.Dealer,
            Retail = itemRecord.Retail,
            Closeout = itemRecord.Closeout,
            QtyByWarehouse = x.ToDictionary<ItemRecord, int, Decimal?>((Func<ItemRecord, int>) (y => y.QtyByWarehouse.FirstOrDefault<KeyValuePair<int, Decimal?>>().Key), (Func<ItemRecord, Decimal?>) (y => y.QtyByWarehouse.FirstOrDefault<KeyValuePair<int, Decimal?>>().Value))
          };
        })).ToList<ItemRecord>();
        break;
      case "KYT":
        ClassMap<ItemRecord> classMap4 = (ClassMap<ItemRecord>) new KYTRecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "KYT"));
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap4);
        break;
      case "LEA":
        itemRecords = ACVIImportItemProcess.GetLeatRecordFromXSLX(record, ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "LEA"));
        break;
      case "LS2":
        ClassMap<ItemRecord> classMap5 = (ClassMap<ItemRecord>) new LS2RecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "LS2"));
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap5);
        break;
      case "ON":
        ClassMap<ItemRecord> classMap6 = (ClassMap<ItemRecord>) new OnealRecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "ON"));
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap6);
        break;
      case "PU":
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromPUApi(record, firstTableItems);
        break;
      case "SMK":
        ClassMap<ItemRecord> classMap7 = (ClassMap<ItemRecord>) new SMKRecordMap(ACVIImportItemProcess.GetWarehouseInList(firstTableItems, "SMK"));
        itemRecords = ACVIImportItemProcess.GetItemRecordsFromCSV(record, classMap7, isSftp: true);
        break;
      case "WP":
        itemRecords = WPSService.GetItemRecords(record, firstTableItems);
        break;
      default:
        throw new ACVIHandledException("This vendor is not mapped in the code");
    }
    ACVIImportItemProcess.HandleItemRecord(itemRecords, record, instance);
  }

  private static int GetWarehouseInList(
    IEnumerable<ACVIWarehouseSetup> warehouseSetups,
    string warehouseType)
  {
    return ((int?) warehouseSetups.FirstOrDefault<ACVIWarehouseSetup>((Func<ACVIWarehouseSetup, bool>) (x => x.WarehouseType == warehouseType))?.SiteID).GetValueOrDefault();
  }

  private static void HandleItemRecord(
    List<ItemRecord> itemRecords,
    ACVIImportItemProcessRecords record,
    INReceiptEntry receiptEntry)
  {
    ((PXSelectBase<INRegister>) receiptEntry.receipt).Insert(new INRegister()
    {
      TranDesc = $"{record.VendorCD?.Trim() ?? string.Empty} Vendor stock update"
    });
    INIssueEntry instance1 = PXGraph.CreateInstance<INIssueEntry>();
    ((PXSelectBase<INRegister>) instance1.issue).Insert(new INRegister()
    {
      TranDesc = $"{record.VendorCD?.Trim() ?? string.Empty} Vendor stock update"
    });
    InventoryItemMaint instance2 = PXGraph.CreateInstance<InventoryItemMaint>();
    APVendorPriceMaint instance3 = PXGraph.CreateInstance<APVendorPriceMaint>();
    int num1 = 0;
    foreach (ItemRecord itemRecord in itemRecords)
    {
      PXResult<InventoryItem> pxResult = PXResultset<InventoryItem>.op_Implicit(PXSelectBase<InventoryItem, PXViewOf<InventoryItem>.BasedOn<SelectFromBase<InventoryItem, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlOperand<InventoryItem.inventoryCD, IBqlString>.IsEqual<P.AsString>>>.Config>.SelectWindowed((PXGraph) instance2, 0, 1, new object[1]
      {
        (object) itemRecord.InventoryCD
      }));
      ((PXGraph) instance2).Clear();
      ((PXAction) ((PXGraph<InventoryItemMaintBase, InventoryItem>) instance2).Cancel).Press();
      if (pxResult != null && ((PXResult) pxResult)[typeof (InventoryItem)] != null)
      {
        InventoryItem inventoryItem = ((PXResult) pxResult).GetItem<InventoryItem>();
        ((PXSelectBase<InventoryItem>) ((InventoryItemMaintBase) instance2).Item).Current = inventoryItem;
        inventoryItem.Descr = itemRecord.Description;
        ((PXSelectBase<InventoryItem>) ((InventoryItemMaintBase) instance2).Item).UpdateCurrent();
        IEnumerable<POVendorInventory> firstTableItems1 = ((PXSelectBase<POVendorInventory>) ((InventoryItemMaintBase) instance2).VendorItems).Select(Array.Empty<object>()).FirstTableItems;
        if (!firstTableItems1.Any<POVendorInventory>((Func<POVendorInventory, bool>) (x =>
        {
          int? vendorId3 = x.VendorID;
          int? vendorId4 = record.VendorID;
          return vendorId3.GetValueOrDefault() == vendorId4.GetValueOrDefault() & vendorId3.HasValue == vendorId4.HasValue;
        })))
        {
          ((PXSelectBase<POVendorInventory>) ((InventoryItemMaintBase) instance2).VendorItems).Insert(new POVendorInventory()
          {
            VendorID = record.VendorID
          });
        }
        else
        {
          POVendorInventory poVendorInventory = firstTableItems1.First<POVendorInventory>((Func<POVendorInventory, bool>) (x =>
          {
            int? vendorId1 = x.VendorID;
            int? vendorId2 = record.VendorID;
            return vendorId1.GetValueOrDefault() == vendorId2.GetValueOrDefault() & vendorId1.HasValue == vendorId2.HasValue;
          }));
          ((PXSelectBase<POVendorInventory>) ((InventoryItemMaintBase) instance2).VendorItems).Current = poVendorInventory;
          ((PXSelectBase<POVendorInventory>) ((InventoryItemMaintBase) instance2).VendorItems).UpdateCurrent();
        }
        if (((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).Current == null)
          ((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).Current = PXResultset<InventoryItemCurySettings>.op_Implicit(((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).Select(Array.Empty<object>()));
        Decimal? nullable1;
        if (((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).Current != null)
        {
          nullable1 = itemRecord.Retail;
          int num2;
          if (nullable1.HasValue)
          {
            nullable1 = itemRecord.Retail;
            num2 = nullable1.Value != 0M ? 1 : 0;
          }
          else
            num2 = 0;
          if (num2 != 0)
            ((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).Current.RecPrice = itemRecord.Retail;
          nullable1 = itemRecord.Dealer;
          int num3;
          if (nullable1.HasValue)
          {
            nullable1 = itemRecord.Dealer;
            num3 = nullable1.Value != 0M ? 1 : 0;
          }
          else
            num3 = 0;
          if (num3 != 0)
            ((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).Current.PendingStdCost = itemRecord.Dealer;
          ((PXSelectBase<InventoryItemCurySettings>) ((InventoryItemMaintBase) instance2).ItemCurySettings).UpdateCurrent();
        }
        IEnumerable<CSAnswers> firstTableItems2 = ((PXSelectBase<CSAnswers>) ((InventoryItemMaintBase) instance2).Answers).Select(Array.Empty<object>()).FirstTableItems;
        if (firstTableItems2.Any<CSAnswers>((Func<CSAnswers, bool>) (x => x.AttributeID == "CLOSEDOUT")) && itemRecord.Closeout.HasValue)
        {
          CSAnswers csAnswers = firstTableItems2.First<CSAnswers>((Func<CSAnswers, bool>) (x => x.AttributeID == "CLOSEDOUT"));
          ((PXSelectBase<CSAnswers>) ((InventoryItemMaintBase) instance2).Answers).Current = csAnswers;
          ((PXSelectBase<CSAnswers>) ((InventoryItemMaintBase) instance2).Answers).UpdateCurrent();
          csAnswers.Value = itemRecord.Closeout.Value.ToString();
          ((PXSelectBase<CSAnswers>) ((InventoryItemMaintBase) instance2).Answers).UpdateCurrent();
        }
        ((PXAction) ((PXGraph<InventoryItemMaintBase, InventoryItem>) instance2).Save).Press();
        Decimal? nullable2;
        foreach (KeyValuePair<int, Decimal?> keyValuePair in itemRecord.QtyByWarehouse)
        {
          INLocationStatusByCostCenter statusByCostCenter = PXResultset<INLocationStatusByCostCenter>.op_Implicit(PXSelectBase<INLocationStatusByCostCenter, PXViewOf<INLocationStatusByCostCenter>.BasedOn<SelectFromBase<INLocationStatusByCostCenter, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<INSite>.On<BqlOperand<INSite.siteID, IBqlInt>.IsEqual<INLocationStatusByCostCenter.siteID>>>>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INLocationStatusByCostCenter.inventoryID, Equal<P.AsInt>>>>>.And<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<INLocationStatusByCostCenter.siteID, Equal<P.AsInt>>>>>.And<BqlOperand<INLocationStatusByCostCenter.locationID, IBqlInt>.IsEqual<INSite.receiptLocationID>>>>>.Config>.SelectWindowed((PXGraph) receiptEntry, 0, 1, new object[2]
          {
            (object) ((PXSelectBase<InventoryItem>) ((InventoryItemMaintBase) instance2).Item).Current.InventoryID,
            (object) keyValuePair.Key
          }));
          Decimal? nullable3;
          ref Decimal? local = ref nullable3;
          nullable1 = keyValuePair.Value;
          Decimal num4 = Math.Max(nullable1.GetValueOrDefault(), 0M);
          Decimal? nullable4;
          if (statusByCostCenter == null)
          {
            nullable1 = new Decimal?();
            nullable4 = nullable1;
          }
          else
            nullable4 = statusByCostCenter.QtyOnHand;
          nullable1 = nullable4;
          Decimal valueOrDefault = nullable1.GetValueOrDefault();
          Decimal num5 = num4 - valueOrDefault;
          local = new Decimal?(num5);
          nullable1 = nullable3;
          Decimal num6 = 0M;
          if (!(nullable1.GetValueOrDefault() == num6 & nullable1.HasValue))
          {
            nullable1 = nullable3;
            Decimal num7 = 0M;
            if (nullable1.GetValueOrDefault() < num7 & nullable1.HasValue)
            {
              PXSelect<INTran, Where<INTran.docType, Equal<INDocType.issue>, And<INTran.refNbr, Equal<Current<INRegister.refNbr>>>>> transactions = instance1.transactions;
              INTran inTran = new INTran();
              inTran.SiteID = new int?(keyValuePair.Key);
              inTran.InventoryID = ((PXSelectBase<InventoryItem>) ((InventoryItemMaintBase) instance2).Item).Current.InventoryID;
              nullable1 = nullable3;
              Decimal? nullable5;
              if (!nullable1.HasValue)
              {
                nullable2 = new Decimal?();
                nullable5 = nullable2;
              }
              else
                nullable5 = new Decimal?(-nullable1.GetValueOrDefault());
              inTran.Qty = nullable5;
              inTran.TranCost = new Decimal?(0M);
              inTran.UnitCost = new Decimal?(0M);
              ((PXSelectBase<INTran>) transactions).Insert(inTran);
            }
            else
              ((PXSelectBase<INTran>) receiptEntry.transactions).Insert(new INTran()
              {
                SiteID = new int?(keyValuePair.Key),
                InventoryID = ((PXSelectBase<InventoryItem>) ((InventoryItemMaintBase) instance2).Item).Current.InventoryID,
                Qty = nullable3,
                TranCost = new Decimal?(0M),
                UnitCost = new Decimal?(0M)
              });
          }
        }
        APVendorPrice apVendorPrice1 = PXResultset<APVendorPrice>.op_Implicit(PXSelectBase<APVendorPrice, PXViewOf<APVendorPrice>.BasedOn<SelectFromBase<APVendorPrice, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<InventoryItemCurySettings>.On<BqlOperand<InventoryItemCurySettings.inventoryID, IBqlInt>.IsEqual<APVendorPrice.inventoryID>>>>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<APVendorPrice.expirationDate, IsNull>>>>.And<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<APVendorPrice.inventoryID, Equal<P.AsInt>>>>>.And<BqlOperand<APVendorPrice.vendorID, IBqlInt>.IsEqual<P.AsInt>>>>>.Config>.SelectWindowed((PXGraph) instance3, 0, 1, new object[2]
        {
          (object) inventoryItem.InventoryID,
          (object) record.VendorID
        }));
        int num8;
        if (apVendorPrice1 != null)
        {
          nullable1 = apVendorPrice1.SalesPrice;
          nullable2 = itemRecord.Dealer;
          if (!(nullable1.GetValueOrDefault() == nullable2.GetValueOrDefault() & nullable1.HasValue == nullable2.HasValue))
          {
            num8 = 1;
            goto label_41;
          }
        }
        num8 = apVendorPrice1 != null || !itemRecord.Dealer.HasValue ? 0 : (itemRecord.Dealer.Value != 0M ? 1 : 0);
label_41:
        if (num8 != 0)
        {
          bool flag = false;
          DateTime dateTime;
          if (apVendorPrice1 != null)
          {
            DateTime? effectiveDate = apVendorPrice1.EffectiveDate;
            DateTime date = PXTimeZoneInfo.Now.Date;
            if (effectiveDate.HasValue && effectiveDate.GetValueOrDefault() == date)
            {
              apVendorPrice1.SalesPrice = itemRecord.Dealer;
              ((PXSelectBase<APVendorPrice>) instance3.Records).Update(apVendorPrice1);
              ((PXAction) instance3.Save).Press();
              flag = true;
            }
            if (!flag)
            {
              APVendorPrice apVendorPrice2 = apVendorPrice1;
              dateTime = PXTimeZoneInfo.Now;
              dateTime = dateTime.Date;
              DateTime? nullable6 = new DateTime?(dateTime.AddDays(-1.0));
              apVendorPrice2.ExpirationDate = nullable6;
              ((PXSelectBase<APVendorPrice>) instance3.Records).Update(apVendorPrice1);
            }
          }
          if (!flag)
          {
            PXSelectJoin<APVendorPrice, LeftJoin<InventoryItem, On<InventoryItem.inventoryID, Equal<APVendorPrice.inventoryID>>, LeftJoin<INItemClass, On<INItemClass.itemClassID, Equal<InventoryItem.itemClassID>>, LeftJoin<Vendor, On<APVendorPrice.vendorID, Equal<Vendor.bAccountID>>, LeftJoin<INSite, On<APVendorPrice.siteID, Equal<INSite.siteID>>>>>>, Where2<Where<Vendor.bAccountID, IsNull, Or<Match<Vendor, Current<AccessInfo.userName>>>>, And2<Where<InventoryItem.inventoryID, IsNull, Or<Match<InventoryItem, Current<AccessInfo.userName>>>>, And2<Where<INItemClass.itemClassID, IsNull, Or<Match<INItemClass, Current<AccessInfo.userName>>>>, And2<Where<APVendorPrice.siteID, IsNull, Or<Match<INSite, Current<AccessInfo.userName>>>>, And<InventoryItem.itemStatus, NotEqual<INItemStatus.inactive>, And<InventoryItem.itemStatus, NotEqual<InventoryItemStatus.unknown>, And<InventoryItem.itemStatus, NotEqual<INItemStatus.toDelete>, And2<Where<APVendorPrice.vendorID, Equal<Current<APVendorPriceFilter.vendorID>>, Or<Current<APVendorPriceFilter.vendorID>, IsNull>>, And2<Where<APVendorPrice.siteID, Equal<Current<APVendorPriceFilter.siteID>>, Or<Current<APVendorPriceFilter.siteID>, IsNull>>, And2<Where2<Where2<Where<APVendorPrice.effectiveDate, LessEqual<Optional2<APVendorPriceFilter.effectiveAsOfDate>>, Or<APVendorPrice.effectiveDate, IsNull>>, And<Where<APVendorPrice.expirationDate, GreaterEqual<Optional2<APVendorPriceFilter.effectiveAsOfDate>>, Or<APVendorPrice.expirationDate, IsNull>>>>, Or<Optional2<APVendorPriceFilter.effectiveAsOfDate>, IsNull>>, And<Where2<Where<Current<APVendorPriceFilter.itemClassCD>, IsNull, Or<INItemClass.itemClassCD, Like<Current<APVendorPriceFilter.itemClassCDWildcard>>>>, And2<Where<Current<APVendorPriceFilter.ownerID>, IsNull, Or<Current<APVendorPriceFilter.ownerID>, Equal<InventoryItem.productManagerID>>>, And2<Where<Current<APVendorPriceFilter.myWorkGroup>, Equal<boolFalse>, Or<InventoryItem.productWorkgroupID, IsWorkgroupOfContact<CurrentValue<APVendorPriceFilter.currentOwnerID>>>>, And2<Where<Current<APVendorPriceFilter.workGroupID>, IsNull, Or<Current<APVendorPriceFilter.workGroupID>, Equal<InventoryItem.productWorkgroupID>>>, And<Vendor.bAccountID, IsNotNull>>>>>>>>>>>>>>>>, OrderBy<Asc<InventoryItem.inventoryCD, Asc<APVendorPrice.uOM, Asc<APVendorPrice.breakQty, Asc<APVendorPrice.effectiveDate>>>>>> records = instance3.Records;
            APVendorPrice apVendorPrice3 = new APVendorPrice();
            apVendorPrice3.InventoryID = inventoryItem.InventoryID;
            apVendorPrice3.VendorID = record.VendorID;
            dateTime = PXTimeZoneInfo.Now;
            apVendorPrice3.EffectiveDate = new DateTime?(dateTime.Date);
            apVendorPrice3.SalesPrice = itemRecord.Dealer;
            ((PXSelectBase<APVendorPrice>) records).Insert(apVendorPrice3);
            ((PXAction) instance3.Save).Press();
          }
        }
        ++num1;
        int num9 = num1;
        int? lineNbrToTreat = record.LineNbrToTreat;
        int valueOrDefault1 = lineNbrToTreat.GetValueOrDefault();
        if (num9 == valueOrDefault1 & lineNbrToTreat.HasValue)
          break;
      }
    }
    if (((PXSelectBase<INTran>) receiptEntry.transactions).Select(Array.Empty<object>()).Count > 0)
    {
      ((PXAction) ((PXGraph<PXGraph, INRegister>) receiptEntry).Save).Press();
      if (((PXSelectBase<INRegister>) receiptEntry.receipt).Current.Status == "H")
        ((PXAction) ((INRegisterEntryBase) receiptEntry).releaseFromHold).Press();
      ((PXAction) ((PXGraph<PXGraph, INRegister>) receiptEntry).Cancel).Press();
      ((PXAction) ((INRegisterEntryBase) receiptEntry).release).Press();
    }
    if (((PXSelectBase<INTran>) instance1.transactions).Select(Array.Empty<object>()).Count <= 0)
      return;
    ((PXAction) ((PXGraph<PXGraph, INRegister>) instance1).Save).Press();
    if (((PXSelectBase<INRegister>) instance1.issue).Current.Status == "H")
      ((PXAction) ((INRegisterEntryBase) instance1).releaseFromHold).Press();
    ((PXAction) ((PXGraph<PXGraph, INRegister>) instance1).Cancel).Press();
    ((PXAction) ((INRegisterEntryBase) instance1).release).Press();
  }

  private static string AddSuffixBeforeExtension(string fileFullName, string suffix)
  {
    string directoryName = Path.GetDirectoryName(fileFullName);
    string withoutExtension = Path.GetFileNameWithoutExtension(fileFullName);
    string str = Path.GetExtension(fileFullName);
    string path2 = withoutExtension + suffix + str;
    return string.IsNullOrEmpty(directoryName) ? path2 : Path.Combine(directoryName, path2);
  }

  private static List<ItemRecord> GetItemRecordsFromCSV(
    ACVIImportItemProcessRecords record,
    ClassMap<ItemRecord> classMap,
    string specificFileName = null,
    bool isSftp = false)
  {
    FTPConnectionParameters connection = new FTPConnectionParameters()
    {
      Host = record.FTPHost,
      Port = record.FTPPort,
      Username = record.FTPUsername,
      Password = record.FTPPassword
    };
    return ACVIImportItemProcess.Deserialize(!isSftp ? FTPService.GetFile(connection, specificFileName ?? record.FTPFileName) : SFTPService.GetFile(connection, specificFileName ?? record.FTPFileName), classMap);
  }

  private static List<ItemRecord> GetLeatRecordFromXSLX(
    ACVIImportItemProcessRecords record,
    int siteID)
  {
    return LeatXSLXReader.ReadItems(FTPService.GetFileBytes(new FTPConnectionParameters()
    {
      Host = record.FTPHost,
      Port = record.FTPPort,
      Username = record.FTPUsername,
      Password = record.FTPPassword
    }, record.FTPFileName), siteID);
  }

  private static List<ItemRecord> GetItemRecordsFromPUApi(
    ACVIImportItemProcessRecords record,
    IEnumerable<ACVIWarehouseSetup> warehouseSetups)
  {
    Dictionary<string, string> fileContents = PUService.GetFileContents(record, (IEnumerable<string>) new string[2]
    {
      record.APIFileName,
      record.API2ndFileName
    });
    string csvContent1 = fileContents[record.APIFileName];
    string csvContent2 = fileContents[record.API2ndFileName];
    PUBasePriceFileRecordMap priceFileRecordMap = new PUBasePriceFileRecordMap(ACVIImportItemProcess.GetWarehouseInList(warehouseSetups, "PUWI"), ACVIImportItemProcess.GetWarehouseInList(warehouseSetups, "PUNY"), ACVIImportItemProcess.GetWarehouseInList(warehouseSetups, "PUTX"), ACVIImportItemProcess.GetWarehouseInList(warehouseSetups, "PUNV"), ACVIImportItemProcess.GetWarehouseInList(warehouseSetups, "PUNC"));
    List<ItemRecord> recordsFromPuApi = ACVIImportItemProcess.Deserialize(csvContent1, (ClassMap<ItemRecord>) priceFileRecordMap);
    Dictionary<string, Decimal> dictionary = ACVIImportItemProcess.Deserialize(csvContent2, (ClassMap<ItemRecord>) priceFileRecordMap).Where<ItemRecord>((Func<ItemRecord, bool>) (x => !string.IsNullOrWhiteSpace(x.InventoryCD))).GroupBy<ItemRecord, string>((Func<ItemRecord, string>) (x => x.InventoryCD.Trim())).ToDictionary<IGrouping<string, ItemRecord>, string, Decimal>((Func<IGrouping<string, ItemRecord>, string>) (x => x.Key), (Func<IGrouping<string, ItemRecord>, Decimal>) (x => x.First<ItemRecord>().Dealer.GetValueOrDefault()));
    foreach (ItemRecord itemRecord in recordsFromPuApi)
    {
      Decimal num;
      if (!string.IsNullOrWhiteSpace(itemRecord.InventoryCD) && dictionary.TryGetValue(itemRecord.InventoryCD.Trim(), out num))
        itemRecord.Dealer = new Decimal?(num);
    }
    return recordsFromPuApi;
  }

  private static List<ItemRecord> Deserialize(string csvContent, ClassMap<ItemRecord> classMap)
  {
    CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture, (Type) null)
    {
      HasHeaderRecord = true,
      TrimOptions = (TrimOptions) 1,
      MissingFieldFound = (MissingFieldFound) null,
      HeaderValidated = (HeaderValidated) null,
      BadDataFound = (BadDataFound) null
    };
    using (StringReader stringReader = new StringReader(csvContent))
    {
      using (CsvReader csvReader = new CsvReader((TextReader) stringReader, (IReaderConfiguration) csvConfiguration, false))
      {
        csvReader.Context.RegisterClassMap((ClassMap) classMap);
        return csvReader.GetRecords<ItemRecord>().ToList<ItemRecord>();
      }
    }
  }
}
