<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Html.ascx.cs" Inherits="Portal.Modulos.Html.Html" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../Titulo.ascx" %>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="100%">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td>
				<uc1:Titulo id="Titulo1" TextoEditar="Editar" runat="server"></uc1:Titulo>
			</td>
		</tr>
		<tr>
			<td id="MuestraHtml" runat="server">
			</td>
		</tr>
	</tbody>
</table>
<br>
