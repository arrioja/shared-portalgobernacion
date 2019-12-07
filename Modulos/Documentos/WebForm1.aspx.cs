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
using System.IO;

namespace PortalGobernacion.Modulos.Documentos
{
	/// <summary>
	/// Descripci�n breve de WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Span1;
		protected System.Web.UI.WebControls.Button Button1;
		protected HtmlInputFile File1; 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string ServerFileName; 
			ServerFileName = Path.GetFileName(File1.PostedFile.FileName); 
			File1.PostedFile.SaveAs("C:\\Temp\\" + ServerFileName);
		}
			/*// Get the HtmlInputFile control from the Controls collection 
			// of the PlaceHolder control.
			HtmlInputFile file = (HtmlInputFile)Place.FindControl("File1");
 

			if (Text1.Value == "") 
			{
				Span1.InnerHtml = "Error: you must enter a file name";
				return;
			}
 
			if (File1.PostedFile != null) 
			{
				try
				{
					File1.PostedFile.SaveAs("c:\\temp\\"+Text1.Value);
					Span1.InnerHtml = "File uploaded successfully to <b>c:\\temp\\" + 
						Text1.Value + "</b> on the Web server";
				}
				catch (Exception exc) 
				{
					Span1.InnerHtml = "Error saving file <b>c:\\temp\\" + 
						Text1.Value + "</b><br>" + exc.ToString();
				}
			}

			
			
			
		}*/
	}
}
