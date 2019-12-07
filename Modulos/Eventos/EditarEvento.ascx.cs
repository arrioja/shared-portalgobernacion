namespace PortalGobernacion.Modulos.Eventos
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descripci�n breve de EditarEvento.
	/// </summary>
	public class EditarEvento : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton botonActualiza;
		protected System.Web.UI.WebControls.LinkButton botonCancelar;
		protected System.Web.UI.WebControls.TextBox textTitulo;
		protected FreeTextBoxControls.FreeTextBox textDescripcion;
		protected PeterBlum.DateTextBoxControls.DateTextBox textFecha;
		protected PeterBlum.DateTextBoxControls.DateTextBox textVencimiento;

		int eventoId = -1;
		protected System.Web.UI.WebControls.TextBox textLugar;
		protected System.Web.UI.WebControls.LinkButton botonBorrar;
		int moduloId = -1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["eventoId"] != null)
				eventoId = Int32.Parse(Request.Params["eventoId"]);

			if (Request.Params["mid"] != null)
				moduloId = Int32.Parse(Request.Params["mid"]);

			botonBorrar.Visible = (eventoId != -1);

			if(!Page.IsPostBack)
			{
				if(eventoId != -1)
					EnlazarDatos();
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
			}

			
		}

		void EnlazarDatos()
		{
			IDataReader dr = EventosBD.ObtenerUnEvento(eventoId);

			dr.Read();

			textTitulo.Text = dr["Titulo"].ToString();
			textDescripcion.Text = dr["Descripcion"].ToString();
			textFecha.Text = dr["Fecha"].ToString();
			textLugar.Text = dr["Lugar"].ToString();
			textVencimiento.Text = dr["Fecha_Vencimiento"].ToString();

			dr.Close();
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
			this.botonActualiza.Click += new System.EventHandler(this.botonActualiza_Click);
			this.botonBorrar.Click += new System.EventHandler(this.botonBorrar_Click);
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonActualiza_Click(object sender, System.EventArgs e)
		{
			string Fecha = textFecha.xDate.Year.ToString() + "-";
			Fecha += textFecha.xDate.Month.ToString() + "-";
			Fecha += textFecha.xDate.Day.ToString();

			string Vencimiento = textVencimiento.xDate.Year.ToString() + "-";
			Vencimiento += textVencimiento.xDate.Month.ToString() + "-";
			Vencimiento += textVencimiento.xDate.Day.ToString();

			if (eventoId == -1)
				EventosBD.CrearEvento(moduloId, textTitulo.Text, textDescripcion.Text, Fecha, textLugar.Text, Vencimiento);
			else
				EventosBD.ActualizarEvento(eventoId, textTitulo.Text, textDescripcion.Text, Fecha, textLugar.Text, Vencimiento);

			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void botonBorrar_Click(object sender, System.EventArgs e)
		{
			EventosBD.BorrarEvento(eventoId);
			Response.Redirect((string) ViewState["UrlAnterior"]);	
		}
	}
}
