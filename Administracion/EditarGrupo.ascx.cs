namespace Portal.Administracion
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de EditarGrupo.
	/// </summary>
	public class EditarGrupo : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DropDownList todosUsuarios;
		protected System.Web.UI.WebControls.LinkButton agregarUsuario;
		protected System.Web.UI.WebControls.DataList usuariosGrupo;
		protected System.Web.UI.WebControls.Label nombreGrupo;

		int pagId;
		int grupo;
		protected System.Web.UI.WebControls.LinkButton Regresar;
		string grupoNombre;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			if (Request.Params["grupo"] != null)
				grupo = Int32.Parse(Request.Params["grupo"]);

			if (Request.Params["nombregrupo"] != null)
				grupoNombre = (string)Request.Params["nombregrupo"];

			if(!Page.IsPostBack)
			{
				EnlazarDatos();
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
			}
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
			this.usuariosGrupo.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.usuariosGrupo_ItemCommand);
			this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
			this.agregarUsuario.Click += new System.EventHandler(this.agregarUsuario_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		void EnlazarDatos()
		{
			nombreGrupo.Text = grupoNombre;

			IDataReader drUsuarios = UsuariosBD.Obtener();

			todosUsuarios.DataSource = drUsuarios;

			todosUsuarios.DataBind();

			drUsuarios.Close();

			drUsuarios = GruposBD.ObtenerUsuarios(grupo);

			usuariosGrupo.DataSource = drUsuarios;

			usuariosGrupo.DataBind();

			drUsuarios.Close();
		}

		private void Regresar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void agregarUsuario_Click(object sender, System.EventArgs e)
		{
			int usuarioId = Int32.Parse(todosUsuarios.SelectedItem.Value);

			GruposBD.CrearUsuario(grupo, usuarioId);
			
			EnlazarDatos();
		}

		private void usuariosGrupo_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			int usuarioId = (int) usuariosGrupo.DataKeys[e.Item.ItemIndex];

			GruposBD.BorrarUsuario(grupo, usuarioId);

			EnlazarDatos();
		}

	}
}
