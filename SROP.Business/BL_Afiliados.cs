using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Collections;
using System.Data;


public class BL_Afiliados : BL_BASE
{
    private DA_Afiliados data;
    public List<BE_Afiliados> Listar_Padron_Afil_1(BE_Afiliados c)
    {
        List<BE_Afiliados> r = new List<BE_Afiliados>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Padron_Afil_1(cn, c);
        while (dr.Read())
        {
            BE_Afiliados i = new BE_Afiliados();
            i.SeqPadronAfil = dr.Num("seq");
            i.Cod_OP = dr.Num("cod_op");
            i.Cod_DNI = dr.Text("cod_dni");
            i.ApePat = dr.Text("apepat");
            i.ApeMat = dr.Text("apemat");
            i.Nombres = dr.Text("nombres");
            i.En_Padron_Afil = dr.Text("flg_padron_afil");
            i.En_Comites = dr.Text("flg_comites");
            i.En_Directivos = dr.Text("flg_representante");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }


    public ArrayList Get_Afiliacion_Filtrado(ref BE_Afiliados c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Afiliados oAfiliado = default(BE_Afiliados);
        ArrayList arrAfiliado = new ArrayList();
        int iCod_Op = 0;
        c.MensajeAmostrar = "Ninguno";
        bool mostrar = true;
        OracleDataReader dr = data.Get_Afiliacion(cn, c);

        while (dr.Read())
        {
            iCod_Op = dr.Num("cod_op");
            oAfiliado = Get_Afiliacion_DNI_OP(c);
            mostrar = Convert.ToBoolean(Mostrar_Registro_Afil(c));
            if (mostrar == true)
            {
                arrAfiliado.Add(oAfiliado);
            }
        }
        pCerrarDr(cn, dr);
        return arrAfiliado;
    }


    public BE_Afiliados Get_Afiliacion_DNI_OP(BE_Afiliados c)
    {       
        BE_Afiliados i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BL_OP oBL_OP = new BL_OP();
        BE_OP oBE_OP = new BE_OP(c.Cod_OP);
        oBE_OP = oBL_OP.Obtener_OP_Selecc(oBE_OP);
        OracleDataReader dr = data.Get_Afiliacion_DNI_OP(cn, c);
        if (dr.HasRows)
        {

            if (dr.Read())
            {
                i = new BE_Afiliados();

                i.Cod_OP = dr.Num("Cod_OP");
                i.Cod_DNI = c.Cod_DNI;
                i.Nombre_OP = oBE_OP.Des_OP;
                i.Tipo_OP = oBE_OP.Des_Tipo_Op;
                //= oBE_OP.Des_Estado_Insc_2
                i.Ubigeo_OP = oBE_OP.Ubigeo_OP;
                i.Estado_Insc = oBE_OP.Estado_Insc;
                i.Cod_Proc = oBE_OP.Proc_Insc;
                i.Cod_Estado_Insc = oBE_OP.Cod_Est_Insc;
                i.Fec_Estado_Insc = string.Format("{0:dd-MMM-yyyy}", oBE_OP.Fec_Estado_Insc);
                i.Fec_Solic_Insc = string.Format("{0:dd-MMM-yyyy}", oBE_OP.Fec_Solic_Insc);

                i.FLESTADOAFILIACION = dr.Num("flg_estado_afil");

                i.ApePat = dr["apepat"].ToString();
                i.ApeMat = dr["apemat"].ToString();
                i.Nombres = dr["nombres"].ToString();

                i.FLREPRESENTANTE = dr.Num("flg_representante");
                i.FLPADRONAFILIADO = dr.Num("flg_padron_afil");
                i.FLCOMITE = dr.Num("flg_comites");
                i.FLAFILIADOFROM = dr.Num("flg_afil_from");

                i.Fec_Renuncia = string.Format("{0:dd-MMM-yyyy}", dr.Text("fec_renuncia"));
                i.Fec_Renun_OP = string.Format("{0:dd-MMM-yyyy}", dr.Text("fec_renun_op"));
                i.Fec_Padron_Afil = string.Format("{0:dd-MMM-yyyy}", dr.Text("fec_padron_afil"));
                i.Fec_Comite = string.Format("{0:dd-MMM-yyyy}", dr.Text("fec_comite"));
                i.Fec_Repres = string.Format("{0:dd-MMM-yyyy}", dr.Text("fec_repres"));

                if (Convert.ToString(dr["nro_entrega_padron"]) == "0")
                {
                    i.Nro_Entrega_Padron = "";
                }
                else
                {
                    i.Nro_Entrega_Padron = dr.Text("nro_entrega_padron");
                }

                if ((int) i.FLCOMITE == 1)
                {
                    i.UBIREGION = dr.Text("ubiregion");
                    i.UBIPROVINCIA = dr.Text("ubiprov");
                    i.UBIDISTRITO = dr.Text("UbiDist");
                    i.Comite_name = _Comite_Name(i.UBIREGION.Num(), i.UBIPROVINCIA.Num(), i.UBIDISTRITO.Num());
                }
                else
                {
                    i.Comite_name = "No";
                }
                i.FLVALIDACOMITE = dr.Num("flg_valid_comite");
                i.FLVALIDAREPRESENTANTE = dr.Num("flg_valid_repres");
                i.FLVALIDAPADRONAFILIADO = dr.Num("flg_valid_padron_afil");
                i.Observ = dr["observ"].ToString();
                i.IsAfiliado = Convert.ToBoolean((dr.Num("flg_IsAfiliado") == 1 ? true : false));
                i.Cod_Ente_Renuncia = dr["Cod_Ente_Renuncia"].ToString();
                i.Des_Ente_Renuncia = dr["Des_Ente_Renuncia"].ToString();
                i.FecIni_Afil = string.Format("{0:dd-MMM-yyyy}", dr.Text("FecIni_Afil"));
                i.FecFin_Afil = string.Format("{0:dd-MMM-yyyy}", dr.Text("FecFin_Afil"));

                i.CodExpMTD = dr["cod_exp_mtd"].ToString();
                i.CodDocMTD = dr["cod_doc_mtd"].ToString();

                i.FLPADRONELECTORAL = 1;
                switch ((int) i.FLESTADOAFILIACION)
                {
                    case 0:
                        i.IsRenunciado = false;
                        i.FLPADRONELECTORAL = 0;
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 7:
                    case 8:
                    case 9:
                        i.IsRenunciado = true;
                        break;
                    case 5:
                        i.IsRenunciado = false;
                        break;
                    case 6:
                        i.IsRenunciado = false;
                        break;
                }

                
                if (Yoo.Cod_Rol.Text() == "12")
                {
                    //Internauta
                    i.Representante = Cargar_Cargos_Repres_Internauta(c);
                }
                else
                {
                    i.Representante = Cargar_Cargos_Representante(c);
                }

                i.liPeriodosAfilAnt = Get_PeriodosAfilAnt(c);

                i.Fue_Afiliado_OtraOP = dr.Text("fue_Afiliado_otraOP");

                BE_Afiliados oAfil = Estado_Afil(c);
                i.FLESTADOAFILIACION = oAfil.FLESTADOAFILIACION;
                i.Prefijo_PeriodoAfil = oAfil.Prefijo_PeriodoAfil;
                i.Estado_Afil = oAfil.Estado_Afil;
                i.Estado_Afil_Nombre_Largo = oAfil.Estado_Afil_Nombre_Largo;

            }

        }
        else
        {
            i = new BE_Afiliados();
            i.FLESTADOAFILIACION = -1;
            BL_Persona b = new BL_Persona();
            BE_Persona p = new BE_Persona();
            p = b.Obtener_Persona(c.Cod_DNI);
            //mFlg_Padron_Elec = c.Encontrado
            i.Cod_DNI = c.Cod_DNI;
            i.ApePat = p.ApePat;
            i.ApeMat = p.ApeMat;
            i.Nombres = p.Nombre;

            i.FLREPRESENTANTE = 0;

            i.FLPADRONAFILIADO = 0;

            i.FLCOMITE = 0;

            i.Fec_Renuncia = "";
            i.Fec_Renun_OP = "";
            i.Fec_Padron_Afil = "";
            i.Nombre_OP = "-";
            i.Tipo_OP = "-";
            i.Ubigeo_OP = "-";
            i.Estado_Insc = "-";
            i.Fec_Estado_Insc = "-";
            i.Fec_Solic_Insc = "-";

            //i.UBIREGION = ;
            //i.UbiProv = 0;
            //i.UbiDist = 0;
            i.Comite_name = "No";

            i.IsRenunciado = false;

            i.IsAfiliado = false;

            i.Fue_Afiliado_OtraOP = "";

            i.Representante = null;

            //Dim Representante As Personero
            //Representante = New Personero("00000000", iCod_Op, "00")
            //Representante.Cargar_Cargos()
        }
        oBE_OP.Dispose();
        oBE_OP = null;
        oBL_OP.Dispose();
        oBL_OP = null;
        pCerrarDr(cn, dr);
        return i;
    }

    public BE_Afiliados.Valores Get_Afiliacion(BE_Afiliados c)
    {

        BE_Afiliados.Valores Ret = new BE_Afiliados.Valores();
        Ret.EsAfiliado = false;

        OracleConnection cn = new OracleConnection(TX_ESQUEMA);


        BE_Afiliados oAfiliado = default(BE_Afiliados);
        ArrayList arrAfiliado = new ArrayList();      
        //bool mostrar = true;
        OracleDataReader dr = data.Get_Afiliacion(cn, c);


        if (dr.HasRows == true)
        {

            while (dr.Read())
            {
                c.Cod_OP = dr.Num("cod_op");

                oAfiliado = Get_Afiliacion_DNI_OP(c);

                // ' Determinas si el ciudadano es Afiliado (true/false) por cualquier OP
                if (oAfiliado.IsAfiliado == true)
                {
                    Ret.EsAfiliado = oAfiliado.IsAfiliado;
                }

                arrAfiliado.Add(oAfiliado);

            }
        }
        else
        {
            //DNI no existe en tbl_afiliados            
            oAfiliado = Get_Afiliacion_DNI_OP(c);
            arrAfiliado.Add(oAfiliado);
        }

        Ret.arrAfiliados = arrAfiliado;
        pCerrarDr(cn, dr);
        return Ret;
    }


    public List<BE_PeriodosAfilAnt> Get_PeriodosAfilAnt(BE_Afiliados c)
    {

        List<BE_PeriodosAfilAnt> r = new List<BE_PeriodosAfilAnt>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_PeriodosAfilAnt(cn, c);
        while (dr.Read())
        {
            BE_PeriodosAfilAnt i = new BE_PeriodosAfilAnt();
            i.Fec_Ini = dr.Text("fec_ini");
            i.Fec_Fin = dr.Text("fec_fin");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    private BE_Afiliados Estado_Afil(BE_Afiliados c)
    {
        BE_Afiliados i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Get_Estado_Afil(cn, c);
            if (dr.Read())
            {
                i = new BE_Afiliados();
                i.FLESTADOAFILIACION = dr.Num("cod_estado");
                i.Estado_Afil = dr.Text("des_estado");
                i.Estado_Afil_Nombre_Largo = dr.Text("des_nombre_largo");
                i.Prefijo_PeriodoAfil = dr.Text("prefijo_periodoafil");
            }            
            return i;
        }finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public BE_Personero Cargar_Cargos_Representante(BE_Afiliados c)
    {
        BE_Personero Representante = new BE_Personero();
        Representante.Cod_OP = c.Cod_OP;
        Representante.Cod_DNI = c.Cod_DNI;
        BL_Cargo x = new BL_Cargo();
        BE_Cargo Cargo = new BE_Cargo();
        Cargo.Cod_OP = c.Cod_OP; Cargo.Cod_DNI = c.Cod_DNI;
        Representante.Cargos = x.Cargar_Cargos(Cargo);
        return Representante;
    }

    public BE_Personero Cargar_Cargos_Repres_Internauta(BE_Afiliados c)
    {
        BE_Personero Representante = new BE_Personero();
        Representante.Cod_OP = c.Cod_OP;
        Representante.Cod_DNI = c.Cod_DNI;
        BL_Cargo x = new BL_Cargo();
        BE_Cargo Cargo = new BE_Cargo();
        Cargo.Cod_OP = c.Cod_OP; Cargo.Cod_DNI = c.Cod_DNI;
        Representante.Cargos = x.Cargar_Cargos_Internauta(Cargo);
        return Representante;
    }

    public string _Comite_Name(int iUbiRegion, int iUbiProv, int iUbiDist)
    {
        return data.Comite_Name(iUbiRegion, iUbiProv, iUbiDist);
    }

    public int Mostrar_Registro_Afil(BE_Afiliados c)
    {
        return data.Mostrar_Registro_Afil(c);
    }

    public int Mostrar_Registro_Afil_Const(int Cod_OP, string Cod_DNI, int flg_estado_afil, string Cod_Rol, ref string MensajeAmostrar)
    {
        return data.Mostrar_Registro_Afil_Const(Cod_OP, Cod_DNI, flg_estado_afil, Cod_Rol, ref MensajeAmostrar);
    }

    public BE_Persona Busca_Afiliado_Por_DNI(string Cod_Dni)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Persona i = null;
        OracleDataReader dr = data.Busca_Afiliado_Por_DNI(cn, Cod_Dni);
        if (dr.Read())
        {
            i = new BE_Persona();
            i.Cod_Dni = dr.Text("Cod_DNI");
            i.ApePat = dr.Text("ApePat");
            i.ApeMat = dr.Text("ApeMat");
            i.Nombre = dr.Text("Nombre");
        }
        pCerrarDr(cn, dr);
        return i;
    }

    public List<BE_EstadoAfil> Listar_Tipo_Renuncias(int param1)
    {
        List<BE_EstadoAfil> r = new List<BE_EstadoAfil>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Tipo_Renuncias(cn, param1);
        while (dr.Read())
        {
            BE_EstadoAfil i = new BE_EstadoAfil();
            i.Cod_Estado = dr.Num("cod_estado");
            i.Des_Estado = dr.Text("des_estado");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_EstadoAfil> Listar_EstadosAfil()
    {
        List<BE_EstadoAfil> r = new List<BE_EstadoAfil>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Tipo_EstadosAfil(cn);
        while (dr.Read())
        {
            BE_EstadoAfil i = new BE_EstadoAfil();
            i.Cod_Estado = dr.Num("cod_estado");
            i.Des_Estado = dr.Text("des_estado");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }


    public bool Renunciar(BE_Afiliados oBE_Afil, BE_HistAfil oBE_HistAfil, int iFlg_estado_afil, string sFec_Sol, string sFecRenOP, string sUserId, string Observ, string expMTD, string docMTD, string Aspx)
    {
        bool functionReturnValue = false;
        int ret = data.Cambiar_Estado(oBE_Afil);
        switch (ret)
        {
            case 1:
                functionReturnValue = true;
                // Se ha registrado exitosamente ...
                //oHist_Afil.Registra_Hist("Update")
                BL_HistAfil x = new BL_HistAfil();
                x.UpdateFlagsComites_Personeros(oBE_HistAfil);
                break;
            case 0:
                functionReturnValue = false;
                //NO SE HA GRABADO cambios...Por favor, corriga los datos...
                break;
            default:
                throw new Exception();
        }
        return functionReturnValue;
    }

    public bool Exclusion(BE_Afiliados oBE_Afil, int iFlg_estado_afil, string sFec_Sol, string sUserId, string Observ, string expMTD, string docMTD, string Aspx, string ApePat, string ApeMat,
    string Nombre)
    {
        bool functionReturnValue = false;
        DA_Afiliados data = new DA_Afiliados();
        int ret = data.Exclusion(oBE_Afil);
        switch (ret)
        {
            case 1:
                functionReturnValue = true;
                // Se ha registrado exitosamente ...
                break;
            //oHist_Afil.Registra_Hist("Insert")
            case 0:
                functionReturnValue = false;
                //NO SE HA GRABADO cambios...Por favor, corriga los datos...
                break;
            default:
                throw new Exception();
        }
        return functionReturnValue;
    }

    public bool CorregirRenuncia(BE_Afiliados oBE_Afil, BE_HistAfil oBE_HistAfil, int iFlg_estado_afil, string sUserId, string Observ, string expMTD, string docMTD, string Aspx)
    {
        bool functionReturnValue = false;
        int ret = data.Cambiar_Estado(oBE_Afil);
        switch (ret)
        {
            case 1:
                functionReturnValue = true;
                // Se ha registrado exitosamente ...
                //oHist_Afil.Registra_Hist("Update")
                BL_HistAfil x = new BL_HistAfil();
                x.UpdateFlagsComites_Personeros(oBE_HistAfil);
                break;
            case 0:
                functionReturnValue = false;
                //NO SE HA GRABADO cambios...Por favor, corriga los datos...
                break;
            default:
                throw new Exception();
        }
        return functionReturnValue;
    }

    public bool CorregirExclusion(BE_Afiliados oBE_Afil, int iFlg_estado_afil, string expMTD, string docMTD, string sUserId, string Aspx)
    {
        bool functionReturnValue = false;
        int ret = data.Revertir_Exclusion(null, oBE_Afil);
        switch (ret)
        {
            case 1:
                functionReturnValue = true;
                // Se ha registrado exitosamente ...
                break;
            //oHist_Afil.Registra_Hist("Insert")
            case 0:
                functionReturnValue = false;
                //NO SE HA GRABADO cambios...Por favor, corriga los datos...
                break;
            default:
                throw new Exception();
        }
        return functionReturnValue;
    }

    public bool Cambiar_Estado(BE_Afiliados oBE_Afil, BE_HistAfil oBE_HistAfil, int iFlg_estado_afil, string sFec_Sol, string sFecRenOP, string sUserId, string Observ, string expMTD, string docMTD, string Aspx)
    {
        bool functionReturnValue = false;

        int ret = data.Cambiar_Estado(oBE_Afil);

        switch (ret)
        {
            case 1:
                functionReturnValue = true;
                // Se ha registrado exitosamente ...
                //oHist_Afil.Registra_Hist("Update")
                BL_HistAfil x = new BL_HistAfil();
                x.UpdateFlagsComites_Personeros(oBE_HistAfil);
                break;
            case 0:
                functionReturnValue = false;
                //NO SE HA GRABADO cambios...Por favor, corriga los datos...
                break;
            default:
                throw new Exception();
        }
        return functionReturnValue;
    }

    public List<BE_Afil_ult4> listar_afil_ult4()
    {
        List<BE_Afil_ult4> r = new List<BE_Afil_ult4>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.sp_listar_afil_ult4(cn);
        while (dr.Read())
        {
            BE_Afil_ult4 i = new BE_Afil_ult4();
            i.DNI = dr.Text("DNI");
            i.ApPat = dr.Text("ApPat");
            i.ApMat = dr.Text("ApMat");
            i.Nombres = dr.Text("Nombres");
            i.Afil_Actual = dr.Text("Afil_Actual");
            i.Afil_4_anios = dr.Text("Afil_4_anios");
            i.OP = dr.Text("OP");
            i.Tipo = dr.Text("Tipo");
            i.Estado = dr.Text("Estado");
            i.Motivo = dr.Text("Motivo");
            i.observ = dr.Text("Observ");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public int Limpiar_Consulta_Ult4()
    {
        return data.Limpiar_Consulta_Ult4();

    }

    public int Insert_Ciudadano_Consulta_Ult4(BE_Persona c)
    {
        return data.Insert_Ciudadano_Consulta_Ult4(c);
    }

    public DataTable DT_Consulta_Afil_Ult4()
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.sp_listar_afil_ult4(cn);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    public BL_Afiliados() { data = new DA_Afiliados(); }
    bool disposed = false;
    protected override void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            data.Dispose(); data = null;
        }
        disposed = true;
        base.Dispose(disposing);
    }


}

