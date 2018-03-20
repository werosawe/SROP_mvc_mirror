using System.Data;
using Oracle.DataAccess.Client;

	public class DA_Sede : DA_BASE
	{

		public OracleDataReader Listar_Sedes(OracleConnection CN, string UserId)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[2];
			
				ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
				ARRPARAM[0].Value = UserId;
				ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_sedes_resol_cbo", ARRPARAM);
			
		}
	}

