// Decompiled with JetBrains decompiler
// Type: VendorIntegration.CSV.SMKRecordMap
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

public sealed class SMKRecordMap : ClassMap<ItemRecord>
{
  public SMKRecordMap(int siteID)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SMKRecordMap.\u003C\u003Ec__DisplayClass0_0 cDisplayClass00 = new SMKRecordMap.\u003C\u003Ec__DisplayClass0_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass00.siteID = siteID;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.InventoryCD), true).Name(new string[1]
    {
      "SKU"
    });
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.Description), true).Name(new string[1]
    {
      "SKU NAME"
    });
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Retail), true).Name(new string[1]
    {
      "Regular Price"
    });
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Dealer), true).Ignore();
    // ISSUE: method pointer
    this.Map<Dictionary<int, Decimal?>>((Expression<Func<ItemRecord, Dictionary<int, Decimal?>>>) (x => x.QtyByWarehouse), true).Convert(new ConvertFromString<Dictionary<int, Decimal?>>((object) cDisplayClass00, __methodptr(\u003C\u002Ector\u003Eb__5)));
    this.Map<bool?>((Expression<Func<ItemRecord, bool?>>) (x => x.Closeout), true).Ignore();
  }
}
