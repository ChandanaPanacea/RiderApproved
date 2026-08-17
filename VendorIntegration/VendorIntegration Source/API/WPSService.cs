// Decompiled with JetBrains decompiler
// Type: WPSService
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VendorIntegration;
using VendorIntegration.DAC;
using VendorIntegration.Exceptions;

#nullable disable
internal static class WPSService
{
  internal static List<ItemRecord> GetItemRecords(
    ACVIImportItemProcessRecords record,
    IEnumerable<ACVIWarehouseSetup> warehouseSetups)
  {
    RestClient restClient = new RestClient(record.APIEndpoint);
    List<ItemRecord> itemRecords = new List<ItemRecord>();
    string str = (string) null;
    do
    {
      RestRequest restRequest = new RestRequest(string.Empty, (Method) 0);
      RestRequestExtensions.AddQueryParameter(restRequest, "include", "item", true);
      RestRequestExtensions.AddQueryParameter(restRequest, "page[size]", "1000", true);
      if (!string.IsNullOrEmpty(str))
        RestRequestExtensions.AddQueryParameter(restRequest, "page[cursor]", str, true);
      RestRequestExtensions.AddHeader(restRequest, "Authorization", "Bearer " + record.APIPassword);
      RestResponse restResponse = restClient.Execute(restRequest);
      WPSService.WPSInventoryResponse inventoryResponse = ((RestResponseBase) restResponse).IsSuccessful ? JsonConvert.DeserializeObject<WPSService.WPSInventoryResponse>(((RestResponseBase) restResponse).Content) : throw new ACVIHandledException($"API Error {((RestResponseBase) restResponse).StatusCode.ToString()} - {((RestResponseBase) restResponse).Content}");
      if (inventoryResponse == null || inventoryResponse.Data == null)
        throw new ACVIHandledException("Empty API response");
      foreach (WPSService.WPSInventoryData data1 in inventoryResponse.Data)
      {
        WPSService.WPSItemData data2 = data1.Item != null ? data1.Item.Data : (WPSService.WPSItemData) null;
        ItemRecord itemRecord = new ItemRecord()
        {
          InventoryCD = data2 != null ? data2.Sku : data1.Sku,
          Description = data2?.Name,
          Retail = data2 != null ? WPSService.ToDecimalNullable(data2.ListPrice) : new Decimal?(),
          Dealer = data2 != null ? WPSService.ToDecimalNullable(data2.StandardDealerPrice) : new Decimal?(),
          QtyByWarehouse = WPSService.GetQtyByWarehouse(data1, warehouseSetups),
          Closeout = new bool?()
        };
        itemRecords.Add(itemRecord);
      }
      str = inventoryResponse.Meta == null || inventoryResponse.Meta.Cursor == null ? (string) null : inventoryResponse.Meta.Cursor.Next;
    }
    while (!string.IsNullOrEmpty(str));
    return itemRecords;
  }

  private static Dictionary<int, Decimal?> GetQtyByWarehouse(
    WPSService.WPSInventoryData data,
    IEnumerable<ACVIWarehouseSetup> warehouseSetups)
  {
    Dictionary<int, Decimal?> qtyByWarehouse = new Dictionary<int, Decimal?>();
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPCA"), data.CaWarehouse);
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPGA"), data.GaWarehouse);
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPID"), data.IdWarehouse);
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPIN"), data.InWarehouse);
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPPA"), data.PaWarehouse);
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPP2"), data.Pa2Warehouse);
    WPSService.AddQty(qtyByWarehouse, WPSService.GetWarehouseInList(warehouseSetups, "WPTX"), data.TxWarehouse);
    return qtyByWarehouse;
  }

  private static void AddQty(Dictionary<int, Decimal?> qtyByWarehouse, int siteID, int? qty)
  {
    if (siteID == 0)
      return;
    qtyByWarehouse[siteID] = new Decimal?((Decimal) qty.GetValueOrDefault());
  }

  private static int GetWarehouseInList(
    IEnumerable<ACVIWarehouseSetup> warehouseSetups,
    string warehouseType)
  {
    return ((int?) warehouseSetups.FirstOrDefault<ACVIWarehouseSetup>((Func<ACVIWarehouseSetup, bool>) (x => x.WarehouseType == warehouseType))?.SiteID).GetValueOrDefault();
  }

  private static Decimal? ToDecimalNullable(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      return new Decimal?();
    Decimal result;
    return Decimal.TryParse(value, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? new Decimal?(result) : new Decimal?();
  }

  internal class WPSInventoryResponse
  {
    [JsonProperty("data")]
    public List<WPSService.WPSInventoryData> Data { get; set; }

    [JsonProperty("meta")]
    public WPSService.WPSMeta Meta { get; set; }
  }

  internal class WPSInventoryData
  {
    [JsonProperty("sku")]
    public string Sku { get; set; }

    [JsonProperty("total")]
    public int? Total { get; set; }

    [JsonProperty("ca_warehouse")]
    public int? CaWarehouse { get; set; }

    [JsonProperty("ga_warehouse")]
    public int? GaWarehouse { get; set; }

    [JsonProperty("id_warehouse")]
    public int? IdWarehouse { get; set; }

    [JsonProperty("in_warehouse")]
    public int? InWarehouse { get; set; }

    [JsonProperty("pa_warehouse")]
    public int? PaWarehouse { get; set; }

    [JsonProperty("pa2_warehouse")]
    public int? Pa2Warehouse { get; set; }

    [JsonProperty("tx_warehouse")]
    public int? TxWarehouse { get; set; }

    [JsonProperty("item")]
    public WPSService.WPSItemWrapper Item { get; set; }
  }

  internal class WPSItemWrapper
  {
    [JsonProperty("data")]
    public WPSService.WPSItemData Data { get; set; }
  }

  internal class WPSItemData
  {
    [JsonProperty("sku")]
    public string Sku { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("list_price")]
    public string ListPrice { get; set; }

    [JsonProperty("standard_dealer_price")]
    public string StandardDealerPrice { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
  }

  internal class WPSMeta
  {
    [JsonProperty("cursor")]
    public WPSService.WPSCursor Cursor { get; set; }
  }

  internal class WPSCursor
  {
    [JsonProperty("current")]
    public string Current { get; set; }

    [JsonProperty("prev")]
    public string Prev { get; set; }

    [JsonProperty("next")]
    public string Next { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
  }
}
