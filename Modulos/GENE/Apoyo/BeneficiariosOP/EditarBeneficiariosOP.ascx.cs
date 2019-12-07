namespace PortalGobernacion.Modulos.GENE.Apoyo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using Portal.Kernel;

	/// <summary>
	///		Descripci�n breve de EditarBeneficiariosOP.
	/// </summary>
	public class EditarBeneficiariosOP : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton botonActualiza;
		protected System.Web.UI.WebControls.LinkButton botonCancelar;
		protected System.Web.UI.WebControls.DropDownList Nivel;

		int idModulo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idModulo = Int32.Parse(Request.Params["mid"]);

			if (Page.IsPostBack == false)
			{
				if(idModulo >0)
				{
					Hashtable configuracion = ModulosBD.ObtenerConfig(idModulo);
					Nivel.SelectedValue = (string) configuracion["NivelAcceso"];
				}


				// Store URL Referrer to return to portal
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
			}
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
			this.botonActualiza.Click += new System.EventHandler(this.botonActualiza_Click);
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonActualiza_Click(object sender, System.EventArgs e)
		{
			ModulosBD.ActualizaConfig(idModulo, "NivelAcceso", Nivel.SelectedValue);
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}
	}
}
