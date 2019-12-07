<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../Titulo.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarContactos.ascx.cs" Inherits="Portal.Modulos.EditarContactos.EditarContactos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table class="TablaModulo" id="Table1" style="LEFT: 10px; WIDTH: 781px; TOP: 15px; HEIGHT: 269px"
	height="269" cellSpacing="0" cellPadding="4" width="781" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td style="HEIGHT: 28px"></td>
		</tr>
		<tr vAlign="top">
			<td height="144">
				<table style="WIDTH: 772px; HEIGHT: 219px" cellSpacing="0" cellPadding="4" width="772"
					border="0">
					<TR vAlign="top">
						<TD width="150">&nbsp;
						</TD>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="Head" align="left"><asp:literal id="Literal1" Text="Detalle del contacto" runat="server"></asp:literal></TD>
								</TR>
								<TR>
									<TD colSpan="2"></TD>
								</TR>
							</TABLE>
							<TABLE style="WIDTH: 750px; HEIGHT: 120px" cellSpacing="0" cellPadding="0" width="750"
								border="0">
								<TR vAlign="top">
									<TD class="SubHead"><asp:literal id="Literal2" Text="Nombre" runat="server"></asp:literal>:
									</TD>
									<TD rowSpan="5">&nbsp;
									</TD>
									<TD align="left" width="347"><asp:textbox id="TextoNombre" runat="server" Width="391px"></asp:textbox></TD>
									<TD width="25" rowSpan="5">&nbsp;
									</TD>
									<TD class="Normal" width="250"><asp:requiredfieldvalidator id="RequiredName" runat="server" Width="226px" Visible="False" ControlToValidate="NameField"
											Display="Dynamic" ErrorMessage="Por Favor, ingrese un nombre valido"></asp:requiredfieldvalidator></TD>
								</TR>
								<TR vAlign="top">
									<TD class="SubHead"><asp:literal id="Literal3" Text="Cargo" runat="server"></asp:literal>:
									</TD>
									<TD width="347"><asp:textbox id="TextoCargo" runat="server" maxlength="100" Columns="30" width="390"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD class="SubHead"><asp:literal id="Literal4" Text="Email" runat="server"></asp:literal>:
									</TD>
									<TD width="347"><asp:textbox id="TextoEmail" runat="server" maxlength="100" Columns="30" width="390"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD class="SubHead" style="HEIGHT: 21px"><asp:literal id="Literal5" Text="Contacto 1" runat="server"></asp:literal>:
									</TD>
									<TD style="HEIGHT: 21px" width="347"><asp:textbox id="TextoContacto1" runat="server" maxlength="250" Columns="30" width="390"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">
									<TD class="SubHead"><asp:literal id="Literal6" Text="Contacto 2" runat="server"></asp:literal>:
									</TD>
									<TD width="347"><asp:textbox id="TextoContacto2" runat="server" maxlength="250" Columns="30" width="390"></asp:textbox></TD>
								</TR>
							</TABLE>
							<SPAN class="Normal">
								<HR noShade SIZE="1">
								<P>
								&nbsp;</SPAN><SPAN class="Normal">&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:linkbutton id="updateButton" Text="Actualizar" runat="server">
										Actualizar</asp:linkbutton>&nbsp;
								<asp:linkbutton id="deleteButton" Text="Borrar Contacto" runat="server" CausesValidation="False">
										Borrar este contacto</asp:linkbutton>&nbsp;
								<asp:linkbutton id="cancelButton" Text="Cancelar" runat="server" CausesValidation="False">
										Cancelar</asp:linkbutton></SPAN></P></TD>
					</TR>
				</table>
			</td>
		</tr>
		<tr>
			<td style="HEIGHT: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
		</tr>
	</tbody>
</table>
