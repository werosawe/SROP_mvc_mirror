using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Oracle.DataAccess.Client;

//Imports Oracle.DataAccess.Types
//Imports Utilitario

public class DA_Abogado : DA_BASE
{
    public string Agregar(BE_Abogado c)
    {
        OracleParameter[] arrParam = new OracleParameter[5];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_useridasis", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.UserIdaSis;
        arrParam[2] = new OracleParameter("i_fec_ini", OracleDbType.Date, ParameterDirection.Input);
        arrParam[2].Value = c.Fec_Ini;
        arrParam[3] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = Yoo.UserId;
        arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_exp_op.sp_insert_asigna_abog", arrParam);
        return (string)arrParam[4].Value;
    }

    public string Eliminar(BE_Abogado c)
    {
        OracleParameter[] arrParam = new OracleParameter[5];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_useridasis", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.UserIdaSis;
        arrParam[2] = new OracleParameter("i_fec_ini", OracleDbType.Date, ParameterDirection.Input);
        arrParam[2].Value = c.Fec_Ini;
        arrParam[3] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = Yoo.UserId;
        arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        arrParam[4].Direction = ParameterDirection.Output;
        ORACLEHELPER.EjecutarQR("pkg_exp_op.sp_delete_asigna_abog", arrParam);
        return (string)arrParam[4].Value;
    }



    public OracleDataReader Listar_Abogado(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_abogado_cbo", ARRPARAM);
    }

    public OracleDataReader Get_Last_Abogado_OP(OracleConnection CN, BE_Abogado c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;

        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_abogado_sel", ARRPARAM);

    }

    public OracleDataReader Listar_AsistentexOP(OracleConnection CN, int Cod_OP)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = Cod_OP;

        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_asistentesxop_grid", ARRPARAM);

    }

}

