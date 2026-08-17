// Decompiled with JetBrains decompiler
// Type: VendorIntegration.CSV.HelmetHouseRecordMap
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#nullable disable
namespace VendorIntegration.CSV;

public sealed class HelmetHouseRecordMap : ClassMap<ItemRecord>
{
  private int _westSiteID { get; set; }

  private int _eastSiteID { get; set; }

  public HelmetHouseRecordMap(int westSiteID, int eastSiteID)
  {
    this._westSiteID = westSiteID;
    this._eastSiteID = eastSiteID;
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.InventoryCD), true).Name(new string[1]
    {
      "Part Number"
    });
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.Description), true).Name(new string[1]
    {
      "Description"
    });
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Dealer), true).Name(new string[1]
    {
      "Dealer"
    });
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Retail), true).Name(new string[1]
    {
      "Retail"
    });
    // ISSUE: method pointer
    this.Map<Dictionary<int, Decimal?>>((Expression<Func<ItemRecord, Dictionary<int, Decimal?>>>) (x => x.QtyByWarehouse), true).Convert(new ConvertFromString<Dictionary<int, Decimal?>>((object) this, __methodptr(\u003C\u002Ector\u003Eb__8_5)));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<bool?>((Expression<Func<ItemRecord, bool?>>) (x => x.Closeout), true).Convert(HelmetHouseRecordMap.\u003C\u003Ec.\u003C\u003E9__8_7 ?? (HelmetHouseRecordMap.\u003C\u003Ec.\u003C\u003E9__8_7 = new ConvertFromString<bool?>((object) HelmetHouseRecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__8_7))));
  }
}
