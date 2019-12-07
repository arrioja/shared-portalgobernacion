using Root.Reports;
using System;
using System.Data;
using System.Drawing;
using System.IO;

namespace Portal.Modulos.GENE.Apoyo
{
	/// <summary>
	/// Descripción breve de RepAnalisisDePrecios.
	/// </summary>
	public class ReporteAnalisisDePrecios : Report
	{
		private FontDef fd;
		private Double rPosIzquierda = 25;
		private Double rPosDerecha = 288;
		private Double rPosSuperior = 10;
		private Double rPosInferior = 195;
		private string rSector;
		private DateTime rDesde;
		private DateTime rHasta;
		private IDataReader rDatos;

		protected override void Create()
		{
			fd = new FontDef(this, "Arial");
			
			FontProp fp = new FontPropMM(fd, 1.9);
			FontProp fp_Encabezado = new FontPropMM(fd, 1.9);
			fp_Encabezado.bBold = true;

			TableLayoutManager tlm = new TableLayoutManager(fp_Encabezado);
						
			tlm.rContainerHeightMM = 50; //rPosInferior - rPosSuperior;
			tlm.headerCellDef.rAlignV = RepObj.rAlignCenter;
			//tlm.cellDef.pp_LineBottom = new PenProp(this, 0.05, Color.LightGray);
			tlm.pp_LineV = null;
			tlm.pp_LineH = null;

			tlm.eNewContainer += new TableLayoutManager.NewContainerEventHandler(Tlm_NewContainer);

			TableLayoutManager.Column col;

			col = new TableLayoutManager.ColumnMM(tlm, "Nro.", 15);
			col = new TableLayoutManager.ColumnMM(tlm, "Fecha", 18);
			col.cellDef.rAlignH = RepObj.rAlignRight;
			col = new TableLayoutManager.ColumnMM(tlm, "Proveedor", 54);
			col.cellDef.textMode = TableLayoutManager.TextMode.MultiLine;
			col = new TableLayoutManager.ColumnMM(tlm, "Partida", 22);
			col.cellDef.textMode = TableLayoutManager.TextMode.MultiLine;
			col = new TableLayoutManager.ColumnMM(tlm, "Unidad Solicitante", 69);
			col.cellDef.textMode = TableLayoutManager.TextMode.MultiLine;
			col = new TableLayoutManager.ColumnMM(tlm, "Observaciones", 69);
			col.cellDef.textMode = TableLayoutManager.TextMode.MultiLine;
			col = new TableLayoutManager.ColumnMM(tlm, "Monto", 23);
			col.cellDef.rAlignH = RepObj.rAlignRight;

			BrushProp bp_Anulada = new BrushProp(this, Color.FromArgb(255, 255, 200));

			//rDatos = ComprasSuministrosBD.ObtenerOrdenesCompras(rSector, rDesde, rHasta);

	   	    rDatos = ApoyoBD.ObtenerAnalisisDePrecios(rSector);
            int nTotal = 0;
			while ( (rDatos.Read()) && (nTotal <=88) )
			//rDatos.Read();
			{
				//tlm.cellDef.bp_Back = ((rDatos["Indi_Anulacion"].ToString() == "1") ? bp_Anulada : null);
				tlm.NewRow();
				tlm.Add(0, new RepString(fp, nTotal.ToString() ));
				tlm.Add(1, new RepString(fp, " " ));
				tlm.Add(2, new RepString(fp, " " ));
				tlm.Add(3, new RepString(fp, " " ));
				//tlm.Add(4, new RepString(fp, " " ));
				//tlm.Add(5, new RepString(fp, " " ));
				//tlm.Add(6, new RepString(fp, rDatos["Monto"].ToString()));
				//tlm.Add(6, new RepString(fp, "Monto" ));
				nTotal += 1;
			}

			rDatos.Close();

			foreach(Page page in enum_Page)
			{
				Double rY = rPosInferior + 1.5;
				page.SetLandscape();
				page.AddLT_MM(rPosIzquierda, rY, new RepString(fp, DateTime.Now.ToShortDateString() +
					" " + DateTime.Now.ToShortTimeString() + " " + nTotal.ToString() ));
				page.AddRT_MM(rPosDerecha, rY, new RepString(fp, page.iPageNo + " / " + iPageCount));
			}
		}

		public void Tlm_NewContainer(Object oSender, TableLayoutManager.NewContainerEventArgs ea)
		{
			new Page(this);

			if(page_Cur.iPageNo == 1)
			{
				FontProp fp_Titulo = new FontPropMM(fd, 7);
				fp_Titulo.bBold = true;
				page_Cur.AddCT_MM(rPosIzquierda + (rPosDerecha - rPosIzquierda) / 2, rPosSuperior,
					new RepString(fp_Titulo, "Hoja de Análisis de Precios"));
				ea.container.rHeightMM -= fp_Titulo.rLineFeedMM;
			}
			page_Cur.AddMM(rPosIzquierda, rPosInferior - ea.container.rHeightMM, ea.container);
		}

		

		public ReporteAnalisisDePrecios(string Sector, DateTime Desde, DateTime Hasta)
		{
			rSector = Sector;
			rDesde = Desde;
			rHasta = Hasta;
		}
	}
}
