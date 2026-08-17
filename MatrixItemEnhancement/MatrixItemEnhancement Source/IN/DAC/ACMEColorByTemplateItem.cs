// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.DAC.ACMEColorByTemplateItem
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using MatrixItemEnhancement.Helpers;
using PX.Common;
using PX.CS;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;
using System;

#nullable enable
namespace MatrixItemEnhancement.IN.DAC;

public class ACMEColorByTemplateItem : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXDBIdentity]
  public virtual int? LinkID { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "", IsKey = true)]
  [PXUIField(DisplayName = "Color")]
  [PXSelector(typeof (Search<CSAttributeDetail.valueID, Where<BqlOperand<CSAttributeDetail.attributeID, IBqlString>.IsEqual<ACMEConstants.colorAttribute>>>), new Type[] {typeof (CSAttributeDetail.valueID)}, DescriptionField = typeof (CSAttributeDetail.description))]
  [PXDefault]
  public virtual 
  #nullable disable
  string Color { get; set; }

  [PXDBBool]
  [PXUIField(DisplayName = "Active")]
  [PXDefault(true)]
  public virtual bool? IsActive { get; set; }

  [PXDBInt(IsKey = true)]
  [PXDBDefault(typeof (InventoryItem.inventoryID))]
  [PXParent(typeof (SelectFromBase<InventoryItem, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlOperand<InventoryItem.inventoryID, IBqlInt>.IsEqual<BqlField<ACMEColorByTemplateItem.templateItemID, IBqlInt>.FromCurrent>>))]
  public virtual int? TemplateItemID { get; set; }

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
  [PXUIField(DisplayName = "Tstamp")]
  public virtual byte[] Tstamp { get; set; }

  [PXNote]
  public virtual Guid? Noteid { get; set; }

  public abstract class linkID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACMEColorByTemplateItem.linkID>
  {
  }

  public abstract class color : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACMEColorByTemplateItem.color>
  {
  }

  public abstract class isActive : BqlType<
  #nullable enable
  IBqlBool, bool>.Field<
  #nullable disable
  ACMEColorByTemplateItem.isActive>
  {
  }

  public abstract class templateItemID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    ACMEColorByTemplateItem.templateItemID>
  {
  }

  public abstract class createdByID : 
    BqlType<
    #nullable enable
    IBqlGuid, Guid>.Field<
    #nullable disable
    ACMEColorByTemplateItem.createdByID>
  {
  }

  public abstract class createdByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACMEColorByTemplateItem.createdByScreenID>
  {
  }

  public abstract class createdDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACMEColorByTemplateItem.createdDateTime>
  {
  }

  public abstract class lastModifiedByID : 
    BqlType<
    #nullable enable
    IBqlGuid, Guid>.Field<
    #nullable disable
    ACMEColorByTemplateItem.lastModifiedByID>
  {
  }

  public abstract class lastModifiedByScreenID : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACMEColorByTemplateItem.lastModifiedByScreenID>
  {
  }

  public abstract class lastModifiedDateTime : 
    BqlType<
    #nullable enable
    IBqlDateTime, DateTime>.Field<
    #nullable disable
    ACMEColorByTemplateItem.lastModifiedDateTime>
  {
  }

  public abstract class tstamp : BqlType<
  #nullable enable
  IBqlByteArray, byte[]>.Field<
  #nullable disable
  ACMEColorByTemplateItem.tstamp>
  {
  }

  public abstract class noteid : BqlType<
  #nullable enable
  IBqlGuid, Guid>.Field<
  #nullable disable
  ACMEColorByTemplateItem.noteid>
  {
  }
}
