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
    /// Summary description for SistemaBD.
    /// </summary>
    public class SistemaBD {

        /// <summary>
        /// Creates a new instance of SistemaBD
        /// </summary>
        private SistemaBD() {
        }

		
        //----------------------------------------------------------------------
        // Usuario

        //---------------------------------------------------------------------
        // Grupos
        public static IDataReader ObtenerGrupos()
        {
        	string Sentencia = "select * from grupos";

        	return AyudanteMySQL.EjecutarReader(ConfigurationSettings.AppSettings["CadenaConexion"], Sentencia);
        }
    }
}
