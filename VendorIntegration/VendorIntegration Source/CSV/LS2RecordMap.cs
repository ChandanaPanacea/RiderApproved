// Decompiled with JetBrains decompiler
// Type: VendorIntegration.CSV.LS2RecordMap
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

public sealed class LS2RecordMap : ClassMap<ItemRecord>
{
  private int _siteID { get; set; }

  public LS2RecordMap(int siteID)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    LS2RecordMap.\u003C\u003Ec__DisplayClass4_0 cDisplayClass40 = new LS2RecordMap.\u003C\u003Ec__DisplayClass4_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass40.siteID = siteID;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass40.\u003C\u003E4__this = this;
    // ISSUE: reference to a compiler-generated field
    this._siteID = cDisplayClass40.siteID;
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.InventoryCD), true).Name(new string[1]
    {
      "PartNumber"
    });
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.Description), true).Name(new string[1]
    {
      "Item Description"
    });
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Dealer), true).Name(new string[1]
    {
      "Dealer Cost"
    });
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Retail), true).Name(new string[1]
    {
      "RetailPrice"
    });
    // ISSUE: method pointer
    this.Map<Dictionary<int, Decimal?>>((Expression<Func<ItemRecord, Dictionary<int, Decimal?>>>) (x => x.QtyByWarehouse), true).Convert(new ConvertFromString<Dictionary<int, Decimal?>>((object) cDisplayClass40, __methodptr(\u003C\u002Ector\u003Eb__5)));
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<bool?>((Expression<Func<ItemRecord, bool?>>) (x => x.Closeout), true).Convert(LS2RecordMap.\u003C\u003Ec.\u003C\u003E9__4_7 ?? (LS2RecordMap.\u003C\u003Ec.\u003C\u003E9__4_7 = new ConvertFromString<bool?>((object) LS2RecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__4_7))));
  }
}
