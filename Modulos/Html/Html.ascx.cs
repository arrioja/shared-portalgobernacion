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
	///		Descripción breve de Html.
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

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Método necesario para admitir el Diseñador. No se puede modificar
		///		el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
