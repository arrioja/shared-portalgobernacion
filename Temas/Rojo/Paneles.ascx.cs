namespace Portal.Temas.Rojo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de Paneles.
	/// </summary>
	public class Paneles : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DropDownList cboModuloDefs;
		protected System.Web.UI.WebControls.LinkButton NuevoModulo;
		protected System.Web.UI.HtmlControls.HtmlTableCell Centro;
		protected System.Web.UI.HtmlControls.HtmlTableCell Izquierda;
		protected System.Web.UI.HtmlControls.HtmlTableCell Derecha;

		private void Page_Load(object sender, System.EventArgs e)
		{
			PortalConfig configPortal = (PortalConfig) HttpContext.Current.Items["PortalConfig"];

			int Login  = 0;
			if(Request.Params["login"] != null)
				Login = Int32.Parse(Request.Params["login"]);

			int Editar = 0;
			if(Request.Params["editar"] != null)
				Editar = Int32.Parse(Request.Params["editar"]);

			if(Editar == 1)
				CargarEdicion();
			else
			{
				if(SeguridadPortal.EstaEnGrupos(configPortal.PagActiva.GruposAutorizados))
				{
					if(Login == 1)
						CargarLogin();

					foreach(Modulo _moduloConfig in configPortal.PagActiva.Modulos)
						CargarModulo(_moduloConfig);
				}
				else
					CargarAccesoDenegado();
			}
		}

		void CargarLogin()
		{
			Control padre = this.FindControl("Izquierda");

			ControlModuloPortal portalModulo = (ControlModuloPortal) Page.LoadControl(Global.ObtenerRuta(Request) + "/Administracion/Ingresar.ascx");

			padre.Controls.Add(portalModulo);

			padre.Controls.Add(new LiteralControl("<br>"));

			padre.Visible = true;
		}

		void CargarEdicion()
		{
			int ModuloId = 0;
			if(Request.Params["mid"] != null)
				ModuloId = Int32.Parse(Request.Params["mid"]);
			if(ModuloId != 0)
			{
				Control padre = this.FindControl("Centro");

				IDataReader dr = ModulosBD.Obtener(ModuloId);

				dr.Read();
				string GruposAutorizadosEdicion = (string) dr["GruposAutorizadosEdicion"];
				int Definicion = (int) dr["ModuloDefId"];
				dr.Close();

				dr = ModulosBD.ObtenerDefiniciones(Definicion);

				if(dr.Read())
				{
					string UbicacionEdicion = (string) dr["UbicacionEdicion"];
							
					if(SeguridadPortal.EstaEnGrupos(GruposAutorizadosEdicion))
					{

						ControlModuloPortal portalModulo = (ControlModuloPortal) Page.LoadControl(Global.ObtenerRuta(Request) + UbicacionEdicion);

						padre.Controls.Add(portalModulo);

						padre.Controls.Add(new LiteralControl("<br>"));

						padre.Visible = true;
					}
					else
						CargarAccesoDenegado();
				}

				dr.Close();
			}
		}

		void CargarModulo(Modulo ModuloCargar)
		{
			if(SeguridadPortal.EstaEnGrupos(ModuloCargar.GruposAutorizados))
			{
				Control padre = this.FindControl(ModuloCargar.NombrePanel);

				if(ModuloCargar.TiempoCache == 0)
				{
					ControlModuloPortal portalModulo = (ControlModuloPortal) this.LoadControl(Global.ObtenerRuta(Request) + ModuloCargar.Ubicacion);

					portalModulo.ConfiguracionModulo = ModuloCargar;

					padre.Controls.Add(portalModulo);
				}
				else
				{
					ControlModuloCachePortal portalModulo = new ControlModuloCachePortal();
                   
					portalModulo.ConfiguracionModulo = ModuloCargar;

					portalModulo.ConfiguracionModulo.Ubicacion = Global.ObtenerRuta(Request) + ModuloCargar.Ubicacion;
					
					padre.Controls.Add(portalModulo);
				}
				padre.Visible = true; 
			}
		}

		void CargarAccesoDenegado()
		{
			Control padre = this.FindControl("Centro");

			ControlModuloPortal portalModulo = (ControlModuloPortal) Page.LoadControl(Global.ObtenerRuta(Request) + "/Administracion/AccesoDenegado.ascx");

			padre.Controls.Add(portalModulo);

			padre.Controls.Add(new LiteralControl("<br>"));

			padre.Visible = true;
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
	}
}
