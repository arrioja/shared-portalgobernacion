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
using System.Timers;



namespace PortalGobernacion.Modulos.Documentos
{
	/// <summary>
	/// Descripci�n breve de WebForm1.
	/// </summary>
	/// 
	public class WebForm1 : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Span1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnVolver;
		protected HtmlInputFile File1; 
		 string nombre;
		string rutaServidor;
		 string descripcion;
			string UrlAnterior;


	
		private void Page_Load(object sender, System.EventArgs e)
		{
		
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			btnVolver.Visible=false;
			UrlAnterior = Request.QueryString["UrlAterior"];
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
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void Button1_Click(object sender, System.EventArgs e)
		{int i,j=0;
			
			if (File1.PostedFile != null) 
			{
			nombre=Path.GetFileName(File1.PostedFile.FileName);
			descripcion=File1.PostedFile.ContentType;
			rutaServidor=Context.Server.MapPath(@"Archivos\") + nombre;
				try
				{
				File1.PostedFile.SaveAs(rutaServidor);	
			    Label1.Visible=true;
				Label1.Text	 = "Archivo cargado al servidor exitosamente";
					for (i=1;i<5000;i++) 
					{j++;
					}
				ViewState["RutaDocumento"]=rutaServidor;
				ViewState["NombreDocumento"]=nombre;
				ViewState["Tipo"]=  descripcion;
				Response.Redirect(UrlAnterior);
				
				//btnVolver.Visible=true;
				}
				catch (Exception exc) 
				{Label1.Visible=true;
					Label1.Text = "Error al guardar el archivo. Descripcion: " + exc.ToString();
				}
			}else
			{
				Label1.Text= "Error: Debe seleccionar un archivo"; 
				return;
			}

			
			
			
		}

		private void btnVolver_Click(object sender, System.EventArgs e)
		{
	
		}
	}
}
