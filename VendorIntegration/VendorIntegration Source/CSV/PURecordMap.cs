// Decompiled with JetBrains decompiler
// Type: VendorIntegration.CSV.PUBasePriceFileRecordMap
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

#nullable disable
namespace VendorIntegration.CSV;

public sealed class PUBasePriceFileRecordMap : ClassMap<ItemRecord>
{
  private readonly int _wiSiteID;
  private readonly int _nySiteID;
  private readonly int _txSiteID;
  private readonly int _nvSiteID;
  private readonly int _ncSiteID;

  public PUBasePriceFileRecordMap(
    int wiSiteID,
    int nySiteID,
    int txSiteID,
    int nvSiteID,
    int ncSiteID)
  {
    this._wiSiteID = wiSiteID;
    this._nySiteID = nySiteID;
    this._txSiteID = txSiteID;
    this._nvSiteID = nvSiteID;
    this._ncSiteID = ncSiteID;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.InventoryCD), true).Convert(PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_1 ?? (PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_1 = new ConvertFromString<string>((object) PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__5_1))));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.Description), true).Convert(PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_3 ?? (PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_3 = new ConvertFromString<string>((object) PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__5_3))));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Retail), true).Convert(PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_5 ?? (PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_5 = new ConvertFromString<Decimal?>((object) PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__5_5))));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Dealer), true).Convert(PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_7 ?? (PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9__5_7 = new ConvertFromString<Decimal?>((object) PUBasePriceFileRecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__5_7))));
    // ISSUE: method pointer
    this.Map<Dictionary<int, Decimal?>>((Expression<Func<ItemRecord, Dictionary<int, Decimal?>>>) (x => x.QtyByWarehouse), true).Convert(new ConvertFromString<Dictionary<int, Decimal?>>((object) this, __methodptr(\u003C\u002Ector\u003Eb__5_9)));
    this.Map<bool?>((Expression<Func<ItemRecord, bool?>>) (x => x.Closeout), true).Ignore();
  }

  private static void AddQty(Dictionary<int, Decimal?> qtyByWarehouse, int siteID, string value)
  {
    if (siteID == 0 || string.IsNullOrWhiteSpace(value))
      return;
    qtyByWarehouse[siteID] = new Decimal?((Decimal) PUBasePriceFileRecordMap.ToQty(value));
  }

  private static int ToQty(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      return 0;
    value = value.Trim();
    if (string.Equals(value, "N/A", StringComparison.OrdinalIgnoreCase))
      return 0;
    if (value.EndsWith("+", StringComparison.Ordinal))
      value = value.Replace("+", string.Empty);
    int result;
    return int.TryParse(value, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? result : 0;
  }

  private static string GetField(IReaderRow row, params string[] names)
  {
    foreach (string name in names)
    {
      string field;
      if (row.TryGetField<string>(name, ref field))
        return field;
    }
    return (string) null;
  }

  private static Decimal? ToDecimalNullable(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      return new Decimal?();
    value = value.Trim();
    if (string.Equals(value, "N/A", StringComparison.OrdinalIgnoreCase))
      return new Decimal?();
    Decimal result;
    return Decimal.TryParse(value, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? new Decimal?(result) : new Decimal?();
  }
}
