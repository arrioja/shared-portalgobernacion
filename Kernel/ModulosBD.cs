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
	public class ModulosBD : object
	{
		
		/// <summary>
		/// Default constructor - initializes all fields to default values
		/// </summary>
		private ModulosBD()
		{
		}
		
		public static IDataReader Obtener(int moduloId)
		{
			string Sentencia = "SELECT * FROM modulos WHERE ModuloID = ";
			Sentencia += moduloId;
			
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static int Crear(int PagId, int definicionId, string Nombre, int TiempoCache)
		{
			string Sentencia = "SELECT MAX(ModuloOrden) AS Orden FROM modulos WHERE ";
			Sentencia += "PagID = " + PagId + " AND NombrePanel = 'Centro'";

			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int Orden = 1;

			if(Datos.Read())
				Orden = (Datos["Orden"] == DBNull.Value) ? 1 : ((int) Datos["Orden"]) + 2 ;

			Datos.Close();

        	Sentencia = "INSERT INTO modulos (PagID, ModuloDefID, ModuloOrden, NombrePanel, ModuloTitulo, GruposAutorizados, GruposAutorizadosEdicion, TiempoCache) ";
        	Sentencia += "VALUES (" + PagId + ", " + definicionId + ", " + Orden + ", 'Centro', ";
			Sentencia += "'" + Regex.Replace(Nombre, "'", "''") + "', 'Todos', 'Administradores', " + TiempoCache + ")";

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1; 
			Datos.Close();
			return resultado;
		}
		
		public static void Actualizar(int moduloId, string Titulo, string Autorizados, string Edicion, int TiempoCache)
		{
			string Sentencia = "UPDATE modulos SET ";
        	Sentencia += "ModuloTitulo = '" + Regex.Replace(Titulo, "'", "''") + "', ";
        	Sentencia += "GruposAutorizados = '" + Regex.Replace(Autorizados, "'", "''") + "', ";
        	Sentencia += "GruposAutorizadosEdicion = '" + Regex.Replace(Edicion, "'", "''") + "', ";
			Sentencia += "TiempoCache = " + TiempoCache + " ";
        	Sentencia += "WHERE ModuloID = " + moduloId;

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);	
		}
		
		public static void Borrar(int ModuloId)
		{
			string Sentencia = "DELETE FROM modulos WHERE ModuloID = " + ModuloId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static void ActualizaOrden(int ModuloId, int Orden, string Panel)
		{
			string Sentencia = "SELECT PagID FROM modulos WHERE ModuloID = " + ModuloId;
			
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int PagId = 0;
			
			if(Datos.Read())
				PagId = (int) Datos["PagID"];
			
			Datos.Close();
			
			Sentencia = "SELECT MAX(ModuloOrden) AS ModuloOrden ";
			Sentencia += "FROM modulos WHERE  PagID = " + PagId;
			
			Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
			
			if(Datos.Read())
				Orden = (Orden != -1) ? Orden : ((int) Datos["ModuloOrden"]) + 2;
			
			Datos.Close();
			
			Sentencia = "UPDATE modulos SET ModuloOrden = " + Orden;
			Sentencia += ", NombrePanel = '" + Regex.Replace(Panel, "'", "''") + "'";
			Sentencia += " WHERE PagID = " + PagId;
			Sentencia += " AND ModuloID = " + ModuloId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static IDataReader ObtenerPagina(int PagId)
        {
        	string Sentencia = "SELECT modulos.*, modulosdefinicion.Ubicacion, modulosdefinicion.UbicacionEdicion ";
        	Sentencia += "FROM modulos INNER JOIN modulosdefinicion ON modulos.ModuloDefID = modulosdefinicion.ModuloDefID ";
        	Sentencia += "WHERE PagID = " + PagId + " ORDER BY ModuloOrden";

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

        public static IDataReader ObtienePermisos(int moduloId)
        {
        	string Sentencia = "SELECT modulos.GruposAutorizados, modulos.GruposAutorizadosEdicion ";
        	Sentencia += "FROM modulos INNER JOIN paginas ON modulos.PagID = paginas.PagID ";
        	Sentencia += "WHERE ModuloID = " + moduloId;

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }
        
        public static IDataReader ObtenerDefiniciones()
		{
			string Sentencia = "SELECT * FROM modulosdefinicion WHERE Sistema = 0 ORDER BY Nombre";

			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static IDataReader ObtenerDefiniciones(int definicionId)
		{
			string Sentencia = "SELECT * FROM modulosdefinicion WHERE ";
			Sentencia += "ModuloDefID = " + definicionId;

			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static int CrearDefinicion(string Nombre, string Ubicacion, string UbicacionEdicion)
		{
			string Sentencia = "INSERT INTO modulosdefinicion (Nombre, Ubicacion, UbicacionEdicion) VALUES (";
			Sentencia += "'" + Regex.Replace(Nombre, "'", "''") + "', ";
			Sentencia += "'" + Regex.Replace(Ubicacion, "'", "''") + "', ";
			Sentencia += "'" + Regex.Replace(UbicacionEdicion, "'", "''") + "')";

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1;
			Datos.Close();
			return 	resultado;

		}
		
		public static void ActualizarDefinicion(int definicionId, string Nombre, string Ubicacion, string UbicacionEdicion)
		{
			string Sentencia = "UPDATE modulosDefinicion SET ";
        	Sentencia += "Nombre = '" + Regex.Replace(Nombre, "'", "''") + "', ";
			Sentencia += "Ubicacion = '" + Regex.Replace(Ubicacion, "'", "''") + "', ";
			Sentencia += "UbicacionEdicion = '" + Regex.Replace(UbicacionEdicion, "'", "''") + "' ";
        	Sentencia += "WHERE ModuloDefID = " + definicionId;

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static void BorrarDefinicion(int definicionId)
		{
			string Sentencia = "DELETE FROM modulosdefinicion WHERE ModuloDefID = " + definicionId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);	
		}
        
        public static Hashtable ObtenerConfig(int ModuloId)
        {
        	Hashtable config = new Hashtable();

        	string Sentencia = "SELECT * FROM modulosconfig WHERE ModuloID = " + ModuloId;

        	IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

        	while(Datos.Read())
        		config[(string) Datos["Configuracion"]] = (string) Datos["Valor"];

        	Datos.Close();

        	return config;
        }

        public static void ActualizaConfig(int ModuloId, string Configuracion, string Valor)
        {
        	string Sentencia = "SELECT * FROM modulosconfig WHERE ModuloID = " + ModuloId;

        	Sentencia += " AND Configuracion = '" + Regex.Replace(Configuracion, "'", "''") + "'";

        	IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

        	if(Datos.Read())
        	{
        		Sentencia = "UPDATE modulosconfig SET Valor = '" + Valor + "'";
        		Sentencia += " WHERE ModuloID = " + ModuloId + " AND Configuracion = '" + Regex.Replace(Configuracion, "'", "''") + "'";

        		AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        	}
        	else
        	{
        		Sentencia = "INSERT INTO modulosconfig (ModuloID, Configuracion, Valor) VALUES (";
        		Sentencia += ModuloId + ", '" + Regex.Replace(Configuracion, "'", "''") + "', '" + Regex.Replace(Valor, "'", "''") + "')";

        		AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        	}
        	
        	Datos.Close();
        }
	}
}
