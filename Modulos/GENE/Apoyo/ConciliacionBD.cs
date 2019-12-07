using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using AyudanteSQL;


namespace PortalGobernacion.Modulos.GENE.Apoyo
{
	/// <summary>
	/// Descripci�n breve de ConciliacionBD.
	/// </summary>
	public class ConciliacionBD
	{
		public ConciliacionBD()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//
		}

		public static DataSet BuscarDepFisicos(string Mes, string Seleccion )
		{
			string Sentencia = "SELECT A.NumeroDep,A.Fecha,sum(A.Monto) As MontoL,sum(B.Monto) As MontoB ";
				   Sentencia +=" FROM PortalGene.DepositoFisico A LEFT JOIN PortalGene.DepositoBanco B ON A.NumeroDep = B.NumeroDep ";
			       Sentencia +=" WHERE (MONTH(A.Fecha) = '" + Mes + "') ";
			
			       switch (Seleccion)
			       {
				      case "T": Sentencia += " and ( A.Conciliado = 'T' ) "; break;
				      case "C": Sentencia += " and ( A.Conciliado = 'C' ) "; break;
			       }
                   Sentencia += " GROUP bY A.NumeroDep With RollUp";			

			return AyudanteMySQL.EjecutarDataSet(ConfigurationSettings.AppSettings["PortalGene"],  Sentencia);
		}

		public static DataSet BuscarDepBancos(string Mes, string Cta, string Seleccion )
		{
			string Sentencia = "SELECT A.NumeroDep, A.Fecha,sum(B.Monto) As MontoL,sum(A.Monto) as MontoB ";
			       Sentencia += " FROM PortalGene.DepositoBanco A LEFT JOIN PortalGene.DepositoFisico B ON A.NumeroDep = B.NumeroDep ";
			Sentencia +="WHERE (MONTH(A.Fecha) = '" + Mes + "')  and (NumeroCta = '" + Cta + "' ) ";
			
			switch (Seleccion)
			{
				case "T": Sentencia += " and ( A.Conciliado = 'T' ) "; break;
				case "C": Sentencia += " and ( A.Conciliado = 'C' ) "; break;
			}

			Sentencia += " GROUP bY A.NumeroDep With RollUp";			

			return AyudanteMySQL.EjecutarDataSet(ConfigurationSettings.AppSettings["PortalGene"],  Sentencia);
		}

		public static void Conciliar(string Mes, string Cta)
		{
			string SentenciaBx = "UPDATE DepositoBanco SET ";
			SentenciaBx += "Conciliado = 'T' ";
            AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], SentenciaBx);

			string SentenciaLx = "UPDATE DepositoFisico SET ";
			SentenciaLx += "Conciliado = 'T' ";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], SentenciaLx);
			

			string SentenciaB = "UPDATE DepositoBanco SET ";
			SentenciaB += "Conciliado = 'C' ";
			SentenciaB += "WHERE (NumeroDep IN (SELECT NumeroDep FROM DepositoFisico ))";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], SentenciaB);

			string SentenciaL = "UPDATE DepositoFisico SET ";
			SentenciaL += "Conciliado = 'C' ";
			SentenciaL += "WHERE (NumeroDep IN (SELECT NumeroDep FROM DepositoBanco ))";
			AyudanteMySQL.Ejecutar(ConfigurationSettings.AppSettings["PortalGene"], SentenciaL);
		}
	}
}
