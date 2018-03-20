using System.Data;
using Oracle.DataAccess.Client;

public class DA_Tipo : DA_BASE
{
    public OracleDataReader GetsActivo(OracleConnection cn, BE_Tipo c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("IDGRUPO", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.IDGRUPO;
        pr[1] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "ORGPOL_PKG_TIPO.GETS", pr);
    }

    public OracleDataReader Get(OracleConnection cn, BE_Tipo c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("IDGRUPO", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.IDGRUPO;
        pr[1] = new OracleParameter("IDTIPO", OracleDbType.Int32, ParameterDirection.Input);
        pr[1].Value = c.IDTIPO;
        pr[2] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "ORGPOL_PKG_TIPO.GETS", pr);
    }
}
