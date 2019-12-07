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
	///		Descripci�n breve de Documentos.
	/// </summary>
	public class Documentos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DataGrid ListaDocumentos;
		public int pagId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);
				ListaDocumentos.Columns[6].Visible=false;
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			// si el usuario tiene acceso de edici�n, se muestran los links de edicion,
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
