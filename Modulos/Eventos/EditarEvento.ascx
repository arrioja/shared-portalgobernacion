<%@ Register TagPrefix="date" Namespace="PeterBlum.DateTextBoxControls" Assembly="DateTextBoxControls" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarEvento.ascx.cs" Inherits="PortalGobernacion.Modulos.Eventos.EditarEvento" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="*">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="3">
				Editar Evento
			</td>
		</tr>
		<TR>
			<td class="Normal" width="124">
				Titulo:
			</td>
			<td>
				<asp:textbox id="textTitulo" runat="server" width="400px"></asp:textbox>
			</td>
		</TR>
		<tr>
			<td class="Normal" width="124">
				<p>
					Descripcion:
				</p>
			</td>
			<td>
				<FTB:FreeTextBox id="textDescripcion" runat="server"></FTB:FreeTextBox>
			</td>
		</tr>
		<TR>
			<td class="Normal" width="124">
				Fecha:
			</td>
			<td>
				<Date:DateTextBox id="textFecha" runat="server" xPopupURL="popupcalendar.aspx" xImageURL="~/Temas/Defecto/Imagenes/calendar.gif"
					xPopupHeight="160" xPopupWidth="300" xInvalidDateMsg="La fecha es invalida." xTodayKeys="H"></Date:DateTextBox>
			</td>
		</TR>
		<TR>
			<td class="Normal" width="124">
				Lugar:
			</td>
			<td>
				<asp:textbox id="textLugar" runat="server" width="400px"></asp:textbox>
			</td>
		</TR>
		<TR>
			<td class="Normal" width="124">
				Fecha de Vencimiento:
			</td>
			<td>
				<date:DateTextBox id="textVencimiento" runat="server" xPopupURL="popupcalendar.aspx" xImageURL="~/Temas/Defecto/Imagenes/calendar.gif"
					xPopupHeight="160" xPopupWidth="300" xInvalidDateMsg="La fecha es invalida." xTodayKeys="H"></date:DateTextBox>
			</td>
		</TR>
		<tr>
			<td colspan="3">
				<asp:LinkButton id="botonActualiza" Text="Update" runat="server" BorderStyle="none">
										Actualizar</asp:LinkButton>
				&nbsp;
				<asp:LinkButton id="botonBorrar" Text="Cancel" CausesValidation="False" runat="server" BorderStyle="none">
										Borrar</asp:LinkButton>
				&nbsp;
				<asp:LinkButton id="botonCancelar" Text="Cancel" CausesValidation="False" runat="server" BorderStyle="none">
										Cancelar</asp:LinkButton>&nbsp;
				<P></P>
			</td>
		</tr>
	</tbody>
</table>
