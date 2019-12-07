using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using AyudanteSQL;

namespace Portal.Kernel {
    /// <summary>
    /// Esta clase se encarga de comprobar los permisos de seguridad
    /// que posee un usuario del Portal.
    /// </summary>
    /// <remarks>
	/// 	Creada por - Pedro Arrioja
	/// 	Fecha - 28/03/2004
	/// </remarks>
    public class SeguridadPortal {

        /// <summary>
        /// Se hace que el constructor sea privado para evitar que 
        /// se cree una instancia de la clase.
        /// </summary>
        private SeguridadPortal() {
        }
		
		///<summary>
		/// Verifica si el usuario pertence al grupo especificado.
		/// </summary>
		/// <param name="Grupo">
		/// Grupo al que el usuario debe pertenecer.
		/// </param>
		/// <returns>
		/// Verdadero si el usuario pertenece al grupo y falso en caso
		/// contrario.
		/// </returns>
        public static bool EstaEnGrupo(string Grupo)
        {
        	return HttpContext.Current.User.IsInRole(Grupo);
        }

		///<summary>
		/// Verifica si el usuario pertence al los grupos especificados.
		/// </summary>
		/// <param name="Grupos">
		/// Grupos a los que el usuario debe pertenecer; estos grupos
		/// deben estar separados por un punto y coma (;).
		/// </param>
		/// <returns>
		/// Verdadero si el usuario pertenece a alguno de los grupos y 
		/// falso en caso contrario
		/// </returns>
        public static bool EstaEnGrupos(string Grupos)
        {
        	HttpContext contexto = HttpContext.Current;

        	foreach(string grupo in Grupos.Split(';'))
        		if(grupo != "" && grupo != null && ((grupo == "Todos") || (contexto.User.IsInRole(grupo))))
        			return true;

        	return false;
        }

		/// <summary>
		/// Verifica si el usuario tiene permisos de edici� para el
		/// m�ulo especificado.
		/// </summary>
		/// <param name="moduloId">
		/// Identificaci� del m�ulo al cual el usuario debe tener 
		/// permisos de edici�.
		/// </param>
		/// <returns>
		/// Verdadero si el usuario tiene permisos de edici� para el
		/// m�ulo especificado y falso en caso contrario.
		/// </returns>
        public static bool TienePermisosEdicion(int moduloId)
        {
        	IDataReader Datos = ModulosBD.ObtienePermisos(moduloId);

			bool resultado = (Datos.Read()) ? ((SeguridadPortal.EstaEnGrupos((string) Datos["GruposAutorizados"]))&&(SeguridadPortal.EstaEnGrupos((string) Datos["GruposAutorizadosEdicion"]))) : false;
			Datos.Close();
        	return resultado;
        }

		/// <summary>
		/// Verifica si el usuario y la clave son validos para ingresar
		/// al Portal.
		/// </summary>         
		/// <param name="Usuario">
		/// Usuario que desea ingresar al Portal.
		/// </param>
		/// <param name="Clave">
		/// Clave del usuario
		/// </param>
		/// <returns>
		/// Una cadena vacia si el Usuario no se corresponde con la 
		/// clave o no existe; en caso contrario devuelve el login 
		/// del Usuario. 
		/// </returns>
        public static string Ingresar(string Usuario, string Clave)
        {
        	string Sentencia = "SELECT * FROM usuarios WHERE Usuario = '";
        	Sentencia += Regex.Replace(Usuario, "'", "''") + "' and Clave = '";
        	Sentencia += Regex.Replace(Clave, "'", "''") + "'";

        	IDataReader Datos = AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);

			string resultado = (Datos.Read()) ? (string) Datos["Usuario"] : string.Empty;
			Datos.Close();
        	return resultado;
        }

    }
}
