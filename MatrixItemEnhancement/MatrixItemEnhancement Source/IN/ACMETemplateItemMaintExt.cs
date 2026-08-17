// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.ACMETemplateInventoryItemMaintExt
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using MatrixItemEnhancement.Helpers;
using MatrixItemEnhancement.IN.DAC;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.IN.Matrix.DAC.Unbound;
using PX.Objects.IN.Matrix.GraphExtensions;
using PX.Objects.IN.Matrix.Graphs;
using System;
using System.Collections;
using System.Linq;

#nullable enable
namespace MatrixItemEnhancement.IN;

public class ACMETemplateInventoryItemMaintExt : 
  PXGraphExtension<
  #nullable disable
  CreateMatrixItemsTabExt, TemplateInventoryItemMaint>
{
  public FbqlSelect<SelectFromBase<ACMEColorByTemplateItem, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Left<CSAttributeDetail>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<
  #nullable enable
  CSAttributeDetail.attributeID, 
  #nullable disable
  Equal<ACMEConstants.colorAttribute>>>>>.And<BqlOperand<
  #nullable enable
  CSAttributeDetail.valueID, IBqlString>.IsEqual<
  #nullable disable
  ACMEColorByTemplateItem.color>>>>>.Where<BqlOperand<
  #nullable enable
  ACMEColorByTemplateItem.templateItemID, IBqlInt>.IsEqual<
  #nullable disable
  BqlField<
  #nullable enable
  InventoryItem.inventoryID, IBqlInt>.FromCurrent>>, 
  #nullable disable
  ACMEColorByTemplateItem>.View ACMEColorsByTemplateItem;

  [PXOverride]
  public virtual MatrixGridExt<TemplateInventoryItemMaint, InventoryItem>.MatrixAttributeValues GetMatrixAttributeValues()
  {
    CSAttributeDetail[] array1 = PXSelectBase<CSAttributeDetail, PXViewOf<CSAttributeDetail>.BasedOn<SelectFromBase<CSAttributeDetail, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<ACMEColorByTemplateItem>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<CSAttributeDetail.valueID, Equal<ACMEColorByTemplateItem.color>>>>>.And<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<ACMEColorByTemplateItem.templateItemID, Equal<BqlField<EntryHeader.templateItemID, IBqlInt>.FromCurrent>>>>>.And<BqlOperand<ACMEColorByTemplateItem.isActive, IBqlBool>.IsEqual<True>>>>>>.Where<BqlOperand<CSAttributeDetail.attributeID, IBqlString>.IsEqual<BqlField<EntryHeader.colAttributeID, IBqlString>.FromCurrent>>>.Config>.Select((PXGraph) ((PXGraphExtension<TemplateInventoryItemMaint>) this).Base, Array.Empty<object>()).FirstTableItems.ToArray<CSAttributeDetail>();
    CSAttributeDetail[] array2 = GraphHelper.RowCast<CSAttributeDetail>((IEnumerable) ((PXSelectBase<CSAttributeDetail>) new PXSelect<CSAttributeDetail, Where<CSAttributeDetail.attributeID, Equal<Current<EntryHeader.rowAttributeID>>>, OrderBy<Asc<CSAttributeDetail.sortOrder>>>((PXGraph) ((PXGraphExtension<TemplateInventoryItemMaint>) this).Base)).SelectWindowed(0, 3, Array.Empty<object>())).ToArray<CSAttributeDetail>();
    return new MatrixGridExt<TemplateInventoryItemMaint, InventoryItem>.MatrixAttributeValues()
    {
      ColumnValues = array1,
      RowValues = array2
    };
  }
}
