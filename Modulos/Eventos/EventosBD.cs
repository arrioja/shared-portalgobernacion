using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using AyudanteSQL;

namespace PortalGobernacion.Modulos.Eventos
{
	/// <summary>
	/// Descripci�n breve de EventosDB.
	/// </summary>
	public class EventosBD
	{
		private EventosBD()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public static IDataReader ObtenerEventos(int moduloId)
		{
			string Sentencia = "SELECT * FROM eventos WHERE (ModuloID = " + moduloId + ")";
			Sentencia += " AND (Fecha_Vencimiento >= CURDATE())";
			Sentencia += " ORDER BY Fecha DESC, Titulo ASC";
			
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static IDataReader ObtenerUnEvento(int eventoId)
		{
			string Sentencia = "SELECT * FROM eventos WHERE EventoId = " + eventoId;
			
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void CrearEvento(int moduloId, string Titulo, string Descripcion, string Fecha, string Lugar, string Vencimiento)
		{
			string Sentencia = "INSERT INTO eventos (ModuloId, Titulo, Descripcion, Fecha, Lugar, Fecha_Vencimiento) VALUES ";
			Sentencia += "(" + moduloId + ", ";
			Sentencia += "'" + Regex.Replace(Titulo, "'", "''") + "', ";
			Sentencia += "'" + Regex.Replace(Descripcion, "'", "''") + "', ";
			Sentencia += "'" + Regex.Replace(Fecha, "'", "''") + "', ";
			Sentencia += "'" + Regex.Replace(Lugar, "'", "''") + "', ";
			Sentencia += "'" + Regex.Replace(Vencimiento, "'", "''") + "')";

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void ActualizarEvento(int eventoId, string Titulo, string Descripcion, string Fecha, string Lugar, string Vencimiento)
		{
			string Sentencia = "UPDATE eventos SET ";
			Sentencia += "Titulo = '" + Regex.Replace(Titulo, "'", "''") + "', ";
			Sentencia += "Descripcion = '" + Regex.Replace(Descripcion, "'", "''") + "', ";
			Sentencia += "Fecha = '" + Regex.Replace(Fecha, "'", "''") + "', ";
			Sentencia += "Lugar = '" + Regex.Replace(Lugar, "'", "''") + "', ";
			Sentencia += "Fecha_Vencimiento = '" + Regex.Replace(Vencimiento, "'", "''") + "' ";
			Sentencia += "WHERE EventoId = " + eventoId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void BorrarEvento(int eventoId)
		{
			string Sentencia = "DELETE FROM eventos WHERE EventoId = " + eventoId;
			
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
	}
}
