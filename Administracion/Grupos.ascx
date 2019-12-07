<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Grupos.ascx.cs" Inherits="Portal.Administracion.Grupos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="100%">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td>
				<uc1:Titulo id="Titulo1" runat="server"></uc1:Titulo></td>
		</tr>
		<tr valign="top">
			<td>
				<asp:DataList id="listaGrupos" runat="server" DataKeyField="GrupoID">
					<ItemTemplate>
						<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" CommandName="editar" AlternateText="Editar grupo"
							runat="server" ID="Imagebutton1" NAME="Imagebutton1" />
						<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/borrar.gif" CommandName="borrar" AlternateText="Eliminar grupo"
							runat="server" ID="Imagebutton2" NAME="Imagebutton2" />
						&nbsp;&nbsp;
						<asp:Label text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' runat="server" ID="Label1" NAME="Label1"/>
					</ItemTemplate>
					<EditItemTemplate>
						<asp:Textbox id="nombreGrupo" width="200" cssclass="NormalTextBox" Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' runat="server" />
						<asp:LinkButton Text="Aplicar" CommandName="aplicar" runat="server" ID="Linkbutton1" NAME="Linkbutton1" />
						<asp:LinkButton Text="Cambiar miembros del grupo" CommandName="miembros" runat="server" ID="Linkbutton2"
							NAME="Linkbutton2" />
					</EditItemTemplate>
				</asp:DataList>
			</td>
		</tr>
		<tr>
			<td>
				<asp:LinkButton id="botonCrear" runat="server" Text="Agregar Nuevo Grupo"></asp:LinkButton>
			</td>
		</tr>
	</tbody>
</table>
<br>
