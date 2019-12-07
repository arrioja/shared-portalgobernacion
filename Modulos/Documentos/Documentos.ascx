<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Documentos.ascx.cs" Inherits="Portal.Modulos.Documentos.Documentos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" style="WIDTH: 1px; HEIGHT: 1px" cellSpacing="0"
	cellPadding="4" width="1" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td style="WIDTH: 800px; HEIGHT: 1px">
				<P align="left"><uc1:titulo id="Titulo2" runat="server" TextoEditar="Editar"></uc1:titulo></P>
			</td>
		</tr>
	</tbody>
	<TR>
		<TD>
			<P align="left"><asp:datagrid id="ListaDocumentos" runat="server" GridLines="Horizontal" Height="1px" Width="648px"
					HorizontalAlign="Left" CellPadding="0" BorderWidth="1px" BorderStyle="None" CssClass="Grid" AutoGenerateColumns="False"
					BorderColor="#E7E7FF" BackColor="White">
					<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="GridAlterno" BackColor="#F7F7F7"></AlternatingItemStyle>
					<ItemStyle ForeColor="#4A3C8C" CssClass="GridElemento" BackColor="#E7E7FF"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" CssClass="GridTitulo" BackColor="#4A3C8C"></HeaderStyle>
					<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:HyperLink id=Hyperlink1 runat="server" ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" NavigateUrl='<%# "~/Default.aspx?editar=1&amp;pagId=" + pagId + "&amp;DocumentoId=" + DataBinder.Eval(Container.DataItem,"DocumentoId") + "&amp;mid=" + ModuloId+ "&amp;Titulo=" +  DataBinder.Eval(Container.DataItem,"Titulo") %>' Text="Edit">Edit</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:HyperLink id=Hyperlink1 runat="server" ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" NavigateUrl='<%# "~/Default.aspx?editar=1&amp;pagId=" + pagId + "&amp;DocumentoId=" + DataBinder.Eval(Container.DataItem,"DocumentoId") + "&amp;mid=" + ModuloId +"&amp;borrar=1" %>' Text="Edit">Borrar</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n"></asp:BoundColumn>
						<asp:BoundColumn DataField="Formato" HeaderText="Formato"></asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha" HeaderText="Fecha"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Download">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:HyperLink id=Hyperlink1 runat="server" ImageUrl="~/Modulos/Documentos/Imagenes/download.gif" NavigateUrl='<%# "~/Modulos/Documentos/Archivos/"+ DataBinder.Eval(Container.DataItem,"titulo") %>' Text="Edit">Download</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="titulo" HeaderText="Titulo"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></P>
		</TD>
	</TR>
</table>
<P></P>
