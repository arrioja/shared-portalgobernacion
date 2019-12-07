<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarXml.ascx.cs" Inherits="Portal.Modulos.Xml.EditarXml" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="*">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="3">
				Editar Xml
			</td>
		</tr>
		<TR>
			<td class="Normal" width="124">
				Archivo de Datos XML:
			</td>
			<td>
				<asp:textbox id="XmlData" runat="server" width="400px"></asp:textbox>
			</td>
		</TR>
		<tr>
			<td class="Normal" width="124">
				<p>
					Archivo de Transformación XSL/T:
				</p>
			</td>
			<td>
				<asp:textbox id="XslTransform" runat="server" width="400px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td colspan="3">
				<asp:LinkButton id="botonActualiza" Text="Update" runat="server" BorderStyle="none">
										Actualizar</asp:LinkButton>
				&nbsp;
				<asp:LinkButton id="botonCancelar" Text="Cancel" CausesValidation="False" runat="server"
					BorderStyle="none">
										Cancelar</asp:LinkButton>&nbsp;
				<P></P>
			</td>
		</tr>
	</tbody>
</table>
