using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_Resolucion : DA_BASE
{


    public OracleDataReader Listar_Resoluciones(OracleConnection cn, BE_Resolucion c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_resolucionesOP_Cab_grid", ARRPARAM);
    }

    public OracleDataReader Listar_ResolucionDetalle(OracleConnection cn, BE_Resolucion c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Orden;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_resolucionesOP_Det_grid", ARRPARAM);

    }

    public OracleDataReader Listar_Resoluciones_Sueltas(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = 0;
        ARRPARAM[1] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_resoluciones_sueltas", ARRPARAM);
    }

    public OracleDataReader Obtener_Resolucion(OracleConnection cn, BE_Resolucion c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];
        ARRPARAM[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Orden;
        ARRPARAM[2] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_resolucionesOP_sel", ARRPARAM);
    }

    public int Resolucion_Repetida(BE_Resolucion c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_Tipo_Doc;
        arrParam[1] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.Des_Doc;
        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);        
        ORACLEHELPER.EjecutarQR("pkg_op.sp_resol_repetida", arrParam);
        return arrParam[2].Num();
    }


    public int Agregar(BE_Resolucion c)    {
        OracleParameter[] arrParam = new OracleParameter[22];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Des_Doc;

        arrParam[3] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.File_Name;

        arrParam[4] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[4].Value = c.Fec_Doc;

        arrParam[5] = new OracleParameter("i_fec_eleva", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Eleva;

        arrParam[6] = new OracleParameter("i_nro_resol_pleno", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = c.Nro_Resol_Pleno;

        arrParam[7] = new OracleParameter("i_file_resol_pleno", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = c.File_Resol_Pleno;

        arrParam[8] = new OracleParameter("i_fec_resol_pleno", OracleDbType.Date, ParameterDirection.Input);
        arrParam[8].Value = c.Fec_Resol_Pleno;

        arrParam[9] = new OracleParameter("i_cod_resul_pleno", OracleDbType.Char, ParameterDirection.Input);
        arrParam[9].Value = c.Cod_Resul_Pleno;

        arrParam[10] = new OracleParameter("i_nro_resol_pleno_ext", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = c.Nro_Resol_Pleno_Ext;

        arrParam[11] = new OracleParameter("i_file_resol_pleno_ext", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[11].Value = c.File_Resol_Pleno_Ext;

        arrParam[12] = new OracleParameter("i_fec_resol_pleno_ext", OracleDbType.Date, ParameterDirection.Input);
        arrParam[12].Value = c.Fec_Resol_Pleno_Ext;

        arrParam[13] = new OracleParameter("i_cod_resul_pleno_ext", OracleDbType.Char, ParameterDirection.Input);
        arrParam[13].Value = c.Cod_Resul_Pleno_Ext;

        arrParam[14] = new OracleParameter("i_flg_visible", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[14].Value = c.FLVISIBLE;

        arrParam[15] = new OracleParameter("i_fec_notif_pleno", OracleDbType.Date, ParameterDirection.Input);
        arrParam[15].Value = c.Fec_Notif_Pleno;

        arrParam[16] = new OracleParameter("i_fec_notif_ext", OracleDbType.Date, ParameterDirection.Input);
        arrParam[16].Value = c.Fec_Notif_Ext;

        arrParam[17] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[17].Value = Yoo.UserId;

        arrParam[18] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
        arrParam[18].Value = c.Cod_Tipo_Doc;

        arrParam[19] = new OracleParameter("i_cod_tipo_resol", OracleDbType.Char, ParameterDirection.Input);
        arrParam[19].Value = c.Cod_Tipo_Resol;

        arrParam[20] = new OracleParameter("o_orden", OracleDbType.Int32, ParameterDirection.Output);
        arrParam[21] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        
        ORACLEHELPER.EjecutarQR("pkg_op.sp_insert_resolucion", arrParam);

        return arrParam[21].Num();

    }

    public int Modificar(BE_Resolucion c)
    {
        OracleParameter[] arrParam = new OracleParameter[23];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;

        arrParam[2] = new OracleParameter("i_des_doc", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[2].Value = c.Des_Doc;

        arrParam[3] = new OracleParameter("i_file_name", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[3].Value = c.File_Name;

        arrParam[4] = new OracleParameter("i_fec_doc", OracleDbType.Date, ParameterDirection.Input);
        arrParam[4].Value = c.Fec_Doc;

        arrParam[5] = new OracleParameter("i_fec_eleva", OracleDbType.Date, ParameterDirection.Input);
        arrParam[5].Value = c.Fec_Eleva;

        arrParam[6] = new OracleParameter("i_nro_resol_pleno", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[6].Value = c.Nro_Resol_Pleno;

        arrParam[7] = new OracleParameter("i_file_resol_pleno", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[7].Value = c.File_Resol_Pleno;

        arrParam[8] = new OracleParameter("i_fec_resol_pleno", OracleDbType.Date, ParameterDirection.Input);
        arrParam[8].Value = c.Fec_Resol_Pleno;

        arrParam[9] = new OracleParameter("i_cod_resul_pleno", OracleDbType.Char, ParameterDirection.Input);
        arrParam[9].Value = c.Cod_Resul_Pleno;

        arrParam[10] = new OracleParameter("i_nro_resol_pleno_ext", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[10].Value = c.Nro_Resol_Pleno_Ext;

        arrParam[11] = new OracleParameter("i_file_resol_pleno_ext", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[11].Value = c.File_Resol_Pleno_Ext;

        arrParam[12] = new OracleParameter("i_fec_resol_pleno_ext", OracleDbType.Date, ParameterDirection.Input);
        arrParam[12].Value = c.Fec_Resol_Pleno_Ext;

        arrParam[13] = new OracleParameter("i_cod_resul_pleno_ext", OracleDbType.Char, ParameterDirection.Input);
        arrParam[13].Value = c.Cod_Resul_Pleno_Ext;

        arrParam[14] = new OracleParameter("i_flg_visible", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[14].Value = c.FLVISIBLE;

        arrParam[15] = new OracleParameter("i_observ", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[15].Value = c.Observ;

        arrParam[16] = new OracleParameter("i_fec_notif_pleno", OracleDbType.Date, ParameterDirection.Input);
        arrParam[16].Value = c.Fec_Notif_Pleno;

        arrParam[17] = new OracleParameter("i_fec_notif_ext", OracleDbType.Date, ParameterDirection.Input);
        arrParam[17].Value = c.Fec_Notif_Ext;

        arrParam[18] = new OracleParameter("i_userid", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[18].Value = Yoo.UserId;

        arrParam[19] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
        arrParam[19].Value = c.Cod_Tipo_Doc;

        arrParam[20] = new OracleParameter("i_cod_tipo_resol", OracleDbType.Char, ParameterDirection.Input);
        arrParam[20].Value = c.Cod_Tipo_Resol;

        arrParam[21] = new OracleParameter("o_orden", OracleDbType.Int32, ParameterDirection.Output);
        arrParam[22] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_resolucion", arrParam);

        return arrParam[22].Num();

    }

    public int Eliminar(BE_Resolucion c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_orden", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.Orden;
        arrParam[2] = new OracleParameter("i_cod_tipo_doc", OracleDbType.Char, ParameterDirection.Input);
        arrParam[2].Value = c.Cod_Tipo_Doc;
        arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);        
        ORACLEHELPER.EjecutarQR("pkg_op.sp_delete_resolucion", arrParam);
        return arrParam[3].Num();
    }

    public OracleDataReader Listar_Tipo_Resol(OracleConnection cn)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[1];
        ARRPARAM[0] = new OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_tipo_resol_cbo", ARRPARAM);
    }


}

