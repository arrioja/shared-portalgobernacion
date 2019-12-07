namespace Portal.Modulos.Xml
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.IO;
	using Portal.Kernel;

	/// <summary>
	///		Descripci�n breve de Xml.
	/// </summary>
	public class Xml : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Xml muestraXML;

		private void Page_Load(object sender, System.EventArgs e)
		{
			string xmlfuente = (string) Configuracion["xmlfue"];

			if ((xmlfuente != null) && (xmlfuente != ""))
			{

				if  (File.Exists(Server.MapPath(xmlfuente)))
				{

					muestraXML.DocumentSource = xmlfuente;
				}
				else
				{
					Controls.Add(new LiteralControl("<" + "br" + "><" + "span class=Error" + ">" + "Archivo " + xmlfuente + " no encontrado.<" + "br" + ">"));
				}
			}

			string xslfuente = (string) Configuracion["xslfue"];

			if ((xslfuente != null) && (xslfuente != ""))
			{

				if  (File.Exists(Server.MapPath(xslfuente)))
				{

					muestraXML.TransformSource = xslfuente;
				}
				else
				{

					Controls.Add(new LiteralControl("<" + "br" + "><" + "span class=Error>Archivo " + xslfuente+ " no encontrado.<" + "br" +">"));
				}
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
		///		M�todo necesario para admitir el Dise�ador. No se puede modificar
		///		el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
