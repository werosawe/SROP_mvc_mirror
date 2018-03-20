using System;
using System.Data;
using Oracle.DataAccess.Client;


public class DA_ComiteLista : DA_BASE
{

    #region "Procedimientos de consulta"

    public OracleDataReader Listar_Comites(OracleConnection CN, Int32 Cod_OP, Int32 Nro_Entrega)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = Nro_Entrega;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_comites_grid", ARRPARAM);
    }

    public OracleDataReader Listar_Comites_Uniq(OracleConnection CN, Int32 Cod_OP, string str_entregas)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];


        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_str_entregas", OracleDbType.Varchar2, ParameterDirection.Input);
        ARRPARAM[1].Value = str_entregas;
        // "2,3"

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_listar_comites_uniq", ARRPARAM);

    }

    public OracleDataReader Listar_Comites_Dist(OracleConnection cn, BE_ComiteLista c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.UBIREGION.Num();

        ARRPARAM[2] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[2].Value = c.UBIPROVINCIA.Num();

        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(cn, "pkg_comites.sp_comites_dist_grid", ARRPARAM);
    }

    public int Numero_Provincias(BE_ComiteLista c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.UBIREGION.Num();

        arrParam[2] = new OracleParameter("o_num_prov", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_cantidad_prov", arrParam);

        return Convert.ToInt32(arrParam[2].Value.ToString());


    }

    public int Numero_Distritos(BE_ComiteLista c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.UBIREGION.Num();

        arrParam[2] = new OracleParameter("i_provincia", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.UBIPROVINCIA.Num();

        arrParam[3] = new OracleParameter("o_num_dist", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_cantidad_dist", arrParam);

        return Convert.ToInt32(arrParam[3].Value.ToString());


    }


    #endregion

    #region "Procedimientos de transaccion"

    public int Agregar(BE_ComiteLista c)
    {
        OracleParameter[] arrParam = new OracleParameter[7];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.UBIREGION.Num();

        arrParam[2] = new OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.UBIPROVINCIA.Num();

        arrParam[3] = new OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.UBIDISTRITO.Num();

        arrParam[4] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = Yoo.UserId;

        arrParam[5] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.Nro_Entrega;

        arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_insert_comites", arrParam);

        return Convert.ToInt32(arrParam[6].Value.ToString());


    }

    public int Modificar(BE_ComiteLista c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Entrega;

        arrParam[2] = new OracleParameter("i_dir_comite", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Dir_Comite;

        arrParam[3] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.UBIREGION.Num();

        arrParam[4] = new OracleParameter("i_ubiprov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[4].Value = c.UBIPROVINCIA.Num();

        arrParam[5] = new OracleParameter("i_ubidist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.UBIDISTRITO.Num();

        arrParam[6] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_update_comites", arrParam);

        return Convert.ToInt32(arrParam[7].Value.ToString());


    }

    public int Eliminar(BE_ComiteLista c)
    {
        OracleParameter[] arrParam = new OracleParameter[7];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Entrega;

        arrParam[2] = new OracleParameter("i_region", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.UBIREGION.Num();

        arrParam[3] = new OracleParameter("i_prov", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.UBIPROVINCIA.Num();

        arrParam[4] = new OracleParameter("i_dist", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[4].Value = c.UBIDISTRITO.Num();

        arrParam[5] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = Yoo.UserId;

        arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_delete_comite", arrParam);

        return Convert.ToInt32(arrParam[6].Value.ToString());


    }
    #endregion
}
