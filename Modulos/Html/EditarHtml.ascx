<%@ import Namespace="Portal.Kernel" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditarHtml.ascx.cs" Inherits="Portal.Modulos.Html.EditarHtml" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="*" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td colSpan="3">Editar Html
			</td>
		</tr>
		<tr vAlign="top">
			<td>Contenido Html:
			</td>
			<td>&nbsp;&nbsp;
			</td>
			<td><FTB:FREETEXTBOX language=es-ES id=Texto 
       
      
      Width="750px" runat="server" ButtonSet="Office2003" 
      ToolbarStyleConfiguration="Office2003" 
      ImageGalleryPath="~/Datos/Imagenes/" DropDownListCssClass="/Temas/<%= Global.ObtenerTemaPortal() %>/Estilo.css"><toolbars>
				<FTB:Toolbar>
					<FTB:InsertImageFromGallery />
				</FTB:Toolbar>
			</toolbars></FTB:FREETEXTBOX></td>
		</tr>
		<tr>
			<td colSpan="3"><asp:linkbutton id="botonActualiza" runat="server" BorderStyle="none" Text="Update">
										Actualizar</asp:linkbutton>&nbsp;
				<asp:linkbutton id="botonCancelar" runat="server" BorderStyle="none" Text="Cancel" CausesValidation="False">
										Cancelar</asp:linkbutton>&nbsp;
				<P></P>
			</td>
		</tr>
	</tbody>
</table>
