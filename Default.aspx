<%@ import Namespace="Portal.Kernel" %>
<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Portal._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%= Global.ObtenerNombrePortal() %>
		</title>
		<LINK href="Temas/<%= Global.ObtenerTemaPortal() %>/Estilo.css" type="text/css" rel="stylesheet">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="FormDefault" method="post" runat="server">
			<asp:PlaceHolder id="TemaHolder" runat="server"></asp:PlaceHolder>
		</form>
	</body>
</HTML>
