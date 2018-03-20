using System;
using System.Data;
using Oracle.DataAccess.Client;



public class DA_Sintesis : DA_BASE
{


    public OracleDataReader Gets(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_sintesis_grid", ARRPARAM);
    }

    public OracleDataReader Get(OracleConnection cn, BE_Sintesis c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_sintesis_sel", ARRPARAM);

    }


    public int Agregar(BE_Sintesis c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32);
        arrParam[7].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_op.???", arrParam);

        return Convert.ToInt32(arrParam[7].Value.ToString());


    }

    public int Modificar(BE_Sintesis c)
    {
        OracleParameter[] arrParam = new OracleParameter[20];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.File_Name;
        arrParam[2] = new OracleParameter("i_file_path", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.File_Path;
        arrParam[3] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[3].Value = Convert.ToDateTime(c.Fec_Doc);
        arrParam[4] = new OracleParameter("i_tx_sintesinsc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Tx_SintesInsc;
        arrParam[5] = new OracleParameter("i_tx_simbolo", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[5].Value = c.Tx_Simbolo;
        arrParam[6] = new OracleParameter("i_tx_des_op", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = c.Tx_Des_OP;
        arrParam[7] = new OracleParameter("i_tx_siglas", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = c.tx_Siglas;
        arrParam[8] = new OracleParameter("i_tx_fundadores", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[8].Value = c.Tx_Fundadores;
        arrParam[9] = new OracleParameter("i_tx_dirigentes", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[9].Value = c.Tx_Dirigentes;
        arrParam[10] = new OracleParameter("i_tx_apoderados", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = c.Tx_Apoderados;
        arrParam[11] = new OracleParameter("i_tx_persolegal", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[11].Value = c.Tx_PersoLegal;
        arrParam[12] = new OracleParameter("i_tx_persotecni", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[12].Value = c.Tx_PersoTecni;
        arrParam[13] = new OracleParameter("i_tx_reprelegal", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[13].Value = c.Tx_RepreLegal;
        arrParam[14] = new OracleParameter("i_tx_tesorero", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[14].Value = c.Tx_Tesorero;
        arrParam[15] = new OracleParameter("i_tx_domiclegal", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[15].Value = c.Tx_Domiclegal;
        arrParam[16] = new OracleParameter("i_tx_resumenestatuto", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[16].Value = c.Tx_ResumenEstatuto;
        arrParam[17] = new OracleParameter("i_flg_visible", OracleDbType.Int16, ParameterDirection.Input);
        arrParam[17].Value = c.Visible;
        arrParam[18] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[18].Value = Yoo.UserId;
        arrParam[19] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);        
        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_sintesis", arrParam);        
        return arrParam[19].Num();
    }

    public int Eliminar(BE_Sintesis c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = Yoo.UserId;
        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);        
        ORACLEHELPER.EjecutarQR("pkg_op.sp_delete_sintesis", arrParam);
        return arrParam[2].Num();

    }

    public OracleDataReader GetSimbolo(OracleConnection cn, BE_Sintesis c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_simbolo_sintesis_sel", ARRPARAM);
    }

    public void GuardarSimbolo(BE_Sintesis c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("BLARCHIVO", OracleDbType.Blob, ParameterDirection.Input);
        pr[1].Value = c.BLARCHIVO;
        ORACLEHELPER.EjecutarQR("Pkg_OP.sp_save_blob_sintesis", pr);
    }



}

