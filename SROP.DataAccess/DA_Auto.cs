using System;
using System.Data;
using Oracle.DataAccess.Client;


public class DA_Auto : DA_BASE
{

    #region "Procedimientos de consulta"

    public OracleDataReader Listar_Autos(OracleConnection CN, Int32 Cod_OP, Int32 Orden)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];


        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = Orden;

        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_autos_grid", ARRPARAM);

    }
    #endregion

    #region "Procedimientos de transaccion"

    public int Agregar(BE_Auto c)
    {
        OracleParameter[] arrParam = new OracleParameter[7];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Des_Doc;

        arrParam[3] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.File_Name;

        arrParam[4] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        if (c.Fec_Doc == null)
        {
            arrParam[4].Value = DBNull.Value;
        }
        else
        {
            arrParam[4].Value = c.Fec_Doc;
        }

        arrParam[5] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = Yoo.UserId;

        arrParam[6] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_insert_auto", arrParam);

        return (int)arrParam[6].Value;

    }

    public int Modificar(BE_Auto c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_cod_auto", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Auto;

        arrParam[3] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Des_Doc;

        arrParam[4] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.File_Name;

        arrParam[5] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = Convert.ToDateTime(c.Fec_Doc);

        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_auto", arrParam);

        return Convert.ToInt32(arrParam[7].Value.ToString());

    }

    public int Eliminar(BE_Auto c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];


        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_cod_auto", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Auto;

        arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_delete_auto", arrParam);

        return Convert.ToInt32((arrParam[3].Value.ToString()));

    }
    #endregion

}

