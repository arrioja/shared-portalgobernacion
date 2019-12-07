namespace Portal.Temas.Defecto
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripci�n breve de Titulo.
	/// </summary>
	public class Titulo : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label TituloModulo;
		protected System.Web.UI.WebControls.HyperLink Editar;

		public string TextoEditar = null;
		public int pagId = -1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			PortalConfig configPortal = (PortalConfig) HttpContext.Current.Items["PortalConfig"];

			ControlModuloPortal moduloPortal = (ControlModuloPortal) this.Parent;

			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			TituloModulo.Text = moduloPortal.ConfiguracionModulo.ModuloTitulo;

			if (SeguridadPortal.EstaEnGrupos(moduloPortal.ConfiguracionModulo.GruposAutorizadosEdicion) && (TextoEditar != null))
			{
				Editar.Text = TextoEditar;
				Editar.ToolTip = TextoEditar;
				Editar.NavigateUrl = "~/Default.aspx?editar=1&mid=" + moduloPortal.ModuloId.ToString();
				Editar.Visible = true;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
