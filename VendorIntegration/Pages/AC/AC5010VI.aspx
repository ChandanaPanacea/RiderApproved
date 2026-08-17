<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AC5010VI.aspx.cs" Inherits="Page_AC5010VI" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="VendorIntegration.Graph.ACVIImportItemProcess"
        PrimaryView="Records"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Primary" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="Records">
			    <Columns>
			        <px:PXGridColumn AllowCheckAll="True" Type="CheckBox" DataField="Selected" CommitChanges="True"></px:PXGridColumn>
			        <px:PXGridColumn DataField="Type" Width="180" CommitChanges="True"/>
			        <px:PXGridColumn DataField="VendorType" Width="180" CommitChanges="True"/>
			        <px:PXGridColumn DataField="VendorID" Width="180" CommitChanges="True"/>
			    </Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
		</ActionBar>
	</px:PXGrid>
</asp:Content>