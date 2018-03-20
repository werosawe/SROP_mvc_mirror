using System;
using System.Data;
using Oracle.DataAccess.Client;
public class DA_Partida : DA_BASE
{

    public OracleDataReader Gets(OracleConnection cn,  BE_Partida c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_tareas_cab_grid", ARRPARAM);
    }

    public OracleDataReader Get(OracleConnection cn, BE_Partida c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_cod_Id_Correl", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Id_Correl;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_tareas_cab_sel", ARRPARAM);
    }

    public OracleDataReader Listar_Asignacion_Tareas(OracleConnection cn, BE_Partida c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_id_correl", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Id_Correl;
        ARRPARAM[2] = new OracleParameter("i_id_asig_abogado", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[2].Value = c.Id_Asig_Abogado;
        ARRPARAM[3] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_tareas_det_grid", ARRPARAM);
    }

    public OracleDataReader Listar_Tareas_Cbo(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_tareas_cbo", ARRPARAM);
    }

    public OracleDataReader Listar_TipoDocs_Cbo(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_tipodocs_cbo", ARRPARAM);
    }

    public OracleDataReader Listar_Resultados_Cbo(OracleConnection CN)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];


        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_resultados_cbo", ARRPARAM);

    }


    public OracleDataReader Listar_Tareas_Pendientes_Abog(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_reportes.sp_listar_tareas_pend_x_tarea", ARRPARAM);
    }


    public int Agregar_Partida(BE_Partida c)
    {
        OracleParameter[] arrParam = new OracleParameter[11];


        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Exp_Mtd;

        arrParam[2] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Doc_Mtd;

        arrParam[3] = new OracleParameter("i_Id_asig_abogado", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.Id_Asig_Abogado;

        arrParam[4] = new OracleParameter("i_fec_asig", OracleDbType.Date, ParameterDirection.Input);
        arrParam[4].Value = c.Fec_Asig;

        arrParam[5] = new OracleParameter("i_fec_recep", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Recep;

        arrParam[6] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
        arrParam[6].Value = c.Fec_Fin;

        arrParam[7] = new OracleParameter("i_num_dias_est", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[7].Value = c.Num_Dias_Est;

        arrParam[8] = new OracleParameter("i_observaciones", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[8].Value = c.Observaciones;

        arrParam[9] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[9].Value = Yoo.UserId;

        arrParam[10] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);


        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_insert_tarea_cab", arrParam);

        return arrParam[10].Num();

    }

    public int Modificar_Partida(BE_Partida c)
    {
        OracleParameter[] arrParam = new OracleParameter[12];


        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_id_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Id_Correl;

        arrParam[2] = new OracleParameter("i_Id_asig_abogado", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Id_Asig_Abogado;

        arrParam[3] = new OracleParameter("i_cod_exp_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.Cod_Exp_Mtd;

        arrParam[4] = new OracleParameter("i_cod_doc_mtd", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Doc_Mtd;

        arrParam[5] = new OracleParameter("i_fec_asig", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Asig;

        arrParam[6] = new OracleParameter("i_fec_recep", OracleDbType.Date, ParameterDirection.Input);
        arrParam[6].Value = c.Fec_Recep;

        arrParam[7] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
        arrParam[7].Value = c.Fec_Fin;

        arrParam[8] = new OracleParameter("i_num_dias_est", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[8].Value = c.Num_Dias_Est;

        arrParam[9] = new OracleParameter("i_observaciones", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[9].Value = c.Observaciones;

        arrParam[10] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = Yoo.UserId;

        arrParam[11] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);


        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_update_tarea_cab", arrParam);

        return arrParam[11].Num();


    }

    public int Eliminar_Partida(BE_Partida c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];


        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_id_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Id_Correl;

        arrParam[2] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = Yoo.UserId;

        arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Direction = ParameterDirection.Output;

        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_delete_tarea_cab", arrParam);

        return arrParam[3].Num();

    }

    public int Agregar_Detalle(BE_Partida c)
    {
        OracleParameter[] arrParam = new OracleParameter[8];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_Id_asig_abogado", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Id_Asig_Abogado;
        arrParam[2] = new OracleParameter("i_id_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Id_Correl;
        arrParam[3] = new OracleParameter("i_fec_asig", OracleDbType.Date, ParameterDirection.Input);
        arrParam[3].Value = c.Fec_Asig;
        arrParam[4] = new OracleParameter("i_cod_tarea", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tarea;
        arrParam[5] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Fin;
        arrParam[6] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = Yoo.UserId;
        arrParam[7] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[7].Direction = ParameterDirection.Output;
        ORACLEHELPER.EjecutarQR("pkg_exp_op.sp_insert_tarea_det", arrParam);
        return arrParam[7].Num();
    }

    public int Modificar_Detalle(BE_PartidaDetalle c)
    {
        OracleParameter[] arrParam = new OracleParameter[11];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_id_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Id_Correl;
        arrParam[2] = new OracleParameter("i_Id_asig_abogado", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Id_Asig_Abogado;
        arrParam[3] = new OracleParameter("i_id_asig_tarea", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.Id_Asig_Tarea;
        arrParam[4] = new OracleParameter("i_cod_tarea", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tarea;
        arrParam[5] = new OracleParameter("i_fec_fin", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Fin;
        arrParam[6] = new OracleParameter("i_tipo_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = c.Tipo_Doc;
        arrParam[7] = new OracleParameter("i_num_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = c.Num_Doc;
        arrParam[8] = new OracleParameter("i_resultado", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[8].Value = c.Resultado;
        arrParam[9] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[9].Value = Yoo.UserId;
        arrParam[10] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_update_tarea_det", arrParam);
        return arrParam[10].Num();
    }

    public int Eliminar_Detalle(BE_PartidaDetalle c)
    {
        OracleParameter[] arrParam = new OracleParameter[6];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_id_correl", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Id_Correl;
        arrParam[2] = new OracleParameter("i_Id_asig_abogado", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[2].Value = c.Id_Asig_Abogado;
        arrParam[3] = new OracleParameter("i_id_asig_tarea", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[3].Value = c.Id_Asig_Tarea;
        arrParam[4] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[4].Value = Yoo.UserId;
        arrParam[5] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_Exp_OP.sp_delete_tarea_det", arrParam);
        return arrParam[5].Num();
    }






    public DateTime Add_Working_Days(DateTime start_Date, int nDays)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("start_date", OracleDbType.Date, ParameterDirection.Input);
        arrParam[0].Value = start_Date;
        arrParam[1] = new OracleParameter("days", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = nDays;
        arrParam[2] = new OracleParameter("o_retDate", OracleDbType.Date, ParameterDirection.Output);
        arrParam[2].Size = 10;
        ORACLEHELPER.EjecutarQR("p_add_working_days", arrParam);

        return Convert.ToDateTime(arrParam[2].Value);


    }
    public void GuardarSimbolo(BE_Partida c)
    {
        OracleParameter[] pr = new OracleParameter[4];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("Id_Correl", OracleDbType.Int32, ParameterDirection.Input);
        pr[1].Value = c.Id_Correl;
        pr[2] = new OracleParameter("Id_Asig_Abogado", OracleDbType.Int32, ParameterDirection.Input);
        pr[2].Value = c.Id_Asig_Abogado;
        pr[3] = new OracleParameter("BLARCHIVO", OracleDbType.Blob, ParameterDirection.Input);
        pr[3].Value = c.BLARCHIVO;
        ORACLEHELPER.EjecutarQR("Pkg_OP.sp_save_simbolo_blob_modpart", pr);
    }
  

    public OracleDataReader GetSimbolo(OracleConnection cn, BE_Partida c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("I_ID_CORREL", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Id_Correl;
        ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_simbolo_op_modpart", ARRPARAM);
    }


}

