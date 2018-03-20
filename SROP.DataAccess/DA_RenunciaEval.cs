using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_RenunciaEval : DA_BASE
{

    #region "Procedimientos de transaccion"

    //Comentario prueba

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

        arrParam[4] = new OracleParameter("o_return", OracleDbType.Int32);
        arrParam[4].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_exp_op.sp_insert_asigna_abog", arrParam);

        return Convert.ToString(arrParam[4].Value.ToString());

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

        ORACLEHELPER.EjecutarQR("pkg_exp_op.sp_delete_asigna_abog", arrParam);

        return Convert.ToString(arrParam[4].Value.ToString());

    }

    #endregion

    #region "Procedimientos de consulta"
    public OracleDataReader Listar_Cab_RenunEval(OracleConnection CN, BE_RenunciaEval BE_List)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];

        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_renuncia.sp_lista_cab_renuneval", ARRPARAM);

    }

    public OracleDataReader Listar_Det_RenunEval(OracleConnection CN, BE_RenunciaEval BE_List)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];

        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_renuncia.sp_lista_det_renuneval", ARRPARAM);


    }


    #endregion
}

