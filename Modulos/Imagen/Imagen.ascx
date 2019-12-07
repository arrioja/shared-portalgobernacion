<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Imagen.ascx.cs" Inherits="Portal.Modulos.Imagen.Imagen" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="100%">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td><uc1:Titulo id="Titulo1" TextoEditar="Editar" runat="server"></uc1:Titulo></td>
		</tr>
		<tr>
			<td align="center">
				<asp:Image id="muestraImagen" runat="server"></asp:Image>
			</td>
		</tr>
	</tbody>
</table>
<br>
