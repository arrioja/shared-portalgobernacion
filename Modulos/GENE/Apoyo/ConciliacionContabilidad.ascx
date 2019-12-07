<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ConciliacionContabilidad.ascx.cs" Inherits="PortalGobernacion.Modulos.GENE.Apoyo.ConciliacionContabilidad" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td vAlign="top">Estado de Cuenta del BANCO
			</td>
		</tr>
		<TR>
			<td vAlign="top" noWrap><asp:label id="Label1" runat="server">MES:</asp:label>&nbsp;&nbsp;&nbsp;
				<asp:dropdownlist id="ddl_MesDepBancos" runat="server" Width="136px" AutoPostBack="True">
					<asp:ListItem Value="1">Enero</asp:ListItem>
					<asp:ListItem Value="2">Febrero</asp:ListItem>
					<asp:ListItem Value="3">Marzo</asp:ListItem>
					<asp:ListItem Value="4">Abril</asp:ListItem>
					<asp:ListItem Value="5">Mayo</asp:ListItem>
					<asp:ListItem Value="6">Junio</asp:ListItem>
					<asp:ListItem Value="7">Julio</asp:ListItem>
					<asp:ListItem Value="8">Agosto</asp:ListItem>
					<asp:ListItem Value="9">Septiembre</asp:ListItem>
					<asp:ListItem Value="10">Octubre</asp:ListItem>
					<asp:ListItem Value="11">Noviembre</asp:ListItem>
					<asp:ListItem Value="12">Diciembre</asp:ListItem>
				</asp:dropdownlist>&nbsp;&nbsp;&nbsp;
				<asp:label id="Label3" runat="server">CUENTA:</asp:label>&nbsp;&nbsp;&nbsp;
				<asp:dropdownlist id="ddl_CtasDepBancos" runat="server" Width="184px" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
				<asp:button id="btnConciliar" runat="server" Text="Conciliar"></asp:button><br>
				<br>
				<asp:datagrid id="dgDepBancos" runat="server" Width="100%" OnItemDataBound="Item_DataBound_B"
					DataKeyField="NumeroDep" CssClass="Grid" AutoGenerateColumns="False" AllowPaging="True" PageSize="15">
					<EditItemStyle Font-Bold="True" Wrap="False"></EditItemStyle>
					<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
					<ItemStyle Wrap="False" CssClass="GridElemento"></ItemStyle>
					<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/Crear.gif" CommandName="Crear" AlternateText="Agrega un nuevo Dep�sito"
									runat="server" ID="Imagebutton6" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemStyle Wrap="False"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/guardar.gif" CommandName="Guardar" AlternateText="Almacenar la informaci�n"
									runat="server" ID="Imagebutton3" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemStyle Wrap="False"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="Editar" AlternateText="Editar la informaci�n"
									runat="server" ID="Imagebutton5" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="Eliminar" AlternateText="Eliminar la informaci�n"
									runat="server" ID="Imagebutton2" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/deshacer.gif" CommandName="Deshacer" AlternateText="Deshacer los cambios"
									runat="server" ID="Imagebutton1" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="NumeroDep" HeaderText="# Dep&#243;sito"></asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}"></asp:BoundColumn>
						<asp:BoundColumn DataField="MontoL" HeaderText="Monto Libro" DataFormatString="{0:C}">
							<ItemStyle HorizontalAlign="Right" Width="680"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="MontoB" HeaderText="Monto Banco" DataFormatString="{0:C}">
							<ItemStyle HorizontalAlign="Right" Width="680"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" PageButtonCount="20" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</TR>
		<tr class="TituloModulo">
			<td vAlign="top">Libro de BANCO
			</td>
		</tr>
		<tr>
			<td vAlign="top" noWrap><asp:label id="Label2" runat="server">MES:</asp:label>&nbsp;&nbsp;&nbsp;
				<asp:dropdownlist id="ddl_MesDepFisicos" runat="server" Width="176px" AutoPostBack="True">
					<asp:ListItem Value="01">Enero</asp:ListItem>
					<asp:ListItem Value="02">Febrero</asp:ListItem>
					<asp:ListItem Value="03">Marzo</asp:ListItem>
					<asp:ListItem Value="04">Abril</asp:ListItem>
					<asp:ListItem Value="05">Mayo</asp:ListItem>
					<asp:ListItem Value="06">Junio</asp:ListItem>
					<asp:ListItem Value="07">Julio</asp:ListItem>
					<asp:ListItem Value="08">Agosto</asp:ListItem>
					<asp:ListItem Value="09">Septiembre</asp:ListItem>
					<asp:ListItem Value="10">Octubre</asp:ListItem>
					<asp:ListItem Value="11">Noviembre</asp:ListItem>
					<asp:ListItem Value="12">Diciembre</asp:ListItem>
				</asp:dropdownlist>&nbsp;&nbsp;&nbsp;
				<asp:radiobuttonlist id="rbl_Seleccionar" runat="server" Width="180px" AutoPostBack="True" RepeatLayout="Flow"
					RepeatDirection="Horizontal" Height="24px">
					<asp:ListItem Value="T">Tr&#225;nsito</asp:ListItem>
					<asp:ListItem Value="C">Conciliado</asp:ListItem>
					<asp:ListItem Value="A">Ambos</asp:ListItem>
				</asp:radiobuttonlist><br>
				<br>
				<asp:datagrid id="dgDepFisicos" runat="server" Width="100%" OnItemDataBound="Item_DataBound_L"
					DataKeyField="NumeroDep" CssClass="Grid" AutoGenerateColumns="False" AllowPaging="True" PageSize="15">
					<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
					<ItemStyle Wrap="False" CssClass="GridElemento"></ItemStyle>
					<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/Crear.gif" CommandName="Crear" AlternateText="Agrega un nuevo Dep�sito"
									runat="server" ID="Imagebutton4" Enabled=False />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemStyle Wrap="False"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/guardar.gif" CommandName="Guardar" AlternateText="Almacenar la informaci�n"
									runat="server" ID="Imagebutton7" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemStyle Wrap="False"></ItemStyle>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="Editar" AlternateText="Editar la informaci�n"
									runat="server" ID="Imagebutton8" Enabled=False />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="Eliminar" AlternateText="Eliminar la informaci�n"
									runat="server" ID="Imagebutton9"  Enabled=False/>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/deshacer.gif" CommandName="Deshacer" AlternateText="Deshacer los cambios"
									runat="server" ID="Imagebutton10" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="NumeroDEP" HeaderText="# Dep&#243;sito">
							<HeaderStyle Wrap="False"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}"></asp:BoundColumn>
						<asp:BoundColumn DataField="MontoL" HeaderText="Monto Libro" DataFormatString="{0:C}">
							<ItemStyle HorizontalAlign="Right" Width="680"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="MontoB" HeaderText="Monto Banco" DataFormatString="{0:C}">
							<ItemStyle HorizontalAlign="Right" Width="680"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" PageButtonCount="20" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</tr>
	</tbody>
</table>
</TR></TBODY></TABLE>
