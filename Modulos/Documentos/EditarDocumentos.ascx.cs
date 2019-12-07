namespace PortalGobernacion.Modulos.Documentos
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.IO;
	using System.IO.IsolatedStorage;
	using Portal.Kernel;


	/// <summary>
	///		Descripci�n breve de EditarDocumentos.
	/// </summary>
	public class EditarDocumentos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.LinkButton cancelButton;
		protected System.Web.UI.WebControls.LinkButton deleteButton;
		protected System.Web.UI.WebControls.LinkButton updateButton;
		protected System.Web.UI.WebControls.Literal Literal5;
		protected System.Web.UI.WebControls.Literal Literal4;
		protected System.Web.UI.WebControls.Literal Literal3;
		protected System.Web.UI.WebControls.Literal Literal1;
		int ModID;
		int DocId;
		protected System.Web.UI.WebControls.TextBox txtLink;
		protected System.Web.UI.WebControls.TextBox txtFormato;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.LinkButton Linkbutton1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.TextBox txtTitulo;
		protected System.Web.UI.WebControls.Button Button1; //Valores: "<=0" para nuevo documento, >0 para editar
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			IsolatedStorageFile isoFile=IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null);
			
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
		
				if (Page.IsPostBack == false) 
			{
				Button1.Visible=false;
				File1.Visible=false;
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();

				if (Request.Params["DocumentoId"] != null)
				{ //si no es nulo se viene para edicion o borrado y se recupera el doc id (Contact ID)
					DocId = Int32.Parse(Request.Params["DocumentoId"]);
				}
				else
				{
					DocId=-1; //para asegurar un valor inicial que indique nuevo contacto
				}
						
				
				if (Request.Params["borrar"] =="1" )
				{// si la llamada es para borrar, se borra el documento y se devuelve a la ventana
					if (Request.Params["DocumentoId"] != null)
					{ //si no es nulo se viene para borrar y se recupera el DocumentoId (Doc ID)
						DocId = Int32.Parse(Request.Params["DocumentoId"]);
					}
					if (DocId != 0)
					{
							try
					  {
						 /*string	aplicacion=Context.Request.ApplicationPath;
						 aplicacion=aplicacion.Remove(0,1);
						 string nombre=Request.Params["Titulo"];
						string rutaServidor=Context.Server.MapPath(@"\")+ aplicacion+ @"\Modulos\Documentos\Archivos\" +  nombre;

						  isoFile.DeleteFile(rutaServidor);*/
						  IDataReader Docs = DocumentosBD.BorrarDocumento(DocId);
						  Docs.Close();
						  // Redirecciona a la pagina solicitante
						  Response.Redirect((string) ViewState["UrlAnterior"]);
					  }
						catch (Exception exc)
						{Label1.Visible=true;
						Label1.Text=exc.ToString();
						}
					}		
				}
				else // si la llamada no es para borrar, entonces se continua con el proceso normal
			{
				if (DocId >= 0) // si el codigo es Mayor que cero, se asume que es una edicion
				{
					// Obtiene un registro del contacto
					IDataReader Docs = DocumentosBD.ObtenerUnDocumento(DocId);
					// Para que lea el unico Registro extraido de la consulta
					if(Docs.Read())
					{
						txtDescripcion.Text = (String) Docs["Descripcion"];
						txtFormato.Text = (String) Docs["Formato"];
						txtLink.Text = (String) Docs["Link"];
						txtTitulo.Text=(String) Docs["Titulo"];
					}
					Docs.Close();
				}
				else  //si es un nuevo doc
				{
					deleteButton.Visible = false; // Para que no se borre un usuario inexistente
					updateButton.Visible=false;//no actualizar si es uno nuevo
					Linkbutton1.Visible=true;
				}
			}//del else de borrar
			}
			else
			{//ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
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
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			this.Linkbutton1.Click += new System.EventHandler(this.Linkbutton1_Click);
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void updateButton_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["DocumentoId"] != null)
			{ //si no es nulo se viene para edicion y se recupera el CID (Contact ID)
				DocId = Int32.Parse(Request.Params["DocumentoId"]);
			}

			if (DocId <= 0) // si viene en "0" se incluye el nuevo Documento
			{  				
				ModID = Int32.Parse(Request.Params["mid"]);
				DocumentosBD.IncluirDocumento(ModID,DateTime.Now.ToString("yyyy/MM/dd"),txtDescripcion.Text,txtFormato.Text,txtLink.Text,txtTitulo.Text);
				// Redirecciona a la pagina solicitante
				//Response.Redirect("~/Default.aspx?pagId=" + Request.Params["pagId"]);
				Response.Redirect((string) ViewState["UrlAnterior"]);
			}
			else //Si es diferente de cero, es para modificar
			{
				DocumentosBD.ActualizarDocumento(DocId,DateTime.Now.ToString("yyyy/MM/dd"),txtDescripcion.Text,txtFormato.Text,txtLink.Text,txtTitulo.Text);
				// Redirecciona a la pagina solicitante
				//Response.Redirect("~/Default.aspx?pagId=" + Request.Params["pagId"]);
				Response.Redirect((string) ViewState["UrlAnterior"]);			
			}	
		}

		private void Linkbutton1_Click(object sender, System.EventArgs e)
		{
		File1.Visible=true;
		Button1.Visible=true;

		
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("~/Default.aspx?pagId=" + Request.Params["pagId"]);
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{string nombre, descripcion,rutaServidor, aplicacion;
			
			if (File1.PostedFile != null) 
				
			{rutaServidor =Context.Request.PhysicalPath;
				rutaServidor=rutaServidor.Remove(rutaServidor.Length-12,12);	
				nombre=Path.GetFileName(File1.PostedFile.FileName);
				txtTitulo.Text=nombre;
				descripcion=File1.PostedFile.ContentType;
				
				rutaServidor=rutaServidor + @"Modulos\Documentos\Archivos\" +  nombre;
				try
				{
					File1.PostedFile.SaveAs(rutaServidor);	
					Label1.Visible=true;
					Label1.Text	 = "Archivo cargado al servidor exitosamente";
                    Button1.Visible=false;
					File1.Visible=false;
					txtLink.Text=File1.PostedFile.FileName;
					txtFormato.Text=descripcion;

					Button1.Visible=false;
					Linkbutton1.Visible=false;
					File1.Visible=false;
					Label1.Visible=false;
					updateButton.Visible=true;
				}
				catch (Exception exc) 
				{
						Label1.Visible=true;
					Label1.Text = "Error al guardar el archivo. Descripcion: " + exc.ToString();
				}
			}
			else
			{
				Label1.Text= "Error: Debe seleccionar un archivo"; 
				return;
			}

			
			
			
		}

		private void deleteButton_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
