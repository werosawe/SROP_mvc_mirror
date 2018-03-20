using System.Data;
using Oracle.DataAccess.Client;
	public class DA_ResulResol : DA_BASE
	{

		public OracleDataReader Listar_Resul_Resoluciones(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_resul_resol_cbo", ARRPARAM);
			
		}
	}

