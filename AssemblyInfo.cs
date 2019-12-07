using System.Reflection;
using System.Runtime.CompilerServices;

//
// La informaci�n general de un ensamblado se controla mediante el siguiente 
// conjunto de atributos. Cambie estos atributos para modificar la informaci�n
// asociada con un ensamblado.
//
[assembly: AssemblyTitle("Portal Gobernacion")]
[assembly: AssemblyDescription("Portal para Intranet e Internet")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Ing Pedro Arrioja")]
[assembly: AssemblyProduct("Portal Gobernacion")]
[assembly: AssemblyCopyright("Ing Pedro Arrioja 2005")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		

//
// La informaci�n de versi�n de un ensamblado consta de los siguientes cuatro valores:
//
//      Versi�n principal
//      Versi�n secundaria 
//      Versi�n de compilaci�n
//      Revisi�n
//
// Puede especificar todos los valores o usar los valores predeterminados (n�mero de versi�n de compilaci�n y de revisi�n) 
// usando el s�mbolo '*' como se muestra a continuaci�n:

[assembly: AssemblyVersion("1.0.*")]

//
// Si desea firmar el ensamblado, debe especificar una clave para su uso. Consulte la documentaci�n de 
// Microsoft .NET Framework para obtener m�s informaci�n sobre la firma de ensamblados.
//
// Utilice los atributos siguientes para controlar qu� clave desea utilizar para firmar. 
//
// Notas: 
//   (*) Si no se especifica ninguna clave, el ensamblado no se firma.
//   (*) KeyName se refiere a una clave instalada en el Proveedor de servicios
//       de cifrado (CSP) en el equipo. KeyFile se refiere a un archivo que contiene
//       una clave.
//   (*) Si se especifican los valores KeyFile y KeyName, tendr� 
//       lugar el siguiente proceso:
//       (1) Si KeyName se puede encontrar en el CSP, se utilizar� dicha clave.
//       (2) Si KeyName no existe pero s� KeyFile, se instalar� 
//           y utilizar� la clave de KeyFile en el CSP.
//   (*) Para crear KeyFile, puede ejecutar la utilidad sn.exe (Strong Name).
//        Cuando se especifica KeyFile, la ubicaci�n de KeyFile debe ser
//        relativa al "directorio de resultados del proyecto". La ubicaci�n del directorio de resultados
//        del proyecto depende de si se est� trabajando con un proyecto Web o local.
//        En proyectos locales, el directorio de resultados del proyecto se define como
//       <Directorio del proyecto>\obj\<Configuration>. Por ejemplo, si KeyFile
//       se encuentra en el directorio del proyecto, el atributo AssemblyKeyFile se especifica 
//       como [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//        En proyectos Web, el directorio de resultados del proyecto se define como
//       %RUTA PRINCIPAL%\VSWebCache\<Nombre del equipo>\<Directorio del proyecto>\obj\<Configuraci�n>.
//   (*) (*) Firma retardada es una opci�n avanzada; consulte la documentaci�n de
//       Microsoft .NET Framework para obtener m�s informaci�n.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
