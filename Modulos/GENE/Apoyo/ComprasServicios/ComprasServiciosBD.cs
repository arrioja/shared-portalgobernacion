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
	public class ComprasSuministrosBD
	{
		private ComprasSuministrosBD()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static IDataReader ObtenerOrdenesCompras(string Sector, DateTime Desde, DateTime Hasta)
		{
			string Sentencia = "SELECT DISTINCT a.Nro_Comp, a.Fecha_Orden, a.Direccion,";
			Sentencia += " d.Rif, d.Nombre, b.Monto, left(c.Nro_det, 10) as Codigo, cast(b.Obs as varchar(200)) as Observacion, a.Indi_Anulacion";
			Sentencia += " FROM Orden_Compra a, Comprom b, Det_Comp c, Benef d";
			Sentencia += " WHERE (a.Nro_Comp = b.Nro_Comp) and (b.Tipo = 'OC') and";
			Sentencia += " (b.Cod_Benef = d.Cod_Benef) and (b.Nro_Refer = c.Nro_Refer) and";
			Sentencia += " (left(c.Nro_det,2) = ";
			Sentencia += Sector + ") and (a.Fecha_Orden >= '" + Desde.ToShortDateString();
			Sentencia += "')";

			return AyudanteMSSql.EjecutarDataReader(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static IDataReader ObtenerOrdenesServicios(string Sector, DateTime Desde, DateTime Hasta)
		{
			string Sentencia = "SELECT * FROM Benef";

			return AyudanteMSSql.EjecutarDataReader(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}
	}
}
