<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Titulo.ascx.cs" Inherits="Portal.Temas.Defecto.Titulo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" class="TituloModulo">
	<TR>
		<TD style="HEIGHT: 14px" vAlign="middle" noWrap align="left" height="14">&nbsp;
			<asp:Label id="TituloModulo" runat="server" enableviewstate="false"></asp:Label></TD>
		<TD style="HEIGHT: 14px" vAlign="middle" noWrap align="right">
			<asp:HyperLink id="Editar" runat="server" ImageUrl="Temas/Defecto/Imagenes/editarm.gif" Visible="False"></asp:HyperLink>
		</TD>
	</TR>
</TABLE>
