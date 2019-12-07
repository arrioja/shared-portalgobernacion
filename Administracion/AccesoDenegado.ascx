<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AccesoDenegado.ascx.cs" Inherits="Portal.Administracion.AccesoDenegado" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ import Namespace="Portal.Kernel" %>
<table id="Table1" cellspacing="0" cellpadding="4" align="center" class="TablaModulo" border="0">
				<tbody>
					<tr>
						<td class="TituloModulo">
							<img alt="" src="<%= Global.ObtenerRuta(Request) + "/Temas/" + Global.ObtenerTemaPortal() %>/Imagenes/error.gif" align="absMiddle" >&nbsp; 
							Acceso Denegado&nbsp;
						</td>
					</tr>
					<tr>
						<td class="Modulo">
							Usted no ha accesado legalmente, o no tiene autorización para utilizar esta 
							página. Por favor pongase en contacto con el administrador.
						</td>
					</tr>
				</tbody>
			</table>
