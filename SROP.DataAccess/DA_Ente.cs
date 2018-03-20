using System.Data;
using Oracle.DataAccess.Client;

public class DA_Ente : DA_BASE
{

    public OracleDataReader GetsPrefijoExpedienteMTD(OracleConnection cn, BE_Ente c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
        pr[0].Value = c.Cod_Ente;
        pr[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_prefijoMTD_cbo", pr);
    }

    public OracleDataReader GetsEnte(OracleConnection cn)
    {
        OracleParameter[] pr = new OracleParameter[1];
        pr[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_entes_cbo", pr);
    }

    public OracleDataReader Listar_Entes_Const(OracleConnection CN, string Cod_Ente)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_param1", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_Ente;

        ARRPARAM[1] = new OracleParameter("i_param2", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = "00";

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_Listar.sp_entes_lista", ARRPARAM);

    }

    public OracleDataReader Get_Responsable_Ente(OracleConnection CN, string Cod_Ente)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];


        ARRPARAM[0] = new OracleParameter("i_cod_ente", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_Ente;

        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_responsable_ente", ARRPARAM);


    }

    public OracleDataReader Listar_TiposEntes(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_param1", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = "";

        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_entes_tipo", ARRPARAM);

    }

}

