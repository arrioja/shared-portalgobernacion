<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Usuarios.ascx.cs" Inherits="Portal.Administracion.Usuarios" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="100%">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td>
				<uc1:Titulo id="Titulo1" runat="server"></uc1:Titulo></td>
		</tr>
		<tr valign="top">
			<td class="Normal">
				Usuarios Registrados:&nbsp;
				<asp:DropDownList id="todosUsuarios" runat="server" DataValueField="UsuarioID" DataTextField="Usuario"></asp:DropDownList>
				&nbsp;
				<asp:ImageButton id="botonCrear" runat="server" CommandName="Crear" AlternateText="Crear usuario"
					ImageUrl="~/Temas/Defecto/Imagenes/crear.gif"></asp:ImageButton>
				<asp:ImageButton id="botonEditar" runat="server" CommandName="Editar" AlternateText="Editar usuario"
					ImageUrl="~/Temas/Defecto/Imagenes/editar.gif"></asp:ImageButton>
				<asp:ImageButton id="botonBorrar" runat="server" CommandName="Borrar" AlternateText="Eliminar usuario"
					ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif"></asp:ImageButton>
				&nbsp;
			</td>
		</tr>
	</tbody>
</table>
<br>
