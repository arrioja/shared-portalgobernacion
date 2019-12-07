<%@ Import Namespace="Portal.Kernel" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MenuIzq.ascx.cs" Inherits="Portal.Temas.BlancoNegro.MenuIzq" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="DUEMETRI.UI.WebControls.HWMenu" Assembly="DUEMETRI.UI.WebControls.HWMenu" %>
<cc1:MENU id="Menu" runat="server" Horizontal="False" Width="170px" ForeColor="Black" Font-Size="8pt"
	Font-Names="Tahoma" BorderColor="Black" CssClass="OtrasPags">
	<ControlItemStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="Black"
		BorderColor="Black"></ControlItemStyle>
	<ArrowImageDown Width="10px" Height="5px" ImageUrl="tridown.gif"></ArrowImageDown>
	<ControlSubStyle BorderStyle="Solid" Font-Size="11pt" Font-Names="Tahoma" Width="300px" BorderWidth="1px"
		ForeColor="Black" BorderColor="Black" BackColor="White"></ControlSubStyle>
	<ControlHiStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="White"
		BorderColor="Black" BackColor="Black"></ControlHiStyle>
	<ControlHiSubStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="White"
		BorderColor="Black" BackColor="Black"></ControlHiSubStyle>
	<ArrowImage Width="5px" Height="10px" ImageUrl="tri2.gif"></ArrowImage>
	<ArrowImageLeft Width="5px" Height="10px" ImageUrl="trileft2.gif"></ArrowImageLeft>
</cc1:MENU>
