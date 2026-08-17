<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="ADPO5000.aspx.cs" Inherits="Page_ADPO5000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>
<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" Width="100%" runat="server" Visible="True" PrimaryView="PickPackFilter" TypeName="ADCPOSource.BLC.ADCSOPickPackMaint" PageLoadBehavior="PopulateSavedValues" />
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" DataMember="PickPackFilter" Caption="Selection" DefaultControlID="edDeleteUpToDate" AllowCollapse="false">
        <Activity HighlightColor="" SelectedColor="" Width="" Height="" />
        <Template>
            <px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="S" ControlSize="XM" />
            <px:PXDropDown CommitChanges="True" ID="edPOSource" runat="server" DataField="POSource" />
            <px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="S" ControlSize="XM" />
            <px:PXSelector CommitChanges="True" ID="edShipVia" runat="server" DataField="ShipVia" />
            <px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="S" ControlSize="XM" />
            <px:PXCheckBox CommitChanges="True" ID="edIsPrintedReport" runat="server" DataField="IsPrintedReport" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid ID="grid" runat="server" Height="400px" Width="100%" Style="z-index: 100" AllowPaging="true" AdjustPageSize="Auto"
        AllowSearch="true" DataSourceID="ds" BatchUpdate="True" SkinID="PrimaryInquire" Caption="Documents" SyncPosition="True" NoteIndicator="false">
        <Levels>
            <px:PXGridLevel DataMember="PickPackOrders">
                <RowTemplate>
                    <px:PXCheckBox ID="chkSelected" runat="server" DataField="Selected" />
                    <px:PXSegmentMask ID="edCustomerID" runat="server" DataField="CustomerID" AllowEdit="True" />
                    <px:PXSelector ID="edOrderType" runat="server" DataField="OrderType" />
                    <px:PXSelector ID="edOrderNbr" runat="server" DataField="OrderNbr" AllowEdit="True" />
                    <px:PXDropDown ID="edStatus" runat="server" DataField="Status" />
                    <px:PXSegmentMask ID="edInventoryID" runat="server" DataField="InventoryID" AllowEdit="True" />
                    <px:PXDropDown ID="edPOSource" runat="server" DataField="POSource" />
                    <px:PXSelector ID="edShipVia" runat="server" DataField="ShipVia" AllowEdit="True" />
                    <px:PXNumberEdit ID="edOrderQty" runat="server" DataField="OrderQty" />
                    <px:PXNumberEdit ID="edCuryUnitPrice" runat="server" DataField="CuryUnitPrice" />
                    <px:PXDateTimeEdit ID="edUsrProcessedDate" runat="server" DataField="UsrProcessedDate"
                                       DisplayFormat="g" />
                </RowTemplate>
                <Columns>
                    <px:PXGridColumn DataField="Selected" TextAlign="Center" Type="CheckBox" AllowCheckAll="True" CommitChanges="True" />
                    <px:PXGridColumn DataField="CustomerID" />
                    <px:PXGridColumn DataField="OrderType" />
                    <px:PXGridColumn DataField="OrderNbr" />
                    <px:PXGridColumn DataField="Status" />
                    <px:PXGridColumn DataField="InventoryID" />
                    <px:PXGridColumn DataField="POSource" />
                    <px:PXGridColumn DataField="ShipVia" />
                    <px:PXGridColumn DataField="OrderQty" />
                    <px:PXGridColumn DataField="CuryUnitPrice" />
                    <px:PXGridColumn DataField="OrderDate" />
                    <px:PXGridColumn DataField="OrderDesc" />
                    <px:PXGridColumn DataField="CustomerOrderNbr" />
                    <px:PXGridColumn DataField="PickPackPrinted" />
                    <px:PXGridColumn DataField="UserName" />
                    <px:PXGridColumn DataField="ProcessedDate" DisplayFormat="M/d/yyyy/h:mm tt" Width="180px"/>
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <Mode AllowAddNew="false" AllowUpdate="false" AllowDelete="false"></Mode>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
    </px:PXGrid>
</asp:Content>
