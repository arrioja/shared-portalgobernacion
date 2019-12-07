namespace Portal.Modulos.GENE.Apoyo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descripción breve de ConsultaBeneficiarios.
	/// </summary>
	public class BeneficiariosOP : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button botonBuscar;
		protected System.Web.UI.WebControls.DataList Datos;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td1;
		protected System.Web.UI.WebControls.TextBox Busqueda;

		int Nivel = 0;


		private void Page_Load(object sender, System.EventArgs e)
		{
			string NivelAcceso = (string) Configuracion["NivelAcceso"];
			
			if ((NivelAcceso != null) && (NivelAcceso != "")) 
				Nivel = Int32.Parse(NivelAcceso);

			if(!IsPostBack)
				Datos.SelectedIndex = -1;
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
			this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
			this.Datos.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.Datos_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		void EnlazarDatos()
		{
			string cadenaBuscar = ViewState["Busqueda"].ToString();

			IDataReader dr = BeneficiariosOPBD.ObtenerBeneficiarios(cadenaBuscar);

			Datos.DataSource = dr;

			Datos.DataBind();

			dr.Close();
		}

		private void botonBuscar_Click(object sender, System.EventArgs e)
		{
			ViewState["Busqueda"] = Busqueda.Text.ToUpper();

			Datos.SelectedIndex = -1;

			EnlazarDatos();
		}

		private void Datos_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			string cmd = ((LinkButton)e.CommandSource).CommandName;

			DataList sender = (DataList)source;

			if (cmd == "select")
				sender.SelectedIndex = e.Item.ItemIndex;

			ViewState["_Beneficiario"] = ((Label)e.Item.FindControl("COD_BENEF")).Text;

			EnlazarDatos();

		}

		public void Ordenes_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			if(Nivel > 0)
			{
				string cmd = ((LinkButton)e.CommandSource).CommandName;
				DataList sender = (DataList)source;

				if (cmd == "select")
					sender.SelectedIndex = e.Item.ItemIndex;

				sender.DataSource = ObtenerOrdenes((string)ViewState["_Beneficiario"]);
				sender.DataBind();
			}
		}

		public DataSet ObtenerOrdenes(string Beneficiario)
		{
			if(Beneficiario == null)
				Beneficiario = (string)ViewState["_Beneficiario"];
			else
				ViewState["_Beneficiario"] = Beneficiario;

			return BeneficiariosOPBD.ObtenerBeneficiariosOP(Beneficiario);
		}

		public DataSet ObtenerCheques(string Orden)
		{
			return BeneficiariosOPBD.ObtenerChequesOP(Orden);
		}
	}
}
