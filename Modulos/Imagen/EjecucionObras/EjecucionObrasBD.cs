using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using AyudanteSQL;

namespace Portal.Modulos.GENE.Apoyo
{
	/// <summary>
	/// Descripción breve de ApoyoBD.
	/// </summary>
	public class EjecucionObrasBD
	{
		private EjecucionObrasBD()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static DataSet EjecucionObras(string Presupuesto, string Fecha)
		{
			string Sentencia = "select Obras_E.NRO_DET, Obras_E.COD_OBRA, Obras_E.DENOM, Obras_E.mont_ppt as Asignado, ";
			Sentencia += "(Select sum(Det_Modif.Monto) from Det_Modif where ";
			Sentencia += "(Obras_E.NRO_DET = Det_Modif.NRO_DET) and (Obras_E.COD_OBRA = Det_Modif.OBRA) and (Det_Modif.ANO_PPTO = Obras_E.ANO_PPTO) and (Det_Modif.Tipo_aux <> 'RI') and (Det_Modif.Indi_Anulacion = '0') and (Det_Modif.Fecha_aux <= '" + Regex.Replace(Fecha, "'", "''") + "')) as Modificado,";
			Sentencia += "(Select sum(Det_Modif.Monto) from Det_Modif where ";
			Sentencia += "(Obras_E.NRO_DET = Det_Modif.NRO_DET) and (Obras_E.COD_OBRA = Det_Modif.OBRA) and (Det_Modif.ANO_PPTO = Obras_E.ANO_PPTO) and (Det_Modif.Tipo_aux = 'RI') and (Det_Modif.Indi_Anulacion = '0') and (Det_Modif.Fecha_aux <= '" + Regex.Replace(Fecha, "'", "''") + "')) as Reintegro,";
			Sentencia += "(Select sum(Det_Comp.Monto_Comp) from Det_Comp where ";
			Sentencia += "(Obras_E.NRO_DET = Det_Comp.NRO_DET) and (Obras_E.COD_OBRA = Det_Comp.COD_OBRA) and (Det_Comp.ANO_PPTO = Obras_E.ANO_PPTO) and (Det_Comp.Indi_Anulacion = '0') and (Det_Comp.Fecha_aux <= '" + Regex.Replace(Fecha, "'", "''") + "')) as Comprometido,";
			Sentencia += "(Select sum(Det_Caus.Monto) from Det_Caus where ";
			Sentencia += "(Obras_E.NRO_DET = Det_Caus.NRO_DET) and (Obras_E.COD_OBRA = Det_Caus.COD_OBRA) and (Det_Caus.ANO_PPTO = Obras_E.ANO_PPTO) and (Det_Caus.Indi_Anulacion = '0') and (Det_Caus.Fecha_aux <= '" + Regex.Replace(Fecha, "'", "''") + "')) as Causado,";
			Sentencia += "(Select sum(Det_Pago.Monto_Pord) from Det_Pago where ";
			Sentencia += "(Obras_E.NRO_DET = Det_Pago.NRO_DET) and (Obras_E.COD_OBRA = Det_Pago.COD_OBRA) and (Det_Pago.ANO_PPTO = Obras_E.ANO_PPTO) and (Det_Pago.Indi_Anulacion = '0') and (Det_Pago.Fecha_aux <= '" + Regex.Replace(Fecha, "'", "''") + "')) as Pagado ";
			Sentencia += "from Obras_E ";
			Sentencia += "where (Obras_E.ANO_PPTO = '" + Regex.Replace(Presupuesto, "'", "''") + "') ";
			Sentencia += "group by Obras_E.NRO_DET, Obras_E.COD_OBRA, Obras_E.DENOM with rollup ";
			Sentencia += "order by Obras_E.NRO_DET, Obras_E.COD_OBRA ";
			

			return AyudanteMSSql.EjecutarDataSet(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}
	}
}
