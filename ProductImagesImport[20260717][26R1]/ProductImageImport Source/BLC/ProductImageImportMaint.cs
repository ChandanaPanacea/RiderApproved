// Decompiled with JetBrains decompiler
// Type: ProductImageImport.BLC.ProductImageImportMaint
// Assembly: ProductImageImport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62B14B32-6B78-42F3-B1E6-95F477266629
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ProductImagesImport[20260717][26R1] (1)\Bin\ProductImageImport.dll

using PX.Common;
using PX.Data;
using PX.Objects.IN;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

#nullable disable
namespace ProductImageImport.BLC;

public class ProductImageImportMaint : PXGraph<ProductImageImportMaint>
{
  public PXCancel<ProductImageImport.DAC.ProductImageImport> Cancel;
  public PXSave<ProductImageImport.DAC.ProductImageImport> Save;
  [PXImport(typeof (ProductImageImport.DAC.ProductImageImport))]
  public PXSelectOrderBy<ProductImageImport.DAC.ProductImageImport, OrderBy<Desc<ProductImageImport.DAC.ProductImageImport.createdDateTime>>> ProductImages;
  public PXAction<ProductImageImport.DAC.ProductImageImport> Process;
  public PXAction<ProductImageImport.DAC.ProductImageImport> ProcessAll;
  public PXAction<ProductImageImport.DAC.ProductImageImport> ClearData;

  [PXUIField]
  [PXButton]
  protected virtual IEnumerable process(PXAdapter adapter)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ProductImageImportMaint.\u003C\u003Ec__DisplayClass4_0 cDisplayClass40 = new ProductImageImportMaint.\u003C\u003Ec__DisplayClass4_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass40.list = GraphHelper.RowCast<ProductImageImport.DAC.ProductImageImport>((IEnumerable) ((PXSelectBase<ProductImageImport.DAC.ProductImageImport>) this.ProductImages).Select(Array.Empty<object>())).Where<ProductImageImport.DAC.ProductImageImport>((Func<ProductImageImport.DAC.ProductImageImport, bool>) (r => r.Selected.GetValueOrDefault())).ToList<ProductImageImport.DAC.ProductImageImport>();
    // ISSUE: reference to a compiler-generated field
    if (cDisplayClass40.list.Any<ProductImageImport.DAC.ProductImageImport>())
    {
      // ISSUE: method pointer
      PXLongOperation.StartOperation((PXGraph) this, new PXToggleAsyncDelegate((object) cDisplayClass40, __methodptr(\u003Cprocess\u003Eb__1)));
    }
    return adapter.Get();
  }

  [PXUIField]
  [PXButton]
  protected virtual IEnumerable processAll(PXAdapter adapter)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ProductImageImportMaint.\u003C\u003Ec__DisplayClass6_0 cDisplayClass60 = new ProductImageImportMaint.\u003C\u003Ec__DisplayClass6_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass60.list = GraphHelper.RowCast<ProductImageImport.DAC.ProductImageImport>((IEnumerable) ((PXSelectBase<ProductImageImport.DAC.ProductImageImport>) this.ProductImages).Select(Array.Empty<object>())).ToList<ProductImageImport.DAC.ProductImageImport>();
    // ISSUE: reference to a compiler-generated field
    if (cDisplayClass60.list.Any<ProductImageImport.DAC.ProductImageImport>())
    {
      // ISSUE: method pointer
      PXLongOperation.StartOperation((PXGraph) this, new PXToggleAsyncDelegate((object) cDisplayClass60, __methodptr(\u003CprocessAll\u003Eb__0)));
    }
    return adapter.Get();
  }

  [PXButton(CommitChanges = true)]
  [PXUIField]
  protected virtual IEnumerable clearData(PXAdapter adapter)
  {
    if (((PXSelectBase<ProductImageImport.DAC.ProductImageImport>) this.ProductImages).Ask("Please Confirm, Are you sure you want to delete the data?", (MessageButtons) 4) == 6)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ProductImageImportMaint.\u003C\u003Ec__DisplayClass8_0 cDisplayClass80 = new ProductImageImportMaint.\u003C\u003Ec__DisplayClass8_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass80.currentGraph = this;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      PXLongOperation.StartOperation((PXGraph) cDisplayClass80.currentGraph, new PXToggleAsyncDelegate((object) cDisplayClass80, __methodptr(\u003CclearData\u003Eb__0)));
    }
    return adapter.Get();
  }

  public static void ProductImagesUpdate(List<ProductImageImport.DAC.ProductImageImport> list)
  {
    PXGraph.CreateInstance<ProductImageImportMaint>().ProductImagesProcessing(list);
  }

  public virtual void ProductImagesProcessing(List<ProductImageImport.DAC.ProductImageImport> list)
  {
    foreach (ProductImageImport.DAC.ProductImageImport productImageImport1 in list)
    {
      ProductImageImport.DAC.ProductImageImport productImageImport2 = PXResultset<ProductImageImport.DAC.ProductImageImport>.op_Implicit(((PXSelectBase<ProductImageImport.DAC.ProductImageImport>) this.ProductImages).Search<ProductImageImport.DAC.ProductImageImport.lineNbr>((object) productImageImport1.LineNbr, Array.Empty<object>()));
      if (productImageImport2 != null)
      {
        if (!(productImageImport2.ProcessStatus == "Success"))
        {
          try
          {
            if (string.IsNullOrWhiteSpace(productImageImport2.InventoryCD))
              throw new PXException("Inventory CD is missing.");
            if (string.IsNullOrWhiteSpace(productImageImport2.ImageURL))
              throw new PXException("Image URL is missing.");
            InventoryItemMaint instance = PXGraph.CreateInstance<InventoryItemMaint>();
            InventoryItem inventoryItem = PXResultset<InventoryItem>.op_Implicit(((PXSelectBase<InventoryItem>) ((InventoryItemMaintBase) instance).Item).Search<InventoryItem.inventoryCD>((object) productImageImport2.InventoryCD.Trim(), Array.Empty<object>()));
            if (inventoryItem == null)
              throw new PXException("Stock Item '{0}' not found.", new object[1]
              {
                (object) productImageImport2.InventoryCD
              });
            byte[] numArray = ProductImageImportMaint.DownloadImage(productImageImport2.ImageURL.Trim());
            string str1 = Path.GetExtension(new Uri(productImageImport2.ImageURL.Trim()).AbsolutePath);
            if (string.IsNullOrWhiteSpace(str1))
              str1 = ".jpg";
            string str2 = $"{inventoryItem.InventoryCD}_{DateTime.Now:yyyyMMddHHmmss}{str1}";
            FileInfo fileInfo = new FileInfo(Guid.NewGuid(), str2, (string) null, numArray);
            if (!PXGraph.CreateInstance<UploadFileMaintenance>().SaveFile(fileInfo, (FileExistsAction) 1))
              throw new PXException("Unable to save uploaded file.");
            if (fileInfo.UID.HasValue)
              PXNoteAttribute.SetFileNotes((PXCache) GraphHelper.Caches<InventoryItem>((PXGraph) instance), (object) inventoryItem, new Guid[1]
              {
                fileInfo.UID.Value
              });
            ((PXGraph) instance).Actions.PressSave();
            productImageImport2.ProcessStatus = "Success";
            productImageImport2.Message = "Image attached successfully.";
            productImageImport2.ProcessedDate = new DateTime?(PXTimeZoneInfo.Now);
          }
          catch (Exception ex)
          {
            productImageImport2.ProcessStatus = "Failed";
            productImageImport2.Message = ex.Message.ToString();
            productImageImport2.ProcessedDate = new DateTime?(PXTimeZoneInfo.Now);
          }
          ((PXSelectBase<ProductImageImport.DAC.ProductImageImport>) this.ProductImages).Update(productImageImport2);
        }
      }
    }
    ((PXAction) this.Save).Press();
  }

  private static byte[] DownloadImage(string url)
  {
    using (WebClient webClient = new WebClient())
      return webClient.DownloadData(url);
  }
}
