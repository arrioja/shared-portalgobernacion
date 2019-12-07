namespace Portal.Modulos.Documentos
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de Documentos.
	/// </summary>
	public class Documentos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DataGrid ListaDocumentos;
		public int pagId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);
				ListaDocumentos.Columns[6].Visible=false;
			// Introducir aquí el código de usuario para inicializar la página
			// si el usuario tiene acceso de edición, se muestran los links de edicion,
			if (Portal.Kernel.SeguridadPortal.TienePermisosEdicion(ModuloId) == true)
			{
					ListaDocumentos.Columns[0].Visible=true;
			}
			else // se ocultan los links de edicion para el usuario sin acceso
			{
				ListaDocumentos.Columns[0].Visible=false;
				ListaDocumentos.Columns[1].Visible=false;
			}
			IDataReader Docs = DocumentosBD.ObtenerDocumentos(ModuloId);
			ListaDocumentos.DataSource = Docs;
			ListaDocumentos.DataBind();
			string bbb=ListaDocumentos.Columns[0].HeaderImageUrl.ToString();
			Docs.Close();
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
			this.ListaDocumentos.SelectedIndexChanged += new System.EventHandler(this.ListaContactos_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ListaContactos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void LinkNuevo_Click(object sender, System.EventArgs e)
		{

		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("~/Default.aspx?editar=1&pagId=" + pagId +  "&mid=" + ModuloId);
		}
	}
}
