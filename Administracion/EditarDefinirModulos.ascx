<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarDefinirModulos.ascx.cs" Inherits="Portal.Administracion.EditarDefinirModulos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="*">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="2">
				Definición de Módulo
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Nombre:
			</td>
			<td>
				<asp:textbox id="textNombre" runat="server" width="400px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Ubicación:
				</p>
			</td>
			<td>
				<asp:textbox id="textUbicacion" runat="server" width="400px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Ubicación para Edición:
				</p>
			</td>
			<td>
				<asp:textbox id="textEdicion" runat="server" width="400px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:LinkButton id="botonActualiza" Text="Update" runat="server" BorderStyle="none">
										Actualizar</asp:LinkButton>
				&nbsp;
				<asp:LinkButton id="botonCancelar" Text="Cancel" CausesValidation="False" runat="server" BorderStyle="none">
										Cancelar</asp:LinkButton>&nbsp; &nbsp;
				<asp:LinkButton id="botonEliminar" runat="server" BorderStyle="none" Text="Cancel" CausesValidation="False">
										Eliminar</asp:LinkButton><p></p>
			</td>
		</tr>
	</tbody>
</table>
