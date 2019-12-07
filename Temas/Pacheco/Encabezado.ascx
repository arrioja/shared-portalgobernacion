<%@ Import Namespace="PortalGobernacion.Kernel" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Encabezado.ascx.cs" Inherits="PortalGobernacion.Temas.Pacheco.Encabezado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tbody>
		<tr>
			<td vAlign="top" align="right" colSpan="2">
				<table cellSpacing="0" cellPadding="0">
					<tbody>
						<tr>
							<td vAlign="top">
								<table class="PortalLink" cellSpacing="0" border="0">
									<tbody>
										<tr>
											<td><a 
                  href="<%= Global.ObtenerRuta(Request) %>/Default.aspx" 
                  >P�gina Principal</a>
											</td>
											<td>|
											</td>
											<td><asp:hyperlink id="hypLogin" runat="server">hypLogin</asp:hyperlink></td>
											<td>|
											</td>
											<td><asp:hyperlink id="hypUsuario" runat="server">hypUsuario</asp:hyperlink></td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
					</tbody>
				</table>
			</td>
		</tr>
		<tr vAlign="top">
			<td vAlign="middle" align="left" colSpan="2" style="HEIGHT: 1px">
				<asp:label id="nombrePortal" runat="server" cssclass="TituloPortal">Titulo del Portal</asp:label></td>
		</tr>
		<tr class="OtrasPags" vAlign="bottom" align="left">
			<td vAlign="bottom" align="left">
				<asp:datalist id="Paginas" runat="server" RepeatDirection="Horizontal" CellPadding="0" colspan="2"
					HorizontalAlign="Left" CssClass="OtrasPags" Height="25px">
					<SelectedItemStyle BorderWidth="1px" BorderColor="#FFCC33" CssClass="SeleccionPag" VerticalAlign="Middle"></SelectedItemStyle>
					<SelectedItemTemplate>
						&nbsp;<a href='<%= Global.ObtenerRuta(Request) %>/Default.aspx?pagid=<%# ((Pagina) Container.DataItem).PagId %>' class="SeleccionPag" ><%# ((Pagina) Container.DataItem).PagNombre %></a>&nbsp;
					</SelectedItemTemplate>
					<ItemStyle BorderWidth="1px" BorderColor="Yellow" CssClass="OtrasPags" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
						&nbsp;<a href='<%= Global.ObtenerRuta(Request) %>/Default.aspx?pagid=<%# ((Pagina) Container.DataItem).PagId %>' class="OtrasPags" ><%# ((Pagina) Container.DataItem).PagNombre %></a>&nbsp;
					</ItemTemplate>
				</asp:datalist>
			</td>
		</tr>
		<tr>
			<td bgcolor="yellow" height="2">
			</td>
		</tr>
		<tr>
			<td bgcolor="#3366ff" height="2">
			</td>
		</tr>
	</tbody>
</table>
