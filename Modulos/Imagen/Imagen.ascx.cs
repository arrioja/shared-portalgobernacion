namespace Portal.Modulos.Imagen
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de Imagen.
	/// </summary>
	public class Imagen : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Image muestraImagen;

		private void Page_Load(object sender, System.EventArgs e)
		{
			string imagenFuente = (string) Configuracion["ubicacion"];
			string imagenAlto = (string) Configuracion["altura"];
			string imagenAncho = (string) Configuracion["ancho"];

			// Set Image Source, Width and Height Properties
			if ((imagenFuente != null) && (imagenFuente != "")) 
			{
				muestraImagen.ImageUrl = imagenFuente;
			}

			if ((imagenAncho != null) && (imagenAncho != "")) 
			{
				muestraImagen.Width = Int32.Parse(imagenAncho);
			}

			if ((imagenAlto != null) && (imagenAlto != "")) 
			{
				muestraImagen.Height = Int32.Parse(imagenAlto);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
