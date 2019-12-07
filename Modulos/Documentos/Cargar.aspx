<%@ Page language="c#" Codebehind="Cargar.aspx.cs" AutoEventWireup="false" Inherits="PortalGobernacion.Modulos.Documentos.WebForm1" %>
    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
    <HTML>

    <HEAD>
        <title>Cargar Archivo</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    </HEAD>

    <body MS_POSITIONING="GridLayout" bgColor="white" topMargin="20">
        <form id="Form1" encType="multipart/form-data" runat="server">
            &nbsp;<span id="Span1" style="FONT: 8pt verdana" runat="server"></span> <input id="File1" type="file" runat="server">
            <asp:label id="Label1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 64px" runat="server" Visible="False">Label</asp:label>
            <asp:button id="Button1" style="Z-INDEX: 102; LEFT: 56px; POSITION: absolute; TOP: 112px" runat="server" Text="Enviar"></asp:button>
            <asp:Button id="btnVolver" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 112px" runat="server" Text="Volver" Visible="False"></asp:Button>
        </form>
    </body>

    </HTML>