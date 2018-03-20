using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


public class DA_Estatuto : DA_BASE
{


    public OracleDataReader Gets(OracleConnection cn, BE_Estatuto c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_estatutos_op_grid", ARRPARAM);
    }

    public OracleDataReader Get(OracleConnection cn, BE_Estatuto c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Orden;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_estatutos_sel", ARRPARAM);
    }


    public int Agregar(BE_Estatuto c)
    {
        OracleParameter[] arrParam = new OracleParameter[10];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Des_Doc;

        arrParam[3] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[3].Value = Convert.ToDateTime(c.Fec_Doc);

        arrParam[4] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.File_Name;

        arrParam[5] = new OracleParameter("i_flg_visible", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.FLVISIBLE;

        arrParam[6] = new OracleParameter("i_anos_vigencia_cargo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[6].Value = c.Anos_Vigencia_Cargo;

        arrParam[7] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = Yoo.UserId;

        arrParam[8] = new OracleParameter("o_orden", OracleDbType.Int32, ParameterDirection.Output);
        arrParam[8].Value = c.Orden;

        arrParam[9] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_insert_estatuto_op", arrParam);

        return arrParam[8].Num();

    }

    public int Modificar(BE_Estatuto c)
    {
        OracleParameter[] arrParam = new OracleParameter[10];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Des_Doc;

        arrParam[3] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[3].Value = Convert.ToDateTime(c.Fec_Doc);

        arrParam[4] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.File_Name;

        arrParam[5] = new OracleParameter("i_flg_visible", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[5].Value = c.FLVISIBLE;

        arrParam[6] = new OracleParameter("i_anos_vigencia_cargo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[6].Value = c.Anos_Vigencia_Cargo;

        arrParam[7] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = Yoo.UserId;

        arrParam[8] = new OracleParameter("o_orden", OracleDbType.Int32, ParameterDirection.Output);
        arrParam[8].Value = c.Orden;

        arrParam[9] = new OracleParameter("o_return", OracleDbType.Int32);
        arrParam[9].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_estatuto_op", arrParam);

        return arrParam[8].Num();

    }

    public int Eliminar(BE_Estatuto c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_delete_estatuto_op", arrParam);

        return arrParam[2].Num();


    }


}

