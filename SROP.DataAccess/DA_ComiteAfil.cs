using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_ComiteAfil : DA_BASE
{

    #region "Procedimientos de consulta"

    public OracleDataReader Listar_Afiliados(OracleConnection cn, BE_ComiteAfil c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[6];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Nro_Entrega;

        ARRPARAM[2] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[2].Value = c.UBIREGION.Num();

        ARRPARAM[3] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[3].Value = c.UBIPROVINCIA.Num();

        ARRPARAM[4] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[4].Value = c.UBIDISTRITO.Num();

        ARRPARAM[5] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(cn, "pkg_comites.sp_comites_afil_grid", ARRPARAM);

    }

    public OracleDataReader Listar_Afiliados_Busq(OracleConnection CN, BE_ComiteAfil c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[7];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Nro_Entrega;

        ARRPARAM[2] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[2].Value = c.UBIREGION.Num();

        ARRPARAM[3] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[3].Value = c.UBIPROVINCIA.Num();

        ARRPARAM[4] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[4].Value = c.UBIDISTRITO.Num();

        ARRPARAM[5] = new OracleParameter("i_search", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[5].Value = c.Cond_Busqueda;

        ARRPARAM[6] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_comites_afil_grid_busq", ARRPARAM);


    }

    public OracleDataReader Listar_MotivoBaja(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];

        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_motivobaja_grid", ARRPARAM);

    }

    #endregion

    #region "Procedimientos de transaccion"

    public int Agregar(BE_ComiteAfil c)
    {
        OracleParameter[] arrParam = new OracleParameter[9];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Entrega;

        arrParam[2] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Dni;

        arrParam[3] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.UBIREGION.Num();

        arrParam[4] = new OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[4].Value = c.UBIPROVINCIA.Num();

        arrParam[5] = new OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.UBIDISTRITO.Num();

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("i_tipo_insert", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = c.Tipo_Insercion;

        arrParam[8] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_insert_comites_afil", arrParam);

        return Convert.ToInt32(arrParam[8].Value.ToString());

    }

    public int Modificar(BE_ComiteAfil c)
    {
        OracleParameter[] arrParam = new OracleParameter[10];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Entrega;

        arrParam[2] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Dni;

        arrParam[3] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.UBIREGION.Num();

        arrParam[4] = new OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[4].Value = c.UBIPROVINCIA.Num();

        arrParam[5] = new OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.UBIDISTRITO.Num();

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("i_cod_motivo_baja", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[7].Value = c.Cod_Motivo_Baja;

        arrParam[8] = new OracleParameter("i_flg_DJ", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[8].Value = c.FLDJ;

        arrParam[9] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_update_comites_afil", arrParam);

        return Convert.ToInt32(arrParam[9].Value.ToString());

    }

    public int Eliminar(BE_ComiteAfil oBE_ComiteAfil)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = oBE_ComiteAfil.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = oBE_ComiteAfil.Nro_Entrega;

        arrParam[2] = new OracleParameter("i_cod_dni", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = oBE_ComiteAfil.Cod_Dni;

        arrParam[3] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = oBE_ComiteAfil.UBIREGION.Num();

        arrParam[4] = new OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[4].Value = oBE_ComiteAfil.UBIPROVINCIA.Num();

        arrParam[5] = new OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = oBE_ComiteAfil.UBIDISTRITO.Num();

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32);
        arrParam[7].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_delete_comite_afil", arrParam);

        return Convert.ToInt32(arrParam[7].Value.ToString());

    }

    public string Mensaje_Ubigeo(BE_ComiteAfil oBE_ComiteAfil)
    {
        OracleParameter[] arrParam = new OracleParameter[5];


        arrParam[0] = new OracleParameter("i_ubireg", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = oBE_ComiteAfil.UBIREGION.Num();

        arrParam[1] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = oBE_ComiteAfil.UBIPROVINCIA.Num();

        arrParam[2] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = oBE_ComiteAfil.UBIDISTRITO.Num();

        arrParam[3] = new OracleParameter("o_mensaje", OracleDbType.Varchar2, 200);
        arrParam[3].Direction = ParameterDirection.Output;

        arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32);
        arrParam[4].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_listar.sp_get_ubigeo", arrParam);

        return arrParam[3].Value.ToString();

    }

    public string Es_ComiteVerificado(BE_ComiteAfil c)
    {
        OracleParameter[] arrParam = new OracleParameter[7];


        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_cod_dni", OracleDbType.Char, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Dni;

        arrParam[2] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Nro_Entrega;

        arrParam[3] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.UBIREGION.Num();

        arrParam[4] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[4].Value = c.UBIPROVINCIA.Num();

        arrParam[5] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.UBIDISTRITO.Num();

        arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_Comite_Verificado", arrParam);

        return arrParam[6].Value.ToString();

    }

    #endregion

}

