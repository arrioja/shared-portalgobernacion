<%@ Register TagPrefix="uc1" TagName="Pie" Src="Pie.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Paneles" Src="Paneles.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Encabezado" Src="Encabezado.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Default.ascx.cs" Inherits="Portal.Temas.Defecto._Default" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellspacing="0" cellpadding="0" width="100%" height="100%" align="center" border="0">
	<tr valign="top" class="Encabezado" height="1">
		<td>
			<uc1:Encabezado id="Encabezado1" runat="server"></uc1:Encabezado>
		</td>
	</tr>
	<tr valign="bottom" height="*" class="Paneles">
		<td>
			<uc1:Paneles id="Paneles1" runat="server"></uc1:Paneles>
		</td>
	</tr>
	<tr class="Pie" height="1">
		<td align="center" valign="bottom">
			<uc1:Pie id="Pie1" runat="server"></uc1:Pie>
		</td>
	</tr>
</table>
