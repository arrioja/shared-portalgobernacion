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
using Root.Reports;

namespace PortalGobernacion.Modulos.GENE.Apoyo.ComprasServicios
{
	/// <summary>
	/// Descripci�n breve de ReporteCompras1.
	/// </summary>
	public class ReporteCompras1 : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string Sector;
			DateTime Desde;
			DateTime Hasta;

			Sector = "11";
			Desde = DateTime.Parse("01-01-2005");
			Hasta = DateTime.Parse("31-12-2005");
		/*	Desde.Day = 1; Desde.Month = 1; Desde.Year = 2005;
			Hasta.Day = 31; Hasta.Month = 12; Hasta.Year = 2005;
*/
			RT.ResponsePDF(new ReporteCompras(Sector, Desde, Hasta), this);
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
