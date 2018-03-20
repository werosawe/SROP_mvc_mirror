using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Runtime.InteropServices;
namespace Utilitario
{
	public interface IEntity
	{

		OracleDataReader ObtenerDR(OracleConnection cn, string nombreSP, params OracleParameter[] parametros);

		DataTable ObtenerDT(string nombreSP, params OracleParameter[] parametros);

		int EjecutarQR(string nombreSP, params OracleParameter[] parametros);

	}
}
namespace Utilitario
{
	//   Inherits ServicedComponent
	public class Oracle_Entity : IEntity, IDisposable
	{
		private string TX_CONEXION = "";
		//  <AutoComplete()> _
		public OracleDataReader ObtenerDR(OracleConnection cn, string nombreSP, params OracleParameter[] parametros)
		{
			try {
				OracleDataReader result = Oracle_Helper.ExecuteReader(cn, CommandType.StoredProcedure, nombreSP, parametros);
				return result;
			} catch (OracleException ex) {
				ex.Data.Add("TIPO_ERROR", "EN BASE DE DATOS");
				ex.Data.Add("BD_CONSULTA_ORIGEN", Funciones.GET_SENTENCIA_SQL(nombreSP, parametros));
				throw ex;
			} catch (Exception e) {
				e.Data.Add("TIPO_ERROR", "EN CODIGO CAPA DE DATOS");
				e.Data.Add("BD_CONSULTA_ORIGEN", nombreSP);
				throw e;
			}
		}

		// <AutoComplete()> _
		public DataTable ObtenerDT(string nombreSP, params OracleParameter[] parametros)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			try {
				DataTable result = Oracle_Helper.ExecuteDataTable(cn, CommandType.StoredProcedure, nombreSP, parametros);
				return result;
			} catch (OracleException ex) {
				ex.Data.Add("BD_ERROR", ex.Number);
				ex.Data.Add("BD_CONSULTA_ORIGEN", Funciones.GET_SENTENCIA_SQL(nombreSP, parametros));
				throw ex;
			} catch (Exception e) {
				e.Data.Add("DA_ERROR", e.Message);
				e.Data.Add("BD_CONSULTA_ORIGEN", nombreSP);
				throw e;
			} finally {
				cn.Close();
				cn.Dispose();
				cn = null;
			}
		}

		public int EjecutarQR(string nombreSP, params OracleParameter[] parametros)
		{
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			try {
				int result = Oracle_Helper.ExecuteNonQuery(cn, CommandType.StoredProcedure, nombreSP, parametros);
				return result;
			} catch (OracleException ex) {
				ex.Data.Add("BD_ERROR", ex.Number);
				ex.Data.Add("BD_CONSULTA_ORIGEN", Funciones.GET_SENTENCIA_SQL(nombreSP, parametros));
				throw ex;
			} catch (Exception e) {
				e.Data.Add("DA_ERROR", e.Message);
				e.Data.Add("BD_CONSULTA_ORIGEN", nombreSP);
				throw e;
			} finally {
				cn.Close();
				cn.Dispose();
				cn = null;
			}
		}

		public int EjecutarQRTx(OracleConnection objConection, string nombreSP, params OracleParameter[] parametros)
		{
			//Implements IEntity.EjecutarQR
			OracleConnection cn = new OracleConnection(TX_CONEXION);
			try {
				int result = Oracle_Helper.ExecuteNonQuery(objConection, CommandType.StoredProcedure, nombreSP, parametros);
				return result;
			} catch (OracleException ex) {
				ex.Data.Add("BD_ERROR", ex.Number);
				ex.Data.Add("BD_CONSULTA_ORIGEN", Funciones.GET_SENTENCIA_SQL(nombreSP, parametros));
				throw ex;
			} catch (Exception e) {
				e.Data.Add("DA_ERROR", e.Message);
				e.Data.Add("BD_CONSULTA_ORIGEN", nombreSP);
				throw e;
			} finally {
				cn.Close();
				cn.Dispose();
				cn = null;
			}
		}



		public Oracle_Entity(string TX_ESQUEMA, string KEY)
		{
			TX_CONEXION = Encriptar_Desencriptar.Desencriptar_CN(TX_ESQUEMA, KEY);
		}

		//public void RESET_CONEXION(string TX_ESQUEMA, string KEY)
		//{
		//	TX_CONEXION = Encriptar_Desencriptar.Desencriptar_CN(TX_ESQUEMA, KEY);
		//}




		private bool disposedValue = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue) {

				if (disposing) {
					// TODO: Liberar otro estado (objetos administrados).
				}
				TX_CONEXION = null;
				// TODO: Liberar su propio estado (objetos no administrados).
				// TODO: Establecer campos grandes como Null.
			}
			this.disposedValue = true;
		}

		#region " IDisposable Support "
		// Visual Basic agregó este código para implementar correctamente el modelo descartable.
		public void Dispose()
		{
			// No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

	}
}
// END CLASS DEFINITION Entity

