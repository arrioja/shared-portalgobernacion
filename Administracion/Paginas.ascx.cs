namespace Portal.Administracion
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Microsoft.Web.UI.WebControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de Paginas.
	/// </summary>
	public class Paginas : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton agregarPagina;
		protected System.Web.UI.WebControls.ImageButton botonArriba;
		protected System.Web.UI.WebControls.ImageButton botonAbajo;
		protected System.Web.UI.WebControls.ImageButton botonEditar;
		protected System.Web.UI.WebControls.ImageButton botonBorrar;
		protected Microsoft.Web.UI.WebControls.TreeView vistaPaginas;

		int pagId = -1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);


			if(!Page.IsPostBack)
				EnlazarDatos();
		}

		void EnlazarDatos()
		{
			PortalConfig configPortal = (PortalConfig) HttpContext.Current.Items["PortalConfig"];
			
			vistaPaginas.Nodes.Clear();

			for (int i=0; i < configPortal.Paginas.Count; i++)
			{
				Pagina pag = (Pagina) configPortal.Paginas[i];

				if((pag.PagPadre == -1)&&(!pag.Sistema))
				{
					TreeNode tn = new TreeNode();

					tn.Text = pag.PagNombre;
					tn.NodeData = pag.PagId.ToString();
					tn.Expanded = true;
					tn.ImageUrl = "Temas/Defecto/Imagenes/pagina.gif";
					CargarHijas(pag.PagId, tn);
					vistaPaginas.Nodes.Add(tn);
				}
			}
		}

		void CargarHijas(int pagina, TreeNode nodo)
		{
			IDataReader Hijas = PaginasBD.ObtenerHijas(pagina);

			while(Hijas.Read())
			{
				nodo.ImageUrl = "Temas/Defecto/Imagenes/pagina.gif";

				TreeNode tn = new TreeNode();

				tn.Text = Hijas["PagNombre"].ToString();
				tn.NodeData = Hijas["PagId"].ToString();
				tn.Expanded = true;
				tn.ImageUrl = "Temas/Defecto/Imagenes/paginahija.gif";

				CargarHijas((int) Hijas["PagId"], tn);

				nodo.Nodes.Add(tn);
			}

			Hijas.Close();
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
			this.agregarPagina.Click += new System.EventHandler(this.agregarPagina_Click);
			this.botonArriba.Command += new System.Web.UI.WebControls.CommandEventHandler(this.botonArribaAbajo_Command);
			this.botonAbajo.Command += new System.Web.UI.WebControls.CommandEventHandler(this.botonArribaAbajo_Command);
			this.botonEditar.Click += new System.Web.UI.ImageClickEventHandler(this.botonEditar_Click);
			this.botonBorrar.Click += new System.Web.UI.ImageClickEventHandler(this.botonBorrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void agregarPagina_Click(object sender, System.EventArgs e)
		{
			PaginasBD.Crear();
			PaginasBD.ActualizaOrden();
			Response.Redirect(Request.RawUrl, true);
		}

		private void botonBorrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			TreeNode Nodo = vistaPaginas.GetNodeFromIndex(vistaPaginas.SelectedNodeIndex);
			PaginasBD.Borrar(Int32.Parse(Nodo.NodeData));
			Response.Redirect(Request.RawUrl, true);
		}

		private void botonArribaAbajo_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			TreeNode Nodo = vistaPaginas.GetNodeFromIndex(vistaPaginas.SelectedNodeIndex);
			int PagId = Int32.Parse(Nodo.NodeData);
			IDataReader Pagina = PaginasBD.Obtener(PagId);
			Pagina.Read();
			int PagOrden = (int) Pagina["PagOrden"];
			if(e.CommandName == "arriba")
				PaginasBD.ActualizaOrden(PagId, PagOrden - 3);
			else
				PaginasBD.ActualizaOrden(PagId, PagOrden + 3);

			PaginasBD.ActualizaOrden();
			Pagina.Close();
			Response.Redirect(Request.RawUrl, true);
		}

		private void botonEditar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			TreeNode Nodo = vistaPaginas.GetNodeFromIndex(vistaPaginas.SelectedNodeIndex);
			int PagId = Int32.Parse(Nodo.NodeData);
			Response.Redirect("~/Default.aspx?editar=1&pagId=" + pagId +"&pagina=" + PagId + "&mid=" + ModuloId);
		}
	}
}
