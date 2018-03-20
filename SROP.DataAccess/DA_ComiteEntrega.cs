using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_ComiteEntrega : DA_BASE
{
    public OracleDataReader Listar_Entregas(OracleConnection CN, Int32 Cod_OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_entregacomites_grid", ARRPARAM);

    }

    public OracleDataReader Selecciona_Entrega(OracleConnection CN, Int32 Cod_OP, int nro_entrega)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = nro_entrega;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_comites.sp_entregacomites_sel", ARRPARAM);

    }

   
    #region "Procedimientos de transaccion"

    public int Agregar(BE_ComiteEntrega c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = Yoo.UserId;

        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_insert_entregacomites", arrParam);

        return Convert.ToInt32(arrParam[2].Value.ToString());


    }

    public int Modificar(BE_ComiteEntrega c)
    {
        OracleParameter[] arrParam = new OracleParameter[6];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Entrega;

        arrParam[2] = new OracleParameter("i_fec_carga", OracleDbType.Date, ParameterDirection.Input);
        arrParam[2].Value = Convert.ToDateTime(c.Fec_Carga);

        arrParam[3] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Observ;

        arrParam[4] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = Yoo.UserId;

        arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_update_comites_ent", arrParam);

        return Convert.ToInt32(arrParam[5].Value.ToString());


    }

    public int Eliminar(BE_ComiteEntrega c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_nro_entrega", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Entrega;

        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_comites.sp_delete_entregacomites", arrParam);

        return Convert.ToInt32(arrParam[2].Value.ToString());


    }

    public int Update_Carga_FIN(BE_ComiteEntrega c)
    {
        OracleParameter[] arrParam = new OracleParameter[5];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_cargafin", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.CargaFin * -1;

        arrParam[2] = new OracleParameter("i_tipo", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.TipoCargaFin;

        arrParam[3] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = Yoo.UserId;

        arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_OP.SP_UPdate_CargaFIN", arrParam);

        return Convert.ToInt32(arrParam[4].Value.ToString());


    }

    #endregion

}

