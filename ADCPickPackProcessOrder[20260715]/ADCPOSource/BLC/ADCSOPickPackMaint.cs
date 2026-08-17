// Decompiled with JetBrains decompiler
// Type: ADCPOSource.BLC.ADCSOPickPackMaint
// Assembly: ADCPOSource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12801FBE-42B3-408D-8920-F8FE91893630
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\ADCPickPackProcessOrder[20260715] (1)\Bin\ADCPOSource.dll

using ADCPOSource.DAC;
using ADCPOSource.Extensions.DAC;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.SO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace ADCPOSource.BLC;

public class ADCSOPickPackMaint : PXGraph<
#nullable disable
ADCSOPickPackMaint>
{
  public PXFilter<ADCSOPickPackFilter> PickPackFilter;
  public PXCancel<ADCSOPickPackFilter> Cancel;
  public PXFilteredProcessingOrderBy<ADCSOPickPackProjection, ADCSOPickPackFilter, OrderBy<Desc<ADCSOPickPackProjection.orderDate>>> PickPackOrders;

  public ADCSOPickPackMaint()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ADCSOPickPackMaint.\u003C\u003Ec__DisplayClass3_0 cDisplayClass30 = new ADCSOPickPackMaint.\u003C\u003Ec__DisplayClass3_0();
    // ISSUE: reference to a compiler-generated field
    cDisplayClass30.currentFilter = ((PXSelectBase<ADCSOPickPackFilter>) this.PickPackFilter).Current;
    ((PXProcessing<ADCSOPickPackProjection>) this.PickPackOrders).SetProcessCaption("Process");
    ((PXProcessing<ADCSOPickPackProjection>) this.PickPackOrders).SetProcessAllCaption("Process All");
    // ISSUE: method pointer
    ((PXProcessingBase<ADCSOPickPackProjection>) this.PickPackOrders).SetProcessDelegate(new PXProcessingBase<ADCSOPickPackProjection>.ProcessListDelegate((object) cDisplayClass30, __methodptr(\u003C\u002Ector\u003Eb__0)));
  }

  public virtual IEnumerable pickPackOrders()
  {
    ADCSOPickPackFilter filter = ((PXSelectBase<ADCSOPickPackFilter>) this.PickPackFilter).Current;
    if (filter != null)
    {
      FbqlSelect<SelectFromBase<ADCSOPickPackProjection, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<ADCSOPickPackProjection.status, NotEqual<SOOrderStatus.cancelled>>>>>.And<BqlOperand<ADCSOPickPackProjection.status, IBqlString>.IsNotEqual<SOOrderStatus.expired>>>.Order<By<BqlField<ADCSOPickPackProjection.orderDate, IBqlDateTime>.Desc, BqlField<ADCSOPickPackProjection.orderNbr, IBqlString>.Desc>>, ADCSOPickPackProjection>.View query = new FbqlSelect<SelectFromBase<ADCSOPickPackProjection, TypeArrayOf<IFbqlJoin>.Empty>.Where<BqlChainableConditionBase<TypeArrayOf<IBqlBinary>.FilledWith<And<Compare<ADCSOPickPackProjection.status, NotEqual<SOOrderStatus.cancelled>>>>>.And<BqlOperand<ADCSOPickPackProjection.status, IBqlString>.IsNotEqual<SOOrderStatus.expired>>>.Order<By<BqlField<ADCSOPickPackProjection.orderDate, IBqlDateTime>.Desc, BqlField<ADCSOPickPackProjection.orderNbr, IBqlString>.Desc>>, ADCSOPickPackProjection>.View((PXGraph) this);
      if (!string.IsNullOrWhiteSpace(filter.ShipVia))
        ((PXSelectBase<ADCSOPickPackProjection>) query).WhereAnd<Where<ADCSOPickPackProjection.shipVia, Equal<Current<ADCSOPickPackFilter.shipVia>>>>();
      if (!string.IsNullOrWhiteSpace(filter.POSource))
        ((PXSelectBase<ADCSOPickPackProjection>) query).WhereAnd<Where<ADCSOPickPackProjection.pOSource, Equal<Current<ADCSOPickPackFilter.pOSource>>>>();
      bool? isPrintedReport = filter.IsPrintedReport;
      if (isPrintedReport.GetValueOrDefault())
        ((PXSelectBase<ADCSOPickPackProjection>) query).WhereAnd<Where<ADCSOPickPackProjection.pickPackPrinted, Equal<True>>>();
      isPrintedReport = filter.IsPrintedReport;
      bool flag = false;
      if (isPrintedReport.GetValueOrDefault() == flag & isPrintedReport.HasValue)
        ((PXSelectBase<ADCSOPickPackProjection>) query).WhereAnd<Where<ADCSOPickPackProjection.pickPackPrinted, Equal<False>, Or<ADCSOPickPackProjection.pickPackPrinted, IsNull>>>();
      foreach (PXResult<ADCSOPickPackProjection> pxResult in ((PXSelectBase<ADCSOPickPackProjection>) query).Select(Array.Empty<object>()))
      {
        ADCSOPickPackProjection row = PXResult<ADCSOPickPackProjection>.op_Implicit(pxResult);
        yield return (object) row;
        row = (ADCSOPickPackProjection) null;
      }
    }
  }

  public static void SOPickPackReport(
    List<ADCSOPickPackProjection> list,
    ADCSOPickPackFilter filter)
  {
    PXGraph.CreateInstance<ADCSOPickPackMaint>().SOPickPackReportProcessing(list, filter);
  }

  public virtual void SOPickPackReportProcessing(
    List<ADCSOPickPackProjection> list,
    ADCSOPickPackFilter filter)
  {
    List<ADCSOPickPackProjection> list1 = list.GroupBy(x => new
    {
      OrderType = x.OrderType,
      OrderNbr = x.OrderNbr,
      POSource = x.POSource
    }).Select<IGrouping<\u003C\u003Ef__AnonymousType0<string, string, string>, ADCSOPickPackProjection>, ADCSOPickPackProjection>(x => x.First<ADCSOPickPackProjection>()).ToList<ADCSOPickPackProjection>();
    PXReportRequiredException requiredException = (PXReportRequiredException) null;
    for (int index = 0; index < list1.Count; ++index)
    {
      ADCSOPickPackProjection pickPackProjection = list1[index];
      try
      {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary["SOOrder.OrderType"] = pickPackProjection.OrderType;
        dictionary["SOOrder.OrderNbr"] = pickPackProjection.OrderNbr;
        SOOrder soOrder = SOOrder.PK.Find((PXGraph) this, pickPackProjection.OrderType, pickPackProjection.OrderNbr, (PKFindOptions) 0);
        string str = new NotificationUtility((PXGraph) this).SearchCustomerReport("SO641111", soOrder.CustomerID, soOrder.BranchID);
        requiredException = PXReportRequiredException.CombineReport(requiredException, str, dictionary, OrganizationLocalizationHelper.GetCurrentLocalization((PXGraph) this));
        if (requiredException != null)
          ((PXBaseRedirectException) requiredException).Mode = (PXBaseRedirectException.WindowMode) 2;
        PXDatabase.Update<SOLine>(new PXDataFieldParam[6]
        {
          (PXDataFieldParam) new PXDataFieldAssign<ADCSOLineExt.usrPickPackPrinted>((object) true),
          (PXDataFieldParam) new PXDataFieldAssign<ADCSOLineExt.usrUserName>((object) ((PXGraph) this).Accessinfo.UserName),
          (PXDataFieldParam) new PXDataFieldAssign<ADCSOLineExt.usrProcessedDate>((object) PXTimeZoneInfo.Now),
          (PXDataFieldParam) new PXDataFieldRestrict<SOLine.orderType>((object) pickPackProjection.OrderType),
          (PXDataFieldParam) new PXDataFieldRestrict<SOLine.orderNbr>((object) pickPackProjection.OrderNbr),
          (PXDataFieldParam) new PXDataFieldRestrict<SOLine.lineNbr>((object) pickPackProjection.LineNbr)
        });
        PXProcessing<ADCSOPickPackProjection>.SetInfo(index, "Report generated successfully.");
      }
      catch (Exception ex)
      {
        PXProcessing<ADCSOPickPackProjection>.SetError(index, ex.Message);
      }
    }
    if (requiredException != null)
      throw requiredException;
  }
}
