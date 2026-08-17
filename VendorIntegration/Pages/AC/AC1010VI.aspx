<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AC1010VI.aspx.cs" Inherits="Page_AC1010VI" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="VendorIntegration.Graph.ACVIFTPSetupMaint"
        PrimaryView="Setup"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Setup" Width="100%" Height="230px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule6" StartColumn="True" ></px:PXLayoutRule>
			<px:PXLayoutRule GroupCaption="Parts Unlimited" runat="server" ID="CstPXLayoutRule9" StartGroup="True" ></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector14" DataField="PUVendorID" ></px:PXSelector>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit3" DataField="PUEndpoint" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit2" DataField="PUDealerNumber" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit5" DataField="PUUsername" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit4" DataField="PUPassword" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit13" DataField="PUFileName" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit13B" DataField="PU2ndFileName" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule7" StartColumn="True" ></px:PXLayoutRule>
			<px:PXLayoutRule GroupCaption="WPS" runat="server" ID="CstPXLayoutRule10" StartGroup="True" ></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector14A" DataField="WPSVendorID" ></px:PXSelector>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit3C" DataField="WPSEndpoint" ></px:PXTextEdit>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit3D" DataField="WPSToken" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule8" StartColumn="True" ></px:PXLayoutRule>
			<px:PXLayoutRule GroupCaption="Global" runat="server" ID="CstPXLayoutRule11" StartGroup="True" ></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector1" DataField="DefaultItemClassID" ></px:PXSelector>
			<px:PXNumberEdit runat="server" ID="LineNbrToTreat" DataField="LineNbrToTreat" ></px:PXNumberEdit>
</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="Warehouses">
				<Template>
					<px:PXGrid Height="400px" Width="1600px" SkinID="Details" runat="server" ID="CstPXGrid13">
						<Levels>
							<px:PXGridLevel DataMember="FTPSetup" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="VendorType" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="VendorID" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Host" Width="220" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Port" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Username" Width="220" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Password" Width="220" ></px:PXGridColumn>
									<px:PXGridColumn DataField="FileName" Width="280" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels></px:PXGrid></Template>
			</px:PXTabItem>
                        <px:PXTabItem Text="FTPs">
				<Template>
					<px:PXGrid Height="400px" Width="1600px" SkinID="Details" runat="server" ID="CstPXGrid12">
						<Levels>
							<px:PXGridLevel DataMember="WarehouseSetup" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="WarehouseType" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="SiteID" Width="140" ></px:PXGridColumn>
                                                                 </Columns></px:PXGridLevel></Levels></px:PXGrid></Template>
			</px:PXTabItem></Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>