// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.Helpers.ACMECreateMatrixItemsHelper
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using MatrixItemEnhancement.IN;
using MatrixItemEnhancement.IN.DAC;
using PX.Data;
using PX.Objects.IN;
using PX.Objects.IN.Matrix.DAC.Unbound;
using PX.Objects.IN.Matrix.Utility;
using System.Collections.Generic;

#nullable disable
namespace MatrixItemEnhancement.Helpers;

public class ACMECreateMatrixItemsHelper(PXGraph graph) : CreateMatrixItemsHelper(graph)
{
  protected virtual InventoryItem AssignInventoryFields(
    InventoryItemMaintBase graph,
    InventoryItem templateItem,
    InventoryItem item,
    MatrixInventoryItem itemToCreateUpdate,
    bool create)
  {
    base.AssignInventoryFields(graph, templateItem, item, itemToCreateUpdate, create);
    ACMEMatrixInventoryItemExt inventoryItemExt = PXCacheEx.GetExtension<ACMEMatrixInventoryItemExt>((IBqlTable) itemToCreateUpdate);
    if (inventoryItemExt.UsrStkMin.HasValue)
      item = this.AssignInventoryField<ACMEInventoryItemExt.usrStkMin>(graph, item, (object) inventoryItemExt.UsrStkMin);
    if (inventoryItemExt.UsrStkMax.HasValue)
      item = this.AssignInventoryField<ACMEInventoryItemExt.usrStkMax>(graph, item, (object) inventoryItemExt.UsrStkMax);
    if (!string.IsNullOrEmpty(inventoryItemExt.Availability))
      item = this.AssignInventoryField<InventoryItem.availability>(graph, item, (object) inventoryItemExt.Availability);
    if (!string.IsNullOrEmpty(inventoryItemExt.Visibility))
      item = this.AssignInventoryField<InventoryItem.visibility>(graph, item, (object) inventoryItemExt.Visibility);
    return item;
  }

  protected virtual InventoryItem AssignRestInventoryFields(
    InventoryItemMaintBase graph,
    InventoryItem item,
    InventoryItem templateItem,
    HashSet<string> userExcludedFields)
  {
    return base.AssignRestInventoryFields(graph, item, templateItem, userExcludedFields);
  }
}
