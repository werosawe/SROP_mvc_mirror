using System.Data;
using Oracle.DataAccess.Client;

public class DA_EstadoOP : DA_BASE
{
    public OracleDataReader Listar_EstadoOP(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_EstadoOP_cbo", ARRPARAM);
    }
}
