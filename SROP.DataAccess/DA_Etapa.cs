using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
public class DA_Etapa : DA_BASE
{

    public OracleDataReader Gets(OracleConnection cn, BE_Etapa c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_etapasInsc_grid", pr);
    }

    public OracleDataReader GetQTEtapa(OracleConnection cn, BE_Etapa c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.GetQTEtapa", pr);
    }

    public OracleDataReader Get(OracleConnection cn, BE_Etapa c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("i_cod_correlativo", OracleDbType.Int32, ParameterDirection.Input);
        pr[1].Value = c.Cod_Correlativo;
        pr[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_etapasInsc_sel", pr);
    }

    public int Insertar(BE_Etapa c)
    {
        OracleParameter[] arrParam = new OracleParameter[18];

        arrParam[0] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = c.MTDCODEXPEDIENTE;

        arrParam[1] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.MTDCODDOCUMENTO;

        arrParam[2] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_OP;

        arrParam[3] = new OracleParameter("i_cod_correlativo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.Cod_Correlativo;

        arrParam[4] = new OracleParameter("i_cod_tipo_etapa", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tipo_Etapa;

        arrParam[5] = new OracleParameter("i_fec_estado_insc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Estado_Insc;

        arrParam[6] = new OracleParameter("i_cod_est_insc", OracleDbType.Char, ParameterDirection.Input);
        arrParam[6].Value = c.Cod_Est_Insc;

        arrParam[7] = new OracleParameter("i_cod_tipo_cancel", OracleDbType.Char, ParameterDirection.Input);
        arrParam[7].Value = c.Cod_Tipo_Cancel;

        arrParam[8] = new OracleParameter("i_cod_ente", OracleDbType.Char, ParameterDirection.Input);
        arrParam[8].Value = c.Cod_Ente;

        arrParam[9] = new OracleParameter("i_des_num_resol", OracleDbType.Char, ParameterDirection.Input);
        arrParam[9].Value = c.Des_Num_Resol;

        arrParam[10] = new OracleParameter("i_des_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = c.Des_Observ;

        arrParam[11] = new OracleParameter("i_hor", OracleDbType.Char, ParameterDirection.Input);
        arrParam[11].Value = c.Hor;

        arrParam[12] = new OracleParameter("i_min", OracleDbType.Char, ParameterDirection.Input);
        arrParam[12].Value = c.Min;

        arrParam[13] = new OracleParameter("i_seg", OracleDbType.Char, ParameterDirection.Input);
        arrParam[13].Value = c.Seg;

        arrParam[14] = new OracleParameter("i_ampm", OracleDbType.Char, ParameterDirection.Input);
        arrParam[14].Value = c.AmPm;

        arrParam[15] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[15].Value = Yoo.UserId;

        arrParam[16] = new OracleParameter("o_cod_correl", OracleDbType.Int32, ParameterDirection.Output);

        arrParam[17] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);


        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_ins_etapa_insc", arrParam);

        return Convert.ToInt32(arrParam[16].Value.ToString());

    }

    public int Agregar(BE_Etapa c)
    {
        OracleParameter[] arrParam = new OracleParameter[18];

        arrParam[0] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = c.MTDCODEXPEDIENTE;

        arrParam[1] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.MTDCODDOCUMENTO;

        arrParam[2] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_OP;

        arrParam[3] = new OracleParameter("i_cod_correlativo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.Cod_Correlativo;

        arrParam[4] = new OracleParameter("i_cod_tipo_etapa", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tipo_Etapa;

        arrParam[5] = new OracleParameter("i_fec_estado_insc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Estado_Insc;

        arrParam[6] = new OracleParameter("i_cod_est_insc", OracleDbType.Char, ParameterDirection.Input);
        arrParam[6].Value = c.Cod_Est_Insc;

        arrParam[7] = new OracleParameter("i_cod_tipo_cancel", OracleDbType.Char, ParameterDirection.Input);
        arrParam[7].Value = c.Cod_Tipo_Cancel;

        arrParam[8] = new OracleParameter("i_cod_ente", OracleDbType.Char, ParameterDirection.Input);
        arrParam[8].Value = c.Cod_Ente;

        arrParam[9] = new OracleParameter("i_des_num_resol", OracleDbType.Char, ParameterDirection.Input);
        arrParam[9].Value = c.Des_Num_Resol;

        arrParam[10] = new OracleParameter("i_des_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = c.Des_Observ;

        arrParam[11] = new OracleParameter("i_hor", OracleDbType.Char, ParameterDirection.Input);
        arrParam[11].Value = c.Hor;

        arrParam[12] = new OracleParameter("i_min", OracleDbType.Char, ParameterDirection.Input);
        arrParam[12].Value = c.Min;

        arrParam[13] = new OracleParameter("i_seg", OracleDbType.Char, ParameterDirection.Input);
        arrParam[13].Value = c.Seg;

        arrParam[14] = new OracleParameter("i_ampm", OracleDbType.Char, ParameterDirection.Input);
        arrParam[14].Value = c.AmPm;

        arrParam[15] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[15].Value = Yoo.UserId;

        arrParam[16] = new OracleParameter("o_cod_correl", OracleDbType.Int32, ParameterDirection.Output);

        arrParam[17] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);


        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_append_etapa_insc", arrParam);

        return Convert.ToInt32(arrParam[16].Value.ToString());

    }

    public int Actualizar(BE_Etapa c)
    {
        OracleParameter[] arrParam = new OracleParameter[18];

        arrParam[0] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = c.MTDCODEXPEDIENTE;

        arrParam[1] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.MTDCODDOCUMENTO;

        arrParam[2] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_OP;

        arrParam[3] = new OracleParameter("i_cod_correlativo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.Cod_Correlativo;

        arrParam[4] = new OracleParameter("i_cod_tipo_etapa", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tipo_Etapa;

        arrParam[5] = new OracleParameter("i_fec_estado_insc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Estado_Insc;

        arrParam[6] = new OracleParameter("i_cod_est_insc", OracleDbType.Char, ParameterDirection.Input);
        arrParam[6].Value = c.Cod_Est_Insc;

        arrParam[7] = new OracleParameter("i_cod_tipo_cancel", OracleDbType.Char, ParameterDirection.Input);
        arrParam[7].Value = c.Cod_Tipo_Cancel;

        arrParam[8] = new OracleParameter("i_cod_ente", OracleDbType.Char, ParameterDirection.Input);
        arrParam[8].Value = c.Cod_Ente;

        arrParam[9] = new OracleParameter("i_des_num_resol", OracleDbType.Char, ParameterDirection.Input);
        arrParam[9].Value = c.Des_Num_Resol;

        arrParam[10] = new OracleParameter("i_des_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = c.Des_Observ;

        arrParam[11] = new OracleParameter("i_hor", OracleDbType.Char, ParameterDirection.Input);
        arrParam[11].Value = c.Hor;

        arrParam[12] = new OracleParameter("i_min", OracleDbType.Char, ParameterDirection.Input);
        arrParam[12].Value = c.Min;

        arrParam[13] = new OracleParameter("i_seg", OracleDbType.Char, ParameterDirection.Input);
        arrParam[13].Value = c.Seg;

        arrParam[14] = new OracleParameter("i_ampm", OracleDbType.Char, ParameterDirection.Input);
        arrParam[14].Value = c.AmPm;

        arrParam[15] = new OracleParameter("i_user", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[15].Value = Yoo.UserId;

        arrParam[16] = new OracleParameter("o_cod_correl", OracleDbType.Int32, ParameterDirection.Output);
        arrParam[17] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_update_etapa_insc", arrParam);

        return arrParam[16].Num();
    }

    public int Eliminar(BE_Etapa c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_cod_correlativo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Correlativo;
        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_delete_etapa_insc", arrParam);
        return Convert.ToInt32(arrParam[0].Value.ToString());
    }
    
} 

