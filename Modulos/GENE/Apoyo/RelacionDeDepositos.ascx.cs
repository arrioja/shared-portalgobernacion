namespace PortalGobernacion.Modulos.GENE.Apoyo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descripci�n breve de RelacionDeDepositos.
	/// </summary>
	public class RelacionDeDepositos : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.DataGrid dgDepBancos;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DataGrid dgDepFisicos;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddl_CtasDepBancos;
		protected System.Web.UI.WebControls.DropDownList ddl_MesDepFisicos;
		protected PeterBlum.DateTextBoxControls.DateTextBox fecBanco;
		protected PeterBlum.DateTextBoxControls.DateTextBox fecFisico;
		protected System.Web.UI.WebControls.Button btnActualizar;
		protected System.Web.UI.WebControls.Button btnFisico;
		protected System.Web.UI.WebControls.DataGrid dgDepFisico;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aqu� el c�digo de usuario para inicializar la p�gina

			if (Page.IsPostBack == false)
			{
				fecBanco.xDate = DateTime.Today;
                fecFisico.xDate = DateTime.Today;
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
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			this.btnFisico.Click += new System.EventHandler(this.btnFisico_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void BindDepBancos()
		{

			string strFecha  = fecBanco.xDate.Year.ToString() + '-';
			       strFecha += fecBanco.xDate.Month.ToString() + '-';
			       strFecha += fecBanco.xDate.Day.ToString();
			
			DataSet dsDepBancos = RecaudacionBD.BuscarDepBancos( strFecha,ddl_CtasDepBancos.SelectedValue.ToString() );
			dgDepBancos.DataSource = dsDepBancos;
			dgDepBancos.DataBind();
		}

		protected void BindDepFisicos()
		{
			string strFecha  = fecFisico.xDate.Year.ToString() + '-';
			       strFecha += fecFisico.xDate.Month.ToString() + '-';
			       strFecha += fecFisico.xDate.Day.ToString();

			DataSet dsDepFisicos = RecaudacionBD.BuscarDepFisicos( strFecha );
			dgDepFisicos.DataSource = dsDepFisicos;
			dgDepFisicos.DataBind();
		}

		protected void dgDepBancos_Edit(object sender, DataGridCommandEventArgs e)
		{

			string strFecha  = fecBanco.xDate.Year.ToString() + '-';
			       strFecha += fecBanco.xDate.Month.ToString() + '-';
			       strFecha += fecBanco.xDate.Day.ToString();
			
			if (e.CommandName.ToString() == "Crear")
			{
                DataSet dsDepBancos = RecaudacionBD.BuscarDepBancos( strFecha,ddl_CtasDepBancos.SelectedValue.ToString() );

				DataRow newRow = dsDepBancos.Tables[0].NewRow();
				dsDepBancos.Tables[0].Rows.InsertAt( newRow, dsDepBancos.Tables[0].Rows.Count );
                Session["dsDataBanco"] = dsDepBancos;

                dgDepBancos.DataSource = dsDepBancos;
				dgDepBancos.EditItemIndex = dsDepBancos.Tables[0].Rows.Count-1;
				DesactivarEdicion('1');
				dgDepBancos.DataBind();
			}
			if (e.CommandName.ToString() == "Editar")
			{
				DataSet dsDepBancos = RecaudacionBD.BuscarDepBancos( strFecha,ddl_CtasDepBancos.SelectedValue.ToString() );
				Session["dsDataBanco"] = dsDepBancos;
				dgDepBancos.EditItemIndex = e.Item.ItemIndex;
				DesactivarEdicion('1');
				BindDepBancos();
			}

			if (e.CommandName.ToString() == "Guardar")
			{
				string strNumeroDep = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
				string strFechaT    = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
				string strNumeroCta = ddl_CtasDepBancos.SelectedValue.ToString();
				string strMonto     = ((TextBox)e.Item.Cells[7].Controls[0]).Text;
				
				string strFecha_g  = System.DateTime.Parse( strFechaT ).Year.ToString() + '-';
					   strFecha_g += System.DateTime.Parse( strFechaT ).Month.ToString() + '-';
					   strFecha_g += System.DateTime.Parse( strFechaT ).Day.ToString();
				
				DataSet ds = (DataSet) Session["dsDataBanco"];
				DataTable dt = ds.Tables[0];
				DataRow dr = dt.Rows[dt.Rows.Count-1];
				if (dr.RowState == DataRowState.Added)
				{
					RecaudacionBD.CrearBanco( strNumeroDep,strFecha_g,strNumeroCta,strMonto ); 
				}
				else
				{
					RecaudacionBD.ActualizarBanco( strNumeroDep,strFecha_g,strNumeroCta,strMonto ); 
				}

				dgDepBancos.EditItemIndex = -1;
				ActivarEdicion('1');
				BindDepBancos();			   
			}

			if (e.CommandName.ToString() == "Deshacer")
			{
				dgDepBancos.EditItemIndex = -1;
                ActivarEdicion('1');
				BindDepBancos();
			}

			if ( e.CommandName.ToString() == "Eliminar")
			{
				string strNumeroDep = e.Item.Cells[5].Text;
				RecaudacionBD.EliminarFisico( strNumeroDep );
				BindDepBancos();			   
			}
			
		}

		protected void dgDepFisicos_Edit(object sender, DataGridCommandEventArgs e)
		{
			string strFecha  = fecFisico.xDate.Year.ToString() + '-';
			       strFecha += fecFisico.xDate.Month.ToString() + '-';
			       strFecha += fecFisico.xDate.Day.ToString();

			if (e.CommandName.ToString() == "Crear")
			{
                DataSet dsDepFisicos = RecaudacionBD.BuscarDepFisicos( strFecha );

				DataRow newRow = dsDepFisicos.Tables[0].NewRow();
				dsDepFisicos.Tables[0].Rows.InsertAt( newRow, dsDepFisicos.Tables[0].Rows.Count );
			    Session["dsDataFisico"] = dsDepFisicos;

				dgDepFisicos.DataSource = dsDepFisicos;
				dgDepFisicos.EditItemIndex = dsDepFisicos.Tables[0].Rows.Count-1;
				DesactivarEdicion('2');
				dgDepFisicos.DataBind();
			}			

			if (e.CommandName.ToString() == "Editar")
			{
				DataSet dsDepFisicos = RecaudacionBD.BuscarDepFisicos( strFecha );
				Session["dsDataFisico"] = dsDepFisicos;
				dgDepFisicos.EditItemIndex = e.Item.ItemIndex;
				DesactivarEdicion('2');
				BindDepFisicos();
			}

			if (e.CommandName.ToString() == "Guardar")
			{
				string strNumeroDep   = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
				string strFechaT      = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
				string strFormaDePago = ((DropDownList)e.Item.Cells[7].FindControl("ddl_FormaDePago")).SelectedValue.ToString();
                string strNumeroPar   = ((DropDownList)e.Item.Cells[8].FindControl("ddl_Partidas")).SelectedValue.ToString();
				string strNumeroPla   = ((TextBox)e.Item.Cells[9].Controls[0]).Text;
				
				string strFecha_g  = System.DateTime.Parse( strFechaT ).Year.ToString() + '-';
				       strFecha_g += System.DateTime.Parse( strFechaT ).Month.ToString() + '-';
				       strFecha_g += System.DateTime.Parse( strFechaT ).Day.ToString();

				DataSet ds = (DataSet) Session["dsDataFisico"];
				DataTable dt = ds.Tables[0];
				DataRow dr = dt.Rows[dt.Rows.Count-1];
				if (dr.RowState == DataRowState.Added)
				{
					RecaudacionBD.CrearFisico( strNumeroDep,strFecha_g,strFormaDePago,strNumeroPla, strNumeroPar ); 
				}
				else
				{
					RecaudacionBD.ActualizarFisico( strNumeroDep,strFecha_g,strFormaDePago,strNumeroPla, strNumeroPar ); 
				}
				
				dgDepFisicos.EditItemIndex = -1;
				ActivarEdicion('2');
				BindDepFisicos();			   
			}

			if (e.CommandName.ToString() == "Deshacer")
			{
				dgDepFisicos.EditItemIndex = -1;
                ActivarEdicion('2');
				BindDepFisicos();
			}


			if ( e.CommandName.ToString() == "Eliminar")
			{
				string strNumeroDep = e.Item.Cells[5].Text;
				RecaudacionBD.EliminarFisico( strNumeroDep );
				BindDepFisicos();			   
			}

		}

		protected void DesactivarEdicion( char dg )
		{
			bool [] ArrActDes = new bool [5] {false, true, false, false, true};

			if (dg == '1')
			{
				for (int ind = 0; ind < 5; ++ind ) { dgDepBancos.Columns[ind].Visible = false;	}
			}
			else
			{
                for (int ind = 0; ind < 5; ++ind )	{ dgDepFisicos.Columns[ind].Visible = ArrActDes[ind]; }
			}
			
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
		
		public String CalcFormaDePago( char FormaDePago )
		{
			string rFormaDePago = " ";
			switch (FormaDePago)
			{
				case 'E': rFormaDePago = "EFECTIVO"; break;
				case 'C': rFormaDePago = "CHEQUE"; break;
			}
			return(  rFormaDePago );
		}

		public DataView CargarDatos()
		{
			DataSet dsPartidas = RecaudacionBD.ObtenerPartidas();
			return (dsPartidas.Tables[0].DefaultView);
		}

		private void fecBanco_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
           BindDepBancos();		
		}

		private void btnFisico_Click(object sender, System.EventArgs e)
		{
           BindDepFisicos();				
		}

	}
}
