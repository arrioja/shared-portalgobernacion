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
	/// 	Creada por - Pedro Arrioja
	/// 	Fecha - 28/03/2004
	/// </remarks>
	public class PaginasBD : object
	{
		
		/// <summary>
		/// Default constructor - initializes all fields to default values
		/// </summary>
		private PaginasBD()
		{
		}
		
		public static int Crear()
		{
			string Sentencia = "SELECT MAX(PagOrden) AS Orden FROM paginas";

			IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int Orden = 1000;

			if(Datos.Read())
				Orden = (int) Datos["Orden"];

			Orden = Orden + 2;

			Datos.Close();

        	Sentencia = "INSERT INTO paginas (PagPadre, PagOrden, PagNombre, GruposAutorizados) ";
        	Sentencia += "VALUES (-1, " + Orden + ", 'Nueva Pagina', 'Todos')";

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "SELECT LAST_INSERT_ID() AS ID";
			Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			int resultado = (Datos.Read()) ? Int32.Parse(Datos["ID"].ToString()) : -1; 
			Datos.Close();
			return resultado;

		}

		public static void Borrar(int PagId)
		{
			string Sentencia = "DELETE FROM paginas WHERE PagID = " + PagId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "DELETE FROM paginas WHERE PagPadre = " + PagId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void ActualizaOrden(int PagId, int PagOrden)
		{
			string Sentencia = "UPDATE paginas SET PagOrden = ";
			Sentencia += (PagOrden == -1) ? "MAX(PagOrden) + 2" : PagOrden.ToString();
			Sentencia += " WHERE PagID = " + PagId;

			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void ActualizaOrden()
		{
			int Contador;
			int Padre;
			int Orden;

			string Sentencia = "SELECT DISTINCT PagPadre FROM paginas ORDER BY PagPadre";

			IDataReader Padres = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			while(Padres.Read())
			{
				Padre = (int) Padres["PagPadre"];

				Contador = 0;

				Sentencia = "SELECT DISTINCT PagOrden FROM paginas WHERE PagPadre = " + Padre;
				Sentencia += " ORDER BY PagOrden";

				IDataReader Paginas = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

				while(Paginas.Read())
				{
					Contador++;

					Orden = (int) Paginas["PagOrden"];

					int NuevoOrden = ((Contador * 2) - 1) * -1;

					Sentencia = "UPDATE paginas SET PagOrden = " + NuevoOrden;
					Sentencia += " WHERE PagPadre = " + Padre;
					Sentencia += " AND PagOrden = " + Orden;

					AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
				}
				Paginas.Close();
			}
			Padres.Close();
			
			Sentencia = "UPDATE paginas SET PagOrden = PagOrden * -1";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			Sentencia = "UPDATE paginas SET PagOrden = 1000 WHERE PagNombre = 'Administración' ";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static void ActualizaOrdenModulos(int PagId)
		{
			int Contador;
			int Orden;
			string Panel;

			string Sentencia = "SELECT DISTINCT NombrePanel FROM modulos ";
			Sentencia += "WHERE PagID = " + PagId + " ORDER BY NombrePanel";

			IDataReader Paneles = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			while(Paneles.Read())
			{
				Panel = Paneles["NombrePanel"].ToString();

				Contador = 0;

				Sentencia = "SELECT DISTINCT ModuloOrden FROM modulos WHERE ";
				Sentencia += "PagID = " + PagId + " AND NombrePanel = '" + Regex.Replace(Panel, "'", "''") + "' ";
				Sentencia += "ORDER BY ModuloOrden";

				IDataReader Modulos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

				while(Modulos.Read())
				{
					Contador++;

					Orden = (int) Modulos["ModuloOrden"];

					int NuevoOrden = ((Contador * 2) - 1) * -1;

					Sentencia = "UPDATE modulos SET ModuloOrden = " + NuevoOrden;
					Sentencia += " WHERE PagID = " + PagId;
					Sentencia += " AND ModuloOrden = " + Orden;
					Sentencia += " AND NombrePanel = '" + Regex.Replace(Panel, "'", "''") + "'";

					AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
				}
				
				Modulos.Close();
				
				Sentencia = "UPDATE modulos SET ModuloOrden = ModuloOrden * -1";
				Sentencia += " WHERE PagID = " + PagId;
				Sentencia += " AND NombrePanel = '" + Regex.Replace(Panel, "'", "''") + "'";
		
				AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
			}
			Paneles.Close();
		}

		public static IDataReader ObtenerHijas(int PagId)
		{
			string Sentencia = "SELECT * FROM paginas WHERE PagPadre = " + PagId;
			Sentencia += " ORDER BY PagOrden";

			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

        public static IDataReader Obtener(int PagId)
        {
        	string Sentencia = "SELECT * FROM paginas WHERE PagID = " + PagId;

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

        public static IDataReader Obtener()
        {
        	string Sentencia = "SELECT * FROM paginas ORDER BY PagOrden";

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }
        
        public static void Actualizar(int pagId, int pagPadre, string Nombre, 
                                      string Autorizados)
        {
        	string Sentencia = "UPDATE paginas SET ";
        	Sentencia += "PagPadre = " + pagPadre + ", ";
        	Sentencia += "PagNombre = '" + Regex.Replace(Nombre, "'", "''") + "', ";
        	Sentencia += "GruposAutorizados = '" + Regex.Replace(Autorizados, "'", "''") + "' ";
        	Sentencia += "WHERE PagID = " + pagId;

        	AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }

	}
}
