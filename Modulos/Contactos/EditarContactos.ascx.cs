namespace Portal.Modulos.EditarContactos
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de EditarContactos.
	///						//Con este codigo se conocen TODOS los parametros que recibe una pagina
	//mediante el Request, incluso los que no se muestran.  Los parámetros enviados por el usuario
	//se encuentran generalmente en los primeros lugares del arreglo, posiciones cero (0) en adelante
	//				for (int co=0; co<=Request.Params.AllKeys.Length-1; co++)
	//				{
	//					if (Request.Params.Keys[co].CompareTo("CID") == 0)
	//					{
	//						CoID = Int32.Parse(Request.Params["CID"]); //se obtiene el codigo del contacto
	//					}
	//				}				   

	/// </summary>
	public class EditarContactos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Literal Literal2;
		protected System.Web.UI.WebControls.TextBox TextoNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredName;
		protected System.Web.UI.WebControls.Literal Literal3;
		protected System.Web.UI.WebControls.TextBox TextoCargo;
		protected System.Web.UI.WebControls.Literal Literal4;
		protected System.Web.UI.WebControls.TextBox TextoEmail;
		protected System.Web.UI.WebControls.Literal Literal5;
		protected System.Web.UI.WebControls.TextBox TextoContacto1;
		protected System.Web.UI.WebControls.Literal Literal6;
		protected System.Web.UI.WebControls.TextBox TextoContacto2;
		protected System.Web.UI.WebControls.LinkButton updateButton;
		protected System.Web.UI.WebControls.LinkButton deleteButton;
		protected System.Web.UI.WebControls.LinkButton cancelButton;
		int ModID;
		int CoID; //Valores: "<=0" para nuevo contacto, >0 para editar
		bool Borrar;//para saber si la llamada a la pagina es para borrar un contacto

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página		

			if (Page.IsPostBack == false) 
			{				
				ViewState["UrlAnterior"] = Request.UrlReferrer.ToString();
				if (Request.Params["CID"] != null)
				{ //si no es nulo se viene para edicion y se recupera el CID (Contact ID)
					CoID = Int32.Parse(Request.Params["CID"]);
				}
				else
				{CoID=-1; //para asegurar un valor inicial que indique nuevo contacto
				}
						
				if (Request.Params["borrar"] != null)
				{ //Si es true, quiere decir que la llamada es para borrar el contacto, sino no.
					Borrar = bool.Parse(Request.Params["borrar"]);
				}
				else
				{
					Borrar=false; //valor inicial que indique que la llamada no es para borrar un contacto
				}
				
				if (Borrar == true)
				{// si la llamada es para borrar, se borra el contacto y se devuelve a la ventana
					if (Request.Params["CID"] != null)
					{ //si no es nulo se viene para edicion y se recupera el CID (Contact ID)
						CoID = Int32.Parse(Request.Params["CID"]);
					}
					if (CoID != 0) 
					{
						IDataReader Contac = ContactosBD.BorrarContacto(CoID);
						Contac.Close();
						// Redirecciona a la pagina solicitante
						Response.Redirect((string) ViewState["UrlAnterior"]);
					}		
				}
				else // si la llamada no es para borrar, entonces se continua con el proceso normal
				{
					if (CoID >= 0) // si el codigo es Mayor que cero, se asume que es una edicion
					{
						// Obtiene un registro del contacto
						IDataReader Contac = ContactosBD.ObtenerUnContacto(CoID);
						// Para que lea el unico Registro extraido de la consulta
						if(Contac.Read())
						{
							TextoNombre.Text = (String) Contac["Nombre"];
							TextoCargo.Text = (String) Contac["Cargo"];
							TextoEmail.Text = (String) Contac["Email"];
							TextoContacto1.Text = (String) Contac["Contacto1"];
							TextoContacto2.Text = (String) Contac["Contacto2"];
							//						LabelFecha.Text = ((DateTime) Contac["Fecha"]).ToString();
							//VER QUE COÑO LE PASA A LA FECHA DE MIEEEEEEERDAAAAAAAA!!!
						}
						Contac.Close();
					}
					else  //del ItemID
					{
						deleteButton.Visible = false; // Para que no se borre un usuario inexistente
					}
				}//del else de borrar
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
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void updateButton_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["CID"] != null)
			{ //si no es nulo se viene para edicion y se recupera el CID (Contact ID)
				CoID = Int32.Parse(Request.Params["CID"]);
			}

			if (CoID <= 0) // si viene en "0" se incluye el nuevo Contacto
			{
					ModID = Int32.Parse(Request.Params["mid"]);
				ContactosBD.IncluirContacto(ModID,TextoNombre.Text,TextoCargo.Text,TextoEmail.Text,TextoContacto1.Text,TextoContacto2.Text);
				// Redirecciona a la pagina solicitante
				Response.Redirect((string) ViewState["UrlAnterior"]);
			}
			else //Si es diferente de cero, es para modificar
			{
				ContactosBD.ActualizarContacto(CoID,TextoNombre.Text,TextoCargo.Text,TextoEmail.Text,TextoContacto1.Text,TextoContacto2.Text);
				// Redirecciona a la pagina solicitante
				Response.Redirect((string) ViewState["UrlAnterior"]);			
			}		
		}

		private void deleteButton_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["CID"] != null)
			{ //si no es nulo se viene para edicion y se recupera el CID (Contact ID)
				CoID = Int32.Parse(Request.Params["CID"]);
			}

			if (CoID != 0) 
			{
				IDataReader Contac = ContactosBD.BorrarContacto(CoID);
				Contac.Close();
				// Redirecciona a la pagina solicitante
				Response.Redirect((string) ViewState["UrlAnterior"]);
			}		
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{   // Redirecciona a la pagina solicitante
			Response.Redirect((string) ViewState["UrlAnterior"]);
		}
	}
}
