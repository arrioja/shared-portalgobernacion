<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Paginas.ascx.cs" Inherits="Portal.Administracion.Paginas" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="100%">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colspan="3">
				<uc1:Titulo id="Titulo1" runat="server"></uc1:Titulo></td>
		</tr>
		<tr>
			<td colspan="3">
				<asp:LinkButton id="agregarPagina" runat="server" Text="Add New Tab">Agregar una página</asp:LinkButton>
			</td>
		</tr>
		<tr valign="top">
			<td width="100">
				&nbsp;
			</td>
			<td width="50">
				Páginas:
			</td>
			<td width="*">
				<table cellspacing="0" cellpadding="0" border="0">
					<tbody>
						<tr valign="top">
							<td valign="middle" width="*">
								<iewc:TreeView id="vistaPaginas" runat="server" BorderWidth="1px"></iewc:TreeView>
							</td>
							<td>
								&nbsp;
							</td>
							<td>
								<table>
									<tbody>
										<tr>
											<td>
												<asp:ImageButton id="botonArriba" runat="server" ImageUrl="~/Temas/Defecto/Imagenes/arriba.gif" CommandName="arriba"
													AlternateText="Mover página seleccionada hacia arriba"></asp:ImageButton>
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="botonAbajo" runat="server" ImageUrl="~/Temas/Defecto/Imagenes/abajo.gif" CommandName="abajo"
													AlternateText="Mover página seleccionada hacia abajo"></asp:ImageButton>
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="botonEditar" runat="server" ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" AlternateText="Editar las propiedades de la página seleccionada"></asp:ImageButton>
											</td>
										</tr>
										<tr>
											<td>
												<asp:ImageButton id="botonBorrar" runat="server" ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" AlternateText="Eliminar la página seleccionada"></asp:ImageButton>
											</td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
					</tbody>
				</table>
			</td>
		</tr>
	</tbody>
</table>
<br>
