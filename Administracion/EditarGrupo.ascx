<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarGrupo.ascx.cs" Inherits="Portal.Administracion.EditarGrupo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="*" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colSpan="2">Miembros del grupo:
				<asp:label id="nombreGrupo" runat="server">Grupo</asp:label></td>
		</tr>
		<tr>
			<td>&nbsp;
			</td>
			<td>
				<table cellSpacing="0" cellPadding="0" width="100%">
					<tbody>
						<tr>
							<td><asp:dropdownlist id="todosUsuarios" runat="server" DataValueField="UsuarioID" DataTextField="Usuario"></asp:dropdownlist></td>
							<td>&nbsp;
								<asp:linkbutton id="agregarUsuario" runat="server" Text="Agregar un usuario existente al grupo">Agregar un usuario existente al grupo</asp:linkbutton></td>
						</tr>
					</tbody>
				</table>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<hr noshade size="1">
			</td>
		</tr>
		<tr vAlign="top">
			<td>&nbsp;
			</td>
			<td><asp:datalist id="usuariosGrupo" runat="server" DataKeyField="UsuarioId" RepeatColumns="2">
					<ItemStyle width="225px"></ItemStyle>
					<ItemTemplate>
						&nbsp;&nbsp;
						<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="borrar" AlternateText="Borrar este usuario del grupo"
							runat="server" ID="Imagebutton1" NAME="Imagebutton1" />
						<asp:Label text='<%# DataBinder.Eval(Container.DataItem, "Usuario") %>' runat="server" ID="Label2" NAME="Label2"/>
					</ItemTemplate>
				</asp:datalist></td>
		</tr>
		<tr>
			<td colSpan="2"><asp:linkbutton id="Regresar" runat="server" Text="Guardar Cambios del Grupo"> Regresar</asp:linkbutton></td>
		</tr>
	</tbody>
</table>
