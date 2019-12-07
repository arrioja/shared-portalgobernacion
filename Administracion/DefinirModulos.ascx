<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DefinirModulos.ascx.cs" Inherits="Portal.Administracion.DefinirModulos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width="100%">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td>
				<uc1:Titulo id="Titulo1" runat="server"></uc1:Titulo></td>
		</tr>
		<tr vAlign="top">
			<td><asp:datalist id="listaDefiniciones" runat="server" DataKeyField="ModuloDefID">
					<ItemTemplate>
						<asp:ImageButton ImageUrl="~/Temas/Defecto/Imagenes/editar.gif" AlternateText="Editar definición"
							runat="server" ID="Imagebutton1" NAME="Imagebutton1" />
						&nbsp;&nbsp;
						<asp:Label text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' runat="server" ID="Label1" NAME="Label1"/>
					</ItemTemplate>
				</asp:datalist></td>
		</tr>
		<tr>
			<td><asp:linkbutton id="botonCrear" runat="server" cssclass="BotonComando" Text="Definir un Nuevo Modulo"></asp:linkbutton></td>
		</tr>
	</tbody>
</table>
<br>
