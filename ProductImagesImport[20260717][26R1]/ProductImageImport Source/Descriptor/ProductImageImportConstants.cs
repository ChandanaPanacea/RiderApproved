// Decompiled with JetBrains decompiler
// Type: ProductImageImport.Descriptor.ProductImageImportConstants
// Assembly: ProductImageImport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62B14B32-6B78-42F3-B1E6-95F477266629
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ProductImagesImport[20260717][26R1] (1)\Bin\ProductImageImport.dll

using PX.Common;

#nullable disable
namespace ProductImageImport.Descriptor;

[PXLocalizable]
public static class ProductImageImportConstants
{
  public const string InventoryCDMissing = "Inventory CD is missing.";
  public const string ImageURLMissing = "Image URL is missing.";
  public const string StockItemNotFound = "Stock Item '{0}' not found.";
  public const string FileUploadFailed = "Unable to save uploaded file.";
  public const string ImageAttachedSuccessfully = "Image attached successfully.";
  public const string StatusSuccess = "Success";
  public const string StatusFailed = "Failed";
  public const string DefaultImageExtension = ".jpg";
  public const string FileNameFormat = "{0}_{1:yyyyMMddHHmmss}{2}";
}
