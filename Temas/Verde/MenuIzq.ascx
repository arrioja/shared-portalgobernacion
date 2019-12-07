<%@ Register TagPrefix="cc1" Namespace="DUEMETRI.UI.WebControls.HWMenu" Assembly="DUEMETRI.UI.WebControls.HWMenu" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MenuIzq.ascx.cs" Inherits="Portal.Temas.Verde.MenuIzq" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="Portal.Kernel" %>
<cc1:MENU id="Menu" runat="server" Horizontal="False" Width="170px" ForeColor="#009966" Font-Size="8pt"
	Font-Names="Tahoma" BorderColor="#009966" CssClass="OtrasPags">
	<ControlItemStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="#009966"
		BorderColor="#009966"></ControlItemStyle>
	<ArrowImageDown Width="10px" Height="5px" ImageUrl="tridown.gif"></ArrowImageDown>
	<ControlSubStyle BorderStyle="Solid" Font-Size="11pt" Font-Names="Tahoma" Width="300px" BorderWidth="1px"
		ForeColor="#009966" BorderColor="#009966" BackColor="White"></ControlSubStyle>
	<ControlHiStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="White"
		BorderColor="#009966" BackColor="#009966"></ControlHiStyle>
	<ControlHiSubStyle BorderStyle="Solid" Font-Names="Tahoma" Width="300px" BorderWidth="1px" ForeColor="White"
		BorderColor="#009966" BackColor="#009966"></ControlHiSubStyle>
	<ArrowImage Width="5px" Height="10px" ImageUrl="tri2.gif"></ArrowImage>
	<ArrowImageLeft Width="5px" Height="10px" ImageUrl="trileft2.gif"></ArrowImageLeft>
</cc1:MENU>
