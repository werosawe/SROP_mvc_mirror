using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Globalization;
using System.Linq;
using System.Data;

public class BL_Sintesis : BL_BASE
{
    private DA_Sintesis data;

    public List<BE_Sintesis> Gets()
    {
        string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
        List<BE_Sintesis> r = new List<BE_Sintesis>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn);
            while (dr.Read())
            {
                BE_Sintesis i = new BE_Sintesis();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Tx_Des_OP = dr.Text("Des_OP");
                i.Tx_Des_Tipo_OP = dr.Text("Des_Tipo_OP");
                i.Fec_Doc = dr.Text("Fec_Doc");
                i.TXREGION = dr.Text("region");
                i.TXPROVINCIA = dr.Text("provincia");
                i.TXDISTRITO = dr.Text("distrito");
                i.URL_Sintesis_OP = _URL + dr.Text("URL_Sintesis_OP");
                r.Add(i);
            }          
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_Sintesis Get(BE_Sintesis c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Sintesis i = null;
        OracleDataReader dr = null;
        try
        {
            dr = data.Get(cn, c);
            if (dr.Read())
            {
                i = new BE_Sintesis();
                i.Existe = true;
                i.Cod_OP = dr.Num("Cod_OP");
                i.Cod_Tipo_OP = dr.Text("Cod_Tipo_OP");
                i.File_Path = dr.Text("file_path");
                i.File_Name = dr.Text("File_Name");
                i.Fec_Doc = dr.Text("Fec_Doc");
                i.Tx_SintesInsc = dr.Text("tx_sintesinsc");
                i.Tx_Simbolo = dr.Text("Tx_Simbolo");
                i.Tx_Fundadores = dr.Text("Tx_Fundadores");
                i.Tx_Dirigentes = dr.Text("Tx_Dirigentes");
                i.Tx_Apoderados = dr.Text("Tx_Apoderados");
                i.Tx_PersoLegal = dr.Text("Tx_PersoLegal");
                i.Tx_PersoTecni = dr.Text("tx_persotecni");
                i.Tx_RepreLegal = dr.Text("Tx_RepreLegal");
                i.Tx_Tesorero = dr.Text("Tx_tesorero");
                i.Tx_Domiclegal = dr.Text("Tx_Domiclegal");
                i.Tx_ResumenEstatuto = dr.Text("Tx_Resumenestatuto");
                i.FirmadoPor = dr.Text("FirmadoPor");
                i.CargoSede = dr.Text("CargoSede");
                i.Ciudad = dr.Text("Ciudad");
                i.tx_OrgPol_Alianza = dr.Text("tx_OrgPol_Alianza");
                i.tx_ProcElec_Alianza = dr.Text("tx_ProcElec_Alianza");
                i.tx_Siglas = dr.Text("tx_Siglas");
            }            
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_Sintesis ObtenerDatos_Para_Sintesis(BE_Sintesis c)
    {
        return Carga_1(c);
    }

    private BE_Sintesis Carga_1(BE_Sintesis c)
    {
        BE_Sintesis Sintesis = new BE_Sintesis();
        BE_OP OP = new BE_OP();
        BL_OP bOP = new BL_OP();
        BL_Representantes bRepresentantes = new BL_Representantes();
        try
        {
            OP = bOP.Obtener_OP_Completa(new BE_OP(c.Cod_OP));
            if (OP != null)
            {
                Sintesis.Tx_Des_OP = OP.Des_OP;
                Sintesis.Tx_Des_Tipo_OP = OP.Des_Tipo_Op;
                Sintesis.tx_Siglas = OP.Des_Siglas;
                Sintesis.BLARCHIVO = OP.Img_Simbolo_Op;
                string DomicilioLegal = OP.Tip_Calle_Domleg + ". " + OP.Des_Domicilio_Legal + " N°" + OP.Num_Num_Domleg + " - " + OP.Dist_Domic_Legal + ", " + OP.Prov_Domic_Legal + ", " + OP.Reg_Domic_Legal;
                Sintesis.Tx_Domiclegal = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DomicilioLegal.ToLower());

                //Jala Lista de Directivos
                BE_Representantes Representante = new BE_Representantes();
                Representante.Cod_OP = c.Cod_OP;
                Sintesis.Directivos = bRepresentantes.Listar_Representantes(Representante);

                Sintesis.Directivos = Ordenar_por_Prioridad_Cargo(Sintesis.Directivos);

                Filtrar_Directivos(ref Sintesis);
            }
            return Sintesis;
        }
        finally
        {
            OP.Dispose(); OP = null;
            bRepresentantes.Dispose(); bRepresentantes = null;
            bOP.Dispose(); bOP = null;
        }
    }

    private List<BE_Representantes> Ordenar_por_Prioridad_Cargo(List<BE_Representantes> lstDirectivos)
    {

        try
        {

            foreach (BE_Representantes REP in lstDirectivos)
            {
                //Por defecto todos los cargos que tengan valor 2
                REP.Orden_Cargo = 2;

                //Presidente:
                if (REP.Des_Cargo_Comun.Minuscula().IndexOf("presidente") >= 0)
                {
                    REP.Orden_Cargo = 1;
                }

                //Personero Legal Titular o Personero Tecnico Titular:
                if (REP.Des_Cargo_Comun.Minuscula().IndexOf("titular") >= 0)
                {
                    REP.Orden_Cargo = 1;
                }

            }

            List<BE_Representantes> sortedList = new List<BE_Representantes>();
            sortedList = lstDirectivos.OrderBy(x => x.Orden_Cargo).ThenBy(x => x.Des_Cargo).ToList();

            return sortedList;

        }
        catch (Exception ex)
        {
            //code for throwing error goes here
            return lstDirectivos;
        }


    }


    private void Filtrar_Directivos(ref BE_Sintesis BE_Sint)
    {

        foreach (BE_Representantes Repres_loopVariable in BE_Sint.Directivos)
        {
            BE_Representantes Repres = Repres_loopVariable;
            BE_Sint.Tx_Fundadores = Filtrar_Por_Cargo("fundador", Repres);
            //Filtrar_Por_Cargo("dirigente", Repres, BE_Sint.Tx_Dirigentes)
            BE_Sint.Tx_Apoderados = Filtrar_Por_Cargo("apoderado", Repres);
            BE_Sint.Tx_PersoLegal = Filtrar_Por_Cargo("personero legal", Repres);
            BE_Sint.Tx_PersoTecni = Filtrar_Por_Cargo("personero técnico", Repres);
            BE_Sint.Tx_RepreLegal = Filtrar_Por_Cargo("representante legal", Repres);
            BE_Sint.Tx_Tesorero = Filtrar_Por_Cargo("tesorero", Repres);
            BE_Sint.Tx_Dirigentes = Filtrar_Otros_Cargos(Repres);
        }

        if (BE_Sint.Tx_Fundadores.NoNulo()) { BE_Sint.Tx_Fundadores = BE_Sint.Tx_Fundadores.Text().TrimEnd(Convert.ToChar(",")); }
        if (BE_Sint.Tx_Dirigentes.NoNulo()) { BE_Sint.Tx_Dirigentes = BE_Sint.Tx_Dirigentes.Text().TrimEnd(Convert.ToChar(",")); }
        if (BE_Sint.Tx_Apoderados.NoNulo()) { BE_Sint.Tx_Apoderados = BE_Sint.Tx_Apoderados.Text().TrimEnd(Convert.ToChar(",")); }
        if (BE_Sint.Tx_PersoLegal.NoNulo()) { BE_Sint.Tx_PersoLegal = BE_Sint.Tx_PersoLegal.Text().TrimEnd(Convert.ToChar(",")); }
        if (BE_Sint.Tx_PersoTecni.NoNulo()) { BE_Sint.Tx_PersoTecni = BE_Sint.Tx_PersoTecni.Text().TrimEnd(Convert.ToChar(",")); }
        if (BE_Sint.Tx_RepreLegal.NoNulo()) { BE_Sint.Tx_RepreLegal = BE_Sint.Tx_RepreLegal.Text().TrimEnd(Convert.ToChar(",")); }
        if (BE_Sint.Tx_Tesorero.NoNulo()) { BE_Sint.Tx_Tesorero = BE_Sint.Tx_Tesorero.Text().TrimEnd(Convert.ToChar(",")); }
              

    }

    private string Filtrar_Por_Cargo(string Filtro, BE_Representantes Repres)
    {
        string s = "";
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        if (Repres.Cod_Motivo_Baja == "00" & Repres.EsAfiliado == true)
        {
            if (Repres.Des_Cargo_Comun.NoNulo())
            {
                if (Repres.Des_Cargo_Comun.Minuscula().IndexOf(Filtro) >= 0)
                {
                    if (Filtro == "fundador")
                    {
                        if (Repres.Nombre_Completo.NoNulo())
                        {
                            s = s + myTI.ToTitleCase(Repres.Nombre_Completo.Minuscula()) + ", ";
                        }
                    }
                    else
                    {
                        if (Repres.Nombre_Completo.NoNulo())
                        {
                            s = s + Repres.Des_Cargo + ": " + myTI.ToTitleCase(Repres.Nombre_Completo.Minuscula()) + (char)10;
                        }
                    }

                }
            }

        }
        return s;
    }

    private string Filtrar_Otros_Cargos(BE_Representantes Repres)
    {
        string s = "";
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        if (Repres.Cod_Motivo_Baja == "00" & Repres.EsAfiliado == true)
        {
            if (Repres.Des_Cargo_Comun.EsNulo())
            {
                if (Repres.Nombre_Completo.NoNulo())
                {
                    s = s + Repres.Des_Cargo + ": " + myTI.ToTitleCase(Repres.Nombre_Completo.Minuscula()) + (char)10;
                }
            }
            else
            {
                if (Repres.Des_Cargo_Comun.Minuscula().IndexOf("fundador") >= 0 | Repres.Des_Cargo_Comun.Minuscula().IndexOf("apoderado") >= 0 | Repres.Des_Cargo_Comun.Minuscula().IndexOf("personero legal") >= 0 | Repres.Des_Cargo_Comun.Minuscula().IndexOf("personero técnico") >= 0 | Repres.Des_Cargo_Comun.Minuscula().IndexOf("representante legal") >= 0 | Repres.Des_Cargo_Comun.Minuscula().IndexOf("tesorero") >= 0)
                {

                }
                else
                {
                    if (Repres.Nombre_Completo.NoNulo())
                    {
                        s = s + Repres.Des_Cargo + ": " + myTI.ToTitleCase(Repres.Nombre_Completo.Minuscula()) + (char)10;
                    }
                }
            }

        }
        return s;
    }



    public int Agregar(BE_Sintesis c)
    {
        return data.Agregar(c);
    }

    public int Modificar(BE_Sintesis c)
    {
        return data.Modificar(c);
    }

    public void GuardarSimbolo(BE_Sintesis c)
    {
        data.GuardarSimbolo(c);
    }


    public int Eliminar(BE_Sintesis c)
    {
        return data.Eliminar(c);
    }


    public void Generar_PDF(string strFilePath, string PDFName, BE_Sintesis c)
    {
        if (System.IO.Directory.Exists(strFilePath) == false)
        {
            System.IO.Directory.CreateDirectory(strFilePath);
        }
        DataTable dt = null;
        DataTable dt2 = null;
        DataTable dt3 = null;
        DataTable dt4 = null;

        dt = CrearDT_Obtener_Sintesis(c);

        dt2 = CrearDT_Miembros_Alianza(c.Cod_OP);

        dt3 = Crear_DT_AlianzasTipoElecc(c.Cod_OP);

        dt4 = Crear_DT_Comites(c.Cod_OP);

        //Reportes.CR_Sintesis oRpt = new Reportes.CR_Sintesis();
        //oRpt.SetDataSource(dt);
        //oRpt.OpenSubreport("cr_miembros_alianza").SetDataSource(dt2);
        //oRpt.OpenSubreport("cr_procesos_electorales").SetDataSource(dt3);
        //oRpt.OpenSubreport("cr_comites").SetDataSource(dt4);

        //oRpt.SetParameterValue("param1", "");

        //string FechaSintesis = Utilitario.Funciones.Fecha_EnLetras(Convert.ToDateTime(BE.Fec_Doc));

        //oRpt.SetParameterValue("FechaSintesis", FechaSintesis);

        //ExportOptions exportOpts = oRpt.ExportOptions;
        //oRpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //oRpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //oRpt.ExportOptions.DestinationOptions = new DiskFileDestinationOptions();
        //((DiskFileDestinationOptions)oRpt.ExportOptions.DestinationOptions).DiskFileName = strFilePath + PDFName;
        //oRpt.Export();
        //oRpt.Close();
        //oRpt.Dispose();

    }

    public DataTable CrearDT_Miembros_Alianza(int Cod_OP)
    {
        DataTable dt = new DataTable();
        BL_Alianza BL = new BL_Alianza();
        dt = BL.Crear_DT_AlianzasGrid(Cod_OP);
        BL.Dispose();
        BL = null;
        return dt;
    }

    public DataTable Crear_DT_AlianzasTipoElecc(int Cod_OP)
    {
        DataTable dt = new DataTable();
        BL_Alianza BL = new BL_Alianza();
        dt = BL.Crear_DT_AlianzasTipoElecc(Cod_OP);

        BL.Dispose();
        BL = null;
        return dt;
    }

    public DataTable Crear_DT_Comites(int Cod_OP)
    {
        DataTable dt = new DataTable();
        BL_ComiteLista b = new BL_ComiteLista();
        dt = b.DT_Comites_Uniq(Cod_OP, "");
        b.Dispose();
        b = null;
        return dt;
    }

    private DataTable CrearDT_Obtener_Sintesis(BE_Sintesis c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Get(cn, c);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }


    //public BE_Sintesis Obtener_OP_Simbolo(int Cod_OP)
    //{
    //    OracleConnection cn = new OracleConnection(TX_ESQUEMA);
    //    BE_Sintesis i = null;
    //    OracleDataReader dr = data.Obtener_OP_Simbolo(cn, Cod_OP);
    //    if (dr.Read())
    //    {
    //        i = new BE_Sintesis();
    //        i.Cod_OP = dr.Num("Cod_OP");
    //        i.Img_Simbolo_OP = (byte[])dr["Img_Simbolo_Op"];
    //    }
    //    pCerrarDr(cn, dr);
    //    return i;

    //}


    public BE_Sintesis GetSimbolo(BE_Sintesis c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        BE_Sintesis i = null;
        try
        {
            dr = data.GetSimbolo(cn, c);
            while (dr.Read())
            {
                i = new BE_Sintesis();
                i.Cod_OP = dr.Num("Cod_OP");
                if (dr["Img_Simbolo_Op"].NoNulo())
                {
                    i.BLARCHIVO = (byte[])dr["Img_Simbolo_Op"];
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


    public BL_Sintesis() { data = new DA_Sintesis(); }
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

