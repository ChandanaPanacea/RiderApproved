// Decompiled with JetBrains decompiler
// Type: ProductImageImport.DAC.ProductImageImport
// Assembly: ProductImageImport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 62B14B32-6B78-42F3-B1E6-95F477266629
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ProductImagesImport[20260717][26R1] (1)\Bin\ProductImageImport.dll

using PX.Data;
using PX.Data.BQL;
using System;

#nullable enable
namespace ProductImageImport.DAC;

[PXCacheName("Product Image Import")]
[Serializable]
public class ProductImageImport : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXBool]
  [PXDefault(false)]
  [PXUIField(DisplayName = "Selected")]
  public virtual bool? Selected { get; set; }

  [PXDBIdentity(IsKey = true)]
  [PXUIField(DisplayName = "Line Nbr.")]
  public virtual int? LineNbr { get; set; }

  [PXDBString(30, IsUnicode = true)]
  [PXUIField(DisplayName = "Inventory CD")]
  public virtual 
  #nullable disable
  string InventoryCD { get; set; }

  [PXDBString(4000, IsUnicode = true)]
  [PXUIField(DisplayName = "Image URL")]
  public virtual string ImageURL { get; set; }

  [PXDBString(4000, IsUnicode = true)]
  [PXUIField(DisplayName = "Message", Enabled = false)]
  public virtual string Message { get; set; }

  [PXDBDateAndTime]
  [PXUIField(DisplayName = "Processed Date", Enabled = false)]
  public virtual DateTime? ProcessedDate { get; set; }

  [PXDBString(30, IsUnicode = true)]
  [PXDefault("Pending")]
  [PXStringList(new string[] {"Pending", "Success", "Failed"}, new string[] {"Pending", "Success", "Failed"})]
  [PXUIField(DisplayName = "Process Status", Enabled = false)]
  public virtual string ProcessStatus { get; set; }

  [PXNote]
  public virtual Guid? NoteID { get; set; }

  [PXDBCreatedByID]
  public virtual Guid? CreatedByID { get; set; }

  [PXDBCreatedByScreenID]
  public virtual string CreatedByScreenID { get; set; }

  [PXDBCreatedDateTime]
  public virtual DateTime? CreatedDateTime { get; set; }

  [PXDBLastModifiedByID]
  public virtual Guid? LastModifiedByID { get; set; }

  [PXDBLastModifiedByScreenID]
  public virtual string LastModifiedByScreenID { get; set; }

  [PXDBLastModifiedDateTime]
  public virtual DateTime? LastModifiedDateTime { get; set; }

  [PXDBTimestamp]
  public virtual byte[] Tstamp { get; set; }

  public abstract class selected : BqlType<
  #nullable enable
  IBqlBool, bool>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.selected>
  {
  }

  public abstract class lineNbr : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.lineNbr>
  {
  }

  public abstract class inventoryCD : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.inventoryCD>
  {
  }

  public abstract class imageURL : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.imageURL>
  {
  }

  public abstract class message : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.message>
  {
  }

  public abstract class processedDate : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.processedDate>
  {
  }

  public abstract class processStatus : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.processStatus>
  {
  }

  public abstract class noteID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.noteID>
  {
  }

  public abstract class createdByID : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.createdByID>
  {
  }

  public abstract class createdByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.createdByScreenID>
  {
  }

  public abstract class createdDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.createdDateTime>
  {
  }

  public abstract class lastModifiedByID : 
    BqlType<
    #nullable enable
    IBqlGuid, Guid>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.lastModifiedByID>
  {
  }

  public abstract class lastModifiedByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.lastModifiedByScreenID>
  {
  }

  public abstract class lastModifiedDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ProductImageImport.DAC.ProductImageImport.lastModifiedDateTime>
  {
  }

  public abstract class tstamp : BqlType<
  #nullable enable
  IBqlByteArray, byte[]>.Field<
  #nullable disable
  ProductImageImport.DAC.ProductImageImport.tstamp>
  {
  }
}
