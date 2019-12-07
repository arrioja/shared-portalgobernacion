<%@ Register TagPrefix="date" Namespace="PeterBlum.DateTextBoxControls" Assembly="DateTextBoxControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Eventos.ascx.cs" Inherits="PortalGobernacion.Modulos.Eventos.Eventos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td>
				<uc1:Titulo id="Titulo1" TextoEditar="Agregar Evento" runat="server"></uc1:Titulo>
			</td>
		</tr>
		<tr>
			<td>
				<asp:DataList id="dataListEventos" runat="server" DataKeyField="EventoId">
					<ItemTemplate>
						<span class="SubTitulo">
							<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" AlternateText="Editar evento" Visible="<%# EsEditable %>" runat="server" ID="Imagebutton1" NAME="Imagebutton1" />
							<asp:Label Text='<%# DataBinder.Eval(Container.DataItem,"Titulo") %>' runat="server" ID="Label1"/>
						</span>
						<br>
						<span class="Normal"><i>
								<%# ((DateTime)DataBinder.Eval(Container.DataItem,"Fecha")).ToLongDateString() %>
								,
								<%# DataBinder.Eval(Container.DataItem,"Lugar") %>
							</i></span>
						<br>
						<span class="Normal">
							<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>
						</span>
						<br>
					</ItemTemplate>
				</asp:DataList>
			</td>
		</tr>
	</tbody>
</table>
<br>
