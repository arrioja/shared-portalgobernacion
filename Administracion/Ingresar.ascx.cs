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
	///		Descripci�n breve de Ingresar.
	/// </summary>
	public class Ingresar : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.TextBox usuario;
		protected System.Web.UI.WebControls.TextBox clave;
		protected System.Web.UI.WebControls.LinkButton ingresarPortal;
		protected System.Web.UI.WebControls.Panel PanelError;

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
		///		M�todo necesario para admitir el Dise�ador. No se puede modificar
		///		el contenido del m�todo con el editor de c�digo.
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
