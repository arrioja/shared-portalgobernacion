<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Contactos.ascx.cs" Inherits="Portal.Modulos.Contactos.Contactos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table class="TablaModulo" id="Table1" style="WIDTH: 1px; HEIGHT: 1px" cellSpacing="0"
	cellPadding="4" width="1" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td style="WIDTH: 800px; HEIGHT: 1px">
				<P align="left"><uc1:titulo id="Titulo1" runat="server" TextoEditar="Editar"></uc1:titulo></P>
			</td>
		</tr>
		<tr vAlign="top">
			<td style="WIDTH: 1px"><asp:datagrid id="ListaContactos" runat="server" GridLines="Horizontal" Height="1px" Width="800px"
					HorizontalAlign="Left" CellPadding="3" BorderWidth="1px" BorderStyle="None" CssClass="Grid" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
					<ItemStyle ForeColor="#4A3C8C" CssClass="GridElemento"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" CssClass="GridTitulo"></HeaderStyle>
					<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:HyperLink id=Hyperlink1 runat="server" NavigateUrl='<%# "~/Default.aspx?editar=1&amp;pagId=" + pagId + "&amp;CID=" + DataBinder.Eval(Container.DataItem,"ContactoID") + "&amp;mid=" + ModuloId%>' ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" Text="Edit">
								</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
						<asp:BoundColumn DataField="Cargo" HeaderText="Cargo"></asp:BoundColumn>
						<asp:HyperLinkColumn DataTextField="Email" HeaderText="Email"></asp:HyperLinkColumn>
						<asp:BoundColumn DataField="Contacto1" HeaderText="Contacto 1"></asp:BoundColumn>
						<asp:BoundColumn DataField="Contacto2" HeaderText="Contacto 2"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</tr>
	</tbody>
</table>
<br>
