<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AnalisisDePrecio.ascx.cs" Inherits="Portal.Modulos.GENE.Apoyo.AnalisisDePrecio" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td><uc1:titulo id="Titulo1" runat="server"></uc1:titulo></td>
		</tr>
		<tr>
			<td style="HEIGHT: 21px" colSpan="3"><asp:label id="Label1" runat="server">Suministro:</asp:label>&nbsp;
				<asp:textbox id="Busqueda" runat="server"></asp:textbox>&nbsp;
				<asp:button id="botonBuscar" runat="server" Text="Buscar"></asp:button></td>
		</tr>
		<tr>
			<td><asp:datagrid id="dgSuministros" runat="server" OnItemCommand="Insertar_Suministro" ShowFooter="True"
					AllowPaging="True" CssClass="Grid" Width="100%" AutoGenerateColumns="False" AllowSorting="false">
					<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
					<ItemStyle CssClass="GridElemento"></ItemStyle>
					<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn ItemStyle-Wrap="false">
							<ItemTemplate>
								<asp:LinkButton ID="lnkSeleccion" Visible="True" Runat="server" CommandName="Select" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Descripcion").ToString()%>' >
									<%# DataBinder.Eval(Container.DataItem, "Descripcion").ToString()%>
								</asp:LinkButton>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Precio" HeaderText="Precio"></asp:BoundColumn>
						<asp:BoundColumn DataField="Cod_Suministro" HeaderText="Código"></asp:BoundColumn>
					</Columns>
					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</tr>
		<tr class="TituloModulo">
			<td><asp:label id="Label2" runat="server">Número:</asp:label><asp:textbox id="Numero" runat="server" Width="96px"></asp:textbox><asp:button id="BotonRestablecer" runat="server" Text="Reestablecer"></asp:button><asp:button id="btnImprimir" runat="server" Text="Imprimir" Font-Bold="True"></asp:button></td>
		</tr>
		<tr class="TituloModulo">
			<td><asp:label id="Label3" runat="server">Prov. 1:</asp:label><asp:dropdownlist id="tdl_Proveedor1" runat="server" width="180px"></asp:dropdownlist><asp:label id="Label4" runat="server">Prov. 2:</asp:label><asp:dropdownlist id="tdl_Proveedor2" runat="server" width="180px"></asp:dropdownlist><asp:label id="Label5" runat="server">Prov. 3:</asp:label><asp:dropdownlist id="tdl_Proveedor3" runat="server" width="180px"></asp:dropdownlist></td>
		</tr>
		<tr>
			<asp:datagrid id="dgAnalisis" runat="server" OnItemCommand="DataGrid_Edit" CssClass="Grid" AutoGenerateColumns="False"
				OnItemCreated="Item_Created" DataKeyField="Numero">
				<EditItemStyle Font-Bold="True" Wrap="False"></EditItemStyle>
				<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
				<ItemStyle CssClass="GridElemento"></ItemStyle>
				<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn ItemStyle-Wrap="False">
						<ItemTemplate>
							<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/guardar.gif" CommandName="Guardar" AlternateText="Almacenar la información"
								runat="server" ID="Imagebutton3" />
							<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="Editar" AlternateText="Editar la información"
								runat="server" ID="Imagebutton1" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="Eliminar" AlternateText="Eliminar suministro"
								runat="server" ID="Imagebutton6" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Codigo" HeaderText="Código">
						<ItemStyle Wrap="False" Width="50px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion">
						<ItemStyle Wrap="False" Width="350px"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad">
						<ItemStyle Wrap="False" Width="80px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Precio1" HeaderText="Precio 1">
						<ItemStyle Wrap="False" Width="80px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SubTotal1" ReadOnly="True" HeaderText="SubTotal 1" DataFormatString="{0:c}">
						<ItemStyle Wrap="False" Width="100px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Precio2" HeaderText="Precio 2">
						<ItemStyle Wrap="False" Width="80px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SubTotal2" ReadOnly="True" HeaderText="SubTotal 2" DataFormatString="{0:c}">
						<ItemStyle Wrap="False" Width="100px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Precio3" HeaderText="Precio 3">
						<ItemStyle Wrap="False" Width="80px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SubTotal3" ReadOnly="True" HeaderText="SubTotal 3" DataFormatString="{0:c}">
						<ItemStyle Wrap="False" Width="100px" HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Seleccionado">
						<ItemTemplate>
							<asp:Label runat="server" Width="200px" Font-Bold=True Text='<%# CalcSeleccionado( Convert.ToDouble(DataBinder.Eval(Container.DataItem, "SubTotal1")),Convert.ToDouble(DataBinder.Eval(Container.DataItem, "SubTotal2")),Convert.ToDouble(DataBinder.Eval(Container.DataItem, "SubTotal3")) ) %>' ID="Label6"/>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Observaciones" HeaderText="Observaci&#243;n">
						<ItemStyle Wrap="False"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</asp:datagrid></tr>
	</tbody>
</table>
