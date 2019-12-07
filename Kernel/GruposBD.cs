using System;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using AyudanteSQL;

namespace Portal.Kernel
{
	/// <summary>
	/// TODO - Add class summary
	/// </summary>
	/// <remarks>
	/// 	created by - Pedro Arrioja
	/// 	created on - 28/03/2004 10:42:05 a.m.
	/// </remarks>
	public class GruposBD : object
	{
		
		/// <summary>
		/// Default constructor - initializes all fields to default values
		/// </summary>
		private GruposBD()
		{
		}
		
		public static int Crear()
		{
			string Sentencia = "INSERT INTO grupos (Nombre) VALUES ('(Nuevo Grupo)')";

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1;
			Datos.Close(); 
			return 	resultado;
		}
		
		public static void Actualizar(int grupoId, string Nombre)
		{
			string Sentencia = "UPDATE grupos SET ";
        	Sentencia += "Nombre = '" + Regex.Replace(Nombre, "'", "''") + "' ";
        	Sentencia += "WHERE GrupoId = " + grupoId;

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
	
		}
		
		public static void Borrar(int grupoId)
		{
			string Sentencia = "DELETE FROM grupos WHERE GrupoId = " + grupoId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);	
		}
		
        public static IDataReader Obtener()
        {
        	string Sentencia = "SELECT * FROM grupos ORDER BY Nombre";

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }
        
        public static IDataReader ObtenerUsuarios(int grupoId)
        {
        	string Sentencia = "SELECT usuarios.* ";
        	Sentencia += "FROM usuarios INNER JOIN usuariosgrupos ON usuarios.UsuarioID = usuariosgrupos.UsuarioID ";
        	Sentencia += "WHERE usuariosgrupos.GrupoID = " + grupoId;
        	
        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }
        
        public static void CrearUsuario(int grupoId, int usuarioId)
        {
        	string Sentencia = "INSERT INTO usuariosgrupos (GrupoID, UsuarioID) ";
        	Sentencia += "VALUES (" + grupoId + ", " + usuarioId + ")";
			
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);	
        }
        
        public static void BorrarUsuario(int grupoId, int usuarioId)
        {
 			string Sentencia = "DELETE FROM usuariosgrupos WHERE ";
        	Sentencia += "GrupoID = " + grupoId + " AND UsuarioID = " + usuarioId;
			
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);	
        }
	}
}
