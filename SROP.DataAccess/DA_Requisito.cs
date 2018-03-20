using System;
using System.Data;
using Oracle.DataAccess.Client;



	public class DA_Requisito : DA_BASE
	{

		public OracleDataReader Listar_Requisitos(OracleConnection CN, Int32 Cod_OP)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
				ARRPARAM[0].Value = Cod_OP;
				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_requisitos_grid", ARRPARAM);
			
		}
	}

