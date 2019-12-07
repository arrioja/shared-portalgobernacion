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
	public class UsuariosBD : object
	{
		
		/// <summary>
		/// Default constructor - initializes all fields to default values
		/// </summary>
		private UsuariosBD()
		{
		}
		
        public static IDataReader ObtenerGruposReader(string Usuario)
        {
        	string Sentencia = "SELECT grupos.GrupoID, grupos.Nombre FROM grupos ";
        	Sentencia += "INNER JOIN (usuarios INNER JOIN usuariosgrupos ON usuarios.UsuarioID = usuariosgrupos.UsuarioID) ";
        	Sentencia += "ON grupos.GrupoID = usuariosgrupos.GrupoID ";
        	Sentencia += "WHERE Usuario = '" + Regex.Replace(Usuario, "'", "''") + "'";

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

        public static string[] ObtenerGrupos(string Usuario)
        {
        	IDataReader Datos = UsuariosBD.ObtenerGruposReader(Usuario);

        	ArrayList gruposUsuario = new ArrayList();

        	while(Datos.Read())
        		gruposUsuario.Add(Datos["Nombre"]);

        	Datos.Close();

        	return (string[]) gruposUsuario.ToArray(typeof(string));
        }

        public static int Crear(string Usuario, string Nombre)
        {
        	string Sentencia = "INSERT INTO usuarios (Usuario, Nombre) VALUES ('";
        	Sentencia += Regex.Replace(Usuario, "'", "''") + "', '" + Regex.Replace(Nombre, "'", "''") + "')";

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
			
			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1;
			Datos.Close(); 
			
			return resultado;
        }

        public static void Actualizar(int UsuarioId, string Usuario, string Clave, string Email, string Nombre, string Apellido)
        {
        	string Sentencia = "UPDATE usuarios SET ";
        	Sentencia += "Usuario = '" + Regex.Replace(Usuario, "'", "''") + "', ";
        	Sentencia += "Clave = '" + Regex.Replace(Clave, "'", "''") + "', ";
        	Sentencia += "Email = '" + Regex.Replace(Email, "'", "''") + "', ";
        	Sentencia += "Nombre = '" + Regex.Replace(Nombre, "'", "''") + "', ";
        	Sentencia += "Apellido = '" + Regex.Replace(Apellido, "'", "''") + "' ";
        	Sentencia += "WHERE UsuarioID = " + UsuarioId;

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

        public static void Borrar(int UsuarioId)
        {
        	string Sentencia = "DELETE FROM usuarios WHERE UsuarioID = " + UsuarioId;

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

        public static IDataReader Obtener(string Usuario)
        {
        	string Sentencia = "SELECT * FROM usuarios WHERE Usuario = '";
        	Sentencia += Regex.Replace(Usuario, "'", "''") + "'";

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }
        
        public static IDataReader Obtener()
        {
        	string Sentencia = "SELECT * FROM usuarios ORDER BY Usuario";
        	
        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

        public static string ObtenerNombre(string Usuario)
        {
        	IDataReader Datos = UsuariosBD.Obtener(Usuario);

        	string Nombre = string.Empty;

        	if(Datos.Read())
        	{
        		Nombre += (string) Datos["Nombre"];
        		Nombre += " " + (string) Datos["Apellido"];
        	}
			Datos.Close();
        	return Nombre;
        }	
	}
}
