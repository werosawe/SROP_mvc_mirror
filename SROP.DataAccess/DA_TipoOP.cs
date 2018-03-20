using System.Data;
using System.Linq;
using System.Xml.Linq;
using Oracle.DataAccess.Client;

public class DA_TipoOP : DA_BASE
{

    public OracleDataReader Gets(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "ORGPOL_PKG_TIPO_OP.GETS", ARRPARAM);
    }

    public OracleDataReader Get(OracleConnection cn, BE_TipoOP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("COD_TIPO_OP", OracleDbType.Char,2, ParameterDirection.Input);
        pr[0].Value = c.Cod_Tipo_OP;
        pr[1] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "ORGPOL_PKG_TIPO_OP.GET", pr);
    }

}

