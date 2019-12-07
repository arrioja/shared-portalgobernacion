using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;
using System.Data;
using Portal.Kernel;

namespace Portal.Kernel 
{
	/// <summary>
	/// Descripción breve de Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			string CadenaConexion;

			CadenaConexion = ConfigurationSettings.AppSettings["CadenaConexion"];

			Context.Items.Add("CadenaConexion", CadenaConexion);

			int pagId = 0;

			// Obtener el PagID del querystring
			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			Context.Items.Add("PortalConfig", new PortalConfig(pagId));
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			if (Request.IsAuthenticated == true)
			{
				string[] grupos;
				// Create the roles cookie if it doesn't exist yet for this session.
				if ((Request.Cookies["Portalgrupos"] == null) || (Request.Cookies["Portalgrupos"].Value == ""))
				{
					// Get roles from UserRoles table, and add to cookie
					grupos = UsuariosBD.ObtenerGrupos(User.Identity.Name);

					// Create a string to persist the roles
					string grupoStr = "";
					foreach (string grupo in grupos)
					{
						grupoStr += grupo;
						grupoStr += ";";
					}

					// Create a cookie authentication ticket.
					FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
						1,                              // version
						Context.User.Identity.Name,     // user name
						DateTime.Now,                   // issue time
						DateTime.Now.AddHours(1),       // expires every hour
						false,                          // don't persist cookie
						grupoStr                         // roles
						);

					// Encrypt the ticket
					string cookieStr = FormsAuthentication.Encrypt(ticket);
					// Send the cookie to the client
					Response.Cookies["aplicaciongrupos"].Value = cookieStr;
					Response.Cookies["aplicaciongrupos"].Path = "/";
					Response.Cookies["aplicaciongrupos"].Expires = DateTime.Now.AddMinutes(1);
				}
				else
				{
					// Get roles from roles cookie
					FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Context.Request.Cookies["Portalgrupos"].Value);

					//convert the string representation of the role data into a string array
					ArrayList gruposUsuario = new ArrayList();

					foreach (string grupo in ticket.UserData.Split( new char[] {';'} ))
						gruposUsuario.Add(grupo);

					grupos = (String[]) gruposUsuario.ToArray(typeof(string));
				}

				// Add our own custom principal to the request containing the roles in the auth ticket
				Context.User = new GenericPrincipal(Context.User.Identity, grupos);
			}
		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		public static string ObtenerRuta(HttpRequest request)
		{
			string ruta = string.Empty;

			try
			{
				if(request.ApplicationPath != "/")
					ruta = request.ApplicationPath;
			}
			catch(Exception e)
			{
				throw e;
			}

			return ruta;
		}

		public static string ObtenerNombrePortal()
		{
			return ConfigurationSettings.AppSettings["PortalNombre"];
		}

		public static string ObtenerTemaPortal()
		{
			string Tema = ConfigurationSettings.AppSettings["PortalTema"];

			IDataReader usuario = UsuariosBD.Obtener(HttpContext.Current.User.Identity.Name);

			if(usuario.Read())
			{
				Tema = usuario["Tema"].ToString();
			}

			usuario.Close();

			return Tema;
		}
			
		#region Código generado por el Diseñador de Web Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

