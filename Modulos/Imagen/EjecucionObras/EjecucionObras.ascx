<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EjecucionObras.ascx.cs" Inherits="PortalGobernacion.Modulos.GENE.Apoyo.EjecucionObras" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Titulo" Src="../../../../Titulo.ascx" %>
<table class="TablaModulo" id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
	<tbody class="Modulo">
		<tr class="TituloModulo">
			<td><uc1:titulo id="Titulo1" runat="server"></uc1:titulo></td>
		</tr>
		<tr>
			<td align="center" runat="server" ID="Td1">
				<table cellSpacing="0" cellPadding="0" align="left">
					<tr>
						<td style="HEIGHT: 25px"><asp:label id="Label1" runat="server">Fecha:</asp:label>&nbsp;
							<asp:textbox id="Fecha" runat="server"></asp:textbox>&nbsp;
							<asp:button id="botonActualizar" runat="server" Text="Actualizar"></asp:button></td>
					</tr>
					<tr>
						<td>
							<asp:DataGrid id="Datos" runat="server" AutoGenerateColumns="False" CssClass="Grid" GridLines="Vertical"
								Width="1500px">
								<AlternatingItemStyle CssClass="GirdAlterno"></AlternatingItemStyle>
								<ItemStyle CssClass="GridElemento"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" CssClass="GridTitulo"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="NRO_DET" HeaderText="Estructura Prog.">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COD_OBRA" HeaderText="Obra">
										<HeaderStyle Width="50px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DENOM" HeaderText="Denominaci&#243;n">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Asignado" HeaderText="Asignado" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Modificado" HeaderText="Modificado" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Reintegro" HeaderText="Reintegro" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Comprometido" HeaderText="Comprometido" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Causado" HeaderText="Causado" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Pagado" HeaderText="Pagado" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Acordado" HeaderText="Acordado" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Disponible" HeaderText="Disponible" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Deuda" HeaderText="Deuda" DataFormatString="{0:N2}">
										<HeaderStyle Width="100px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></td>
					</tr>
				</table>
			</td>
		</tr>
	</tbody>
</table>
