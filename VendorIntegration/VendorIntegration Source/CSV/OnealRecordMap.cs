// Decompiled with JetBrains decompiler
// Type: VendorIntegration.CSV.OnealRecordMap
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

public sealed class OnealRecordMap : ClassMap<ItemRecord>
{
  public OnealRecordMap(int siteID)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OnealRecordMap.\u003C\u003Ec__DisplayClass0_0 cDisplayClass00 = new OnealRecordMap.\u003C\u003Ec__DisplayClass0_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass00.siteID = siteID;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.InventoryCD), true).Index(0, -1);
    this.Map<string>((Expression<Func<ItemRecord, string>>) (x => x.Description), true).Index(1, -1);
    // ISSUE: method pointer
    this.Map<Dictionary<int, Decimal?>>((Expression<Func<ItemRecord, Dictionary<int, Decimal?>>>) (x => x.QtyByWarehouse), true).Convert(new ConvertFromString<Dictionary<int, Decimal?>>((object) cDisplayClass00, __methodptr(\u003C\u002Ector\u003Eb__3)));
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Retail), true).Index(4, -1);
    this.Map<Decimal?>((Expression<Func<ItemRecord, Decimal?>>) (x => x.Dealer), true).Index(5, -1);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    this.Map<bool?>((Expression<Func<ItemRecord, bool?>>) (x => x.Closeout), true).Convert(OnealRecordMap.\u003C\u003Ec.\u003C\u003E9__0_7 ?? (OnealRecordMap.\u003C\u003Ec.\u003C\u003E9__0_7 = new ConvertFromString<bool?>((object) OnealRecordMap.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003C\u002Ector\u003Eb__0_7))));
  }
}
