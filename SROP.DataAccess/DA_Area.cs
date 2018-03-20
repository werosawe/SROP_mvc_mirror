using System.Data;
using Oracle.DataAccess.Client;
public class DA_Area : DA_BASE
{
    public OracleDataReader Listar_Areas(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_param1", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = "";
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_entes_oficina", ARRPARAM);
    }


}

