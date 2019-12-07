
namespace Portal.Modulos.GENE.Apoyo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Root.Reports;

	/// <summary>
	///		Descripción breve de AnalisisDePrecio.
	/// </summary>
	public class AnalisisDePrecio : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Button btnSeleccionar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox Busqueda;
		protected System.Web.UI.WebControls.Button botonBuscar;
		protected System.Web.UI.WebControls.TextBox Numero;
		protected System.Web.UI.WebControls.DropDownList tdl_Proveedor1;
		protected System.Web.UI.WebControls.DropDownList tdl_Proveedor2;
		protected System.Web.UI.WebControls.DropDownList tdl_Proveedor3;
		protected System.Web.UI.WebControls.DataGrid dgAnalisis;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button BotonRestablecer;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnImprimir;
		protected System.Web.UI.WebControls.DataGrid dgSuministros;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			if (Page.IsPostBack == false)
			{
				DataSet dsProveedores = ApoyoBD.ObtenerProveedores();
			   
				foreach ( DataRow dr in dsProveedores.Tables[0].Rows )
				{
					tdl_Proveedor1.Items.Add( dr[0].ToString() );
					tdl_Proveedor2.Items.Add( dr[0].ToString() );
					tdl_Proveedor3.Items.Add( dr[0].ToString() );
				}
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
			this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
			this.BotonRestablecer.Click += new System.EventHandler(this.BotonRestablecer_Click);
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void dgSuministros_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		          			
		}

		private void dgSuministros_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgSuministros.CurrentPageIndex = e.NewPageIndex;
			BindSuministro();
		}

		private void botonBuscar_Click(object sender, System.EventArgs e)
		{
			dgSuministros.CurrentPageIndex = 0;
			BindSuministro();
		}

		protected void Insertar_Suministro(object sender, DataGridCommandEventArgs e)
		{
			if (e.CommandName.ToString() == "Select")
			{
				ApoyoBD.Crear(e.Item.Cells[2].Text,e.CommandArgument.ToString(),Numero.Text );
				BindAnalisis();
			}
		}

		private void BotonRestablecer_Click(object sender, System.EventArgs e)
		{
			dgAnalisis.EditItemIndex = -1;
			BindAnalisis();
		}

		protected void DataGrid_Edit(object sender, DataGridCommandEventArgs e)
		{
			if (e.CommandName.ToString() == "Editar")
			{
				dgAnalisis.EditItemIndex = e.Item.ItemIndex;
				BindAnalisis();
			}
			if (e.CommandName.ToString() == "Guardar")
			{
				string strCodigo        = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
				string strDescripcion   = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
				string strCantidad      = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
				string strPrecio1       = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
				string strPrecio2       = ((TextBox)e.Item.Cells[7].Controls[0]).Text;
				string strPrecio3       = ((TextBox)e.Item.Cells[9].Controls[0]).Text;
				string strObservaciones = ((TextBox)e.Item.Cells[12].Controls[0]).Text;
				ApoyoBD.Actualizar( strCodigo,strDescripcion,strCantidad,strPrecio1,strPrecio2,strPrecio3,strObservaciones,Numero.Text); 
				dgAnalisis.EditItemIndex = -1;
				BindAnalisis();			   
			}
			if ( e.CommandName.ToString() == "Eliminar")
			{
				string strCodigo        = e.Item.Cells[2].Text;
				ApoyoBD.Eliminar( strCodigo, Numero.Text );
				BindAnalisis();			   
			}
		}

		protected void Item_Created(object sender, DataGridItemEventArgs e)
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
					if ( drv["Codigo"].ToString() == "" )
					{
						// Modify style and layout here. 
						//    --> Set the background color to white and use bold font
						e.Item.BackColor = Color.BlanchedAlmond; 
						e.Item.Font.Bold = true;

						e.Item.Cells.RemoveAt(0);      // Crear, Modificar
						e.Item.Cells.RemoveAt(0);      // Eliminar
						e.Item.Cells.RemoveAt(0);      // Código
						e.Item.Cells.RemoveAt(0);      // Descripción 
						e.Item.Cells.RemoveAt(0);      // Cantidad
						e.Item.Cells.RemoveAt(0);      // Precio1 
						e.Item.Cells[0].ColumnSpan = 7;   
						e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Right;   

						e.Item.Cells.RemoveAt(1);      // remove Order #, now the first 
						e.Item.Cells[1].ColumnSpan = 2;   
						e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;   
						
						e.Item.Cells.RemoveAt(2);      // remove Order #, now the first 
						e.Item.Cells[2].Width = 180;
						e.Item.Cells[2].ColumnSpan = 2;
						e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;  
						 
					}

				}

			}
		}

		protected void BindAnalisis()
		{
			DataSet dsAnalisis = ApoyoBD.BuscarAnalisis(Numero.Text);
			dgAnalisis.DataSource = dsAnalisis;
			dgAnalisis.DataBind();
		}

		protected void BindSuministro()
		{
			DataSet dsSuministros = ApoyoBD.BuscarSuministro(Busqueda.Text);
			dgSuministros.DataSource = dsSuministros;
			dgSuministros.DataBind();

		}

		public String CalcSeleccionado(Double Sub1, Double Sub2, Double Sub3)
		{
			Double [] arrSub = new double [3];
			String [] arrSel = new string [3];
			Double dMenor = Sub1;
			int indSeleccionado = 0;

			arrSub[0] = Sub1;
			arrSub[1] = Sub2;
			arrSub[2] = Sub3;

			arrSel[0] = tdl_Proveedor1.SelectedValue.ToString();
			arrSel[1] = tdl_Proveedor2.SelectedValue.ToString();
			arrSel[2] = tdl_Proveedor3.SelectedValue.ToString();
            
			for ( int ind = 0; ind < 3; ++ind )
			{
				if (arrSub[ind] < dMenor)
				{
					dMenor = arrSub[ind];
					indSeleccionado = ind;
				}
			}
			return(  arrSel[indSeleccionado] );
		}

		private void btnImprimir_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AnalisisDePreciosRep.aspx");
            //Response.Redirect("Modulos/GENE/Apoyo/ComprasServicios/ReporteCompras.aspx");
		}

	}
}

