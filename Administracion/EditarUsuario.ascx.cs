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
	///		Descripción breve de EditarUsuario.
	/// </summary>
	public class EditarUsuario : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.TextBox Usuario;
		protected System.Web.UI.WebControls.TextBox Clave;
		protected System.Web.UI.WebControls.TextBox Nombre;
		protected System.Web.UI.WebControls.TextBox Apellido;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.LinkButton botonActualizarUsuario;
		protected System.Web.UI.WebControls.DropDownList todosGrupos;
		protected System.Web.UI.WebControls.LinkButton agregarGrupo;
		protected System.Web.UI.WebControls.DataList usuarioGrupos;
		protected System.Web.UI.WebControls.LinkButton Regresar;

		int usuarioId;
		string usuario;
		protected System.Web.UI.HtmlControls.HtmlGenericControl titulo;
		int pagId;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			if (Request.Params["usuarioid"] != null)
				usuarioId = Int32.Parse(Request.Params["usuarioid"]);

			if (Request.Params["nombreusuario"] != null)
				usuario = (string)Request.Params["nombreusuario"];

			if(!Page.IsPostBack)
			{
				if(usuario == "")
				{
					int uid = -1;
					int i = 0;

					while (uid == -1)
					{
						string nombre = "Nuevo usuario creado " + DateTime.Now.ToString();
						usuario = "Nuevo Usuario " + i.ToString();
						uid = UsuariosBD.Crear(usuario, nombre);
						i++;
					}
				}
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
			this.botonActualizarUsuario.Click += new System.EventHandler(this.botonActualizarUsuario_Click);
			this.agregarGrupo.Click += new System.EventHandler(this.agregarGrupo_Click);
			this.usuarioGrupos.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.usuarioGrupos_ItemCommand);
			this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		void EnlazarDatos()
		{
			IDataReader drUsuario = UsuariosBD.Obtener(usuario);

			drUsuario.Read();

			Usuario.Text = drUsuario["Usuario"].ToString();
			Clave.Text = drUsuario["Clave"].ToString();
			Nombre.Text = drUsuario["Nombre"].ToString();
			Apellido.Text = drUsuario["Apellido"].ToString();
			Email.Text = drUsuario["Email"].ToString();

			drUsuario.Close();

			// agregar el nombre del usuario al titulo
			if (usuario != "")
			{
				titulo.InnerText = "Administrar Usuario: " + usuario;
			}

			IDataReader drGrupos = GruposBD.Obtener();

			todosGrupos.DataSource = drGrupos;

			todosGrupos.DataBind();

			drGrupos.Close();

			drGrupos = UsuariosBD.ObtenerGruposReader(usuario);

			usuarioGrupos.DataSource = drGrupos;

			usuarioGrupos.DataBind();

			drGrupos.Close();
		}

		private void Regresar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonActualizarUsuario_Click(object sender, System.EventArgs e)
		{
			UsuariosBD.Actualizar(usuarioId, Usuario.Text, Clave.Text, Email.Text, Nombre.Text, Apellido.Text);
			usuario = Usuario.Text;
			EnlazarDatos();
		}

		private void agregarGrupo_Click(object sender, System.EventArgs e)
		{
			int grupoId = Int32.Parse(todosGrupos.SelectedItem.Value);

			GruposBD.CrearUsuario(grupoId, usuarioId);

			EnlazarDatos();
		}

		private void usuarioGrupos_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			int grupo = (int) usuarioGrupos.DataKeys[e.Item.ItemIndex];

			GruposBD.BorrarUsuario(grupo, usuarioId);

			EnlazarDatos();
		}
	}
}
