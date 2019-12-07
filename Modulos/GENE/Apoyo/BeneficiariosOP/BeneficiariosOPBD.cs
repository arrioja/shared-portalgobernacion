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
	public class BeneficiariosOPBD
	{
		private BeneficiariosOPBD()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static IDataReader ObtenerBeneficiarios()
		{
			string Sentencia = "SELECT * FROM Benef";

			return AyudanteMSSql.EjecutarDataReader(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static IDataReader ObtenerBeneficiarios(string Busqueda)
		{
			string Sentencia = "SELECT * FROM Benef WHERE ";
			Sentencia += "(RIF LIKE '%" + Busqueda + "%') OR ";
			Sentencia += "(Nombre LIKE '%" + Busqueda + "%') ";
			Sentencia += "ORDER BY Nombre";

			return AyudanteMSSql.EjecutarDataReader(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static DataSet ObtenerBeneficiariosOP(string Beneficiario)
		{
			string Sentencia = "SELECT * FROM Orden_Pago WHERE ";
			Sentencia += "((Cod_Benef = '" + Regex.Replace(Beneficiario, "'", "''") + "') ";
			Sentencia += "AND (Indi_anulacion = '0')) ";
			Sentencia += "ORDER BY Nro_Orden DESC";

			return AyudanteMSSql.EjecutarDataSet(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static DataSet ObtenerChequesOP(string Orden)
		{
			string Sentencia = "select c.denom_banc, b.che_cta, a.che_nro, a.monto, b.che_fecha ";
			Sentencia += "from det_op_cheques a, Cheques b, bancos c ";
			Sentencia += "where (a.codigo_orden = '" + Orden + "') and (a.che_nro = b.che_nro) and (b.che_accion = 'CHEQUE EMITIDO') and (b.che_cod_bco = c.cod_banco) ";
			Sentencia += "ORDER BY c.denom_banc, b.che_cta, a.che_nro";
	
			return AyudanteMSSql.EjecutarDataSet(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}
	}
}

