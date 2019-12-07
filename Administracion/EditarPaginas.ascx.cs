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
	///		Descripción breve de EditarPaginas.
	/// </summary>
	public class EditarPaginas : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton botonActualiza;
		protected System.Web.UI.WebControls.LinkButton botonCancelar;
		protected System.Web.UI.WebControls.DropDownList cboPaginas;
		protected System.Web.UI.WebControls.TextBox Nombre;
		protected System.Web.UI.WebControls.DropDownList moduleType;
		protected System.Web.UI.WebControls.TextBox moduleTitle;
		protected System.Web.UI.WebControls.ListBox panelIzquierdo;
		protected System.Web.UI.WebControls.ImageButton izquierdoArriba;
		protected System.Web.UI.WebControls.ImageButton izquierdoDerecha;
		protected System.Web.UI.WebControls.ImageButton izquierdoAbajo;
		protected System.Web.UI.WebControls.ImageButton izquierdoEditar;
		protected System.Web.UI.WebControls.ImageButton izquierdoBorrar;
		protected System.Web.UI.WebControls.ListBox panelCentral;
		protected System.Web.UI.WebControls.ListBox panelDerecho;
		protected System.Web.UI.WebControls.ImageButton centroArriba;
		protected System.Web.UI.WebControls.ImageButton centroIzquierda;
		protected System.Web.UI.WebControls.ImageButton centroDerecha;
		protected System.Web.UI.WebControls.ImageButton centroAbajo;
		protected System.Web.UI.WebControls.ImageButton centroEditar;
		protected System.Web.UI.WebControls.ImageButton centroBorrar;
		protected System.Web.UI.WebControls.ImageButton derechoArriba;
		protected System.Web.UI.WebControls.ImageButton derechoIzquierda;
		protected System.Web.UI.WebControls.ImageButton derechoAbajo;
		protected System.Web.UI.WebControls.ImageButton derechoEditar;
		protected System.Web.UI.WebControls.ImageButton derechoBorrar;
		protected System.Web.UI.WebControls.LinkButton agregarModulo;
		protected System.Web.UI.WebControls.DropDownList moduloTipo;
		protected System.Web.UI.WebControls.TextBox moduloTitulo;
		protected System.Web.UI.WebControls.CheckBoxList gruposAutorizados;

		int pagId;
		protected System.Web.UI.WebControls.TextBox NombreModulo;
		protected System.Web.UI.WebControls.CheckBoxList autorizadosModulo;
		protected System.Web.UI.WebControls.CheckBoxList edicionModulo;
		protected System.Web.UI.WebControls.LinkButton guardarModulo;
		protected System.Web.UI.WebControls.TextBox TiempoCache;
		int pagina;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			if (Request.Params["pagina"] != null)
				pagina = Int32.Parse(Request.Params["pagina"]);

			if(!Page.IsPostBack)
			{
				EnlazarDatos();
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
			}
		}

		void EnlazarDatos()
		{
			IDataReader Pagina = PaginasBD.Obtener(pagina);

			Pagina.Read();

			Nombre.Text = Pagina["PagNombre"].ToString();
			int PagPadre = (int) Pagina["PagPadre"];
			string GruposAutorizados = Pagina["GruposAutorizados"].ToString();

			Pagina.Close();
			
			cboPaginas.Items.Clear();

			ListItem Ninguna = new ListItem();

			Ninguna.Text = "Ninguna";
			Ninguna.Value = "-1";

			cboPaginas.Items.Add(Ninguna);

			IDataReader Paginas = PaginasBD.Obtener();
			
			while(Paginas.Read())
			{
				ListItem Elemento = new ListItem();

				Elemento.Text = Paginas["PagNombre"].ToString();
				Elemento.Value = Paginas["PagId"].ToString();

				if(Int32.Parse(Elemento.Value) != pagina)
					cboPaginas.Items.Add(Elemento);
			}

			Paginas.Close();

			cboPaginas.Items.FindByValue(PagPadre.ToString()).Selected = true;

			gruposAutorizados.Items.Clear();


			ListItem Todos = new ListItem();

			Todos.Text = "Todos";
			Todos.Value = "-1";

			Todos.Selected = (GruposAutorizados.LastIndexOf("Todos") > -1);

			gruposAutorizados.Items.Add(Todos);

			IDataReader Grupos = GruposBD.Obtener();

			while(Grupos.Read())
			{
				ListItem Autorizado = new ListItem();

				Autorizado.Text = Grupos["Nombre"].ToString();
				Autorizado.Value = Grupos["GrupoId"].ToString();

				Autorizado.Selected = (GruposAutorizados.LastIndexOf(Grupos["Nombre"].ToString()) > -1);

				gruposAutorizados.Items.Add(Autorizado);
			}

			Grupos.Close();

			IDataReader tiposModulo = ModulosBD.ObtenerDefiniciones();

			moduloTipo.DataSource = tiposModulo;
			moduloTipo.DataBind();

			tiposModulo.Close();

			panelIzquierdo.DataSource = ObtenerModulos("izquierda");
			panelIzquierdo.DataBind();

			panelCentral.DataSource = ObtenerModulos("centro");
			panelCentral.DataBind();

			panelDerecho.DataSource = ObtenerModulos("derecha");
			panelDerecho.DataBind();
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
			this.agregarModulo.Click += new System.EventHandler(this.agregarModulo_Click);
			this.izquierdoArriba.Command += new System.Web.UI.WebControls.CommandEventHandler(this.SubirBajar_Command);
			this.izquierdoDerecha.Command += new System.Web.UI.WebControls.CommandEventHandler(this.MoverModulo_Command);
			this.izquierdoAbajo.Command += new System.Web.UI.WebControls.CommandEventHandler(this.SubirBajar_Command);
			this.izquierdoEditar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Editar_Command);
			this.izquierdoBorrar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.BorrarModulo_Command);
			this.centroArriba.Command += new System.Web.UI.WebControls.CommandEventHandler(this.SubirBajar_Command);
			this.centroIzquierda.Command += new System.Web.UI.WebControls.CommandEventHandler(this.MoverModulo_Command);
			this.centroDerecha.Command += new System.Web.UI.WebControls.CommandEventHandler(this.MoverModulo_Command);
			this.centroAbajo.Command += new System.Web.UI.WebControls.CommandEventHandler(this.SubirBajar_Command);
			this.centroEditar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Editar_Command);
			this.centroBorrar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.BorrarModulo_Command);
			this.derechoArriba.Command += new System.Web.UI.WebControls.CommandEventHandler(this.SubirBajar_Command);
			this.derechoIzquierda.Command += new System.Web.UI.WebControls.CommandEventHandler(this.MoverModulo_Command);
			this.derechoAbajo.Command += new System.Web.UI.WebControls.CommandEventHandler(this.SubirBajar_Command);
			this.derechoEditar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Editar_Command);
			this.derechoBorrar.Command += new System.Web.UI.WebControls.CommandEventHandler(this.BorrarModulo_Command);
			this.botonActualiza.Click += new System.EventHandler(this.botonActualiza_Click);
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			this.guardarModulo.Click += new System.EventHandler(this.guardarModulo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private ArrayList ObtenerModulos(string panel) 
		{
			IDataReader modulos = ModulosBD.ObtenerPagina(pagina);
			ArrayList Modulos = new ArrayList();
        
			while(modulos.Read())
			{            
				if (modulos["NombrePanel"].ToString().ToLower() == panel.ToLower()) 
				{
            		ModuloItem m = new ModuloItem();
					m.ModuloTitulo = (string) modulos["ModuloTitulo"];
					m.ModuloId = (int) modulos["ModuloId"];
					m.ModuloDefId = (int) modulos["ModuloDefId"];
					m.ModuloOrden = (int) modulos["ModuloOrden"]; 
					Modulos.Add(m);
				}
			}
        
			modulos.Close();

			return Modulos;
		}

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonActualiza_Click(object sender, System.EventArgs e)
		{			
			string Autorizados = "";
			foreach(ListItem elemento in gruposAutorizados.Items)
				if(elemento.Selected)
					Autorizados += elemento.Text + ";";

			PaginasBD.Actualizar(pagina, Int32.Parse(cboPaginas.SelectedItem.Value), Nombre.Text, Autorizados);
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void agregarModulo_Click(object sender, System.EventArgs e)
		{
			ModulosBD.Crear(pagina, Int32.Parse(moduloTipo.SelectedItem.Value), moduloTitulo.Text, 0);
			EnlazarDatos();
		}

		private void MoverModulo_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			string Panel;
			int moduloId;
			
			if(((ImageButton) sender).CommandName == "izquierda")
			{
				if(((ImageButton) sender).CommandArgument == "panelCentral")
				{
					Panel = "Izquierda";
					moduloId = Int32.Parse(panelCentral.SelectedItem.Value);
				}
				else
				{
					Panel = "Centro";
					moduloId = Int32.Parse(panelDerecho.SelectedItem.Value);
				}
			}
			else
			{
				if(((ImageButton) sender).CommandArgument == "panelCentral")
				{
					Panel = "Derecha";
					moduloId = Int32.Parse(panelCentral.SelectedItem.Value);
				}
				else
				{
					Panel = "Centro";
					moduloId = Int32.Parse(panelIzquierdo.SelectedItem.Value);
				}
			}

			ModulosBD.ActualizaOrden(moduloId, -1, Panel);
			PaginasBD.ActualizaOrdenModulos(pagId);

			EnlazarDatos();
		}

		private void BorrarModulo_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			int moduloId = -1;

			if(((ImageButton) sender).CommandArgument == "panelIzquierdo")
				moduloId = Int32.Parse(panelIzquierdo.SelectedItem.Value);
			else if(((ImageButton) sender).CommandArgument == "panelCentral")
				moduloId = Int32.Parse(panelCentral.SelectedItem.Value);
			else
				moduloId = Int32.Parse(panelDerecho.SelectedItem.Value);

			ModulosBD.Borrar(moduloId);
			EnlazarDatos();
		}

		private void SubirBajar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			string Panel;
			int moduloId;
			int Pasos;
			
			if(((ImageButton) sender).CommandName == "arriba")
			{
				Pasos = -3;
				if(((ImageButton) sender).CommandArgument == "panelIzquierdo")
				{
					moduloId = Int32.Parse(panelIzquierdo.SelectedItem.Value);
					Panel = "Izquierda";
				} 
				else if(((ImageButton) sender).CommandArgument == "panelCentral")
				{
					moduloId = Int32.Parse(panelCentral.SelectedItem.Value);
					Panel = "Centro";
				}
				else
				{
					moduloId = Int32.Parse(panelDerecho.SelectedItem.Value);
					Panel = "Derecha";
				}
			}
			else
			{
				Pasos = 3;
				if(((ImageButton) sender).CommandArgument == "panelIzquierdo")
				{
					moduloId = Int32.Parse(panelIzquierdo.SelectedItem.Value);
					Panel = "Izquierda";
				}
				else if(((ImageButton) sender).CommandArgument == "panelCentral")
				{
					moduloId = Int32.Parse(panelCentral.SelectedItem.Value);
					Panel = "Centro";
				}
				else
				{
					moduloId = Int32.Parse(panelDerecho.SelectedItem.Value);
					Panel = "Derecha";
				}
			}

			IDataReader dr = ModulosBD.Obtener(moduloId);
			dr.Read();
			Pasos += (int) dr["ModuloOrden"];
			dr.Close();

			ModulosBD.ActualizaOrden(moduloId, Pasos, Panel);
			PaginasBD.ActualizaOrdenModulos(pagId);

			EnlazarDatos();		
		}

		private void Editar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			int moduloId = -1;

			if(((ImageButton) sender).CommandArgument == "panelIzquierdo")
				moduloId = Int32.Parse(panelIzquierdo.SelectedItem.Value);
			else if(((ImageButton) sender).CommandArgument == "panelCentral")
				moduloId = Int32.Parse(panelCentral.SelectedItem.Value);
			else
				moduloId = Int32.Parse(panelDerecho.SelectedItem.Value);

			ViewState["ModuloEdicion"] = moduloId.ToString();
			IDataReader dr = ModulosBD.Obtener(moduloId);
			dr.Read();

			NombreModulo.Text = (string) dr["ModuloTitulo"];
			TiempoCache.Text = dr["TiempoCache"].ToString();
			string GruposAutorizados = (string) dr["GruposAutorizados"];
			string GruposEdicion = (string) dr["GruposAutorizadosEdicion"];

			autorizadosModulo.Items.Clear();
			edicionModulo.Items.Clear();

			ListItem Todos = new ListItem();
			ListItem TodosEdicion = new ListItem();

			Todos.Text = TodosEdicion.Text = "Todos";
			Todos.Value = TodosEdicion.Value = "-1";

			Todos.Selected = (GruposAutorizados.LastIndexOf("Todos") > -1);
			TodosEdicion.Selected = (GruposEdicion.LastIndexOf("Todos") > -1);

			autorizadosModulo.Items.Add(Todos);
			edicionModulo.Items.Add(TodosEdicion);

			IDataReader Grupos = GruposBD.Obtener();

			while(Grupos.Read())
			{
				ListItem Autorizado = new ListItem();
				ListItem Edicion = new ListItem();

				Autorizado.Text = Edicion.Text = Grupos["Nombre"].ToString();
				Autorizado.Value = Edicion.Value = Grupos["GrupoId"].ToString();

				Autorizado.Selected = (GruposAutorizados.LastIndexOf(Grupos["Nombre"].ToString()) > -1);
				Edicion.Selected = (GruposEdicion.LastIndexOf(Grupos["Nombre"].ToString()) > -1);

				autorizadosModulo.Items.Add(Autorizado);
				edicionModulo.Items.Add(Edicion);
			}

			Grupos.Close();

			dr.Close();
		}

		private void guardarModulo_Click(object sender, System.EventArgs e)
		{
			int modulo = Int32.Parse(ViewState["ModuloEdicion"].ToString());

			string Autorizados = "";
			foreach(ListItem elemento in autorizadosModulo.Items)
				if(elemento.Selected)
					Autorizados += elemento.Text + ";";

			string Edicion = "";
			foreach(ListItem elemento in edicionModulo.Items)
				if(elemento.Selected)
					Edicion += elemento.Text + ";";

			ModulosBD.Actualizar(modulo, NombreModulo.Text, Autorizados, Edicion,Int32.Parse(TiempoCache.Text) );
		}
	}
}
