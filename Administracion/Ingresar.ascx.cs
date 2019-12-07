namespace Portal.Administracion
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.Security;
	using System.Security.Principal;
	using Portal.Kernel;

	/// <summary>
	///		Descripción breve de Ingresar.
	/// </summary>
	public class Ingresar : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.TextBox usuario;
		protected System.Web.UI.WebControls.TextBox clave;
		protected System.Web.UI.WebControls.LinkButton ingresarPortal;
		protected System.Web.UI.WebControls.Panel PanelError;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
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
			this.ingresarPortal.Click += new System.EventHandler(this.ingresarPortal_Click);

		}
		#endregion

		private void ingresarPortal_Click(object sender, System.EventArgs e)
		{
			string Usuario = SeguridadPortal.Ingresar(usuario.Text, clave.Text);

			if ((Usuario != null) && (Usuario != ""))
			{
				FormsAuthentication.SetAuthCookie(Usuario, false);
				Response.Redirect(Request.ApplicationPath);
			}
			else
				PanelError.Visible = true;
		}
	}
}
