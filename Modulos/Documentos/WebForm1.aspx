<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="PortalGobernacion.Modulos.Documentos.WebForm1" %>
    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
    <HTML>

    <HEAD>
        <title>WebForm1</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    </HEAD>

    <body MS_POSITIONING="GridLayout">
        <form id="Form1" encType="multipart/form-data" runat="server">
            <input id="Text1" type="text" runat="server">&nbsp;<span id="Span1" style="FONT: 8pt verdana" runat="server"></span>
            <input id="File1" type="file" runat="server">
            <asp:label id="Label1" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 120px" runat="server">Label</asp:label>
            <asp:button id="Button1" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 120px" runat="server" Text="Enviar"></asp:button>
        </form>
    </body>

    </HTML>