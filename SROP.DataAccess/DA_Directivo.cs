using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_Directivo : DA_BASE
{

    #region "Procedimientos de consulta"

    public OracleDataReader Listar_Activos(OracleConnection CN, Int32 Cod_OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_1", ARRPARAM);
    }

    public OracleDataReader Listar_IncluyeBajas(OracleConnection CN, Int32 Cod_OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_2", ARRPARAM);
    }

    public OracleDataReader Listar_Vigencia_Mayor(OracleConnection CN, Int32 Cod_OP, int AnosVigencia)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_anos_vigencia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = AnosVigencia;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_3", ARRPARAM);


    }

    public OracleDataReader Listar_Vigencia_Menor(OracleConnection CN, Int32 Cod_OP, int AnosVigencia)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_anos_vigencia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = AnosVigencia;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_4", ARRPARAM);

    }

    public OracleDataReader Listar_Vigencia_Cerca(OracleConnection CN, Int32 Cod_OP, int AnosVigencia)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_anos_vigencia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = AnosVigencia;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_5", ARRPARAM);

    }


    public OracleDataReader Buscar_NombreDni(OracleConnection CN, Int32 Cod_OP, string Nombre_Dni)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = Nombre_Dni;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_busq_1", ARRPARAM);

    }

    public OracleDataReader Buscar_NombreDni_IncluyeBajas(OracleConnection CN, Int32 Cod_OP, string Nombre_Dni)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = Nombre_Dni;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_busq_2", ARRPARAM);

    }

    public OracleDataReader Buscar_NombreDni_Vigencia_Mayor(OracleConnection CN, Int32 Cod_OP, int AnosVigencia, string Nombre_Dni)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("AnosVigencia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = AnosVigencia;

        ARRPARAM[2] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[2].Value = Nombre_Dni;

        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_busq_3", ARRPARAM);

    }

    public OracleDataReader Buscar_NombreDni_Vigencia_Menor(OracleConnection CN, Int32 Cod_OP, int AnosVigencia, string Nombre_Dni)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("AnosVigencia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = AnosVigencia;

        ARRPARAM[2] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[2].Value = Nombre_Dni;

        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_busq_4", ARRPARAM);

    }

    public OracleDataReader Buscar_NombreDni_Vigencia_Cerca(OracleConnection CN, Int32 Cod_OP, int AnosVigencia, string Nombre_Dni)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("AnosVigencia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = AnosVigencia;

        ARRPARAM[2] = new OracleParameter("i_param", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[2].Value = Nombre_Dni;

        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_grid_busq_5", ARRPARAM);

    }

    public OracleDataReader Obtener_Directivo(OracleConnection CN, BE_Directivo c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Dni;

        ARRPARAM[2] = new OracleParameter("i_cod_correl", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[2].Value = c.Cod_Correl;

        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_repres.sp_repres_sel", ARRPARAM);

    }

    public OracleDataReader Listar_Directivos_Por_Vencer(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];

        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_op_repres_por_vencer", ARRPARAM);
    }

    public OracleDataReader Listar_Directivos_Vencidos(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];

        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_reportes.sp_listar_op_repres_vencidos", ARRPARAM);


    }

    #endregion

    #region "Procedimientos de transaccion"
    public int Baja_Directivo(BE_Directivo c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Dni;

        arrParam[2] = new OracleParameter("i_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Correl;

        arrParam[3] = new OracleParameter("i_cod_mot_baja", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Cod_Motivo_Baja;

        arrParam[4] = new OracleParameter("i_fec_baja", OracleDbType.Date, ParameterDirection.Input);
        arrParam[4].Value = Convert.ToDateTime(c.Fec_Baja);

        arrParam[5] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = c.Observ;

        arrParam[6] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_repres.sp_baja_repres", arrParam);

        return Convert.ToInt32(arrParam[7].Value.ToString());


    }

    public string Agregar(BE_Directivo c)
    {
        OracleParameter[] arrParam = new OracleParameter[9];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Dni;

        arrParam[2] = new OracleParameter("i_cod_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Correl;

        arrParam[3] = new OracleParameter("i_cod_cargo", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Cod_Cargo;

        arrParam[4] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Observ;

        arrParam[5] = new OracleParameter("i_fec_carga", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = Convert.ToDateTime(c.Fec_Carga);

        arrParam[6] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_mensaje", OracleDbType.Varchar2, ParameterDirection.Output);

        arrParam[8] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_repres.sp_insert_repres", arrParam);

        return Convert.ToString(arrParam[7].Value.ToString());

    }

    public int Modificar(BE_Directivo c)
    {
        OracleParameter[] arrParam = new OracleParameter[10];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Correl;

        arrParam[2] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Dni;

        arrParam[3] = new OracleParameter("i_apepat_pe", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.ApePat_Pe;

        arrParam[4] = new OracleParameter("i_apemat_pe", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.ApeMat_Pe;

        arrParam[5] = new OracleParameter("i_nombre_pe", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = c.Nombre_Pe;

        arrParam[6] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = c.Observ;

        arrParam[7] = new OracleParameter("i_fec_carga", OracleDbType.Date, ParameterDirection.Input);
        arrParam[7].Value = Convert.ToDateTime(c.Fec_Carga);

        arrParam[8] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[8].Value = Yoo.UserId;

        arrParam[9] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_repres.sp_update_repres", arrParam);

        return Convert.ToInt32(arrParam[9].Value.ToString());

    }

    #endregion

}

