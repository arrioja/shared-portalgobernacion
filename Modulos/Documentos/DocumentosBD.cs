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
	public class DocumentosBD
	{
		public DocumentosBD()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static IDataReader ObtenerDocumentos(int moduloid) //Para llenar la lista
		{
			string Sentencia = "SELECT Fecha,Descripcion, Formato,DocumentoId,Link,Titulo FROM Documentos WHERE ModuloID = " + moduloid +" ORDER BY DocumentoId";
        	
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}
		
		public static IDataReader ObtenerUnDocumento(int DocId) //Para obtener el Documento a editar (si se hace click sobre el nombre)
		{
			string Sentencia = "SELECT Fecha,Descripcion, Formato,DocumentoId,Link, Titulo FROM Documentos Where DocumentoId = "+DocId;
        	
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static IDataReader BorrarDocumento(int DocId) //Para Borrar un documento dado su DocId
		{
			string Sentencia = "DELETE FROM Documentos WHERE DocumentoId = "+DocId;
        	
			return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void IncluirDocumento(int moduloid, string Fecha, string Descripcion, string Formato, string Link, string Titulo) //falta fecha... Para Incluir un documento en el modulo indicado
		{
			string Sentencia = "INSERT INTO documentos (ModuloID,Fecha,Descripcion,Formato,Link,Titulo) ";
			Sentencia +="VALUES ("+moduloid+",'"+Fecha+"','"+Descripcion+"','"+Formato+"','"+Link+"','"+Titulo+"')";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}

		public static void ActualizarDocumento(int DocId, string Fecha, string Descripcion, string Formato, string Link, string Titulo) //Para Incluir un Documento en el modulo indicado
		{
			string Sentencia =  "UPDATE documentos SET Fecha='"+Fecha+"',Descripcion='"+Descripcion +"',Formato='"+Formato+"',Link='"+Link+"',Titulo='"+Titulo+"' WHERE (DocumentoId = '"+ DocId +"')";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
		}



		
	}
}
