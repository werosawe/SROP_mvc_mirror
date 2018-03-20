using System.Data;
using Oracle.DataAccess.Client;

	public class DA_Roles : DA_BASE
	{

		public OracleDataReader Listar_Roles(OracleConnection CN)
		{
			OracleParameter[] ARRPARAM = new OracleParameter[1];
			
				//ARRPARAM(0) = New OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input)
				//ARRPARAM(0).Value = UserId
				ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
				return ORACLEHELPER.ObtenerDR(CN, "pkg_Users.SP_Listar_Roles", ARRPARAM);
			
				
		}
	}
