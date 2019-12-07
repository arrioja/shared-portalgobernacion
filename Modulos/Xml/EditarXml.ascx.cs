namespace Portal.Modulos.Xml
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Collections;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de EditarXml.
	/// </summary>
	public class EditarXml : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.TextBox XmlData;
		protected System.Web.UI.WebControls.TextBox XslTransform;
		protected System.Web.UI.WebControls.LinkButton botonActualiza;
		protected System.Web.UI.WebControls.LinkButton botonCancelar;

		int idModulo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idModulo = Int32.Parse(Request.Params["mid"]);

			if (Page.IsPostBack == false)
			{
				if(idModulo >0)
				{
					Hashtable configuracion = ModulosBD.ObtenerConfig(idModulo);
					XmlData.Text = (string) configuracion["xmlfue"];
					XslTransform.Text = (string) configuracion["xslfue"];
				}


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
			ModulosBD.ActualizaConfig(idModulo, "xmlfue", XmlData.Text);
			ModulosBD.ActualizaConfig(idModulo, "xslfue", XslTransform.Text);
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}
	}
}
