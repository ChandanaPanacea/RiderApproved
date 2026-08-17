<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="IMPR5000.aspx.cs" Inherits="Page_IMPR5000" Title="Process Payroll Documents" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>
<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="ProductImageImport.BLC.ProductImageImportMaint"
        PrimaryView="ProductImages" PageLoadBehavior="PopulateSavedValues">
        <CallbackCommands>
            <px:PXDSCallbackCommand Name="Save"></px:PXDSCallbackCommand>
        </CallbackCommands>
        
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid ID="grid" runat="server" DataSourceID="ds" Style="z-index: 100" AllowPaging="true"
        Width="100%" SkinID="PrimaryInquire" SyncPosition="true" NoteIndicator="false" FilesIndicator="false">
        <Levels>
            <px:PXGridLevel DataMember="ProductImages">
                <Columns>
                    <px:PXGridColumn DataField="Selected" Type="CheckBox" TextAlign="Center" Width="60" CommitChanges="True" AllowCheckAll="True"/>
                    <px:PXGridColumn DataField="InventoryCD" Width="180" />
                    <px:PXGridColumn DataField="ImageURL" Width="400" />
                    <px:PXGridColumn DataField="ProcessStatus" Width="100" CommitChanges="True" Type="DropDownList"/>
                    <px:PXGridColumn DataField="Message" Width="500" />
                    <px:PXGridColumn DataField="ProcessedDate" Width="140" DisplayFormat="g" />
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <Mode AllowUpload="true"/>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
        <ActionBar ActionsText="True">
        </ActionBar>
    </px:PXGrid>
</asp:Content>
