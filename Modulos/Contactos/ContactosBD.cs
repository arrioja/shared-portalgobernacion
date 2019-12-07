using System;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using AyudanteSQL;
using MySql.Data.Types;

namespace Portal.Kernel
{
	/// <summary>
	/// Descripción breve de ContactosBD.
	/// </summary>
	public class ContactosBD
	{
		public ContactosBD()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static IDataReader ObtenerContactos(int moduloid) //Para llenar la lista
		{
			string Sentencia = "SELECT ContactoID,ModuloID,Nombre,Cargo,Email,Contacto1,Contacto2 FROM Contactos WHERE ModuloID = " + moduloid +" ORDER BY Nombre";
        	
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static IDataReader ObtenerUnContacto(int Cid) //Para obtener el contacto a editar (si se hace click sobre el nombre)
		{
			string Sentencia = "SELECT ContactoID, Nombre, Cargo, Email, Contacto1, Contacto2 FROM Contactos Where ContactoID = "+Cid;
        	
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static IDataReader BorrarContacto(int Cid) //Para Borrar un contacto dado su ContactId
		{
			string Sentencia = "DELETE FROM Contactos WHERE ContactoID = "+Cid;
        	
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void IncluirContacto(int moduloid, string nombre, string cargo, string email, string contacto1, string contacto2) //Para Incluir un contacto en el modulo indicado
		{
			string Sentencia = "INSERT INTO contactos (ModuloID,Nombre,Cargo,Email,Contacto1,Contacto2) ";
			Sentencia +="VALUES ('"+moduloid+"','"+nombre+"','"+cargo+"','"+email+"','"+contacto1+"','"+contacto2+"')";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void ActualizarContacto(int coid, string nombre, string cargo, string email, string contacto1, string contacto2) //Para Incluir un contacto en el modulo indicado
		{
			string Sentencia =  "UPDATE contactos SET Nombre='"+nombre+"',Cargo='"+cargo +"',Email='"+email+"',Contacto1='"+contacto1+"',Contacto2='"+contacto2+"' WHERE (ContactoID = '"+ coid +"')";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}



		
	}
}
