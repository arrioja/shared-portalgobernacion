<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarPaginas.ascx.cs" Inherits="Portal.Administracion.EditarPaginas" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="*">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="2">
				Mantenimiento de Página
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Nombre:
				</p>
			</td>
			<td>
				<asp:textbox id="Nombre" runat="server" width="410px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Página Superior:
			</td>
			<td>
				<asp:DropDownList id="cboPaginas" width="409px" Runat="server"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<hr noshade size="1">
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Grupos Autorizados:
			</td>
			<td>
				<asp:checkboxlist id="gruposAutorizados" runat="server" width="450px" RepeatColumns="3" Font-Names="Verdana,Arial"
					Font-Size="8pt"></asp:checkboxlist>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<hr noshade size="1">
			</td>
		</tr>
		<tr>
			<td valign="top">
				Crear Módulo:
			</td>
			<td>
				<table cellspacing="0" cellpadding="0">
					<tr>
						<td class="Normal">
							Tipo de Módulo
						</td>
						<td>
							<asp:DropDownList id="moduloTipo" DataValueField="ModuloDefID" DataTextField="Nombre" runat="server" />
						</td>
					</tr>
					<tr>
						<td class="Normal">
							Nombre del Módulo:
						</td>
						<td>
							<asp:Textbox id="moduloTitulo" EnableViewState="false" Text="New Module Name" width="250" runat="server">Nuevo Modulo</asp:Textbox>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td colspan="3">
				<asp:LinkButton class="CommandButton" Text='<img src="Temas/Defecto/Imagenes/crear.gif" border=0> Agregar a "Organizar Módulos" '
					runat="server" id="agregarModulo"><img src="Temas/Defecto/Imagenes/crear.gif" border="0"> Agregar a "Organizar Módulos"</asp:LinkButton>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td colspan="3">
				<hr noshade size="1">
			</td>
		</tr>
		<tr>
			<td valign="top">
				Organizar Módulos:
			</td>
			<td>
				<table cellpadding="2" cellspacing="0" width="100%">
					<tr class="SubTitulo">
						<td>Panel Izquierdo</td>
						<td>Panel Central</td>
						<td>Panel Derecho</td>
					</tr>
					<tr>
						<td width="120" vAlign="top" align="center">
							<table border="0" cellspacing="0" cellpadding="2" width="100%">
								<tr valign="top">
									<td align="center">
										<table border="0" cellspacing="2" cellpadding="0">
											<tr valign="top">
												<td rowspan="2">
													<asp:ListBox id="panelIzquierdo" DataTextField="ModuloTitulo" DataValueField="ModuloId" width="110"
														rows="7" runat="server" />
												</td>
												<td valign="top" nowrap>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/arriba.gif" CommandName="arriba" CommandArgument="panelIzquierdo"
														AlternateText="Mover el módulo seleccionado hacia arriba" runat="server" id="izquierdoArriba" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/derecha.gif" CommandName="derecha" sourcepane="leftPane"
														targetpane="contentPane" AlternateText="Mover el módulo seleccionado al panel central" runat="server"
														id="izquierdoDerecha" CommandArgument="panelIzquierdo" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/abajo.gif" CommandName="abajo" CommandArgument="panelIzquierda"
														AlternateText="Mover el módulo seleccionado hacia abajo" runat="server" id="izquierdoAbajo" />
													&nbsp;&nbsp;
												</td>
											</tr>
											<tr>
												<td valign="bottom" nowrap>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="editar" CommandArgument="panelIzquierdo"
														AlternateText="Editar el módulo seleccionado" runat="server" id="izquierdoEditar" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="borrar" CommandArgument="panelIzquierdo"
														AlternateText="Borrar el módulo seleccionado" runat="server" id="izquierdoBorrar" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
						<td width="*" vAlign="top">
							<table border="0" cellspacing="0" cellpadding="2" width="100%">
								<tr>
									<td align="center">
										<table border="0" cellspacing="2" cellpadding="0">
											<tr valign="top">
												<td rowspan="2">
													<asp:ListBox id="panelCentral" DataTextField="ModuloTitulo" DataValueField="ModuloId" width="170"
														rows="7" runat="server" />
												</td>
												<td valign="top" nowrap>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/arriba.gif" CommandName="arriba" CommandArgument="panelCentral"
														AlternateText="Mover el módulo seleccionado hacia arriba" runat="server" id="centroArriba" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/izquierda.gif" sourcepane="contentPane" targetpane="leftPane"
														AlternateText="Mover el módulo seleccionado al panel izquierdo" runat="server" id="centroIzquierda"
														CommandArgument="panelCentral" CommandName="izquierda" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/derecha.gif" sourcepane="contentPane" targetpane="rightPane"
														AlternateText="Mover el módulo seleccionado al panel derecho" runat="server" id="centroDerecha"
														CommandArgument="panelCentral" CommandName="derecha" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/abajo.gif" CommandName="abajo" CommandArgument="panelCentral"
														AlternateText="Mover el módulo seleccionado hacia abajo" runat="server" id="centroAbajo" />
													&nbsp;&nbsp;
												</td>
											</tr>
											<tr>
												<td valign="bottom" nowrap>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="editar" CommandArgument="panelCentral"
														AlternateText="Editar el módulo seleccionado" runat="server" id="centroEditar" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="borrar" CommandArgument="panelCentral"
														AlternateText="Borrar el módulo seleccionado" runat="server" id="centroBorrar" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
						<td width="120" align="center" vAlign="top">
							<table border="0" cellspacing="0" cellpadding="2" width="100%">
								<tr>
									<td align="center">
										<table border="0" cellspacing="2" cellpadding="0">
											<tr valign="top">
												<td rowspan="2">
													<asp:ListBox id="panelDerecho" DataTextField="ModuloTitulo" DataValueField="ModuloId" width="110"
														rows="7" runat="server" />
												</td>
												<td valign="top" nowrap>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/arriba.gif" CommandName="arriba" CommandArgument="panelDerecho"
														AlternateText="Mover el módulo seleccionado hacia arriba" runat="server" id="derechoArriba" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/izquierda.gif" sourcepane="rightPane" targetpane="contentPane"
														AlternateText="Mover el módulo seleccionado al panel central" runat="server" id="derechoIzquierda"
														CommandArgument="panelDerecho" CommandName="izquierda" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/abajo.gif" CommandName="abajo" CommandArgument="panelDerecho"
														AlternateText="Mover el módulo seleccionado hacia abajo" runat="server" id="derechoAbajo" />
												</td>
											</tr>
											<tr>
												<td valign="bottom" nowrap>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="editar" CommandArgument="panelDerecho"
														AlternateText="Editar el módulo seleccionado" runat="server" id="derechoEditar" />
													<br>
													<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="borrar" CommandArgument="panelDerecho"
														AlternateText="Borrar el módulo seleccionado" runat="server" id="derechoBorrar" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td colspan="2" style="HEIGHT: 81px">
				<asp:LinkButton id="botonActualiza" Text="Update" runat="server" BorderStyle="none">
										Actualizar</asp:LinkButton>
				&nbsp;
				<asp:LinkButton id="botonCancelar" Text="Cancel" CausesValidation="False" runat="server" BorderStyle="none">
										Cancelar</asp:LinkButton><p></p>
			</td>
		</tr>
		<tr class="TituloModulo">
			<td colspan="2">
				Mantenimiento del Módulo
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Nombre:
				</p>
			</td>
			<td>
				<asp:textbox id="NombreModulo" runat="server" width="410px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					TiempoCache:
				</p>
			</td>
			<td>
				<asp:textbox id="TiempoCache" runat="server" width="410px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Grupos Autorizados:
			</td>
			<td>
				<asp:checkboxlist id="autorizadosModulo" runat="server" width="450px" RepeatColumns="3" Font-Names="Verdana,Arial"
					Font-Size="8pt"></asp:checkboxlist>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td colspan="3">
				<hr noshade size="1">
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Grupos Autorizados Edición:
			</td>
			<td>
				<asp:checkboxlist id="edicionModulo" runat="server" width="450px" RepeatColumns="3" Font-Names="Verdana,Arial"
					Font-Size="8pt"></asp:checkboxlist>
			</td>
		</tr>
		<tr>
			<td colspan="2" style="HEIGHT: 81px">
				<asp:LinkButton id="guardarModulo" Text="Update" runat="server" BorderStyle="none">
										Guardar</asp:LinkButton>&nbsp;<p></p>
			</td>
		</tr>
	</tbody>
</table>
