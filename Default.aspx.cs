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

namespace Portal
{
	/// <summary>
	/// Descripci�n breve de _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder TemaHolder;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			PortalConfig configPortal = (PortalConfig) HttpContext.Current.Items["PortalConfig"];

			try
			{
				string RutaTema = string.Concat("Temas/", Global.ObtenerTemaPortal(), "/Default.ascx");
				TemaHolder.Controls.Add(Page.LoadControl(RutaTema));
			}
			catch(System.IO.FileNotFoundException)
			{
				// Tema no encontrado, cargar tema por defecto
				TemaHolder.Controls.Add(Page.LoadControl("Temas/Defecto/Default.ascx"));
			}
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
