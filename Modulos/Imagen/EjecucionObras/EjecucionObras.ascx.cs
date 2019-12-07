namespace PortalGobernacion.Modulos.GENE.Apoyo
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Portal.Modulos.GENE.Apoyo;

	/// <summary>
	///		Descripci�n breve de EjecucionObras.
	/// </summary>
	public class EjecucionObras : Portal.Kernel.ControlModuloPortal
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid Datos;
		protected System.Web.UI.WebControls.TextBox Fecha;
		protected System.Web.UI.WebControls.Button botonActualizar;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
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
			this.botonActualizar.Click += new System.EventHandler(this.botonActualizar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void botonActualizar_Click(object sender, System.EventArgs e)
		{
			DataSet Ejecucion = EjecucionObrasBD.EjecucionObras("2005", Fecha.Text); 

			DataColumn Columna;
			 
			Columna = new DataColumn();
			Columna.DataType = Ejecucion.Tables[0].Columns["Asignado"].DataType;
			Columna.ColumnName = "Acordado";
			Columna.AutoIncrement = false;
			Columna.Caption = "Acordado";
			Ejecucion.Tables[0].Columns.Add(Columna);

			Columna = new DataColumn();
			Columna.DataType = Ejecucion.Tables[0].Columns["Asignado"].DataType;
			Columna.ColumnName = "Disponible";
			Columna.AutoIncrement = false;
			Columna.Caption = "Disponible";
			Ejecucion.Tables[0].Columns.Add(Columna);

			Columna = new DataColumn();
			Columna.DataType = Ejecucion.Tables[0].Columns["Asignado"].DataType;
			Columna.ColumnName = "Deuda";
			Columna.AutoIncrement = false;
			Columna.Caption = "Deuda";
			Ejecucion.Tables[0].Columns.Add(Columna);

			string Partida = Ejecucion.Tables[0].Rows[0]["Nro_Det"].ToString();
			
			foreach(DataRow Registro in Ejecucion.Tables[0].Rows)
			{
				Registro.BeginEdit();

				string Modificado = Registro["Modificado"].ToString();
				if((Modificado == null) || (Modificado == ""))
					Registro["Modificado"] = 0;

				string Reintegro = Registro["Reintegro"].ToString();
				if((Reintegro == null) || (Reintegro == ""))
					Registro["Reintegro"] = 0;

				string Comprometido = Registro["Comprometido"].ToString();
				if((Comprometido == null) || (Comprometido == ""))
					Registro["Comprometido"] = 0;

				string Causado = Registro["Causado"].ToString();
				if((Causado == null) || (Causado == ""))
					Registro["Causado"] = 0;

				string Pagado = Registro["Pagado"].ToString();
				if((Pagado == null) || (Pagado == ""))
					Registro["Pagado"] = 0;

				Registro["Acordado"] = Convert.ToDouble(Registro["Asignado"]) + Convert.ToDouble(Registro["Modificado"]);

				Registro["Disponible"] = (Convert.ToDouble(Registro["Asignado"]) + Convert.ToDouble(Registro["Modificado"])) - Convert.ToDouble(Registro["Comprometido"]) + Convert.ToDouble(Registro["Reintegro"]);

				Registro["Deuda"] = Convert.ToDouble(Registro["Causado"]) - Convert.ToDouble(Registro["Pagado"]);

				Registro.AcceptChanges();
			}

			Datos.DataSource = Ejecucion;
			Datos.DataBind();
		}
	}
}
