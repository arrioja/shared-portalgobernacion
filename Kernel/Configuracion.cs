using System;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Data;
using System.IO;

namespace Portal.Kernel {

    public class Pagina
    {
        public int			PagId;
        public int			PagPadre;
        public string		PagNombre;
        public int			PagOrden;
        public string		GruposAutorizados;
        public ArrayList	Modulos = new ArrayList();
        public bool			Sistema;

        public string ObtenerRuta()
        {
        	return (PagPadre == -1) ? PagNombre : ObtenerRutaPadre(PagPadre) + " > " + PagNombre;
        }

        public int ObtenerPrimera()
        {
        	return (PagPadre == -1) ? PagId : ObtenerPadreId(PagId);
        }

        private int ObtenerPadreId(int pagId)
        {
        	IDataReader Datos = PaginasBD.Obtener(pagId);

			int Padre = (Datos.Read()) ? (int) Datos["PagPadre"] : -1;

        	Datos.Close();

        	return (Padre == -1) ? pagId : ObtenerPadreId(Padre);
        }

        private string ObtenerRutaPadre(int Padre)
        {
        	int NuevoPadre = -1;
        	string Nombre = string.Empty;

        	IDataReader Datos = PaginasBD.Obtener(Padre);

        	if(Datos.Read())
        	{
        		NuevoPadre = (int) Datos["PagPadre"];
        		Nombre = (string) Datos["PagNombre"];
        	}

        	Datos.Close();

        	return (NuevoPadre == -1) ? Nombre : ObtenerRutaPadre(NuevoPadre) + " > " + Nombre;
        }
    }

    public class Modulo
    {
    	public int 			ModuloId;
    	public int			ModuloDefId;
    	public int			PagId;
    	public int			ModuloOrden;
		public int			TiempoCache;
    	public string		NombrePanel;
		public string		ModuloTitulo;
    	public string		GruposAutorizados;
    	public string		GruposAutorizadosEdicion;
    	public string		Ubicacion;
		public string		UbicacionEdicion;
    }

	public class ModuloItem : IComparable 
	{

		private int      _moduloOrden;
		private string   _titulo;
		private string   _panel;
		private int      _id;
		private int      _defId;

		public int ModuloOrden
		{
			get 
			{
				return _moduloOrden;
			}
			set 
			{
				_moduloOrden = value;
			}
		}    

		public string ModuloTitulo 
		{
			get 
			{
				return _titulo;
			}
			set 
			{
				_titulo = value;
			}
		}

		public string NombrePanel
		{
			get 
			{
				return _panel;
			}
			set 
			{
				_panel = value;
			}
		}
        
		public int ModuloId 
		{
			get 
			{
				return _id;
			}
			set 
			{
				_id = value;
			}
		}  
  
		public int ModuloDefId 
		{
			get 
			{
				return _defId;
			}
			set 
			{
				_defId = value;
			}
		} 
   
		public int CompareTo(object value) 
		{
			if (value == null) return 1;

			int comparaOrden = ((ModuloItem)value).ModuloOrden;
            
			if (this.ModuloOrden == comparaOrden) return 0;
			if (this.ModuloOrden < comparaOrden) return -1;
			if (this.ModuloOrden > comparaOrden) return 1;
			return 0;
		}
	}

    public class PortalConfig
    {
    	public string		Nombre;
    	public string		Tema;
    	public ArrayList	Paginas = new ArrayList();
    	public Pagina		PagActiva = new Pagina();

    	public PortalConfig(int pagId)
    	{
    		Nombre = ConfigurationSettings.AppSettings["PortalNombre"];
			Tema = ConfigurationSettings.AppSettings["PortalTema"];
    		
 	  		IDataReader Datos = PaginasBD.Obtener(pagId);

    		if(Datos.Read())
    		{
    			PagActiva.PagId = (int) Datos["PagId"];
				PagActiva.PagPadre = (int) Datos["PagPadre"];
				PagActiva.PagNombre = (string) Datos["PagNombre"];
				PagActiva.PagOrden = (int) Datos["PagOrden"];
				PagActiva.GruposAutorizados = (string) Datos["GruposAutorizados"];
				PagActiva.Sistema = ((int) Datos["Sistema"] == 0) ? false : true;
    		}
    		else
    		{
    			Datos.Close();
    			Datos = PaginasBD.Obtener();

    			if(Datos.Read())
    			{
    				PagActiva.PagId = (int) Datos["PagId"];
    				PagActiva.PagPadre = (int) Datos["PagPadre"];
					PagActiva.PagNombre = (string) Datos["PagNombre"];
					PagActiva.PagOrden = (int) Datos["PagOrden"];
					PagActiva.GruposAutorizados = (string) Datos["GruposAutorizados"];
					PagActiva.Sistema = ((int) Datos["Sistema"] == 0) ? false : true;
    			}
    		}

    		Datos.Close();
    		Datos = PaginasBD.Obtener();

    		while(Datos.Read())
    		{
    			Pagina p = new Pagina();

    			p.PagId = (int) Datos["PagId"];
    			p.PagNombre = (string) Datos["PagNombre"];
				p.PagOrden = (int) Datos["PagOrden"];
				p.GruposAutorizados = (string) Datos["GruposAutorizados"];
				p.PagPadre = (int) Datos["PagPadre"];
				p.Sistema = ((int) Datos["Sistema"] == 0) ? false : true;

				Paginas.Add(p);
    		}

    		Datos.Close();
    		Datos = ModulosBD.ObtenerPagina(PagActiva.PagId);

    		while(Datos.Read())
    		{
    			Modulo m = new Modulo();

				m.ModuloId = (int) Datos["ModuloId"];
				m.ModuloDefId = (int) Datos["ModuloDefId"];
				m.NombrePanel = (string) Datos["NombrePanel"];
				m.ModuloTitulo = (string) Datos["ModuloTitulo"];
				m.ModuloOrden = (int) Datos["ModuloOrden"];
				m.GruposAutorizados = (string) Datos["GruposAutorizados"];
				m.GruposAutorizadosEdicion = (string) Datos["GruposAutorizadosEdicion"];
				m.Ubicacion = (string) Datos["Ubicacion"];
				m.UbicacionEdicion = (string) Datos["UbicacionEdicion"];
				m.TiempoCache = (int) Datos["TiempoCache"];

				PagActiva.Modulos.Add(m);
    		}

    		Datos.Close();
    	}
    }
}
