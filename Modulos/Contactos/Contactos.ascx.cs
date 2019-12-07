namespace Portal.Modulos.Contactos
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;


	/// <summary>
	///		Descripción breve de Contactos.
	/// </summary>
	public class Contactos : Portal.Kernel.ControlModuloPortal//System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton botonCrear;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid ListaContactos;
	    public int pagId = 0;
		
//		int idModulo = 0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);
			// Introducir aquí el código de usuario para inicializar la página
			// si el usuario tiene acceso de edición, se muestran los links de edicion,
			if (Portal.Kernel.SeguridadPortal.TienePermisosEdicion(ModuloId) == true)
			{ListaContactos.Columns[0].Visible=true;
//			 
			}
			else // se ocultan los links de edicion para el usuario sin acceso
			{
				ListaContactos.Columns[0].Visible=false;
				ListaContactos.Columns[1].Visible=false;
			}
			IDataReader Contac = ContactosBD.ObtenerContactos(ModuloId);
			ListaContactos.DataSource = Contac;
			ListaContactos.DataBind();
			string bbb=ListaContactos.Columns[0].HeaderImageUrl.ToString();
			Contac.Close();
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

		private void ListaContactos_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{   	
		
			int moduloDefId = (int) ListaContactos.DataKeys[e.Item.ItemIndex];
//			Response.Redirect("~/Default.aspx?editar=1&defId=" + moduloDefId + "&mid=" + ModuloId);
			Response.Redirect("~/Default.aspx?editar=1&pagId=" + pagId + "&defId=" + moduloDefId + "&mid=" + ModuloId);
		}

		private void ListaContactos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			int moduloDefId = (int) ListaContactos.DataKeys[e.Item.ItemIndex];
//		    Response.Redirect("~/Default.aspx?editar=1&pagId=" + pagId + "&defId=" + moduloDefId + "&mid=" + ModuloId);
		}

	}
}
