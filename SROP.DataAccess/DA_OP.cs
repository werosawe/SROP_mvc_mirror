using System;
using System.Data;
using Oracle.DataAccess.Client;

public class DA_OP : DA_BASE
{
        public OracleDataReader Listar_OPs(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[3];

        ARRPARAM[0] = new OracleParameter("I_USERID", OracleDbType.NVarchar2, 100, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        //este parametro no se usa, implementar en el stored procedure

        ARRPARAM[1] = new OracleParameter("I_DESCRIPCION", OracleDbType.NVarchar2, 100, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Des_OP.Mayuscula();

        ARRPARAM[2] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_op_grid", ARRPARAM);

    }

    public OracleDataReader Listar_OP_x_EstadoInsc(OracleConnection CN, BE_OP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[4];
        ARRPARAM[0] = new OracleParameter("i_tipo", OracleDbType.Int32, 4, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Tipo_Estado_Insc;
        //este parametro no se usa, implementar en el stored procedure
        ARRPARAM[1] = new OracleParameter("i_tipo_op", OracleDbType.Char, 2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Tipo_OP;
        ARRPARAM[2] = new OracleParameter("i_ubireg", OracleDbType.Int32, 4, ParameterDirection.Input);
        ARRPARAM[2].Value = c.UBIREGION.Num();
        ARRPARAM[3] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_op_x_estadoinsc", ARRPARAM);
    }

    public OracleDataReader Listar_OP_Debloqueadas(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_Tipo_OP", OracleDbType.Char, 2, ParameterDirection.Input);
        pr[0].Value = c.Cod_Tipo_OP;
        pr[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_Listar.sp_op_desbloq", pr);

    }

    public OracleDataReader Obtener_OP_Seleccionada(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_op_sel", pr);
    }

    public OracleDataReader GetSimbolo(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[2];
        ARRPARAM[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Cod_OP;
        ARRPARAM[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_simbolo_op_sel", ARRPARAM);
    }

    public int Check_Name(BE_OP c)
    {
        OracleParameter[] ARRPARAM = new OracleParameter[7];

        ARRPARAM[0] = new OracleParameter("i_des_op", OracleDbType.Varchar2, 200, ParameterDirection.Input);
        ARRPARAM[0].Value = c.Des_OP.ToUpper();

        ARRPARAM[1] = new OracleParameter("i_cod_ambito", OracleDbType.Char, 2, ParameterDirection.Input);
        ARRPARAM[1].Value = c.Cod_Ambito;

        ARRPARAM[2] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[2].Value = c.Cod_OP;

        ARRPARAM[3] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[3].Value = c.UBIREGION.Num();

        ARRPARAM[4] = new OracleParameter("i_ubiprovincia", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[4].Value = c.UBIPROVINCIA.Num();

        ARRPARAM[5] = new OracleParameter("i_ubidistrito", OracleDbType.Int32, ParameterDirection.Input);
        ARRPARAM[5].Value = c.UBIDISTRITO.Num();

        ARRPARAM[6] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        //Return ORACLEHELPER.ObtenerDR(CN, "pkg_op.sp_check_name_op", ARRPARAM)
        ORACLEHELPER.EjecutarQR("pkg_op.sp_check_name_op", ARRPARAM);

        return Int32.Parse(ARRPARAM[6].Value.ToString());
    }

    public int Generar_Nro_Partida(BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_op.SP_INSERT_NRO_PARTIDA_OP", pr);
        return Int32.Parse(pr[1].Value.ToString());
    }

    public int CheckCargaCompletada(BE_OP c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];
        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_tipo", OracleDbType.Varchar2, ParameterDirection.Input);
        arrParam[1].Value = c.Tipo_Carga_Comite_Repres;
        arrParam[2] = new OracleParameter("o_mensaje", OracleDbType.Varchar2, 200, ParameterDirection.Output);
        arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_OP.sp_check_cargafin", arrParam);
        c.MensajeCargaCompletada = arrParam[2].Value.ToString();
        return Convert.ToInt32(arrParam[3].Value.ToString());
    }

    //Public Function Listar_RequisitoTipo_OP(ByVal CN As OracleConnection, ByVal Cod_Tipo_OP As String) As OracleDataReader
    //    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}
    //    Try
    //        ARRPARAM(0) = New OracleParameter("i_cod_tipo_op", OracleDbType.Char, 2, ParameterDirection.Input)
    //        ARRPARAM(0).Value = Dame_Texto(Cod_Tipo_OP)

    //        ARRPARAM(1) = New OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output)
    //        Return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_requis_tipoOP_grid", ARRPARAM)

    //    Catch EX As Exception
    //        Throw EX
    //    End Try
    //End Function

    //Public Function Listar_RequisitoTipo_OP(ByVal CN As OracleConnection, ByVal Cod_OP As Int32) As OracleDataReader
    //    Dim ARRPARAM() As OracleParameter = New OracleParameter(1) {}
    //    Try
    //        ARRPARAM(0) = New OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input)
    //        ARRPARAM(0).Value = Dame_Entero(Cod_OP)
    //        ARRPARAM(1) = New OracleParameter("r_cursor", OracleDbType.RefCursor, ParameterDirection.Output)
    //        Return ORACLEHELPER.ObtenerDR(CN, "pkg_listar.sp_estatutos_op_grid", ARRPARAM)
    //    Catch EX As Exception
    //        Throw EX
    //    End Try
    //End Function



    public void Editar(BE_OP c)
    {
        OracleParameter[] arrParam = new OracleParameter[45];
        arrParam[0] = new OracleParameter("io_cod_op", OracleDbType.Int32, ParameterDirection.InputOutput);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_nro_partida", OracleDbType.NChar, 6, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Partida;
        arrParam[2] = new OracleParameter("i_des_op", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        arrParam[2].Value = c.Des_OP;
        arrParam[3] = new OracleParameter("i_des_siglas", OracleDbType.NVarchar2, 20, ParameterDirection.Input);
        arrParam[3].Value = c.Des_Siglas;
        arrParam[4] = new OracleParameter("i_cod_tipo_op", OracleDbType.NChar, 2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tipo_OP;
        arrParam[5] = new OracleParameter("i_cod_ambito", OracleDbType.NChar, 2, ParameterDirection.Input);
        arrParam[5].Value = c.Cod_Ambito;
        arrParam[6] = new OracleParameter("i_des_domicilio_legal", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        arrParam[6].Value = c.Des_Domicilio_Legal;
        arrParam[7] = new OracleParameter("i_tip_calle_domleg", OracleDbType.NChar, 2, ParameterDirection.Input);
        arrParam[7].Value = c.Tip_Calle_Domleg;
        arrParam[8] = new OracleParameter("i_num_num_domleg", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[8].Value = c.Num_Num_Domleg;
        arrParam[9] = new OracleParameter("i_Num_DptoLeg", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[9].Value = c.Num_DptoLeg;
        arrParam[10] = new OracleParameter("i_Num_DptoProc", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[10].Value = c.Num_DptoProc;
        arrParam[11] = new OracleParameter("i_ubidistrito", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[11].Value = c.UBIDISTRITO.Num();
        arrParam[12] = new OracleParameter("i_ubiprovincia", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[12].Value = c.UBIPROVINCIA.Num();
        arrParam[13] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[13].Value = c.UBIREGION.Num();
        arrParam[14] = new OracleParameter("i_ubidist_domic_procesal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[14].Value = c.UBIDISTRITODOMPROCESAL.Num();
        arrParam[15] = new OracleParameter("i_ubiprov_domic_procesal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[15].Value = c.UBIPROVINCIADOMPROCESAL.Num();
        arrParam[16] = new OracleParameter("i_ubireg_domic_procesal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[16].Value = c.UBIREGIONDOMPROCESAL.Num();
        arrParam[17] = new OracleParameter("i_observaciones", OracleDbType.NVarchar2, 400, ParameterDirection.Input);
        arrParam[17].Value = c.Observaciones;
        arrParam[18] = new OracleParameter("i_pag_web", OracleDbType.NVarchar2, 50, ParameterDirection.Input);
        arrParam[18].Value = c.Pag_Web;
        arrParam[19] = new OracleParameter("i_des_telef_op_01", OracleDbType.NVarchar2, 14, ParameterDirection.Input);
        arrParam[19].Value = c.Des_Telef_Op_01;
        arrParam[20] = new OracleParameter("i_des_telef_op_02", OracleDbType.NVarchar2, 14, ParameterDirection.Input);
        arrParam[20].Value = c.Des_Telef_Op_02;
        arrParam[21] = new OracleParameter("i_des_correo_op", OracleDbType.NVarchar2, 100, ParameterDirection.Input);
        arrParam[21].Value = c.Des_Correo_Op;
        arrParam[22] = new OracleParameter("i_fec_adq_kit", OracleDbType.Date, ParameterDirection.Input);
        arrParam[22].Value = c.Fec_Adq_Kit;
        arrParam[23] = new OracleParameter("i_user", OracleDbType.NVarchar2, 50, ParameterDirection.Input);
        arrParam[23].Value = Yoo.UserId;
        arrParam[24] = new OracleParameter("i_tipo_libro", OracleDbType.Char, 2, ParameterDirection.Input);
        arrParam[24].Value = c.Tipo_Libro;
        arrParam[25] = new OracleParameter("i_nro_tomo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[25].Value = c.Nro_Tomo;
        arrParam[26] = new OracleParameter("i_fec_ven_kit", OracleDbType.Date, ParameterDirection.Input);
        arrParam[26].Value = c.Fec_Ven_Kit;
        arrParam[27] = new OracleParameter("i_ubireg_domic_legal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[27].Value = c.UBIREGIONDOMLEGAL.Num();
        arrParam[28] = new OracleParameter("i_ubiprov_domic_legal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[28].Value = c.UBIPROVINCIADOMLEGAL.Num();
        arrParam[29] = new OracleParameter("i_ubidist_domic_legal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[29].Value = c.UBIDISTRITODOMLEGAL.Num();
        arrParam[30] = new OracleParameter("i_des_domicilio_procesal", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        arrParam[30].Value = c.Des_Domicilio_Procesal;
        arrParam[31] = new OracleParameter("i_tip_calle_domproc", OracleDbType.Char, 2, ParameterDirection.Input);
        arrParam[31].Value = c.Tip_Calle_Domproc;
        arrParam[32] = new OracleParameter("i_num_num_domproc", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[32].Value = c.Num_Num_Domproc;

        arrParam[33] = new OracleParameter("DOMIDZONA", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[33].Value = c.DOMIDZONA;
        arrParam[34] = new OracleParameter("DOMIDZONA", OracleDbType.Varchar2, 100,ParameterDirection.Input);
        arrParam[34].Value = c.DOMTXZONA;
        arrParam[35] = new OracleParameter("DOMIDVIA", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[35].Value = c.DOMIDVIA;
        arrParam[36] = new OracleParameter("DOMTXVIA", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[36].Value = c.DOMTXVIA;
        arrParam[37] = new OracleParameter("DOMTXNUMERO", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[37].Value = c.DOMTXNUMERO;
        arrParam[38] = new OracleParameter("DOMTXKILOMETRO", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[38].Value = c.DOMTXKILOMETRO;
        arrParam[39] = new OracleParameter("DOMTXMANZANA", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[39].Value = c.DOMTXMANZANA;
        arrParam[40] = new OracleParameter("DOMTXLOTE", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[40].Value = c.DOMTXLOTE;
        arrParam[41] = new OracleParameter("DOMTXDEPARTAMENTO", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[41].Value = c.DOMTXDEPARTAMENTO;
        arrParam[42] = new OracleParameter("DOMTXINTERIOR", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[42].Value = c.DOMTXINTERIOR;
        arrParam[43] = new OracleParameter("DOMTXREFERENCIA", OracleDbType.Varchar2, 200, ParameterDirection.Input);
        arrParam[43].Value = c.DOMTXREFERENCIA;

        arrParam[44] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_maestro_op", arrParam);
    }

    public int Agregar(BE_OP c)
    {
        OracleParameter[] arrParam = new OracleParameter[45];

        arrParam[0] = new OracleParameter("io_cod_op", OracleDbType.Int32, ParameterDirection.InputOutput);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("i_nro_partida", OracleDbType.NChar, 6, ParameterDirection.Input);
        arrParam[1].Value = c.Nro_Partida;
        arrParam[2] = new OracleParameter("i_des_op", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        arrParam[2].Value = c.Des_OP;
        arrParam[3] = new OracleParameter("i_des_siglas", OracleDbType.NVarchar2, 20, ParameterDirection.Input);
        arrParam[3].Value = c.Des_Siglas;
        arrParam[4] = new OracleParameter("i_cod_tipo_op", OracleDbType.NChar, 2, ParameterDirection.Input);
        arrParam[4].Value = c.Cod_Tipo_OP;
        arrParam[5] = new OracleParameter("i_cod_ambito", OracleDbType.NChar, 2, ParameterDirection.Input);
        arrParam[5].Value = c.Cod_Ambito;
        arrParam[6] = new OracleParameter("i_des_domicilio_legal", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        arrParam[6].Value = c.Des_Domicilio_Legal;
        arrParam[7] = new OracleParameter("i_tip_calle_domleg", OracleDbType.NChar, 5, ParameterDirection.Input);
        arrParam[7].Value = c.Tip_Calle_Domleg;
        arrParam[8] = new OracleParameter("i_num_num_domleg", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[8].Value = c.Num_Num_Domleg;
        arrParam[9] = new OracleParameter("i_Num_DptoLeg", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[9].Value = c.Num_DptoLeg;
        arrParam[10] = new OracleParameter("i_Num_DptoProc", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[10].Value = c.Num_DptoProc;
        arrParam[11] = new OracleParameter("i_ubidistrito", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[11].Value = c.UBIDISTRITO.Num();
        arrParam[12] = new OracleParameter("i_ubiprovincia", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[12].Value = c.UBIPROVINCIA.Num();
        arrParam[13] = new OracleParameter("i_ubiregion", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[13].Value = c.UBIREGION.Num();
        arrParam[14] = new OracleParameter("i_ubidist_domic_procesal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[14].Value = c.UBIDISTRITODOMPROCESAL.Num();
        arrParam[15] = new OracleParameter("i_ubiprov_domic_procesal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[15].Value = c.UBIPROVINCIADOMPROCESAL.Num();
        arrParam[16] = new OracleParameter("i_ubireg_domic_procesal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[16].Value = c.UBIREGIONDOMPROCESAL.Num();
        arrParam[17] = new OracleParameter("i_observaciones", OracleDbType.NVarchar2, 400, ParameterDirection.Input);
        arrParam[17].Value = c.Observaciones;
        arrParam[18] = new OracleParameter("i_pag_web", OracleDbType.NVarchar2, 50, ParameterDirection.Input);
        arrParam[18].Value = c.Pag_Web;
        arrParam[19] = new OracleParameter("i_des_telef_op_01", OracleDbType.NVarchar2, 14, ParameterDirection.Input);
        arrParam[19].Value = c.Des_Telef_Op_01;
        arrParam[20] = new OracleParameter("i_des_telef_op_02", OracleDbType.NVarchar2, 14, ParameterDirection.Input);
        arrParam[20].Value = c.Des_Telef_Op_02;
        arrParam[21] = new OracleParameter("i_des_correo_op", OracleDbType.NVarchar2, 100, ParameterDirection.Input);
        arrParam[21].Value = c.Des_Correo_Op;
        arrParam[22] = new OracleParameter("i_fec_adq_kit", OracleDbType.Date, ParameterDirection.Input);
        arrParam[22].Value = c.Fec_Adq_Kit;
        arrParam[23] = new OracleParameter("i_user", OracleDbType.NVarchar2, 50, ParameterDirection.Input);
        arrParam[23].Value = Yoo.UserId;
        arrParam[24] = new OracleParameter("i_tipo_libro", OracleDbType.Char, 2, ParameterDirection.Input);
        arrParam[24].Value = c.Tipo_Libro;
        arrParam[25] = new OracleParameter("i_nro_tomo", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[25].Value = c.Nro_Tomo;
        arrParam[26] = new OracleParameter("i_fec_ven_kit", OracleDbType.Date, ParameterDirection.Input);
        arrParam[26].Value = c.Fec_Ven_Kit; //fecha(new Glo.FeParam { formatoSalida = "dd/MM/yyyy" }); ;
        arrParam[27] = new OracleParameter("i_ubireg_domic_legal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[27].Value = c.UBIREGIONDOMLEGAL.Num();
        arrParam[28] = new OracleParameter("i_ubiprov_domic_legal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[28].Value = c.UBIPROVINCIADOMLEGAL.Num();
        arrParam[29] = new OracleParameter("i_ubidist_domic_legal", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[29].Value = c.UBIDISTRITODOMLEGAL.Num();
        arrParam[30] = new OracleParameter("i_des_domicilio_procesal", OracleDbType.NVarchar2, 200, ParameterDirection.Input);
        arrParam[30].Value = c.Des_Domicilio_Procesal;
        arrParam[31] = new OracleParameter("i_tip_calle_domproc", OracleDbType.Char, 2, ParameterDirection.Input);
        arrParam[31].Value = c.Tip_Calle_Domproc;
        arrParam[32] = new OracleParameter("i_num_num_domproc", OracleDbType.NVarchar2, 10, ParameterDirection.Input);
        arrParam[32].Value = c.Num_Num_Domproc;

        arrParam[33] = new OracleParameter("DOMIDZONA", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[33].Value = c.DOMIDZONA;
        arrParam[34] = new OracleParameter("DOMIDZONA", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[34].Value = c.DOMTXZONA;
        arrParam[35] = new OracleParameter("DOMIDVIA", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[35].Value = c.DOMIDVIA;
        arrParam[36] = new OracleParameter("DOMTXVIA", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[36].Value = c.DOMTXVIA;
        arrParam[37] = new OracleParameter("DOMTXNUMERO", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[37].Value = c.DOMTXNUMERO;
        arrParam[38] = new OracleParameter("DOMTXKILOMETRO", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[38].Value = c.DOMTXKILOMETRO;
        arrParam[39] = new OracleParameter("DOMTXMANZANA", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[39].Value = c.DOMTXMANZANA;
        arrParam[40] = new OracleParameter("DOMTXLOTE", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[40].Value = c.DOMTXLOTE;
        arrParam[41] = new OracleParameter("DOMTXDEPARTAMENTO", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[41].Value = c.DOMTXDEPARTAMENTO;
        arrParam[42] = new OracleParameter("DOMTXINTERIOR", OracleDbType.Varchar2, 100, ParameterDirection.Input);
        arrParam[42].Value = c.DOMTXINTERIOR;
        arrParam[43] = new OracleParameter("DOMTXREFERENCIA", OracleDbType.Varchar2, 200, ParameterDirection.Input);
        arrParam[43].Value = c.DOMTXREFERENCIA;


        arrParam[44] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_op.sp_insert_maestro_op", arrParam);
        return Int32.Parse(arrParam[0].Value.ToString());
    }

    public void Agregar_Requisitos(BE_OP c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];
        arrParam[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.InputOutput);
        arrParam[0].Value = c.Cod_OP;
        arrParam[1] = new OracleParameter("Cod_Tipo_OP", OracleDbType.Char, 2, ParameterDirection.Input);
        arrParam[1].Value = c.Cod_Tipo_OP;
        arrParam[2] = new OracleParameter("i_user", OracleDbType.Varchar2, 50, ParameterDirection.Input);
        arrParam[2].Value = Yoo.UserId;
        ORACLEHELPER.EjecutarQR("pkg_requisitos.sp_insert_req_op", arrParam);
    }

    public int Bloquear_OP(BE_OP c)
    {
        OracleParameter[] arrParam = new OracleParameter[4];


        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_flg_candado", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[1].Value = c.FLCANDADO;

        arrParam[2] = new OracleParameter("i_user", OracleDbType.NVarchar2, 50, ParameterDirection.Input);
        arrParam[2].Value = Yoo.UserId;

        arrParam[3] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_update_candado", arrParam);
        return arrParam[3].Num();

    }

    public void Bloquear_Tipo_OP(BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[3];
        pr[0] = new OracleParameter("i_cod_tipo_op", OracleDbType.Char, ParameterDirection.Input);
        pr[0].Value = c.Cod_Tipo_OP;
        pr[1] = new OracleParameter("FLCANDADO", OracleDbType.Int32, ParameterDirection.Input);
        pr[1].Value = c.FLCANDADO;
        pr[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("pkg_OP.SP_bloq_tipo_op", pr);
    }

    public int Tiene_Permiso_Bloquear(BE_OP c)
    {
        OracleParameter[] arrParam = new OracleParameter[3];

        arrParam[0] = new OracleParameter("i_cod_op", OracleDbType.Int32, ParameterDirection.Input);
        arrParam[0].Value = c.Cod_OP;

        arrParam[1] = new OracleParameter("i_user", OracleDbType.NVarchar2, 50, ParameterDirection.Input);
        arrParam[1].Value = Yoo.UserId;

        arrParam[2] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);

        ORACLEHELPER.EjecutarQR("pkg_op.sp_tiene_permiso_bloq", arrParam);

        return (int)arrParam[2].Value;


    }

    public OracleDataReader Listar_OP_Vinculadas(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("I_COD_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("R_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn, "pkg_listar.sp_op_vincula", pr);
    }

    public int Eliminar_OP(BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Char, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("o_return", OracleDbType.Int32, ParameterDirection.Output);
        ORACLEHELPER.EjecutarQR("Pkg_OP.SP_Delete_OP", pr);
        return (int)pr[1].Value;
    }

    public void GrabaSimbolo(BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("Img_Simbolo_Op", OracleDbType.Blob, ParameterDirection.Input);
        pr[1].Value = c.BLARCHIVO;
        ORACLEHELPER.EjecutarQR("Pkg_OP.sp_save_simbolo_blob", pr);      
    }


    public OracleDataReader GetDatosTipo(OracleConnection cn, BE_OP c)
    {
        OracleParameter[] pr = new OracleParameter[2];
        pr[0] = new OracleParameter("Cod_OP", OracleDbType.Int32, ParameterDirection.Input);
        pr[0].Value = c.Cod_OP;
        pr[1] = new OracleParameter("RC", OracleDbType.RefCursor, ParameterDirection.Output);
        return ORACLEHELPER.ObtenerDR(cn,"PKG_OP.GetDatosTipo", pr);        
    }


}

