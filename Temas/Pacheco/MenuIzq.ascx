<%@ Register TagPrefix="cc1" Namespace="DUEMETRI.UI.WebControls.HWMenu" Assembly="DUEMETRI.UI.WebControls.HWMenu" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MenuIzq.ascx.cs" Inherits="PortalGobernacion.Temas.Pacheco.MenuIzq" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="PortalGobernacion.Kernel" %>
<cc1:MENU id="Menu" runat="server" Horizontal="False" Width="170px" ForeColor="White" Font-Size="8pt"
	Font-Names="Tahoma" BorderColor="#B4CEE5" CssClass="OtrasPags">
	<ControlItemStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="White"
		CssClass="OtrasPags"></ControlItemStyle>
	<ArrowImageDown Width="10px" Height="5px" ImageUrl="tridown.gif"></ArrowImageDown>
	<ControlSubStyle BorderStyle="Solid" Font-Size="11pt" Font-Names="Tahoma" Width="300px" BorderWidth="1px"
		ForeColor="White" CssClass="OtrasPags"></ControlSubStyle>
	<ControlHiStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="#336699"
		CssClass="SeleccionPag"></ControlHiStyle>
	<ControlHiSubStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="#336699"
		CssClass="SeleccionPag"></ControlHiSubStyle>
	<ArrowImage Width="5px" Height="10px" ImageUrl="tri.gif"></ArrowImage>
	<ArrowImageLeft Width="5px" Height="10px" ImageUrl="trileft.gif"></ArrowImageLeft>
</cc1:MENU>
