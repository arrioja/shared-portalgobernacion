using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using AyudanteSQL;


namespace PortalGobernacion.Modulos.GENE.Apoyo
{
	/// <summary>
	/// Descripci�n breve de RecaudacionBD.
	/// </summary>
	public class RecaudacionBD
	{
		public RecaudacionBD()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public static DataSet BuscarDepBancos(string Fecha, string Cta )
		{
			string Sentencia = "SELECT * FROM PortalGene.DepositoBanco ";
			       Sentencia +="WHERE (Fecha = '" + Fecha + "') and (NumeroCta = '" + Cta +"' ) ";
			       Sentencia +="ORDER BY NumeroCta,NumeroDep";

			return AyudanteMySQL.EjecutarDataSet(ConfigurationSettings.AppSettings["PortalGene"],  Sentencia);
		}

		public static DataSet BuscarDepFisicos(string Fecha )
		{
			string Sentencia = "SELECT * FROM PortalGene.DepositoFisico ";
			Sentencia +="WHERE (Fecha = '" + Fecha + "') ";
			Sentencia +="ORDER BY NumeroDep";

			return AyudanteMySQL.EjecutarDataSet(ConfigurationSettings.AppSettings["PortalGene"],  Sentencia);
		}

		public static int CrearBanco(string NumeroDep, string Fecha, string NumeroCta, string Monto)
		{
			string Sentencia = "INSERT INTO DepositoBanco (NumeroDep, Fecha, NumeroCta, Monto ) VALUES ('";
			Sentencia += Regex.Replace(NumeroDep, "'", "''") + "', '" + Regex.Replace(Fecha, "'", "''") + "', '";
			Sentencia += Regex.Replace(NumeroCta, "'", "''") + "', '" + Regex.Replace(Monto,"'", "''") + "')" ;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
			
			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1;
			Datos.Close(); 
			
			return resultado;
		}

		public static void ActualizarBanco(string NumeroDep, string Fecha, string NumeroCta, string Monto)
		{
			string Sentencia = "UPDATE DepositoBanco SET ";
			Sentencia += "Fecha = '" + Regex.Replace(Fecha, "'", "''") + "', ";
			Sentencia += "NumeroCta = '" + Regex.Replace(NumeroCta, "'", "''") + "', ";
			Sentencia += "monto = '" + Regex.Replace(Monto, "'", "''") + "' ";
			Sentencia += "WHERE (NumeroDep = " + NumeroDep + ")";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
		}

		public static int CrearFisico(string NumeroDep, string Fecha, string FormaDePago, string NumeroPla, string NumeroPar )
		{
			string Sentencia = "INSERT INTO DepositoFisico (NumeroDep, Fecha, FormaDePago, NumeroPla, NumeroPar ) VALUES ('";
			Sentencia += Regex.Replace(NumeroDep, "'", "''") + "', '" + Regex.Replace(Fecha, "'", "''") + "', '";
			Sentencia += Regex.Replace(FormaDePago, "'", "''") + "', '" + Regex.Replace(NumeroPla,"'", "''") + "', '" ;
	        Sentencia += Regex.Replace(NumeroPar, "'", "''") + "')" ;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
			
			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1;
			Datos.Close(); 
			
			return resultado;
		}

		public static void ActualizarFisico(string NumeroDep, string Fecha, string FormaDePago, string NumeroPla, string NumeroCta )
		{
			string Sentencia = "UPDATE DepositoFisico SET ";
			Sentencia += "Fecha = '" + Regex.Replace(Fecha, "'", "''") + "', ";
			Sentencia += "FormaDePago = '" + Regex.Replace(FormaDePago, "'", "''") + "', ";
			Sentencia += "NumeroPla = '" + Regex.Replace(NumeroPla, "'", "''") + "', ";
			Sentencia += "NumeroPar = '" + Regex.Replace(NumeroCta, "'", "''") + "' ";
			Sentencia += "WHERE (NumeroDep = " + NumeroDep + ")";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
		}

		public static void EliminarBanco(string NumeroDep )
		{
			string Sentencia = "DELETE FROM DepositoBanco";
			Sentencia += " WHERE (NumeroDep = " + NumeroDep + ")";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
		}

		public static void EliminarFisico(string NumeroDep )
		{
			string Sentencia = "DELETE FROM DepositoFisico";
			Sentencia += " WHERE (NumeroDep = " + NumeroDep + ")";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], Sentencia);
		}

		public static DataSet ObtenerCuentas()
		{
			string Sentencia = "SELECT bcocta_numero FROM Bancos_Ctas WHERE bcocta_tipo =  '3' ORDER BY bcocta_numero";
           
			return AyudanteMSSql.EjecutarDataSet( ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}

		public static DataSet ObtenerPartidas()
		{
			string Sentencia = "SELECT cod_ing, descripcion FROM Ingresos ORDER BY descripcion";
           
			return AyudanteMSSql.EjecutarDataSet( ConfigurationSettings.AppSettings["ConexionApoyo"], System.Data.CommandType.Text, Sentencia);
		}
	}
}
