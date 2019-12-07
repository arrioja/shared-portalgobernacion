<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarBeneficiariosOP.ascx.cs" Inherits="PortalGobernacion.Modulos.GENE.Apoyo.EditarBeneficiariosOP" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="*">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="3">
				Editar Ordenes de Pago por Beneficiario
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Nivel de Acceso:
			</td>
			<td>
				<asp:DropDownList id="Nivel" runat="server" Width="400px">
					<asp:ListItem Value="0">Ordenes</asp:ListItem>
					<asp:ListItem Value="1">Cheques</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td colspan="3">
				<asp:LinkButton id="botonActualiza" Text="Update" runat="server" BorderStyle="none">
										Actualizar</asp:LinkButton>
				&nbsp;
				<asp:LinkButton id="botonCancelar" Text="Cancel" CausesValidation="False" runat="server" BorderStyle="none">
										Cancelar</asp:LinkButton>&nbsp;
				<P></P>
			</td>
		</tr>
	</tbody>
</table>
