namespace Portal.Modulos.Html
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripci�n breve de Html.
	/// </summary>
	public class Html : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell MuestraHtml;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			IDataReader dr = HtmlBD.Obtener(ModuloId);

			if(dr.Read())
			{
				string contenido = Server.HtmlDecode((string) dr["TextoHtml"]);
				MuestraHtml.Controls.Add(new LiteralControl(contenido));
			}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
