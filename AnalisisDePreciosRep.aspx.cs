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

namespace Portal.Modulos.GENE.Apoyo
{
	/// <summary>
	/// Descripción breve de AnalisisDePreciosRep.
	/// </summary>
	public class AnalisisDePreciosRep : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			//string strNumero = "4152";
			//RT.ResponsePDF( new ReporteAnalisisDePrecios( strNumero ), this);
			string Sector;
			DateTime Desde;
			DateTime Hasta;

			Sector = "11";
			//Sector = "4152";
			Desde = DateTime.Parse("01-01-2005");
			Hasta = DateTime.Parse("31-12-2005");
			RT.ResponsePDF(new ReporteAnalisisDePrecios(Sector, Desde, Hasta), this);
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
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
