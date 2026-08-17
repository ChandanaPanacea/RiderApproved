// Decompiled with JetBrains decompiler
// Type: MatrixItemEnhancement.IN.ACMECreateMatrixItemsExt
// Assembly: MatrixItemEnhancement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BAA2ACD9-8175-448A-8838-DD3E85750580
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\MatrixItemEnhancement (1)\Bin\MatrixItemEnhancement.dll

using MatrixItemEnhancement.IN.DAC;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN.Matrix.DAC.Unbound;
using PX.Objects.IN.Matrix.GraphExtensions;
using PX.Objects.IN.Matrix.Graphs;
using System;
using System.Collections;
using System.Linq;

#nullable disable
namespace MatrixItemEnhancement.IN;

public class ACMECreateMatrixItemsExt : 
  PXGraphExtension<CreateMatrixItems.CreateMatrixItemsImpl, CreateMatrixItems>
{
  [PXOverride]
  public virtual MatrixGridExt<CreateMatrixItems, EntryHeader>.MatrixAttributeValues GetMatrixAttributeValues()
  {
    CSAttributeDetail[] array1 = PXSelectBase<CSAttributeDetail, PXViewOf<CSAttributeDetail>.BasedOn<SelectFromBase<CSAttributeDetail, TypeArrayOf<IFbqlJoin>.Append<TypeArrayOf<IFbqlJoin>.Empty, FbqlJoins.Inner<ACMEColorByTemplateItem>.On<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<CSAttributeDetail.valueID, Equal<ACMEColorByTemplateItem.color>>>>>.And<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<ACMEColorByTemplateItem.templateItemID, Equal<BqlField<EntryHeader.templateItemID, IBqlInt>.FromCurrent>>>>>.And<BqlOperand<ACMEColorByTemplateItem.isActive, IBqlBool>.IsEqual<True>>>>>>.Where<BqlOperand<CSAttributeDetail.attributeID, IBqlString>.IsEqual<BqlField<EntryHeader.colAttributeID, IBqlString>.FromCurrent>>>.Config>.Select((PXGraph) ((PXGraphExtension<CreateMatrixItems>) this).Base, Array.Empty<object>()).FirstTableItems.ToArray<CSAttributeDetail>();
    CSAttributeDetail[] array2 = GraphHelper.RowCast<CSAttributeDetail>((IEnumerable) ((PXSelectBase<CSAttributeDetail>) new PXSelect<CSAttributeDetail, Where<CSAttributeDetail.attributeID, Equal<Current<EntryHeader.rowAttributeID>>>, OrderBy<Asc<CSAttributeDetail.sortOrder>>>((PXGraph) ((PXGraphExtension<CreateMatrixItems>) this).Base)).SelectWindowed(0, 3, Array.Empty<object>())).ToArray<CSAttributeDetail>();
    return new MatrixGridExt<CreateMatrixItems, EntryHeader>.MatrixAttributeValues()
    {
      ColumnValues = array1,
      RowValues = array2
    };
  }

  public virtual void TemplateItemIDFieldUpdated(
    Events.FieldUpdated<EntryHeader, EntryHeader.templateItemID> e)
  {
    if (PXSelectBase<ACMEColorByTemplateItem, PXViewOf<ACMEColorByTemplateItem>.BasedOn<SelectFromBase<ACMEColorByTemplateItem, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlOperand<ACMEColorByTemplateItem.templateItemID, IBqlInt>.IsEqual<P.AsInt>>>.Config>.Select((PXGraph) ((PXGraphExtension<CreateMatrixItems>) this).Base, new object[1]
    {
      (object) e.Row.TemplateItemID
    }).FirstTableItems.Count<ACMEColorByTemplateItem>() != 0)
      return;
    ((PXSelectBase<EntryHeader>) ((HeaderAndAttributesExt<CreateMatrixItems, EntryHeader>) this.Base1).Header).Ask("No colors have been defined for this template item.", (MessageButtons) 0);
  }
}
