// Decompiled with JetBrains decompiler
// Type: VendorIntegration.DAC.ACVIImportItemProcessRecords
// Assembly: VendorIntegration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C142D9C-7539-4655-957A-B3253776D413
// Assembly location: C:\Users\HariChandana\OneDrive - Panacea Software Solutions\Acumatica\Rider Approved\Test\VendorIntegration (1)\Bin\VendorIntegration.dll

using PX.Data;
using PX.Data.BQL;
using PX.Objects.AP;
using PX.Objects.IN;

#nullable enable
namespace VendorIntegration.DAC;

[PXVirtual]
public class ACVIImportItemProcessRecords : PXBqlTable, IBqlTable, IBqlTableSystemDataStorage
{
  [PXBool]
  [PXUIField(DisplayName = "Selected")]
  public virtual bool? Selected { get; set; }

  [PXString(50, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Name")]
  [PXStringList(new string[] {"API", "FTP"}, new string[] {"API", "FTP"})]
  public virtual 
  #nullable disable
  string Type { get; set; }

  [PXString(3, IsUnicode = true, InputMask = "", IsKey = true)]
  [PXUIField(DisplayName = "Name")]
  [PXStringList(new string[] {"HH", "KL", "KYT", "LEA", "LS2", "ON", "SMK", "PU", "WP"}, new string[] {"Helmet House", "Klim", "Kyt Americas", "Leatt", "LS2 Dealers", "Oneal", "SMK Helmets", "Parts Unlimited", "Western Power Sports"})]
  public virtual string VendorType { get; set; }

  [PXInt]
  [PXUIField(DisplayName = "Vendor")]
  [PXSelector(typeof (Vendor.bAccountID), SubstituteKey = typeof (Vendor.acctCD))]
  public virtual int? VendorID { get; set; }

  [PXString]
  [PXUIField(DisplayName = "Vendor CD")]
  public virtual string VendorCD { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Default Item Class")]
  [PXSelector(typeof (INItemClass.itemClassID), SubstituteKey = typeof (INItemClass.itemClassCD))]
  public virtual int? DefaultItemClassID { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Max number of lines to Treat")]
  [PXSelector(typeof (INItemClass.itemClassID), SubstituteKey = typeof (INItemClass.itemClassCD))]
  public virtual int? LineNbrToTreat { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Host")]
  public virtual string FTPHost { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Username")]
  public virtual string FTPUsername { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "Password")]
  public virtual string FTPPassword { get; set; }

  [PXDBInt]
  [PXUIField(DisplayName = "Port")]
  public virtual int? FTPPort { get; set; }

  [PXDBString(100, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "File name")]
  public virtual string FTPFileName { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "API Endpoint")]
  public virtual string APIEndpoint { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "API Dealer Number")]
  public virtual string APIDealerNumber { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "API Username")]
  public virtual string APIUsername { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "API Password")]
  public virtual string APIPassword { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "API File Name")]
  public virtual string APIFileName { get; set; }

  [PXDBString(256 /*0x0100*/, IsUnicode = true, InputMask = "")]
  [PXUIField(DisplayName = "API 2nd File Name")]
  public virtual string API2ndFileName { get; set; }

  public abstract class selected : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.selected>
  {
  }

  public abstract class type : BqlType<
  #nullable enable
  IBqlString, string>.Field<
  #nullable disable
  ACVIImportItemProcessRecords.type>
  {
  }

  public abstract class vendorType : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.vendorType>
  {
  }

  public abstract class vendorID : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIImportItemProcessRecords.vendorID>
  {
  }

  public abstract class vendorCD : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.vendorCD>
  {
  }

  public abstract class defaultItemClassID : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.defaultItemClassID>
  {
  }

  public abstract class lineNbrToTreat : 
    BqlType<
    #nullable enable
    IBqlInt, int>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.lineNbrToTreat>
  {
  }

  public abstract class fTPHost : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.fTPHost>
  {
  }

  public abstract class fTPUsername : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.fTPUsername>
  {
  }

  public abstract class fTPPassword : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.fTPPassword>
  {
  }

  public abstract class fTPPort : BqlType<
  #nullable enable
  IBqlInt, int>.Field<
  #nullable disable
  ACVIImportItemProcessRecords.fTPPort>
  {
  }

  public abstract class fTPFileName : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.fTPFileName>
  {
  }

  public abstract class aPIEndpoint : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.aPIEndpoint>
  {
  }

  public abstract class aPIDealerNumber : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.aPIDealerNumber>
  {
  }

  public abstract class aPIUsername : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.aPIUsername>
  {
  }

  public abstract class aPIPassword : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.aPIPassword>
  {
  }

  public abstract class aPIFileName : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.aPIFileName>
  {
  }

  public abstract class aPI2ndFileName : 
    BqlType<
    #nullable enable
    IBqlString, string>.Field<
    #nullable disable
    ACVIImportItemProcessRecords.aPI2ndFileName>
  {
  }
}
