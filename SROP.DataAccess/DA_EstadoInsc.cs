using System.Data;
using Oracle.DataAccess.Client;

public class DA_EstadoInsc : DA_BASE
{   
    public OracleDataReader Gets(OracleConnection cn, BE_EstadoInsc c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[0].Value = Yoo.UserId;
        pr[1] = new OracleParameter("CODTIPOMOV", OracleDbType.Char,2, ParameterDirection.Input);
        pr[1].Value = c.CODTIPOMOV;
        pr[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_estadoInsc_grid", pr);
    }  
}

