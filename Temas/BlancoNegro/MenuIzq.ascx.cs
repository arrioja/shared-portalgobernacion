namespace Portal.Temas.BlancoNegro
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using DUEMETRI.UI.WebControls.HWMenu;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de MenuIzq.
	/// </summary>
	public class MenuIzq : System.Web.UI.UserControl
	{
		protected DUEMETRI.UI.WebControls.HWMenu.Menu Menu;

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
			
			int pagId;
			
			int paginaActual = configPortal.PagActiva.PagId;;
    
			if(configPortal.PagActiva.PagPadre == -1)
				pagId = configPortal.PagActiva.PagId;
			else
				pagId = BuscarPadre(configPortal.PagActiva.PagId);
                			
			ArrayList PaginasAutorizadas = new ArrayList();

			Menu.ClientScriptPath = Global.ObtenerRuta(Request) + "/Controles/DUEMETRI_UI_WebControls_HWMenu/1_0_0_0";
			Menu.ImagesPath = Global.ObtenerRuta(Request) + "/Controles/DUEMETRI_UI_WebControls_HWMenu/1_0_0_0";

			IDataReader Hijas = PaginasBD.ObtenerHijas(pagId);
    
			//int agregadas = 0;

			while(Hijas.Read())
			{
				string GruposAutorizados = Hijas["GruposAutorizados"].ToString();
				if (SeguridadPortal.EstaEnGrupos(GruposAutorizados))
				{
					string Nombre = Hijas["PagNombre"].ToString();
					MenuTreeNode elementoMenu = new MenuTreeNode(Nombre);
					elementoMenu.Link = Global.ObtenerRuta(Request) + "/Default.aspx?pagid=" + Hijas["PagId"].ToString();
					elementoMenu.Width = Menu.Width;
					elementoMenu.Font.Name = "Tahoma";
					elementoMenu.Font.Bold = false;
					elementoMenu.Font.Size = 11;
					elementoMenu = CreaSubMenu(elementoMenu, (int)Hijas["PagId"]);
					Menu.Childs.Add(elementoMenu);
				}
			}

			Hijas.Close();
		}

		MenuTreeNode CreaSubMenu(MenuTreeNode elementoMenu, int pagId)
		{
			IDataReader Hijas = PaginasBD.ObtenerHijas(pagId);

			while(Hijas.Read())
			{
				string GruposAutorizados = Hijas["GruposAutorizados"].ToString();
				if (SeguridadPortal.EstaEnGrupos(GruposAutorizados))
				{
					string Nombre = Hijas["PagNombre"].ToString();
					MenuTreeNode subMenu = new MenuTreeNode(Nombre);
					subMenu.Link = Global.ObtenerRuta(Request) + "/Default.aspx?pagid=" + Hijas["PagId"].ToString();
					subMenu.Width = elementoMenu.Width;
					subMenu = CreaSubMenu(subMenu, (int) Hijas["PagId"]);
					elementoMenu.Childs.Add(subMenu);
				}
			}

			Hijas.Close();

			return elementoMenu;
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
