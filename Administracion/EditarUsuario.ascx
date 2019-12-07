<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarUsuario.ascx.cs" Inherits="Portal.Administracion.EditarUsuario" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="*" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colSpan="2"><span id="titulo" runat="server">Mantenimiento de Usuario</span></td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				<p>
					Usuario:
				</p>
			</td>
			<td>
				<asp:textbox id="Usuario" runat="server" width="358px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Clave:
			</td>
			<td>
				<asp:textbox id="Clave" runat="server" width="358px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Nombre:
			</td>
			<td>
				<asp:textbox id="Nombre" runat="server" width="359px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				Apellido:
			</td>
			<td>
				<asp:textbox id="Apellido" runat="server" width="359px"></asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="Normal" width="124">
				E-mail:
			</td>
			<td>
				<asp:textbox id="Email" runat="server" width="357px"></asp:textbox>
			</td>
		</tr>
		<TR>
			<td colSpan="3">
				<asp:linkbutton id="botonActualizarUsuario" runat="server" Text="Guardar cambios de Clave y Usuario"></asp:linkbutton>
				<br>
				<br>
			</td>
		</TR>
		<tr>
			<td colspan="2">
				<hr noshade size="1">
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:dropdownlist id="todosGrupos" runat="server" Width="131px" DataTextField="Nombre" DataValueField="GrupoID"></asp:dropdownlist>
				&nbsp;<asp:linkbutton id="agregarGrupo" runat="server" Text="Agregar usuario a este Grupo"></asp:linkbutton>
			</td>
		</tr>
		<tr valign="top">
			<td width="124">
				&nbsp;
			</td>
			<td>
				<asp:datalist id="usuarioGrupos" runat="server" Width="450px" RepeatColumns="3" DataKeyField="GrupoId">
					<ItemStyle width="225px"></ItemStyle>
					<ItemTemplate>
						&nbsp;&nbsp;
						<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="delete" AlternateText="Eliminar este usuario del Grupo"
							runat="server" ID="Imagebutton1" />
						<asp:Label text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' cssclass="Normal" runat="server" id="Label1" />
					</ItemTemplate>
				</asp:datalist>
			</td>
		</tr>
		<tr>
			<td colSpan="2"><asp:linkbutton id="Regresar" runat="server" Text="Guardar Cambios del Usuario"> Regresar</asp:linkbutton></td>
		</tr>
	</tbody>
</table>
