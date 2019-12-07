<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarImagen.ascx.cs" Inherits="Portal.Modulos.Imagen.EditarImagen" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="*">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="3">
				Editar Imagen
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Ubicación de la Imagen:
			</td>
			<td>
				<asp:textbox id="Ubicacion" runat="server" width="400px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Ancho:
				</p>
			</td>
			<td>
				<asp:textbox id="Ancho" runat="server" width="400px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Alto:
				</p>
			</td>
			<td>
				<asp:textbox id="Alto" runat="server" width="400px"></asp:textbox>
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
