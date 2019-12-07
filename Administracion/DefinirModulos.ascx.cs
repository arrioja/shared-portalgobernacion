namespace Portal.Administracion
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Kernel;

	/// <summary>
	///		Descripci�n breve de DefinirModulos.
	/// </summary>
	public class DefinirModulos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DataList listaDefiniciones;
		protected System.Web.UI.WebControls.LinkButton botonCrear;
		public string Ruta = "";
		int pagId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Ruta = Global.ObtenerRuta(Request);

			if (Request.Params["pagid"] != null)
				pagId = Int32.Parse(Request.Params["pagid"]);

			if(Page.IsPostBack == false)
				EnlazarDatos();
		}

		void EnlazarDatos()
		{
			IDataReader dr = ModulosBD.ObtenerDefiniciones();
			listaDefiniciones.DataSource = dr;
			listaDefiniciones.DataBind();
			dr.Close();
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
			this.listaDefiniciones.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.listaDefiniciones_ItemCommand);
			this.botonCrear.Click += new System.EventHandler(this.botonCrear_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonCrear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("~/Default.aspx?editar=1&defId=-1&mid=" + ModuloId);
		}

		private void listaDefiniciones_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			int moduloDefId = (int) listaDefiniciones.DataKeys[e.Item.ItemIndex];

			Response.Redirect("~/Default.aspx?editar=1&pagId=" + pagId + "&defId=" + moduloDefId + "&mid=" + ModuloId);
		}
	}
}
