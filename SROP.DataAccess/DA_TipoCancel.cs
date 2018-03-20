using System.Data;
using Oracle.DataAccess.Client;

public class DA_TipoCancel : DA_BASE
{
    public OracleDataReader Gets(OracleConnection cn)
    {
        OracleParameter[] pr = new OracleParameter[1];
        pr[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_motivo_cancel_cbo", pr);
    }
}

