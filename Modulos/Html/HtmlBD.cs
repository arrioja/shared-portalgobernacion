using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using AyudanteSQL;

namespace Portal.Modulos.Html
{
	/// <summary>
	/// Descripci�n breve de HtmlDB.
	/// </summary>
	public class HtmlBD
	{
		private HtmlBD()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public static IDataReader Obtener(int moduloId)
		{
			string Sentencia = "SELECT * FROM htmltexto WHERE ModuloID = " + moduloId;
			
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void Actualizar(int moduloId, string TextoHtml)
		{
			string Sentencia = string.Empty;
			
			IDataReader Datos = HtmlBD.Obtener(moduloId);
						
			if(Datos.Read())
			{
				Sentencia = "UPDATE htmltexto SET ";
				Sentencia += "TextoHtml = '" + Regex.Replace(TextoHtml, "'", "''") + "' ";
				Sentencia += "WHERE ModuloId = " + moduloId;	
			}
			else
			{
				Sentencia = "INSERT INTO htmltexto (ModuloID, TextoHtml) ";
				Sentencia += "VALUES (" + moduloId + ", ";
				Sentencia += "'" + Regex.Replace(TextoHtml, "'", "''") + "')";
			}

			Datos.Close();
			
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
	}
}
