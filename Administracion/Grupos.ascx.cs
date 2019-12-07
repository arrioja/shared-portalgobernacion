namespace Portal.Administracion
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de Grupos.
	/// </summary>
	public class Grupos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DataList listaGrupos;
		protected System.Web.UI.WebControls.LinkButton botonCrear;

		int pagId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			if(Page.IsPostBack == false)
				EnlazarDatos();
		}

		void EnlazarDatos()
		{
			IDataReader dr = GruposBD.Obtener();
			listaGrupos.DataSource = dr;
			listaGrupos.DataBind();
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
			this.listaGrupos.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.listaGrupos_ItemCommand);
			this.botonCrear.Click += new System.EventHandler(this.botonCrear_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonCrear_Click(object sender, System.EventArgs e)
		{
			GruposBD.Crear();

			Response.Redirect(Request.RawUrl, true);
		}

		private void listaGrupos_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			int grupoId = (int) listaGrupos.DataKeys[e.Item.ItemIndex];

			if(e.CommandName == "editar")
			{
				listaGrupos.EditItemIndex = e.Item.ItemIndex;

				EnlazarDatos();
			}
			else if(e.CommandName == "aplicar")
			{
				string nombre = ((TextBox) e.Item.FindControl("nombreGrupo")).Text;

				GruposBD.Actualizar(grupoId, nombre);

				listaGrupos.EditItemIndex = -1;

				EnlazarDatos();
			}
			else if(e.CommandName == "borrar")
			{
				GruposBD.Borrar(grupoId);

				listaGrupos.EditItemIndex = -1;

				EnlazarDatos();
			}
			else if(e.CommandName == "miembros")
			{
				string nombre = ((TextBox) e.Item.FindControl("nombreGrupo")).Text;

				GruposBD.Actualizar(grupoId, nombre);
	
				Response.Redirect("~/Default.aspx?editar=1&pagId=" + pagId +"&grupo=" + grupoId + "&nombregrupo=" + nombre + "&mid=" + ModuloId);				
			}
		}
	}
}
