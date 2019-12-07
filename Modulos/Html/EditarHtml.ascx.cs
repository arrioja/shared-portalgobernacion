namespace Portal.Modulos.Html
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de EditarHtml1.
	/// </summary>
	public class EditarHtml : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton botonActualiza;
		protected System.Web.UI.WebControls.LinkButton botonCancelar;
		protected FreeTextBoxControls.FreeTextBox Texto;
		int idModulo = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idModulo = Int32.Parse(Request.Params["mid"]);

			if (Page.IsPostBack == false)
			{

				// Obtain a single row of text information

				IDataReader dr = HtmlBD.Obtener(idModulo);

				string Estilo = "~/Temas/" + Global.ObtenerTemaPortal() + "/Estilo.css";

				Texto.DesignModeCss = Texto.HtmlModeCss = Texto.DropDownListCssClass = Estilo;

				if (dr.Read())
					Texto.Text = Server.HtmlDecode((string) dr["TextoHtml"]);
				else
					Texto.Text = "Agregue aqui el contenido...";
				
				dr.Close();

				// Store URL Referrer to return to portal
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
			}
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
			this.botonActualiza.Click += new System.EventHandler(this.botonActualiza_Click);
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonActualiza_Click(object sender, System.EventArgs e)
		{
			HtmlBD.Actualizar(idModulo, Server.HtmlEncode(Texto.Text));
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}
	}
}
