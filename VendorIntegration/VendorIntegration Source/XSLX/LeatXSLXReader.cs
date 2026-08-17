// Decompiled with JetBrains decompiler
// Type: VendorIntegration.XSLX.LeatXSLXReader
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#nullable disable
namespace VendorIntegration.XSLX;

internal class LeatXSLXReader
{
  public static List<ItemRecord> ReadItems(byte[] bytes, int siteID)
  {
    List<ItemRecord> itemRecordList = new List<ItemRecord>();
    using (XLSXReader xlsxReader = new XLSXReader(bytes))
    {
      xlsxReader.Reset();
      IDictionary<int, string> dictionary = (IDictionary<int, string>) xlsxReader.IndexKeyPairs.ToDictionary<KeyValuePair<int, string>, int, string>((Func<KeyValuePair<int, string>, int>) (p => p.Key), (Func<KeyValuePair<int, string>, string>) (p => p.Value));
      int index1 = LeatXSLXReader.GetIndex(dictionary, "PartNumber");
      int index2 = LeatXSLXReader.GetIndex(dictionary, "ItemDescription");
      int index3 = LeatXSLXReader.GetIndex(dictionary, "OnHand");
      int index4 = LeatXSLXReader.GetIndex(dictionary, "Dealer4");
      int index5 = LeatXSLXReader.GetIndex(dictionary, "Retail");
      while (xlsxReader.MoveNext())
      {
        string str = xlsxReader.GetValue(index1);
        if (!string.IsNullOrWhiteSpace(str))
          itemRecordList.Add(new ItemRecord()
          {
            InventoryCD = str.Trim(),
            Description = xlsxReader.GetValue(index2),
            Retail = new Decimal?(LeatXSLXReader.ToDecimal(xlsxReader.GetValue(index5))),
            Dealer = new Decimal?(LeatXSLXReader.ToDecimal(xlsxReader.GetValue(index4))),
            QtyByWarehouse = new Dictionary<int, Decimal?>()
            {
              {
                siteID,
                new Decimal?((Decimal) LeatXSLXReader.ToIntQty(xlsxReader.GetValue(index3)))
              }
            },
            Closeout = new bool?(false)
          });
      }
    }
    return itemRecordList;
  }

  private static int GetIndex(IDictionary<int, string> indexes, string columnName)
  {
    KeyValuePair<int, string> keyValuePair = indexes.FirstOrDefault<KeyValuePair<int, string>>((Func<KeyValuePair<int, string>, bool>) (x => string.Equals(x.Value, columnName, StringComparison.OrdinalIgnoreCase)));
    return keyValuePair.Value != null ? keyValuePair.Key : throw new Exception("Colonne introuvable : " + columnName);
  }

  private static int ToIntQty(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      return 0;
    value = value.Trim();
    if (value.EndsWith("+"))
      value = value.Replace("+", string.Empty);
    int result;
    return int.TryParse(value, out result) ? result : 0;
  }

  private static Decimal ToDecimal(string value)
  {
    Decimal result;
    return string.IsNullOrWhiteSpace(value) || !Decimal.TryParse(value, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result) && !Decimal.TryParse(value, NumberStyles.Any, (IFormatProvider) CultureInfo.CurrentCulture, out result) ? 0M : result;
  }
}
