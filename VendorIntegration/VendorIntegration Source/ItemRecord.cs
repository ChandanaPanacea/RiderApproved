// Decompiled with JetBrains decompiler
// Type: VendorIntegration.ItemRecord
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace VendorIntegration;

public class ItemRecord
{
  public string InventoryCD { get; set; }

  public string Description { get; set; }

  public Decimal? Dealer { get; set; }

  public Decimal? Retail { get; set; }

  public bool? Closeout { get; set; }

  public Dictionary<int, Decimal?> QtyByWarehouse { get; set; }
}
