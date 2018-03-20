using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

public class DA_ActaFundacion : DA_BASE
{
    public OracleDataReader Listar_ActasFundacion(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input) { Value = c.Cod_OP };
        ARRPARAM[1] = new OracleParameter("i_cod_req", OracleDbType.Char, 2, ParameterDirection.Input) { Value = c.COD_REQUISITO };
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_req_actafund_estatu_grid", ARRPARAM);
    }

    public int Grabar_Registros(BE_ActaFundacion c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input) { Value = c.Cod_OP };
        arrParam[1] = new OracleParameter("i_cod_req", OracleDbType.Char, ParameterDirection.Input) { Value = c.Cod_Req };
        arrParam[2] = new OracleParameter("i_cod_item", OracleDbType.Char, ParameterDirection.Input) { Value = c.Cod_Item }; 
        arrParam[3] = new OracleParameter("i_flg_cumple", OracleDbType.Int16, ParameterDirection.Input) { Value = c.FLCUMPLE };
        arrParam[4] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input) { Value = c.Observ };
        arrParam[5] = new OracleParameter("i_art_doc", OracleDbType.Varchar2, ParameterDirection.Input) { Value = c.Art_Doc };
        arrParam[6] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input) { Value = Yoo.UserId };
        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_requisitos.SP_Update_OP_Docs_01", arrParam);
        return (int)arrParam[7].Value;
    }

    public int Grabar_CheckReq(BE_ActaFundacion c)
    {
        OracleParameter[] arrParam = new OracleParameter[6];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input) { Value = c.Cod_OP };
        arrParam[1] = new OracleParameter("i_cod_req", OracleDbType.Char, ParameterDirection.Input) { Value = c.Cod_Req };
        arrParam[2] = new OracleParameter("i_flg_cumple", OracleDbType.Int16, ParameterDirection.Input) { Value = c.FLCUMPLE };
        arrParam[3] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input) { Value = c.Observ };
        arrParam[4] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input) { Value = Yoo.UserId };
        arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_requisitos.SP_Update_Req_02", arrParam);
        return (int)arrParam[5].Value;
    }

}

