namespace PortalGobernacion.Temas.Pacheco
{
	using System;
	using System.Drawing;
	using System.Web;
	using System.Collections;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using PortalGobernacion.Kernel;

	/// <summary>
	///		Descripci�n breve de Encabezado.
	/// </summary>
	public class Encabezado : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label nombrePortal;
		protected System.Web.UI.WebControls.DataList Paginas;
		public int pagId;
		protected System.Web.UI.WebControls.HyperLink hypLogin;
		protected System.Web.UI.WebControls.HyperLink hypUsuario;
		public bool MostrarPaginas = true;

		int BuscarPadre(int pagId)
		{
			int Resultado = pagId;
    
			PortalConfig configPortal = (PortalConfig) HttpContext.Current.Items["PortalConfig"];
    
			for (int i=0; i < configPortal.Paginas.Count; i++)
			{
				Pagina pag = (Pagina) configPortal.Paginas[i];
    
				if(pag.PagId == pagId)
					Resultado = pag.ObtenerPrimera();
			}
    
			return Resultado;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			PortalConfig configPortal = (PortalConfig) HttpContext.Current.Items["PortalConfig"];
    
			nombrePortal.Text = configPortal.Nombre;

			if (Request.IsAuthenticated == true)
			{
				string Usuario = UsuariosBD.ObtenerNombre(Context.User.Identity.Name);
				hypUsuario.Text = Usuario;
				hypUsuario.NavigateUrl = Global.ObtenerRuta(Request) + "/Administracion/NombreUsuario.aspx?pagid=" + configPortal.PagActiva.PagId.ToString() + "&usuario="+ Context.User.Identity.Name;
    
				hypLogin.Text = "Salir";

				hypLogin.NavigateUrl = Global.ObtenerRuta(Request) + "/Administracion/Salir.aspx";
			}
			else
			{
				hypLogin.Text = "Ingresar";
				hypLogin.NavigateUrl = Global.ObtenerRuta(Request) + "/Default.aspx?pagid=" + configPortal.PagActiva.PagId.ToString() + "&login=1";
				hypUsuario.Text =  hypUsuario.NavigateUrl = "";
			}

			if(MostrarPaginas)
			{
				int pagId;
    
				if(configPortal.PagActiva.PagPadre == -1)
					pagId = configPortal.PagActiva.PagId;
				else
					pagId = BuscarPadre(configPortal.PagActiva.PagId);
    
				// Build list of tabs to be shown to user
				ArrayList PaginasAutorizadas = new ArrayList();
    
				int agregadas = 0;

				for (int i=0; i < configPortal.Paginas.Count; i++)
				{
					Pagina pag = (Pagina) configPortal.Paginas[i];
    
					if (SeguridadPortal.EstaEnGrupos(pag.GruposAutorizados)&&(pag.PagPadre == -1))
					{
						PaginasAutorizadas.Add(pag);
    
						if(pag.PagId == pagId)
							Paginas.SelectedIndex = agregadas;

						agregadas++;
					}
				}
    
				Paginas.DataSource = PaginasAutorizadas;
				Paginas.DataBind();
    
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
