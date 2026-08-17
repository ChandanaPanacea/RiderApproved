// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIPOSetupExt
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.IN;
using PX.Objects.PO;

#nullable enable
namespace VendorIntegration.DAC;

public class ACVIPOSetupExt : PXCacheExtension<
#nullable disable
POSetup>
{
  [PXDBInt]
  [PXUIField(DisplayName = "Site 1 ID")]
  [PXSelector(typeof (INSite.siteID), SubstituteKey = typeof (INSite.siteCD))]
  public virtual int? UsrSite1ID { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Site 2 ID")]
  [PXSelector(typeof (INSite.siteID), SubstituteKey = typeof (INSite.siteCD))]
  public virtual int? UsrSite2ID { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Site 3 ID")]
  [PXSelector(typeof (INSite.siteID), SubstituteKey = typeof (INSite.siteCD))]
  public virtual int? UsrSite3ID { get; set; }

  public abstract class usrSite1ID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIPOSetupExt.usrSite1ID>
  {
  }

  public abstract class usrSite2ID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIPOSetupExt.usrSite2ID>
  {
  }

  public abstract class usrSite3ID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIPOSetupExt.usrSite3ID>
  {
  }
}
