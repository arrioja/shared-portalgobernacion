<%@ Control Language="c#" AutoEventWireup="false" Codebehind="BeneficiariosOP.ascx.cs" Inherits="Portal.Modulos.GENE.Apoyo.BeneficiariosOP" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0"
	DESIGNTIMEDRAGDROP="1">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td><uc1:titulo id="Titulo1" TextoEditar="Nivel Acceso" runat="server"></uc1:titulo></td>
		</tr>
		<tr>
			<td align="center" runat="server" ID="Td1">
				<table cellSpacing="0" cellPadding="0" align="left">
					<tr>
						<td style="HEIGHT: 21px"><asp:label id="Label1" runat="server">Beneficiario:</asp:label>&nbsp;
							<asp:textbox id="Busqueda" runat="server"></asp:textbox>&nbsp;
							<asp:button id="botonBuscar" runat="server" Text="Buscar"></asp:button></td>
					</tr>
					<tr>
						<td><asp:datalist id="Datos" runat="server" CssClass="Grid">
								<SelectedItemStyle CssClass="GridTituloSeleccion"></SelectedItemStyle>
								<HeaderTemplate>
									Beneficiario(s) Encontrado(s)
								</HeaderTemplate>
								<SelectedItemTemplate>
									<table border="0" cellpadding="5" cellspacing="0" width="100%" class="GridTituloSeleccion"
										align="left">
										<tr>
											<td valign="top" width="75" align="left">
												<%# DataBinder.Eval(Container.DataItem, "Rif") %>
											</td>
											<td valign="top" width="*" align="left">
												<%# DataBinder.Eval(Container.DataItem, "Nombre") %>
											</td>
										</tr>
										<tr>
											<td colspan="2">
												<asp:datalist id="Datalist1" runat="server" DataSource='<%# ObtenerOrdenes((string)DataBinder.Eval(Container.DataItem, "Cod_Benef")) %>' CssClass="Grid" OnItemCommand="Ordenes_ItemCommand">
													<SelectedItemStyle CssClass="GridElementoActivo"></SelectedItemStyle>
													<HeaderTemplate>
														Ordenes de Pago
													</HeaderTemplate>
													<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
													<ItemStyle CssClass="GridElemento"></ItemStyle>
													<ItemTemplate>
														<table border="0" cellpadding="5" cellspacing="0" width="100%" align="left">
															<tr>
																<td align="left" width="70">
																	<asp:linkbutton id="Linkbutton1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NRO_ORDEN") %>' CommandName="select" />
																</td>
																<td align="left" width="70">
																	<asp:label id="Label3" runat="server" Text='<%# string.Format("{0:d}", DataBinder.Eval(Container.DataItem, "Fecha_Orden")) %>' />
																</td>
																<td align="left" width="*">
																	<asp:label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Concepto") %>' />
																</td>
																<td align="right" width="100">
																	<asp:label id="Label4" runat="server" Text='<%# string.Format("{0:c}", DataBinder.Eval(Container.DataItem, "Monto")) %>' />
																</td>
															</tr>
														</table>
													</ItemTemplate>
													<SelectedItemTemplate>
														<table border="0" cellpadding="5" cellspacing="0" width="100%" align="left" class="GridElementoActivo">
															<tr>
																<td align="left" width="70">
																	<asp:linkbutton id="Linkbutton2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NRO_ORDEN") %>' CommandName="select" />
																</td>
																<td align="left" width="70">
																	<asp:label id="Label5" runat="server" Text='<%# string.Format("{0:d}", DataBinder.Eval(Container.DataItem, "Fecha_Orden")) %>' />
																</td>
																<td align="left" width="*">
																	<asp:label id="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Concepto") %>' />
																</td>
																<td align="right" width="100">
																	<asp:label id="Label7" runat="server" Text='<%# string.Format("{0:c}", DataBinder.Eval(Container.DataItem, "Monto")) %>' />
																</td>
															</tr>
															<tr>
																<td>
																</td>
																<td colspan="2">
																	<asp:datagrid id=ChequesGrid runat="server" autogeneratecolumns="false" DataSource='<%# ObtenerCheques((string)DataBinder.Eval(Container.DataItem, "NRO_ORDEN")) %>' BorderColor=#a0c6e5 BorderWidth="1" GridLines="Vertical" Width="100%">
																		<columns>
																			<asp:boundcolumn datafield="denom_banc" headertext="Banco" itemstyle-cssclass="GridElemento" headerstyle-cssclass="GridTitulo"
																				itemstyle-width="100" ItemStyle-HorizontalAlign="Left"></asp:boundcolumn>
																			<asp:boundcolumn datafield="che_cta" headertext="Cuenta" itemstyle-cssclass="GridElemento" headerstyle-cssclass="GridTitulo"
																				itemstyle-width="220" ItemStyle-HorizontalAlign="Left"></asp:boundcolumn>
																			<asp:boundcolumn datafield="che_nro" headertext="Cheque" itemstyle-cssclass="GridElemento" headerstyle-cssclass="GridTitulo"
																				itemstyle-width="100" ItemStyle-HorizontalAlign="Left"></asp:boundcolumn>
																			<asp:boundcolumn datafield="monto" headertext="Monto" itemstyle-cssclass="GridElemento" headerstyle-cssclass="GridTitulo"
																				dataformatstring="{0:c}" itemstyle-width="150" ItemStyle-HorizontalAlign="Right"></asp:boundcolumn>
																			<asp:boundcolumn datafield="che_fecha" headertext="Fecha" itemstyle-cssclass="GridElemento" headerstyle-cssclass="GridTitulo"
																				dataformatstring="{0:d}" itemstyle-width="100" ItemStyle-HorizontalAlign="Right"></asp:boundcolumn>
																		</columns>
																	</asp:datagrid>
																</td>
																<td>
																</td>
															</tr>
														</table>
													</SelectedItemTemplate>
													<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
												</asp:datalist>
											</td>
										</tr>
									</table>
								</SelectedItemTemplate>
								<AlternatingItemStyle CssClass="GridAlterno"></AlternatingItemStyle>
								<ItemStyle CssClass="GridElemento"></ItemStyle>
								<ItemTemplate>
									<table border="0" cellpadding="5" cellspacing="0" width="100%" align="left">
										<tr>
											<td align="left" width="75">
												<asp:label id="RIF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RIF") %>' />
												<asp:label id="COD_BENEF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cod_Benef") %>' Visible=False />
											</td>
											<td align="left" width="*">
												<asp:linkbutton id="NOMBRE" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' CommandName="select" />
											</td>
										</tr>
									</table>
								</ItemTemplate>
								<HeaderStyle CssClass="GridTitulo"></HeaderStyle>
							</asp:datalist></td>
					</tr>
				</table>
			</td>
		</tr>
	</tbody>
</table>
