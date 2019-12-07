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
	///		Descripción breve de EditarDefinirModulo.
	/// </summary>
	public class EditarDefinirModulos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton botonActualiza;
		protected System.Web.UI.WebControls.LinkButton botonCancelar;
		protected System.Web.UI.WebControls.LinkButton botonEliminar;
		protected System.Web.UI.WebControls.TextBox textNombre;
		protected System.Web.UI.WebControls.TextBox textUbicacion;
		protected System.Web.UI.WebControls.TextBox textEdicion;

		int definicionId = -1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.Params["defid"] != null)
				definicionId = Int32.Parse(Request.Params["defid"]);

			if (!Page.IsPostBack) 
			{
				if (definicionId == -1) 
				{
					textNombre.Text = "Nueva Definición";
					textUbicacion.Text = "/Modulos/Archivo.ascx";
					textEdicion.Text = "/Modulos/EditarArchivo.ascx";
					botonEliminar.Visible = false;
				}
				else 
				{
					IDataReader dr = ModulosBD.ObtenerDefiniciones(definicionId);

					// Read in first row from database
					dr.Read();

					textNombre.Text = (string) dr["Nombre"];
					textUbicacion.Text = (string) dr["Ubicacion"];
					textEdicion.Text = (string) dr["UbicacionEdicion"];

					// Close datareader
					dr.Close();
				}
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
			this.botonActualiza.Click += new System.EventHandler(this.botonActualiza_Click);
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonEliminar_Click(object sender, System.EventArgs e)
		{
			ModulosBD.BorrarDefinicion(definicionId);
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonActualiza_Click(object sender, System.EventArgs e)
		{
			if (definicionId == -1)
				ModulosBD.CrearDefinicion(textNombre.Text, textUbicacion.Text, textEdicion.Text);
			else
				ModulosBD.ActualizarDefinicion(definicionId, textNombre.Text, textUbicacion.Text, textEdicion.Text);

			Response.Redirect((string) ViewState["UrlAnterior"]);
		}
	}
}
