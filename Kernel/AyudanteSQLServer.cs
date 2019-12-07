using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace AyudanteSQL
{
	/// <summary>
	/// Esta clase se encapsula el acceso a datos mediante MSSQL.
	/// </summary>
	/// <remarks>
	/// 	Creada por - Pedro Arrioja
	/// 	Fecha - 28/03/2004
	/// </remarks>
	public sealed class AyudanteMSSql
	{
		/// <summary>
		/// Esta clase provee solo metodos estaticos, por lo tanto el constructor es privado 
		/// para prevenir que sea creado un objeto mediante "new AyudanteMSSql()"
		/// </summary>
		private AyudanteMSSql()
		{
		}

		
		/// <summary>
		/// Este metodo es usado para asignar un arreglo de SqlParameters a un SqlCommand.
		/// 
		/// Se asign el valor DbNull a cualquier parametro con una direccion de
		/// InputOuput y un valor de null.
		/// 
		/// </summary>
		/// <param name="comando">El comando al cual se le asignaran los parametros</param>
		/// <param name="Parametros">Un arreglo de SqlParameters para asignarlos al comando</param>
		private static void AsignarParametros(SqlCommand comando, SqlParameter[] Parametros)
		{
			foreach (SqlParameter p in Parametros)
			{
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
					p.Value = DBNull.Value;
				
				comando.Parameters.Add(p);
			}
		}

		
		/// <summary>
		/// Este metodo asigna un arreglo de valores a un arreglo de SqlParameters.
		/// </summary>
		/// <param name="Parametros">Arreglo de SqlParameters a los que se les asignaran los valores</param>
		/// <param name="Valores">Arreglo de objetos que contiene los valores que seran asignados</param>
		private static void AsignarValoresParametros(SqlParameter[] Parametros, object[] Valores)
		{
			// si falta algun dato no hacer nada
			if ((Parametros == null) || (Valores == null)) 
				return;

			// debemos contar con el mismo numero de parametros que de valores
			if (Parametros.Length != Valores.Length)
				throw new ArgumentException("El n�mero de Parametros no concuerda con el n�mero de Valores.");

			// recorrer los SqlParameters, asignandoles los valores correspondientes
			for (int i = 0, j = Parametros.Length; i < j; i++)
				Parametros[i].Value = Valores[i];
		}


		/// <summary>
		/// Este metodo abre (si es necesario) y asigna una conexion, transaccion, tipo de comando y parametros
		/// a un comando.
		/// </summary>
		/// <param name="Comando">El SqlCommand a ser preparado</param>
		/// <param name="Conexion">Una SqlConnection valida, el la cual se ejecutar el comando</param>
		/// <param name="Transaccion">Una SqlTransaction valida, o 'null'</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		private static void PreparaComando(SqlCommand Comando, SqlConnection Conexion, SqlTransaction Transaccion, CommandType Tipo, string Sentencia, SqlParameter[] Parametros)
		{
			// si la conexion no esta abierta, se procede a abrirla
			if (Conexion.State != ConnectionState.Open)
				Conexion.Open();

			// asociar la conexion con el comando
			Comando.Connection = Conexion;

			// fijar el texto del comando (nombre del procedimiento almacenado o sentencia SQL)
			Comando.CommandText = Sentencia;

			// si se tiene una transaccion, asignarla
			if (Transaccion != null)
				Comando.Transaction = Transaccion;

			// establecer el tipo del comando
			Comando.CommandType = Tipo;

			// si existen parametros asignarlos al comando
			if (Parametros != null)
				AsignarParametros(Comando, Parametros);

			return;
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que no regresa un conjunto de resultados) en la base de datos especificada en la cadena de conexion
		/// utilizando los parametros especificados.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>Un entero que representa el numero de registros afectados por el comando</returns>
		public static int Ejecutar(string cadenaConexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crear y abrir una SqlConnection, y desecharla despues de usarla.
			using (SqlConnection cn = new SqlConnection(cadenaConexion))
			{
				cn.Open();

				// llamar al metodo sobrecargado que utiliza una conexion en lugar de una cadena de conexion
				return Ejecutar(cn, Tipo, Sentencia, Parametros);
			}
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que no regresa un conjunto de resultados)  utilizando la conexion y
		/// los parametros especificados.
		/// </summary>
		/// <param name="Conexion">Una SqlConnection valida, el la cual se ejecutar el comando</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>Un entero que representa el numero de registros afectados por el comando</returns>
		public static int Ejecutar(SqlConnection Conexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crea un comando y lo prepara para su ejecucion
			SqlCommand cmd = new SqlCommand();
			PreparaComando(cmd, Conexion, (SqlTransaction)null, Tipo, Sentencia, Parametros);
			
			// ejecutar el comando
			int valorRetorno = cmd.ExecuteNonQuery();
			
			// eliminar los SqlParameters del objeto de comando
			cmd.Parameters.Clear();
			
			return valorRetorno;
		}

		/// <summary>
		/// Ejecuta un procedimiento almacenado por medio de un SqlCommand (que no regresa un conjunto de resultados) en la base de datos especificada 
		/// en la cadena de conexion utilizando los valores de parametros especificados.
		/// 
		/// Este metodo consulta la base de datos para descubrir los parametros del procedimiento almacenado (la primera vez que el procedimiento es llamado),
		/// y asigna los valores basandose en el orden de los parametros.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// <param name="Valores">Un arreglos de objetos para ser asignados como valores de entrada a el procedimiento almacenado</param>
		/// <returns>Un entero que representa el numero de registros afectados por el comando</returns>
		public static int Ejecutar(string cadenaConexion, string spNombre, params object[] Valores)
		{
			// Si se reciben valores, debemos crear los parametros
			if ((Valores != null) && (Valores.Length > 0)) 
			{
				// buscar los parametros para este procedimiento almacenado en el cache de parametros (o descubrilos y colocarlos en el cache)
				SqlParameter[] Parametros = CacheParametros.ObtenerParametrosSp(cadenaConexion, spNombre);

				// asignar los valores especificados a los parametros
				AsignarValoresParametros(Parametros, Valores);

				// llamar al metodo sobrecargado que utiliza un arreglo de SqlParameters
				return Ejecutar(cadenaConexion, CommandType.StoredProcedure, spNombre, Parametros);
			}
				// en otro caso llamar al SP sin parametros
			else 
				return Ejecutar(cadenaConexion, CommandType.StoredProcedure, spNombre);
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que no regresa un conjunto de resultados) en la base de datos especificada en la cadena de conexion
		/// utilizando los parametros especificados.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>DataSet que contiene el conjunto de resultados generados por el comando</returns>
		public static DataSet EjecutarDataSet(string cadenaConexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crear y abrir una SqlConnection, y desecharla despues de usarla.
			using (SqlConnection cn = new SqlConnection(cadenaConexion))
			{
				cn.Open();

				// llamar al metodo sobrecargado que utiliza una conexion en lugar de una cadena de conexion
				return EjecutarDataSet(cn, Tipo, Sentencia, Parametros);
			}
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que regresa un conjunto de resultados)  utilizando la conexion y
		/// los parametros especificados.
		/// </summary>
		/// <param name="Conexion">Una SqlConnection valida, el la cual se ejecutar el comando</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>DataSet que contiene el conjunto de resultados generados por el comando</returns>
		public static DataSet EjecutarDataSet(SqlConnection Conexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crea un comando y lo prepara para su ejecucion
			SqlCommand cmd = new SqlCommand();
			
			PreparaComando(cmd, Conexion, (SqlTransaction)null, Tipo, Sentencia, Parametros);
			
			// crea el DataAdapter y el DataSet
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();

			// llena el DataSet usando los valores por defecto para los nombre de las DataTable, etc.
			da.Fill(ds);
			
			// eliminar los SqlParameters del objeto de comando
			cmd.Parameters.Clear();
			
			// regresa el DataSet
			return ds;						
		}
		
		/// <summary>
		/// Ejecuta un procedimiento almacenado por medio de un SqlCommand (que no regresa un conjunto de resultados) en la base de datos especificada 
		/// en la cadena de conexion utilizando los valores de parametros especificados.
		/// 
		/// Este metodo consulta la base de datos para descubrir los parametros del procedimiento almacenado (la primera vez que el procedimiento es llamado),
		/// y asigna los valores basandose en el orden de los parametros.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// <param name="Valores">Un arreglos de objetos para ser asignados como valores de entrada a el procedimiento almacenado</param>
		/// <returns>DataSet que contiene el conjunto de resultados generados por el comando</returns>
		public static DataSet EjecutarDataSet(string cadenaConexion, string spNombre, params object[] Valores)
		{
			// Si se reciben valores, debemos crear los parametros
			if ((Valores != null) && (Valores.Length > 0)) 
			{
				// buscar los parametros para este procedimiento almacenado en el cache de parametros (o descubrilos y colocarlos en el cache)
				SqlParameter[] Parametros = CacheParametros.ObtenerParametrosSp(cadenaConexion, spNombre);

				// asignar los valores especificados a los parametros
				AsignarValoresParametros(Parametros, Valores);

				// llamar al metodo sobrecargado que utiliza un arreglo de SqlParameters

				return EjecutarDataSet(cadenaConexion, CommandType.StoredProcedure, spNombre, Parametros);
			}
				// en otro caso llamar al SP sin parametros
			else 
				return EjecutarDataSet(cadenaConexion, CommandType.StoredProcedure, spNombre);
		}		

		/// <summary>
		/// Ejecuta un SqlCommand (que regresa un solo valor) en la base de datos especificada en la cadena de conexion
		/// utilizando los parametros especificados.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>Un objeto que contiene el valor regresado por el comando</returns>
		public static object EjecutarEscalar(string cadenaConexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crear y abrir una SqlConnection, y desecharla despues de usarla.
			using (SqlConnection cn = new SqlConnection(cadenaConexion))
			{
				cn.Open();

				// llamar al metodo sobrecargado que utiliza una conexion en lugar de una cadena de conexion
				return EjecutarEscalar(cn, Tipo, Sentencia, Parametros);
			}
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que regresa un solo valor)  utilizando la conexion y
		/// los parametros especificados.
		/// </summary>
		/// <param name="Conexion">Una SqlConnection valida, el la cual se ejecutar el comando</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>Un objeto que contiene el valor regresado por el comando</returns>
		public static object EjecutarEscalar(SqlConnection Conexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crea un comando y lo prepara para su ejecucion
			SqlCommand cmd = new SqlCommand();
			PreparaComando(cmd, Conexion, (SqlTransaction)null, Tipo, Sentencia, Parametros);
			
			// ejecutar el comando
			object valorRetorno = cmd.ExecuteNonQuery();
			
			// eliminar los SqlParameters del objeto de comando
			cmd.Parameters.Clear();
			
			return valorRetorno;
		}

		/// <summary>
		/// Ejecuta un procedimiento almacenado por medio de un SqlCommand (que regresa un solo valor) en la base de datos especificada 
		/// en la cadena de conexion utilizando los valores de parametros especificados.
		/// 
		/// Este metodo consulta la base de datos para descubrir los parametros del procedimiento almacenado (la primera vez que el procedimiento es llamado),
		/// y asigna los valores basandose en el orden de los parametros.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// <param name="Valores">Un arreglos de objetos para ser asignados como valores de entrada a el procedimiento almacenado</param>
		/// <returns>Un objeto que contiene el valor regresado por el comando</returns>
		public static object EjecutarEscalar(string cadenaConexion, string spNombre, params object[] Valores)
		{
			// Si se reciben valores, debemos crear los parametros
			if ((Valores != null) && (Valores.Length > 0)) 
			{
				// buscar los parametros para este procedimiento almacenado en el cache de parametros (o descubrilos y colocarlos en el cache)
				SqlParameter[] Parametros = CacheParametros.ObtenerParametrosSp(cadenaConexion, spNombre);

				// asignar los valores especificados a los parametros
				AsignarValoresParametros(Parametros, Valores);

				// llamar al metodo sobrecargado que utiliza un arreglo de SqlParameters
				return EjecutarEscalar(cadenaConexion, CommandType.StoredProcedure, spNombre, Parametros);
			}
				// en otro caso llamar al SP sin parametros
			else 
				return EjecutarEscalar(cadenaConexion, CommandType.StoredProcedure, spNombre);
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que no regresa un conjunto de resultados) en la base de datos especificada en la cadena de conexion
		/// utilizando los parametros especificados.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>SqlDataReader que contiene el conjunto de resultados generados por el comando</returns>
		public static SqlDataReader EjecutarDataReader(string cadenaConexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crear y abrir una SqlConnection
			SqlConnection cn = new SqlConnection(cadenaConexion);
			
			cn.Open();

			// llamar al metodo sobrecargado que utiliza una conexion en lugar de una cadena de conexion
			return EjecutarDataReader(cn, Tipo, Sentencia, Parametros);
		}

		/// <summary>
		/// Ejecuta un SqlCommand (que regresa un conjunto de resultados)  utilizando la conexion y
		/// los parametros especificados.
		/// </summary>
		/// <param name="Conexion">Una SqlConnection valida, el la cual se ejecutar el comando</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		/// <returns>SqlDataReader que contiene el conjunto de resultados generados por el comando</returns>
		public static SqlDataReader EjecutarDataReader(SqlConnection Conexion, CommandType Tipo, string Sentencia, params SqlParameter[] Parametros)
		{
			// crea un comando y lo prepara para su ejecucion
			SqlCommand cmd = new SqlCommand();
			
			PreparaComando(cmd, Conexion, (SqlTransaction)null, Tipo, Sentencia, Parametros);

			// crea el SqlDataReader
			SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

			// eliminar los SqlParameters del objeto de comando
			cmd.Parameters.Clear();
			
			// regresa el SqlDataReader
			return dr;						
		}

		/// <summary>
		/// Ejecuta un procedimiento almacenado por medio de un SqlCommand (que no regresa un conjunto de resultados) en la base de datos especificada 
		/// en la cadena de conexion utilizando los valores de parametros especificados.
		/// 
		/// Este metodo consulta la base de datos para descubrir los parametros del procedimiento almacenado (la primera vez que el procedimiento es llamado),
		/// y asigna los valores basandose en el orden de los parametros.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// <param name="Valores">Un arreglos de objetos para ser asignados como valores de entrada a el procedimiento almacenado</param>
		/// <returns>SqlDataReader que contiene el conjunto de resultados generados por el comando</returns>
		public static SqlDataReader EjecutarDataReader(string cadenaConexion, string spNombre, params object[] Valores)
		{
			// Si se reciben valores, debemos crear los parametros
			if ((Valores != null) && (Valores.Length > 0)) 
			{
				// buscar los parametros para este procedimiento almacenado en el cache de parametros (o descubrilos y colocarlos en el cache)
				SqlParameter[] Parametros = CacheParametros.ObtenerParametrosSp(cadenaConexion, spNombre);

				// asignar los valores especificados a los parametros
				AsignarValoresParametros(Parametros, Valores);

				// llamar al metodo sobrecargado que utiliza un arreglo de SqlParameters

				return EjecutarDataReader(cadenaConexion, CommandType.StoredProcedure, spNombre, Parametros);
			}
				// en otro caso llamar al SP sin parametros
			else 
				return EjecutarDataReader(cadenaConexion, CommandType.StoredProcedure, spNombre);
		}
	}

	/// <summary>
	/// Esta clase provee las funciones para utilizar un cache estatico de parametros de procedimientos, y la
	/// habilidad para descubrir los parametros de los procedimientos almacenados en tiempo de ejecucion.
	/// </summary>
	public sealed class CacheParametros
	{
		/// <summary>
		/// Esta clase provee solo metodos estaticos, por lo tanto el constructor es privado 
		/// para prevenir que sea creado un objeto mediante "new CacheParametros()",
		/// </summary>
		private CacheParametros()
		{
		}

		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

		/// <summary>
		/// Resuelve en tiempo de ejecucion el conkunto de SqlParameters para un procedimiento almacenado.
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// <param name="incluirValorRetorno">Si se incluyen o no los valores de retorno de los parametros</param>
		/// <returns>Un arreglo de SqlParameters pertenecientes a el comando</returns>		
		private static SqlParameter[] DescubreSpParametros(string cadenaConexion, string spNombre, bool incluirValorRetorno)
		{
			using (SqlConnection cn = new SqlConnection(cadenaConexion)) 
			using (SqlCommand cmd = new SqlCommand(spNombre,cn))
			{
				cn.Open();
				cmd.CommandType = CommandType.StoredProcedure;

				SqlCommandBuilder.DeriveParameters(cmd);

				if (!incluirValorRetorno) 
					cmd.Parameters.RemoveAt(0);

				SqlParameter[] Parametros = new SqlParameter[cmd.Parameters.Count];;

				cmd.Parameters.CopyTo(Parametros, 0);

				return Parametros;
			}
		}

		/// <summary>
		/// Clona los parametros especificados y crea un nuevo arreglo con los clones
		/// </summary>
		/// <param name="Parametros">Arreglo de parametros a ser clonados</param>
		/// <returns>Arreglo de parametros clonados</returns>
		private static SqlParameter[] ClonarParametros(SqlParameter[] Parametros)
		{
			SqlParameter[] Clonados = new SqlParameter[Parametros.Length];

			for (int i = 0, j = Parametros.Length; i < j; i++)
				Clonados[i] = (SqlParameter)((ICloneable)Parametros[i]).Clone();

			return Clonados;
		}

		/// <summary>
		/// Agrega un arreglo de parametros al cache
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="Tipo">El CommandType (procedimiento almacenado, texto, etc.)</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <param name="Parametros">Un arreglo de SqlParameters a ser asociados con el comando</param>
		public static void FijarCacheParametro(string cadenaConexion, string Sentencia, params SqlParameter[] Parametros)
		{
			string hashKey = cadenaConexion + ":" + Sentencia;

			paramCache[hashKey] = Parametros;
		}

		/// <summary>
		/// Retira un arreglo de parametros desde el cache
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="Sentencia">El nombre del procedimiento almacenado o una sentencia T-SQL</param>
		/// <returns>Un arreglo de SqlParameters</returns>
		public static SqlParameter[] ObtenerParametrosCache(string cadenaConexion, string Sentencia)
		{
			string hashKey = cadenaConexion + ":" + Sentencia;

			SqlParameter[] Parametros = (SqlParameter[])paramCache[hashKey];
			
			if (Parametros == null)
				return null;
			else
				return ClonarParametros(Parametros);
		}

		/// <summary>
		/// Retira el conjunto de SqlParameters apropiado para el procedimiento almacenado.
		/// 
		/// Este metodo consulta la base de datos para esta informacion, y entonces la almacena en el cache para usos futuros
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// <returns>Un arreglo de SqlParameters</returns>
		public static SqlParameter[] ObtenerParametrosSp(string cadenaConexion, string spNombre)
		{
			return ObtenerParametrosSp(cadenaConexion, spNombre, false);
		}

		/// <summary>
		/// Retira el conjunto de SqlParameters apropiado para el procedimiento almacenado.
		/// 
		/// Este metodo consulta la base de datos para esta informacion, y entonces la almacena en el cache para usos futuros
		/// </summary>
		/// <param name="cadenaConexion">Una cadena de conexion valiada para una SqlConnection</param>
		/// <param name="spNombre">Nombre del procedimiento almacenado</param>
		/// /// <param name="incluirValorRetorno">Si se incluyen o no los valores de retorno de los parametros</param>
		/// <returns>Un arreglo de SqlParameters</returns>
		public static SqlParameter[] ObtenerParametrosSp(string cadenaConexion, string spNombre, bool incluirValorRetorno)
		{
			string hashKey = cadenaConexion + ":" + spNombre + (incluirValorRetorno ? ":incluir ValorRetorno Parametro":"");

			SqlParameter[] Parametros;
			
			Parametros = (SqlParameter[])paramCache[hashKey];

			if (Parametros == null)
				Parametros = (SqlParameter[])(paramCache[hashKey] = DescubreSpParametros(cadenaConexion, spNombre, incluirValorRetorno));
			
			return ClonarParametros(Parametros);
		}
	}
}
