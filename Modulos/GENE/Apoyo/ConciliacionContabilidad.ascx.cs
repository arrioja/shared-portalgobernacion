namespace PortalGobernacion.Modulos.GENE.Apoyo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descripci�n breve de ConciliacionContabilidad.
	/// </summary>
	public class ConciliacionContabilidad : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddl_MesDepBancos;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddl_CtasDepBancos;
		protected System.Web.UI.WebControls.DataGrid dgDepBancos;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgDepFisicos;
		protected System.Web.UI.WebControls.Button btnConciliar;
		protected System.Web.UI.WebControls.RadioButtonList rbl_Seleccionar;
		protected System.Web.UI.WebControls.DropDownList ddl_MesDepFisicos;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina
			if (Page.IsPostBack == false)
			{
				ActivarEdicion( '1' );
				ActivarEdicion( '2' );

				BindDepBancos();
				BindDepFisicos();

				DataSet dsCuentas = RecaudacionBD.ObtenerCuentas();
				foreach ( DataRow dr in dsCuentas.Tables[0].Rows )
				{
					ddl_CtasDepBancos.Items.Add( dr[0].ToString() );
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
			this.ddl_MesDepBancos.SelectedIndexChanged += new System.EventHandler(this.ddl_MesDepBancos_SelectedIndexChanged);
			this.ddl_CtasDepBancos.SelectedIndexChanged += new System.EventHandler(this.ddl_MesDepBancos_SelectedIndexChanged);
			this.btnConciliar.Click += new System.EventHandler(this.btnConciliar_Click);
			this.dgDepBancos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgDepBancos_PageIndexChanged);
			this.ddl_MesDepFisicos.SelectedIndexChanged += new System.EventHandler(this.ddl_MesDepFisicos_SelectedIndexChanged);
			this.rbl_Seleccionar.SelectedIndexChanged += new System.EventHandler(this.rbl_Seleccionar_SelectedIndexChanged);
			this.dgDepFisicos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgDepFisicos_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void BindDepBancos()
		{
			DataSet dsDepBancos = ConciliacionBD.BuscarDepBancos( ddl_MesDepBancos.SelectedValue.ToString(),ddl_CtasDepBancos.SelectedValue.ToString(),rbl_Seleccionar.SelectedValue.ToString() );
			dgDepBancos.DataSource = dsDepBancos;
			dgDepBancos.DataBind();
		}

		protected void BindDepFisicos()
		{
			DataSet dsDepFisicos = ConciliacionBD.BuscarDepFisicos( ddl_MesDepFisicos.SelectedValue.ToString(),rbl_Seleccionar.SelectedValue.ToString() );
			dgDepFisicos.DataSource = dsDepFisicos;
			dgDepFisicos.DataBind();
		}

		protected void ActivarEdicion( char dg )
		{
			bool [] ArrActDes = new bool [5] {true, false, true, true, false};

			if (dg == '1') 
			{
				for (int ind = 0; ind < 5; ++ind )	{ dgDepBancos.Columns[ind].Visible = false; }
			}
			else
			{
				for (int ind = 0; ind < 5; ++ind )	{ dgDepFisicos.Columns[ind].Visible = ArrActDes[ind]; }
			}
		}

		private void ddl_MesDepBancos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dgDepBancos.CurrentPageIndex = 0;
			BindDepBancos();
		}

		private void dgDepBancos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgDepBancos.CurrentPageIndex = e.NewPageIndex;
			BindDepBancos();
		}

		private void ddl_MesDepFisicos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            dgDepFisicos.CurrentPageIndex = 0;
			BindDepFisicos();
		}

		private void dgDepFisicos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgDepFisicos.CurrentPageIndex = e.NewPageIndex;
			BindDepFisicos();		
		}

		private void btnConciliar_Click(object sender, System.EventArgs e)
		{
			ConciliacionBD.Conciliar( ddl_MesDepBancos.SelectedValue.ToString(),ddl_CtasDepBancos.SelectedValue.ToString() );
			BindDepBancos();
			BindDepFisicos();
		}

		private void rbl_Seleccionar_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            dgDepBancos.CurrentPageIndex = 0;
            dgDepFisicos.CurrentPageIndex = 0;
			BindDepBancos();
			BindDepFisicos();
		}

		protected void Item_DataBound_L(object sender, DataGridItemEventArgs e)
		{
			// Get the type of the newly created item
			ListItemType itemType = e.Item.ItemType;
			if (itemType == ListItemType.Item || itemType == ListItemType.AlternatingItem ) 
			{
				// Get the data bound to the current row
				DataRowView drv = (DataRowView) e.Item.DataItem;
				if (drv != null)
				{
					// Check here the app-specific way to detect whether the 
					// current row is a summary row
					if ( drv["NumeroDep"].ToString() == "" )
					{
						// Modify style and layout here. 
						//    --> Set the background color to white and use bold font
						e.Item.BackColor = Color.BlanchedAlmond; 
						e.Item.Font.Bold = true;

						for (int ind = 0; ind < 7; ++ind )	{ e.Item.Cells[0].Text = ""; }
						
					}

				}

			}
		}

		protected void Item_DataBound_B(object sender, DataGridItemEventArgs e)
		{
			// Get the type of the newly created item
			ListItemType itemType = e.Item.ItemType;
			if (itemType == ListItemType.Item || itemType == ListItemType.AlternatingItem ) 
			{
				// Get the data bound to the current row
				DataRowView drv = (DataRowView) e.Item.DataItem;
				if (drv != null)
				{
					// Check here the app-specific way to detect whether the 
					// current row is a summary row
					if ( drv["NumeroDep"].ToString() == "" )
					{
						// Modify style and layout here. 
						//    --> Set the background color to white and use bold font
						e.Item.BackColor = Color.BlanchedAlmond; 
						e.Item.Font.Bold = true;

						for (int ind = 0; ind < 7; ++ind )	{ e.Item.Cells[0].Text = ""; }
						
					}

				}

			}
		}

	}
}
