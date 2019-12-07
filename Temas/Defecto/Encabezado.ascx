<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Encabezado.ascx.cs" Inherits="Portal.Temas.Defecto.Encabezado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="Portal.Kernel" %>
<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tbody>
		<tr>
			<td rowspan="2" vAlign="middle" align="center" height="30"><IMG src="Datos/Imagenes/escudo.jpg" width="70">
			</td>
			<td vAlign="top" align="right" height="30">
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
			<td vAlign="middle" align="left"><asp:label id="nombrePortal" runat="server" cssclass="TituloPortal">Titulo del Portal</asp:label></td>
		</tr>
		<tr vAlign="bottom" height="48">
			<td width="109" height="48" rowSpan="2"><IMG src="Temas/Defecto/Imagenes/tab.slide.hm.li.gif">
			</td>
			<td height="13" align="right" class="PortalLink">
				<asp:Label id="lblFecha" runat="server">Label</asp:Label></td>
		</tr>
		<tr class="OtrasPags" vAlign="bottom" height="35" align="left">
			<td vAlign="bottom" align="left" background="Temas/Defecto/Imagenes/tab.bg.gif" height="35">
				<asp:datalist id="Paginas" runat="server" RepeatDirection="Horizontal" Height="35px" CellPadding="0"
					colspan="2" HorizontalAlign="Left">
					<SelectedItemStyle CssClass="SeleccionPag" VerticalAlign="Middle"></SelectedItemStyle>
					<SelectedItemTemplate>
						&nbsp;<a href='<%= Global.ObtenerRuta(Request) %>/Default.aspx?pagid=<%# ((Pagina) Container.DataItem).PagId %>' class="SeleccionPag" ><%# ((Pagina) Container.DataItem).PagNombre %></a>&nbsp;
					</SelectedItemTemplate>
					<ItemStyle CssClass="OtrasPags" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
						&nbsp;<a href='<%= Global.ObtenerRuta(Request) %>/Default.aspx?pagid=<%# ((Pagina) Container.DataItem).PagId %>' class="OtrasPags" ><%# ((Pagina) Container.DataItem).PagNombre %></a>&nbsp;
					</ItemTemplate>
					<SeparatorTemplate>
						<img src="Temas/Defecto/Imagenes/tab.separator.gif">
					</SeparatorTemplate>
				</asp:datalist>
			</td>
		</tr>
	</tbody>
</table>
