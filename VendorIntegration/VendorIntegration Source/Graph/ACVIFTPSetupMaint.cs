// Decompiled with JetBrains decompiler
// Type: VendorIntegration.Graph.ACVIFTPSetupMaint
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Common;
using PX.Data;
using PX.Data.BQL.Fluent;
using VendorIntegration.DAC;

#nullable disable
namespace VendorIntegration.Graph;

public class ACVIFTPSetupMaint : PXGraph<ACVIFTPSetupMaint>
{
  public PXSave<ACVISetup> Save;
  public PXCancel<ACVISetup> Cancel;
  public FbqlSelect<SelectFromBase<ACVISetup, TypeArrayOf<IFbqlJoin>.Empty>, ACVISetup>.View Setup;
  public FbqlSelect<SelectFromBase<ACVIFTPSetup, TypeArrayOf<IFbqlJoin>.Empty>, ACVIFTPSetup>.View FTPSetup;
  public FbqlSelect<SelectFromBase<ACVIWarehouseSetup, TypeArrayOf<IFbqlJoin>.Empty>, ACVIWarehouseSetup>.View WarehouseSetup;
}
