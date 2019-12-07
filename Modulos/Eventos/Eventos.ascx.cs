namespace PortalGobernacion.Modulos.Eventos
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;

	/// <summary>
	///		Descripci�n breve de Eventos.
	/// </summary>
	public class Eventos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DataList dataListEventos;
		protected System.Web.UI.WebControls.DataList myDataList;

		private void Page_Load(object sender, System.EventArgs e)
		{
			/* 	*/
			IDataReader	dr = EventosBD.ObtenerEventos(ModuloId);
			dataListEventos.DataSource = dr;
			dataListEventos.DataBind();
			dr.Close();

			
	
		}

		#region C�digo generado por el Dise�ador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		M�todo necesario para admitir el Dise�ador. No se puede modificar
		///		el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataListEventos.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.dataListEventos_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dataListEventos_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			int eventoId = (int) dataListEventos.DataKeys[e.Item.ItemIndex];

			Response.Redirect("~/Default.aspx?editar=1&eventoId=" + eventoId + "&mid=" + ModuloId);
		}
	}
}
