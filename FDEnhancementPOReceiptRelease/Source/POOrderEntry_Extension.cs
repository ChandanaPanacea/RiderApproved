// Decompiled with JetBrains decompiler
// Type: FDEnhancement.Acumatica.PO.POOrderEntry_Extension
// Assembly: PX.FDEnhancementPOReceiptRelease, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 58D7B13D-5027-42AE-B4B7-0574FA380ED3
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\FDEnhancementPOReceiptRelease\Bin\PX.FDEnhancementPOReceiptRelease.dll

using PX.Common;
using PX.Data;
using PX.Objects.PO;
using System;
using System.Collections;

#nullable disable
namespace FDEnhancement.Acumatica.PO;

public class POOrderEntry_Extension : PXGraphExtension<POOrderEntry>
{
  public PXAction<POOrder> createPOReceiptExt;

  [PXUIField]
  [PXProcessButton]
  public virtual IEnumerable CreatePOReceiptExt(PXAdapter adapter)
  {
    if (((PXSelectBase<POOrder>) this.Base.Document).Current != null && EnumerableExtensions.IsIn<string>(((PXSelectBase<POOrder>) this.Base.Document).Current.OrderType, "RO", "DP", "PD"))
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      POOrderEntry_Extension.\u003C\u003Ec__DisplayClass1_0 cDisplayClass10 = new POOrderEntry_Extension.\u003C\u003Ec__DisplayClass1_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass10.order = ((PXSelectBase<POOrder>) this.Base.Document).Current;
      // ISSUE: reference to a compiler-generated field
      if (cDisplayClass10.order.Status == "N")
      {
        this.Base.ValidateLines();
        bool flag = false;
        foreach (PXResult<POLine> pxResult in ((PXSelectBase<POLine>) this.Base.Transactions).Select(Array.Empty<object>()))
        {
          if (this.Base.NeedsPOReceipt(PXResult<POLine>.op_Implicit(pxResult), ((PXSelectBase<POSetup>) this.Base.POSetup).Current))
          {
            flag = true;
            break;
          }
        }
        if (flag)
        {
          ((PXAction) ((PXGraph<POOrderEntry, POOrder>) this.Base).Save).Press();
          // ISSUE: method pointer
          PXLongOperation.StartOperation((PXGraph) this.Base, new PXToggleAsyncDelegate((object) cDisplayClass10, __methodptr(\u003CCreatePOReceiptExt\u003Eb__0)));
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          throw new PXException("The purchase order {0} does not contain any items to be received.", new object[1]
          {
            (object) cDisplayClass10.order.OrderNbr
          });
        }
      }
    }
    return adapter.Get();
  }

  protected virtual void POOrder_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
  {
    POOrder row = (POOrder) e.Row;
    if (row == null)
      return;
    bool flag = false;
    if (row.Status == "N")
      flag = true;
    ((PXAction) this.createPOReceiptExt).SetEnabled(flag);
  }
}
