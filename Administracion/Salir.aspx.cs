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

namespace Portal.Administracion
{
	using System.Web.Security;
	using System.Security.Principal;
	using Portal.Kernel;
	/// <summary>
	/// Descripci�n breve de Salir.
	/// </summary>
	public class Salir : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Sacar al usuario del sistema
			FormsAuthentication.SignOut();
    
			// Invalidar los grupos
			Response.Cookies["Portalgrupos"].Value = null;
			Response.Cookies["Portalgrupos"].Expires = new System.DateTime(2002, 12, 31);
			Response.Cookies["Portalgrupos"].Path = "/";
    
			// Regresar a la pagina principal
			Response.Redirect(Global.ObtenerRuta(Request)+"/Default.aspx"); 
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
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
