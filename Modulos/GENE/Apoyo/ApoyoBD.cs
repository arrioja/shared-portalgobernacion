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
	public class ApoyoBD
	{
		private ApoyoBD()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static DataSet ObtenerProveedores()
		{
			string Sentencia = "SELECT Nombre FROM Benef WHERE TIPO =  'PR' ORDER BY Nombre";
           
			return AyudanteMSSql.EjecutarDataSet( ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static DataSet BuscarSuministro(string Busqueda)
		{
			string Sentencia = "SELECT * FROM Suministros WHERE ";
			Sentencia += "(Descripcion LIKE '%" + Busqueda + "%') ";
			Sentencia += "ORDER BY Descripcion";

			return AyudanteMSSql.EjecutarDataSet(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static DataSet BuscarAnalisis(string Busqueda)
		{
			string Sentencia = "SELECT *,sum(Cantidad*Precio1) As SubTotal1,";
			Sentencia += " sum(Cantidad*Precio2) As SubTotal2,";
			Sentencia += " sum(Cantidad*Precio3) As SubTotal3";
			Sentencia += " FROM PortalGene.AnalisisDePrecios WHERE"; 
			Sentencia += " Numero = '" + Busqueda + "' ";
			Sentencia += " Group by Numero, Codigo With RollUp";
			Sentencia += " Having Numero is not null";

			return AyudanteMySQL.EjecutarDataSet(ConfigurationSettings.AppSettings["PortalGene"],  Sentencia);
		}

		public static int Crear(string Codigo, string Descripcion, string NumeroId)
		{
			string Sentencia = "INSERT INTO analisisdeprecios (Codigo, Descripcion, Numero) VALUES ('";
			Sentencia += Regex.Replace(Codigo, "'", "''") + "', '" + Regex.Replace(Descripcion, "'", "''") + "', '";
            Sentencia += Regex.Replace(NumeroId, "'", "''") + "')" ;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
			
			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1;
			Datos.Close(); 
			
			return resultado;
		}

		public static void Actualizar(string Codigo, string Descripcion, string Cantidad, string Precio1, string Precio2, string Precio3, string Observaciones, string NumeroId )
		{
			string Sentencia = "UPDATE analisisdeprecios SET ";
            Sentencia += "Descripcion = '" + Regex.Replace(Descripcion, "'", "''") + "', ";
			Sentencia += "Cantidad = '" + Regex.Replace(Cantidad, "'", "''") + "', ";
			Sentencia += "Precio1 = '" + Regex.Replace(Precio1, "'", "''") + "', ";
			Sentencia += "Precio2 = '" + Regex.Replace(Precio2, "'", "''") + "', ";
			Sentencia += "Precio3 = '" + Regex.Replace(Precio3, "'", "''") + "', ";
			Sentencia += "Observaciones = '" + Regex.Replace(Observaciones, "'", "''") + "' ";
			Sentencia += "WHERE (Numero = " + NumeroId + ") and (Codigo = " + Codigo + ")";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
		}

		public static void Eliminar(string Codigo, string NumeroId )
		{
			string Sentencia = "DELETE FROM analisisdeprecios ";
			       Sentencia += "WHERE (Numero = " + NumeroId + ") and (Codigo = " + Codigo + ")";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
		}

		public static IDataReader ObtenerAnalisisDePrecios(string NumeroId )
		{
			string Sentencia = "SELECT * FROM Benef";
                   //Sentencia += "WHERE (Numero = " + NumeroId + ")";       

			return AyudanteMSSql.EjecutarDataReader(ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}
	}
}
