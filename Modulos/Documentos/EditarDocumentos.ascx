<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarDocumentos.ascx.cs" Inherits="PortalGobernacion.Modulos.Documentos.EditarDocumentos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" enableViewState="True" %>
<TABLE class="TablaModulo" id="Table1" style="WIDTH: 692px; HEIGHT: 387px" height="387"
	cellSpacing="0" cellPadding="4" width="692" border="0">
	<TBODY class="Modulo">
		<TR class="TituloModulo">
			<TD style="WIDTH: 706px; HEIGHT: 28px"></TD>
		</TR>
		<TR vAlign="top">
			<TD style="WIDTH: 706px" height="144">
				<TABLE id="Table2" style="WIDTH: 652px; HEIGHT: 219px" cellSpacing="0" cellPadding="4"
					width="652" border="0">
					<TR vAlign="top">
						<TD width="150" style="HEIGHT: 214px">&nbsp;
						</TD>
						<TD style="WIDTH: 728px; HEIGHT: 214px">
							<TABLE id="Table3" style="WIDTH: 622px; HEIGHT: 38px" cellSpacing="0" cellPadding="0" width="622"
								border="0">
								<TR>
									<TD class="Head" style="WIDTH: 713px" align="left"><asp:literal id="Literal1" runat="server" Text="Detalles del Documento"></asp:literal></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 713px" colSpan="2"></TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" style="WIDTH: 621px; HEIGHT: 120px" cellSpacing="0" cellPadding="0"
								width="621" border="0">
								<TR vAlign="top">
									<TD class="SubHead" style="WIDTH: 119px; HEIGHT: 16px"><asp:literal id="Literal3" runat="server" Text="Descripci�n"></asp:literal>:
									</TD>
									<TD style="WIDTH: 416px; HEIGHT: 16px" width="416"><asp:textbox id="txtDescripcion" runat="server" width="487px" Columns="30" maxlength="100"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD class="SubHead" style="WIDTH: 119px; HEIGHT: 21px"><asp:literal id="Literal4" runat="server" Text="Formato"></asp:literal>:
									</TD>
									<TD style="WIDTH: 416px; HEIGHT: 21px" width="416"><asp:textbox id="txtFormato" runat="server" Enabled="False" width="487px" Columns="30" maxlength="100"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD class="SubHead" style="WIDTH: 119px; HEIGHT: 1px"><asp:literal id="Literal5" runat="server" Text="Link"></asp:literal>:
									</TD>
									<TD style="WIDTH: 416px; HEIGHT: 1px" width="416"><asp:textbox id="txtLink" runat="server" Enabled="False" width="487px" Columns="30" maxlength="250"></asp:textbox></TD>
								</TR>
							</TABLE>
							<SPAN class="Normal">
								<HR noShade SIZE="1">
								<P>
								&nbsp;</SPAN><SPAN class="Normal">&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:linkbutton id="updateButton" runat="server" Text="Actualizar">
										Actualizar</asp:linkbutton>&nbsp;
								<asp:linkbutton id="deleteButton" runat="server" Text="Borrar Contacto" CausesValidation="False">
										Borrar este Documento</asp:linkbutton>&nbsp;&nbsp;&nbsp;
								<asp:linkbutton id="Linkbutton1" runat="server" Text="Actualizar" Width="120px">
										Adjuntar 
										Archivo</asp:linkbutton><asp:linkbutton id="cancelButton" runat="server" Text="Cancelar" CausesValidation="False">
										Cancelar</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:textbox id="txtTitulo" runat="server" maxlength="100" Columns="30" width="72px" Visible="False"></asp:textbox></SPAN></P></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD style="WIDTH: 706px; HEIGHT: 40px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;&nbsp;&nbsp;&nbsp; <INPUT id="File1" type="file" name="File1" runat="server"></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 706px; HEIGHT: 21px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:label id="Label1" runat="server" Visible="False">Label</asp:label></TD>
		</TR>
		<TR>
			<TD style="WIDTH: 706px; HEIGHT: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;&nbsp;
				<asp:button id="Button1" runat="server" Text="Adjuntar" Visible="False"></asp:button></TD>
		</TR>
	</TBODY>
</TABLE>
<P>&nbsp;</P>
<P>&nbsp;</P>
