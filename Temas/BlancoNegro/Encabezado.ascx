<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Encabezado.ascx.cs" Inherits="Portal.Temas.BlancoNegro.Encabezado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="Portal.Kernel" %>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tbody>
		<tr>
			<td vAlign="top" align="right">
				<table cellSpacing="0" cellPadding="0">
					<tbody>
						<tr>
							<td vAlign="top">
								<table class="PortalLink" cellSpacing="0" cellPadding="4" border="0">
									<tbody>
										<tr>
											<td><a 
                  href="<%= Global.ObtenerRuta(Request) %>/Default.aspx" 
                  >Página Principal</a>
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
			<td vAlign="middle" align="center"><asp:label id="nombrePortal" runat="server" cssclass="TituloPortal">Titulo del Portal</asp:label></td>
		</tr>
		<tr>
			<td bgcolor="black">
			</td>
		</tr>
		<tr class="OtrasPags" vAlign="bottom" align="left">
			<td vAlign="bottom" align="left">
				<asp:datalist id="Paginas" runat="server" RepeatDirection="Horizontal" Height="30px" CellPadding="0"
					HorizontalAlign="Left">
					<SelectedItemStyle BorderWidth="1px" BorderColor="White" CssClass="SeleccionPag" VerticalAlign="Middle"></SelectedItemStyle>
					<SelectedItemTemplate>
						&nbsp;<a href='<%= Global.ObtenerRuta(Request) %>/Default.aspx?pagid=<%# ((Pagina) Container.DataItem).PagId %>' class="SeleccionPag" ><%# ((Pagina) Container.DataItem).PagNombre %></a>&nbsp;
					</SelectedItemTemplate>
					<ItemStyle BorderWidth="1px" BorderColor="DarkGray" CssClass="OtrasPags" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
						&nbsp;<a href='<%= Global.ObtenerRuta(Request) %>/Default.aspx?pagid=<%# ((Pagina) Container.DataItem).PagId %>' class="OtrasPags" ><%# ((Pagina) Container.DataItem).PagNombre %></a>&nbsp;
					</ItemTemplate>
				</asp:datalist>
			</td>
		</tr>
		<tr>
			<td bgcolor="black">
			</td>
		</tr>
	</tbody>
</table>
