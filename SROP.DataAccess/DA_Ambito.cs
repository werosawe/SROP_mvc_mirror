using System.Data;
using Oracle.DataAccess.Client;



    public class DA_Ambito : DA_BASE
	{

        public OracleDataReader Listar_Ambito(OracleConnection cn)
        {
            OracleParameter[] ARRPARAM = new OracleParameter[1];
            ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
            return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_ambito_cbo", ARRPARAM);
        }
	}

