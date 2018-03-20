using System.Data;
using Oracle.DataAccess.Client;

public class DA_Ubigeo : DA_BASE
{



    public OracleDataReader Listar_Regiones(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_regiones_cbo", ARRPARAM);
    }

    public OracleDataReader Listar_Provincias(OracleConnection CN, BE_UBIGEO c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("I_PARAM1", OracleDbType.Int32, ParameterDirection.InputOutput);
        ARRPARAM[0].Value = c.UBIREGION.Num();
        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_provincias_cbo", ARRPARAM);


    }

    public OracleDataReader Listar_Distritos(OracleConnection CN, BE_UBIGEO c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("I_PARAM1", OracleDbType.Int32, ParameterDirection.InputOutput);
        ARRPARAM[0].Value = c.UBIREGION.Num();
        ARRPARAM[1] = new OracleParameter("I_PARAM2", OracleDbType.Int32, ParameterDirection.InputOutput);
        ARRPARAM[1].Value = c.UBIPROVINCIA.Num();
        ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_distritos_cbo", ARRPARAM);
    }

    public OracleDataReader Listar_Distritos_sin_capitales(OracleConnection CN, BE_UBIGEO BE_Ubig)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("I_PARAM1", OracleDbType.Int32, ParameterDirection.InputOutput);
        ARRPARAM[0].Value = BE_Ubig.UBIREGION.Num();
        ARRPARAM[1] = new OracleParameter("I_PARAM2", OracleDbType.Int32, ParameterDirection.InputOutput);
        ARRPARAM[1].Value = BE_Ubig.UBIPROVINCIA.Num();
        ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_distritos_sin_capitales_cbo", ARRPARAM);
    }

    public OracleDataReader Listar_Regiones_JEE(OracleConnection CN, BE_UBIGEO c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.InputOutput);
        ARRPARAM[0].Value = Yoo.UserId;

        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ubireg_userid_cbo", ARRPARAM);


    }

    public OracleDataReader Listar_Provincias_JEE(OracleConnection CN, BE_UBIGEO c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.InputOutput);
        ARRPARAM[0].Value = Yoo.UserId;

        ARRPARAM[1] = new OracleParameter("i_id_region", OracleDbType.Varchar2, ParameterDirection.InputOutput);
        ARRPARAM[1].Value = c.UBIREGION.Num();

        ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ubiprov_userid_cbo", ARRPARAM);


    }

    public OracleDataReader Listar_Distritos_JEE(OracleConnection CN, BE_UBIGEO c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.InputOutput);
        ARRPARAM[0].Value = Yoo.UserId;

        ARRPARAM[1] = new OracleParameter("i_id_region", OracleDbType.Varchar2, ParameterDirection.InputOutput);
        ARRPARAM[1].Value = c.UBIREGION;

        ARRPARAM[2] = new OracleParameter("i_id_provincia", OracleDbType.Varchar2, ParameterDirection.InputOutput);
        ARRPARAM[2].Value = c.UBIPROVINCIA;

        ARRPARAM[3] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ubidis_userid_cbo", ARRPARAM);


    }

    public OracleDataReader Desc_Ubigeo(OracleConnection CN, string strUbigeo)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("I_UBIGEO", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[0].Value = strUbigeo;

        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_ubigeo_sel", ARRPARAM);


    }

    public string Get_Ubigeo(int ubiRegion, int ubiProv, int ubiDist)
    {


        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_ubireg", OracleDbType.Int16, ParameterDirection.Input);
        ARRPARAM[0].Value = ubiRegion;

        ARRPARAM[1] = new OracleParameter("i_ubiprov", OracleDbType.Int16, ParameterDirection.Input);
        ARRPARAM[1].Value = ubiProv;

        ARRPARAM[2] = new OracleParameter("i_ubidist", OracleDbType.Int16, ParameterDirection.Input);
        ARRPARAM[2].Value = ubiDist;

        ARRPARAM[3] = new OracleParameter("o_mensaje", OracleDbType.Int32, ParameterDirection.Output);
        ARRPARAM[3].Size = 200;

        ORACLEHELPER.EjecutarQR("PKG_LISTAR.sp_get_ubigeo", ARRPARAM);

        return ARRPARAM[3].Value.ToString();

    }

    //Public Function Listar_Regiones(ByVal CN As OracleConnection, ByVal Menu As BE_MenuPadre) As OracleDataReader
    //    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}
    //    Try
    //        ARRPARAM(0) = New OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output)
    //        ARRPARAM(1) = New OracleParameter("ID_SUB_CLASIFICACION", OracleDbType.Int32, ParameterDirection.InputOutput)
    //        ARRPARAM(1).Value = Menu.ID_SUB_CLASIFICACION
    //        Return ORACLEHELPER.ObtenerDR(CN, "PKG_Menu.LST_X_SUB_CLASIFICACION", ARRPARAM)
    //    Catch EX As Exception
    //        Throw EX
    //    End Try
    //End Function
}
