<%@ Register TagPrefix="date" Namespace="PeterBlum.DateTextBoxControls" Assembly="DateTextBoxControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RelacionDeDepositos.ascx.cs" Inherits="PortalGobernacion.Modulos.GENE.Apoyo.RelacionDeDepositos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td vAlign="top">Depositos procesados por el Banco
			</td>
			<td vAlign="top">Copia del Deposito recibido por Administraci�n
			</td>
		</tr>
		<TR>
			<td vAlign="top" noWrap><asp:label id="Label1" runat="server">FECHA:</asp:label>&nbsp;&nbsp;&nbsp;
				<date:datetextbox id="fecBanco" runat="server" xPopupURL="popupcalendar.aspx" xImageURL="~/Temas/Defecto/Imagenes/calendar.gif"
					xPopupHeight="160" xPopupWidth="300" xInvalidDateMsg="La fecha es invalida." xTodayKeys="H" Width="112px"></date:datetextbox>&nbsp;&nbsp;&nbsp;
				<asp:label id="Label3" runat="server">CUENTA:</asp:label>&nbsp;&nbsp;&nbsp;
				<asp:dropdownlist id="ddl_CtasDepBancos" runat="server" Width="176px"></asp:dropdownlist><asp:button id="btnActualizar" runat="server" Text="Actualizar"></asp:button>&nbsp;&nbsp;&nbsp;
				<br>
				<br>
				<asp:datagrid id="dgDepBancos" runat="server" Width="100%" OnItemCommand="dgDepBancos_Edit" AutoGenerateColumns="False"
					CssClass="Grid" DataKeyField="NumeroDep">
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
						<asp:TemplateColumn ItemStyle-Wrap="False">
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/guardar.gif" CommandName="Guardar" AlternateText="Almacenar la informaci�n"
									runat="server" ID="Imagebutton3" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn ItemStyle-Wrap="False">
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
						<asp:BoundColumn DataField="NumeroDep" HeaderText="# Dep�sito"></asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}"></asp:BoundColumn>
						<asp:BoundColumn DataField="Monto" HeaderText="Monto" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
					</Columns>
				</asp:datagrid></td>
			<td vAlign="top" noWrap><asp:label id="Label2" runat="server">Fecha:</asp:label>&nbsp;&nbsp;&nbsp;
				<date:datetextbox id="fecFisico" runat="server" xPopupURL="popupcalendar.aspx" xImageURL="~/Temas/Defecto/Imagenes/calendar.gif"
					xPopupHeight="160" xPopupWidth="300" xInvalidDateMsg="La fecha es invalida." xTodayKeys="H" AutoPostBack="True"></date:datetextbox>&nbsp;&nbsp;&nbsp;
				<asp:button id="btnFisico" runat="server" Text="Actualizar"></asp:button><br>
				<br>
				<asp:datagrid id="dgDepFisicos" runat="server" Width="100%" DataKeyField="NumeroDep" CssClass="Grid"
					AutoGenerateColumns="False" OnItemCommand="dgDepFisicos_Edit">
					<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
					<ItemStyle Wrap="False" CssClass="GridElemento"></ItemStyle>
					<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/Crear.gif" CommandName="Crear" AlternateText="Agrega un nuevo Dep�sito"
									runat="server" ID="Imagebutton4" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn ItemStyle-Wrap="False">
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/guardar.gif" CommandName="Guardar" AlternateText="Almacenar la informaci�n"
									runat="server" ID="Imagebutton7" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn ItemStyle-Wrap="False">
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="Editar" AlternateText="Editar la informaci�n"
									runat="server" ID="Imagebutton8" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="Eliminar" AlternateText="Eliminar la informaci�n"
									runat="server" ID="Imagebutton9" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<ItemTemplate>
								<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/deshacer.gif" CommandName="Deshacer" AlternateText="Deshacer los cambios"
									runat="server" ID="Imagebutton10" />
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="NumeroDEP" HeaderText="# Dep�sito" HeaderStyle-Wrap="False"></asp:BoundColumn>
						<asp:BoundColumn DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Forma De Pago" HeaderStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:Label runat="server" Width="70px" Text='<%# CalcFormaDePago( Convert.ToChar( DataBinder.Eval(Container.DataItem, "FormaDePago") ) ) %>' ID="Label6"/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:dropdownlist id="ddl_FormaDePago" runat="server">
									<asp:ListItem Value="E">EFECTIVO</asp:ListItem>
									<asp:ListItem Value="C">CHEQUE</asp:ListItem>
								</asp:dropdownlist>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Presupuesto" HeaderStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:Label runat="server" Width="70px" Text='<%# (DataBinder.Eval(Container.DataItem, "NumeroPar") ) %>' ID="Label4"/>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:dropdownlist id="ddl_Partidas" runat="server" DataSource ='<%# CargarDatos()%>' DataTextField='Descripcion' DataValueField='cod_ing' >
								</asp:dropdownlist>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="NumeroPLA" HeaderText="# Planilla"></asp:BoundColumn>
					</Columns>
				</asp:datagrid></td>
		</TR>
	</tbody>
</table>
</TR></TBODY></TABLE>
