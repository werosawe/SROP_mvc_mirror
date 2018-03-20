using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

public class BL_OP : BL_BASE
{
    private DA_OP data;

    public List<BE_OP> Listar_OPs(BE_OP c)
    {
        List<BE_OP> r = new List<BE_OP>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_OPs(cn, c);
            while (dr.Read())
            {
                BE_OP i = new BE_OP();
                i.Cod_OP = dr.Num("codigo");
                i.Des_OP = dr.Text("descripcion");
                i.Des_Tipo_Op = dr.Text("des_tipo");
                i.Region = dr.Text("region");
                i.Provincia = dr.Text("provincia");
                i.Distrito = dr.Text("distrito");
                i.Des_Estado_Inscrip = dr.Text("des_est_insc");
                i.Fec_Estado_Insc = dr.Fec("fec_estado_insc");
                r.Add(i);
            }
            return r;
        }
        finally {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_OP> Listar_OP_x_EstadoInsc(BE_OP c)
    {
        List<BE_OP> r = new List<BE_OP>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_OP_x_EstadoInsc(cn, c);
            while (dr.Read())
            {
                BE_OP i = new BE_OP();
                i.Cod_OP = dr.Num("cod_op");
                i.Des_OP = dr.Text("des_op");
                r.Add(i);
            }            
            return r;
        }
        finally { pCerrarDr(cn, dr);
        }
    }

    public List<BE_OP> Listar_OP_Desbloqueadas(BE_OP  c)
    {
        List<BE_OP> r = new List<BE_OP>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_OP_Debloqueadas(cn, c);
            while (dr.Read())
            {
                BE_OP i = new BE_OP();
                i.Cod_OP = dr.Num("cod_op");
                i.Des_OP = dr.Text("des_op");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_OP> Obtener_OP_Seleccionada(BE_OP c)
    {
        List<BE_OP> r = new List<BE_OP>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Obtener_OP_Seleccionada(cn, c);
            while (dr.Read())
            {
                BE_OP i = new BE_OP();
                string Ubigeo_Concat = "";

                i.FLCANDADO = dr.Num("Flg_Candado");
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
                i.Des_OP = dr.Text("Des_OP");
                i.Des_Tipo_Op = dr.Text("Des_Tipo_OP");

                i.Fec_Estado_Insc = dr.Fec("Fec_Estado_Insc");
                i.Region = dr.Text("Region");
                i.Provincia = dr.Text("Provincia");
                i.Distrito = dr.Text("Distrito");
                i.Asistente = dr.Text("Asistente");

                if (!string.IsNullOrEmpty(dr.Text("Region")))
                {
                    Ubigeo_Concat = dr.Text("Region");
                }

                if (!string.IsNullOrEmpty(dr.Text("Provincia")))
                {
                    Ubigeo_Concat += "-" + dr.Text("Provincia");
                }

                if (!string.IsNullOrEmpty(dr.Text("Distrito")))
                {
                    Ubigeo_Concat += "-" + dr.Text("Distrito");
                }

                i.Ubigeo_Concat = Ubigeo_Concat;

                i.Vinculado = OP_Vinculado(c);

                r.Add(i);
            }            
            return r;
        }
        finally { pCerrarDr(cn, dr); }
    }

    public BE_OP Obtener_OP_Selecc(BE_OP c)
    {
        BE_OP i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Obtener_OP_Seleccionada(cn, c);
            if (dr.Read())
            {
                i = new BE_OP();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_OP = dr.Text("Des_OP");
                i.Cod_Tipo_OP = dr.Text("Cod_Tipo_OP");
                i.Des_Tipo_Op = dr.Text("Des_Tipo_OP");
                i.Estado_Op = dr.Text("Estado_Op");
                i.Estado_Insc = dr.Text("des_estado_inscrip_2");
                i.Des_Estado_Inscrip = dr.Text("des_estado_inscrip");
                i.Proc_Insc = "";
                i.Cod_Estado_Insc = dr.Text("cod_estado_insc");
                i.Cod_Ambito = dr.Text("Cod_Ambito");
                i.Des_Ambito = dr.Text("Des_Ambito");

                i.Region = dr.Text("Region");
                i.Provincia = dr.Text("Provincia");
                i.Distrito = dr.Text("Distrito");
                i.FLCANDADO = dr.Num("Flg_Candado");
                i.Fec_Estado_Insc = dr.Fec("Fec_Estado_Insc");
                i.Asistente = dr.Text("Asistente");

                //Dim f As String = String.Format("{0:dd-MMM-yyy}", dr.Item("fec_estado_insc"))

                //Dim dtResult As Date, xdate As Date

                //If DateTime.TryParse(f, dtResult) Then
                //    xdate = dtResult.ToString("f", System.Globalization.CultureInfo.InvariantCulture)                    
                //    i.Fec_Estado_Insc = xdate
                //End If


                i.Fec_Solic_Insc = string.Format("{0:dd-MMM-yyyy}", dr["fec_solic"]);

                switch (i.Cod_Tipo_OP)
                {
                    case "01":
                        i.Ubigeo_OP = "Nacional";
                        i.SiglaTipoOP = "N";
                        break;
                    case "02":
                        i.Ubigeo_OP = dr["region"].ToString();
                        i.SiglaTipoOP = "R";
                        break;
                    case "03":
                        i.Ubigeo_OP = dr["region"].ToString() + " - " + dr["provincia"].ToString();
                        i.SiglaTipoOP = "P";
                        break;
                    case "04":
                        i.Ubigeo_OP = dr["region"].ToString() + " - " + dr["provincia"].ToString() + " - " + dr["distrito"].ToString();
                        i.SiglaTipoOP = "D";
                        break;
                    case "05":
                        i.Ubigeo_OP = dr["des_ambito"].ToString();
                        i.SiglaTipoOP = "A";
                        break;
                }
            }
           
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_OP Obtener_OP_Completa(BE_OP c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        BE_OP i = null;
        try
        {
            dr = data.Obtener_OP_Seleccionada(cn, c);
            if (dr.Read())
            {
                i = new BE_OP();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_OP = dr.Text("Des_Op");
                i.Des_Siglas = dr.Text("Des_Siglas");
                i.Cod_Tipo_OP = dr.Text("Cod_Tipo_Op");
                i.Des_Tipo_Op = dr.Text("Des_Tipo_Op");
                i.Cod_Estado_Insc = dr.Text("Cod_Estado_Insc");
                i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
                i.Estado_Op = dr.Text("Estado_Op");

                i.Fec_Estado_Insc = dr.Fec("Fec_Estado_Insc");
                i.Fec_inscripcion = dr.Fec("Fec_inscripcion");
                i.Fec_Solic = dr.Fec("Fec_Solic");

                i.Cod_Ambito = dr.Text("Cod_Ambito");
                i.Des_Ambito = dr.Text("Des_Ambito");
                i.Tipo_Libro = dr.Text("Tipo_Libro");
                i.Des_Tipo_Libro = dr.Text("Des_Tipo_Libro");
                i.Nro_Tomo = dr.Num("Nro_Tomo");
                i.Nro_Partida = dr.Num("Nro_Partida");
                i.Des_Domicilio_Legal = dr.Text("Des_Domicilio_Legal");
                i.Des_Domicilio_Procesal = dr.Text("Des_Domicilio_Procesal");
                i.Tip_Calle_Domleg = dr.Text("Tip_Calle_Domleg");
                i.Num_Num_Domleg = dr.Text("Num_Num_Domleg");
                i.Num_DptoLeg = dr.Text("Num_DptoLeg");
                i.Num_DptoProc = dr.Text("Num_DptoProc");
                i.Tip_Calle_Domproc = dr.Text("Tip_Calle_Domproc");
                i.Num_Num_Domproc = dr.Text("Num_Num_Domproc");
                i.UBIDISTRITO = dr.Text("Ubidistrito");
                i.UBIPROVINCIA = dr.Text("Ubiprovincia");
                i.UBIREGION = dr.Text("Ubiregion");
                i.UBIREGIONDOMLEGAL = dr.Text("Ubireg_Domic_Legal");
                i.UBIPROVINCIADOMLEGAL = dr.Text("Ubiprov_Domic_Legal");
                i.UBIDISTRITODOMLEGAL = dr.Text("Ubidist_Domic_legal");
                i.UBIREGIONDOMPROCESAL = dr.Text("Ubireg_Domic_Procesal");
                i.UBIPROVINCIADOMPROCESAL = dr.Text("Ubiprov_Domic_Procesal");
                i.UBIDISTRITODOMPROCESAL = dr.Text("Ubidist_Domic_Procesal");
                i.Des_Telef_Op_01 = dr.Text("Des_Telef_Op_01");
                i.Des_Telef_Op_02 = dr.Text("Des_Telef_Op_02");
                i.Des_Fax_Op = dr.Text("Des_Fax_Op");
                i.Des_Correo_Op = dr.Text("Des_Correo_Op");

                i.Fec_Adq_Kit = dr.Fec("Fec_Adq_Kit");
                i.Fec_Ven_Kit = dr.Fec("Fec_Ven_Kit");

                i.Observaciones = dr.Text("Observaciones");
                i.Pag_Web = dr.Text("Pag_Web");
                i.Region = dr.Text("Region");
                i.Provincia = dr.Text("Provincia");
                i.Distrito = dr.Text("Distrito");
                i.Reg_Domic_Legal = dr.Text("Reg_Domic_Legal");
                i.Prov_Domic_Legal = dr.Text("Prov_Domic_Legal");
                i.Dist_Domic_Legal = dr.Text("Dist_Domic_Legal");
                i.Reg_Domic_Procesal = dr.Text("Reg_Domic_Procesal");
                i.Prov_Domic_Procesal = dr.Text("Prov_Domic_Procesal");
                i.Dist_Domic_Procesal = dr.Text("Dist_Domic_Procesal");
                i.FLCANDADO = dr.Num("Flg_Candado");
                i.Cod_Arc = dr.Text("Cod_Arc");
                i.Num_Tom_Leg = dr.Text("Num_Tom_Leg");
                i.Num_Tom_Pla = dr.Text("Num_Tom_Pla");
                i.Tx_Ubic_Arc = dr.Text("Tx_Ubic_Arc");
                i.Asistente = dr.Text("Asistente");
                i.Des_Tarea_Estado = dr.Text("Des_Tarea_Estado");

                i.FLTIENESIMBOLO = dr.Num("FLTIENESIMBOLO");
                //0 Sin Archivo = nulo para que valide el Jquery validation
                //1 Con archivo
                //diferente de 0 o 1 = se cambio de archivo
                if (!i.FLTIENESIMBOLO.Equals(0))
                {
                    i.TXARCHIVONOMBRE = "1";
                }
                





                //
                //if ((!object.ReferenceEquals(dr["img_simbolo_op"], System.DBNull.Value)))
                //{
                //    i.Img_Simbolo_Op = (byte[])dr["img_simbolo_op"];
                //}
                //else
                //{
                //    i.Img_Simbolo_Op = null;
                //}

                i.CargaFin_Comite = dr.Num("cargafin_comite");
                i.CargaFin_Repres = dr.Num("cargafin_repres");
                i.Vinculado = OP_Vinculado(c);

                if (!string.IsNullOrEmpty(dr.Text("Region")))
                {
                    i.Ubigeo_Concat = dr.Text("Region");
                }

                if (!string.IsNullOrEmpty(dr.Text("Provincia")))
                {
                    i.Ubigeo_Concat += "-" + dr.Text("Provincia");
                }

                if (!string.IsNullOrEmpty(dr.Text("Distrito")))
                {
                    i.Ubigeo_Concat += "-" + dr.Text("Distrito");
                }

                i.FLMIEMBRODEALIANZA = dr.Num("es_miembro_alianza");
                i.AlianzaPadre = dr.Text("alianza_padre");
                i.Anos_Vigencia_Cargo = dr.Num("anos_vigencia_cargo");
                
                i.DOMIDZONA = dr.Num("DOMIDZONA");
                i.DOMTXZONA = dr.Text("DOMTXZONA");
                i.DOMIDVIA = dr.Num("DOMIDVIA");
                i.DOMTXVIA = dr.Text("DOMTXVIA");
                i.DOMTXNUMERO = dr.Text("DOMTXNUMERO");
                i.DOMTXKILOMETRO = dr.Text("DOMTXKILOMETRO");
                i.DOMTXMANZANA = dr.Text("DOMTXMANZANA");
                i.DOMTXLOTE = dr.Text("DOMTXLOTE");
                i.DOMTXDEPARTAMENTO = dr.Text("DOMTXDEPARTAMENTO");
                i.DOMTXINTERIOR = dr.Text("DOMTXINTERIOR");
                i.DOMTXREFERENCIA = dr.Text("DOMTXREFERENCIA");

                i.AlianzaPadre = dr.Text("alianza_padre");

            }
            return i;
        }
        finally {
            pCerrarDr(cn, dr);
        }
    }

    public BE_OP GetSimbolo(BE_OP c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        BE_OP i = null;
        try
        {
            dr = data.GetSimbolo(cn, c);
            if (dr.Read())
            {
                i = new BE_OP();
                i.Cod_OP = dr.Num("Cod_OP");
                if (dr["Img_Simbolo_Op"].NoNulo()) {
                    i.Img_Simbolo_Op = (byte[])dr["Img_Simbolo_Op"];
                }
                else
                {
                    i = null;
                }
            }            
            return i;
        }
        finally { pCerrarDr(cn, dr); }
    }

    public List<BE_Estatuto> Listar_RequisitoTipo_OP(int Cod_OP)
    {
        List<BE_Estatuto> r = new List<BE_Estatuto>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DA_Estatuto dataEstatuto = new DA_Estatuto();
        OracleDataReader dr = null;
        try
        {
            dr = dataEstatuto.Gets(cn, new BE_Estatuto(Cod_OP));
            while (dr.Read())
            {
                BE_Estatuto i = new BE_Estatuto();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Orden = dr.Num("Orden");
                i.Des_Doc = dr.Text("Des_Doc");
                i.File_Name = dr.Text("File_Name");
                i.Fec_Doc = dr.Fec("Fec_Doc");
                i.Des_Tipo_Doc = dr.Text("Des_Tipo_Doc");
                i.Observ = dr.Text("Observ");
                i.Url_Estatuto_OP = dr.Text("Url_Estatuto_OP");
                i.FLVISIBLE = dr.Num("Flg_Visible");
                r.Add(i);
            }            
            return r;
        }
        finally { pCerrarDr(cn, dr);
            dataEstatuto.Dispose(); dataEstatuto = null;
        }
    }

    public bool Check_Name(BE_OP c)
    {

        int encontrado = default(int);
        encontrado = data.Check_Name(c);
        if (encontrado == 1)
        {
            return false;
        }
        else if (encontrado == 0)
        {
            return true;
        }
        return false;
    }

    public bool Generar_Nro_Partida(BE_OP c)
    {
        data.Generar_Nro_Partida(c);
        return true;
    }

    public bool CheckCargaCompletada(BE_OP c)
    {
        return Convert.ToBoolean(data.CheckCargaCompletada(c));

    }

    public bool Valida_OrgPol(string strUserId, ref string txtOrgPol, ref string Cod_OP, ref string Cod_Est_Insc, ref string Tipo_OP, ref string Codigo, ref string Descripcion, int ubiReg = -1, int ubiProv = -1, int ubiDist = -1)
    {

        if (string.IsNullOrEmpty(txtOrgPol))
        {
            return false;
        }
        BE_OP BE = new BE_OP();
        //BE.Cod_OP = 0 
        BE.Des_OP = txtOrgPol;
        List<BE_OP> listaOP = new List<BE_OP>();
        listaOP = Listar_OPs(BE);

        foreach (BE_OP x in listaOP)
        {
            txtOrgPol = x.Des_OP;
            Cod_OP = x.Cod_OP.Text();
            Tipo_OP = x.Des_Tipo_Op;
            Codigo = x.Cod_OP.Text();
            Descripcion = x.Des_Tipo_Op;
            Cod_Est_Insc = x.Cod_Estado_Insc;
            if (ubiReg != -1)
            {
                ubiReg = x.UBIREGION.Num();
            }
            if (ubiProv != -1)
            {
                ubiProv = x.UBIPROVINCIA.Num();
            }
            if (ubiDist != -1)
            {
                ubiDist = x.UBIDISTRITO.Num();
            }

            return true;
        }

        return false;

    }



    public void Editar(BE_OP c) { data.Editar(c); }

    public BE_OP Agregar(BE_OP c)
    {
        c.Cod_OP = data.Agregar(c);
        data.Agregar_Requisitos(c);
        return c;

    }

    public int Bloquear_OP(BE_OP c)
    {
        return data.Bloquear_OP(c);
    }

    public void Bloquear_Tipo_OP(BE_OP c)
    {
        data.Bloquear_Tipo_OP(c);
    }

    public int Eliminar_OP(BE_OP c)
    {
        return data.Eliminar_OP(c);
    }

    public int Tiene_Permiso_Bloquear(BE_OP c)
    {
        return data.Tiene_Permiso_Bloquear(c);
    }

    public bool OP_Vinculado(BE_OP c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr= data.Listar_OP_Vinculadas(cn, c);
            return dr.HasRows;
        }
        finally { pCerrarDr(cn, dr); }
    }

    public void GrabaSimbolo(BE_OP c)
    {
        data.GrabaSimbolo(c);
    }


    public BE_OP GetDatosTipo(BE_OP c)
    {
        BE_OP i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetDatosTipo(cn, c);
            if (dr.Read())
            {
                i = new BE_OP();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_Tipo_Op = dr.Text("DES_TIPO_OP");               
                i.Cod_Ambito = dr.Text("COD_AMBITO");
                i.FLSIMBOLO = dr.Text("FLG_SIMBOLO");              
            }
            return i;
        }
        finally { pCerrarDr(cn, dr); }
    }


    public BL_OP() { data = new DA_OP(); }
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

