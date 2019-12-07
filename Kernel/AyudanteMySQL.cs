namespace AyudanteSQL {
	
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Esta clase se encapsula el acceso a datos mediante MySQL.
    /// </summary>
    /// <remarks>
	/// 	Creada por - Pedro Arrioja
	/// 	Fecha - 28/03/2004
	/// </remarks>
    public class AyudanteMySQL {

        /// <summary>
		/// Esta clase provee solo metodos estaticos, por lo tanto el constructor es privado 
		/// para prevenir que sea creado un objeto mediante "new AyudanteMySQL()"
        /// </summary>
        private AyudanteMySQL() 
		{
        }

		/// <summary>
		/// Ejecuta una sentencia que no devuelve datos.
		/// </summary>
		/// <param name="CadenaConexion">
		/// Configuraci�n necesaria para conectarse al servidor MySQL.
		/// </param>
		/// <param name="Sentencia">
		/// Sentecia SQL que ser� ejecutada en el servidor MySQL al 
		/// establecer la conexi�n.
		/// </param>
        public static void Ejecutar(string CadenaConexion, string Sentencia)
        {
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);

            MySqlCommand Comando = new MySqlCommand(Sentencia, Conexion);

            Conexion.Open();

            Comando.ExecuteNonQuery();

            Conexion.Close();
        }

		/// <summary>
		/// Ejecuta una sentencia que devuelve datos en forma de 
		/// MySqlDataReader.
		/// </summary>
		/// <param name="CadenaConexion">
		/// Configuraci�n necesaria para conectarse al servidor MySQL.
		/// </param>
		/// <param name="Sentencia">
		/// Sentecia SQL que ser� ejecutada en el servidor MySQL al 
		/// establecer la conexi�n.
		/// </param>
		/// <returns>
		/// MySqlDataReader con los datos devueltos por la Sentencia.
		/// </returns>
        public static MySqlDataReader EjecutarReader(string CadenaConexion, string Sentencia)
        {
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);

            MySqlCommand Comando = new MySqlCommand(Sentencia, Conexion);

            Conexion.Open();

            return Comando.ExecuteReader(CommandBehavior.CloseConnection);
        }

		/// <summary>
		/// Ejecuta una sentencia que devuelve datos en forma de DataSet.
		/// </summary>
		/// <param name="CadenaConexion">
		/// Configuraci�n necesaria para conectarse al servidor MySQL.
		/// </param>
		/// <param name="Sentencia">
		/// Sentecia SQL que ser� ejecutada en el servidor MySQL al 
		/// establecer la conexi�n.
		/// </param>
		/// <returns>
		/// DataSet que contiene los datos devueltos por la Sentencia
		/// </returns>
        public static DataSet EjecutarDataSet(string CadenaConexion, string Sentencia)
        {
            MySqlConnection Conexion = new MySqlConnection(CadenaConexion);

            MySqlCommand Comando = new MySqlCommand(Sentencia, Conexion);

            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Comando);

            Conexion.Open();

            DataSet Resultado = new DataSet();

            Adaptador.Fill(Resultado);

            Conexion.Close();

            return Resultado;
        }

    }
}
