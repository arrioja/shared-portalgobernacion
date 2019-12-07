<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Paneles.ascx.cs" Inherits="Portal.Temas.BlancoNegro.Paneles" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="MenuIzq" Src="MenuIzq.ascx" %>
<table cellspacing="0" cellpadding="4" width="100%" height="100%" border="0">
	<tbody>
		<tr valign="top" height="100%">
			<td id="Izquierda" width="180" runat="server" visible="true" class="PanelIzq">
				<uc1:MenuIzq id="MenuIzq1" runat="server"></uc1:MenuIzq>
				<br>
			</td>
			<td width="1">
			</td>
			<td id="Centro" width="*" runat="server" Visible="false" class="PanelCentr">
			</td>
			<td id="Derecha" width="230" runat="server" visible="false" class="PanelDer">
			</td>
		</tr>
	</tbody>
</table>
