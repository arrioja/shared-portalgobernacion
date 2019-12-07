<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Ingresar.ascx.cs" Inherits="Portal.Administracion.Ingresar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ import Namespace="Portal.Kernel" %>
<table id="Table1" cellspacing="0" cellpadding="4" class="TablaModulo" border="0" width=100%>
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td>
				Ingresar al Portal</td>
		</tr>
		<tr>
			<td>
				<span class="Normal">Usuario:</span>
				<br>
				<asp:TextBox id="usuario" runat="server" width="130" columns="10"></asp:TextBox>
				<br>
				<span class="Normal">Clave:</span>
				<br>
				<asp:TextBox id="clave" runat="server" width="130" columns="10" textmode="password"></asp:TextBox>
				<br>
			</td>
		</tr>
		<tr>
			<td>
				<p>
					<IMG SRC="Temas/<%=Global.ObtenerTemaPortal()%>/Imagenes/llave.gif">
					<asp:LinkButton id="ingresarPortal" runat="server">Ingresar al Portal</asp:LinkButton>
					<br>
					<br>
					<asp:Panel id="PanelError" runat="server" Visible="False" CssClass="Error"><IMG 
      src="Temas/<%=Global.ObtenerTemaPortal()%>/Imagenes/abortar.gif">&nbsp;Acceso 
      denegado!</asp:Panel>
				</p>
			</td>
		</tr>
	</tbody>
</table>
<br>
