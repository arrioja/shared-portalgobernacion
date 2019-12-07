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
	///		Descripción breve de Usuarios.
	/// </summary>
	public class Usuarios : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Literal Mensaje;
		protected System.Web.UI.WebControls.DropDownList todosUsuarios;
		protected System.Web.UI.WebControls.ImageButton botonCrear;
		protected System.Web.UI.WebControls.ImageButton botonEditar;
		protected System.Web.UI.WebControls.ImageButton botonBorrar;
		protected System.Web.UI.WebControls.Panel pnlContenidoModulo;

		int pagId=-1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			if(!Page.IsPostBack)
				EnlazarDatos();
		}

		void EnlazarDatos()
		{
			IDataReader dr = UsuariosBD.Obtener();
			todosUsuarios.DataSource = dr;
			todosUsuarios.DataBind();
			dr.Close();
		}

		void botonEditar_Command(object sender, CommandEventArgs e)
		{
			int usuarioId = -1;
			string nombreUsuario = "";

			if(e.CommandName == "Editar")
			{
				usuarioId = Int32.Parse(todosUsuarios.SelectedItem.Value);
				nombreUsuario = todosUsuarios.SelectedItem.Text;
			}
	
			Response.Redirect("~/Default.aspx?editar=1&pagid=" + pagId +"&usuarioid=" + usuarioId + "&nombreusuario=" + nombreUsuario + "&mid=" + ModuloId);	
		}

		void botonBorrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			UsuariosBD.Borrar(Int32.Parse(todosUsuarios.SelectedItem.Value));

			EnlazarDatos();
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
			this.botonCrear.Command += new System.Web.UI.WebControls.CommandEventHandler(this.botonEditar_Command);
			this.botonEditar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.botonEditar_Command);
			this.botonBorrar.Click += new System.Web.UI.ImageClickEventHandler(this.botonBorrar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
