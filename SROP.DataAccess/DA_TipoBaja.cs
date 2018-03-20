using System.Data;
using Oracle.DataAccess.Client;

	public class DA_TipoBaja : DA_BASE
	{

		public OracleDataReader Listar_MotivoBaja(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_motivobaja_cbo", ARRPARAM);
			
		}
	}

