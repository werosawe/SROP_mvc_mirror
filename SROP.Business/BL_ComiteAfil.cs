using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

using System.Data;
using System.IO;



public class BL_ComiteAfil : BL_BASE
{

    private DA_ComiteAfil data;


    public List<BE_ComiteAfil> Listar_Afilados(BE_ComiteAfil c)
    {
        List<BE_ComiteAfil> r = new List<BE_ComiteAfil>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Afiliados(cn, c);
        while (dr.Read())
        {
            BE_ComiteAfil i = new BE_ComiteAfil();
            i.Cod_OP = dr.Num("Cod_OP");
            i.Des_OP = dr.Text("Des_OP");
            i.Num_Pag = dr.Num("Num_Pag");
            i.Nro_Entrega = dr.Num("Nro_Entrega");
            i.Num_Ite = dr.Num("Num_Ite");
            i.Cod_Tipo_OP = dr.Text("Cod_Tipo_Op");
            i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
            i.Cod_Dni = dr.Text("Cod_Dni");
            i.ApPat = dr.Text("ApPat");
            i.ApMat = dr.Text("ApMat");
            i.Nombres = dr.Text("Nombres");
            i.UBIREGION = dr.Text("UbiRegion");
            i.UBIPROVINCIA = dr.Text("UbiProv");
            i.UBIDISTRITO = dr.Text("UbiDist");
            i.CodDep = dr.Text("CodDep");
            i.CodPro = dr.Text("CodPro");
            i.CodDis = dr.Text("CodDis");
            i.FLVALIDO = dr.Num("Flg_Valido");
            i.FLRENUNCIA = dr.Num("Flg_Renuncia");
            i.Region = dr.Text("Region");
            i.Provincia = dr.Text("Provincia");
            i.Distrito = dr.Text("Distrito");
            i.Cod_Motivo_Baja = dr.Num("Cod_Motivo");
            i.Des_Motivo_Baja = dr.Text("Des_Motivo");
            i.Codr_VF = dr.Text("Codr_VF");
            i.Des_Motivo_Inval = dr.Text("Des_Motivo_Inval");//.Replace((char) 10,   "<br/>");
            i.FLDJ = dr.Num("Flg_DJ");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public DataTable Crear_DT_Comites_Afil(BE_ComiteAfil c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Listar_Afiliados(cn, c);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }


    public List<BE_ComiteAfil> Listar_Afiliados_Busq(BE_ComiteAfil c)
    {
        List<BE_ComiteAfil> r = new List<BE_ComiteAfil>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Afiliados_Busq(cn, c);

        while (dr.Read())
        {
            BE_ComiteAfil i = new BE_ComiteAfil();
            //.Cod_OP = Dame_Entero(dr("Cod_OP"))
            //.Nro_Entrega = Dame_Entero(dr("Nro_Entrega"))
            //.Num_Ite = Dame_Entero(dr("Num_Ite"))
            //.Cod_Dni = Dame_Texto(dr("Cod_Dni"))
            //.ApPat = Dame_Texto(dr("ApPat"))
            //.ApMat = Dame_Texto(dr("ApMat"))
            //.Nombres = Dame_Texto(dr("Nombres"))
            //.Des_Motivo = Dame_Texto(dr("Des_Motivo"))
            //.Codr_VF = Dame_Texto(dr("Codr_VF"))
            //.UbiRegion = Dame_Entero(dr("UbiRegion"))
            //.UbiProv = Dame_Entero(dr("UbiProv"))
            //.UbiDist = Dame_Entero(dr("UbiDist"))
            //.Cod_Motivo = Dame_Entero(dr("Cod_Motivo"))
            //.Flg_Valido = Dame_Entero(dr("flg_valido"))

            i.Cod_OP = dr.Num("Cod_OP");
            i.Des_OP = dr.Text("Des_OP");
            i.Num_Pag = dr.Num("Num_Pag");
            i.Nro_Entrega = dr.Num("Nro_Entrega");
            i.Num_Ite = dr.Num("Num_Ite");
            i.Cod_Tipo_OP = dr.Text("Cod_Tipo_Op");
            i.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
            i.Cod_Dni = dr.Text("Cod_Dni");
            i.ApPat = dr.Text("ApPat");
            i.ApMat = dr.Text("ApMat");
            i.Nombres = dr.Text("Nombres");
            i.UBIREGION = dr.Text("UbiRegion");
            i.UBIPROVINCIA = dr.Text("UbiProv");
            i.UBIDISTRITO = dr.Text("UbiDist");
            i.CodDep = dr.Text("CodDep");
            i.CodPro = dr.Text("CodPro");
            i.CodDis = dr.Text("CodDis");
            i.FLVALIDO = dr.Num("Flg_Valido");
            i.FLRENUNCIA = dr.Num("Flg_Renuncia");
            i.Region = dr.Text("Region");
            i.Provincia = dr.Text("Provincia");
            i.Distrito = dr.Text("Distrito");
            i.Cod_Motivo_Baja = dr.Num("Cod_Motivo");
            i.Des_Motivo_Baja = dr.Text("Des_Motivo");
            i.Codr_VF = dr.Text("Codr_VF");
            i.Des_Motivo_Inval = dr.Text("Des_Motivo_Inval");
            i.FLDJ = dr.Num("Flg_DJ");


            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_ComiteMotBaja> Listar_MotivoBaja()
    {
        List<BE_ComiteMotBaja> r = new List<BE_ComiteMotBaja>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_MotivoBaja(cn);
        while (dr.Read())
        {
            BE_ComiteMotBaja i = new BE_ComiteMotBaja();
            i.Cod_Motivo = dr.Num("Cod_Motivo");
            i.Des_Motivo = dr.Text("Des_Motivo");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }







    public void Insertar_Varios_DNI(string FILENAME, string sContents, BE_ComiteAfil oBE_ComiteAfil)
    {
        //Create a text file

        string strDNI = "";
        StreamWriter objFileWriter = null;
        objFileWriter = File.CreateText(FILENAME);
        objFileWriter.Write(sContents);
        objFileWriter.Close();

        StreamReader objStreamReader = null;
        objStreamReader = File.OpenText(FILENAME);

        while (objStreamReader.Peek() != -1)
        {
            strDNI = objStreamReader.ReadLine();
            oBE_ComiteAfil.Cod_Dni = strDNI.Trim();

            if (Funciones.Valid_DNI(oBE_ComiteAfil.Cod_Dni))
            {
                Agregar(oBE_ComiteAfil);
            }

        }
        objStreamReader.Close();
        File.Delete(FILENAME);
    }


    public int Agregar(BE_ComiteAfil oBE_ComiteAfil)
    {
        return data.Agregar(oBE_ComiteAfil);
    }

    public int Modificar(BE_ComiteAfil c)
    {
        return data.Modificar(c);
    }

    public int Eliminar(BE_ComiteAfil c)
    {
        return data.Eliminar(c);
    }

    public string Mensaje_Ubigeo(BE_ComiteAfil c)
    {
        return data.Mensaje_Ubigeo(c);
    }

    public string Es_ComiteVerificado(BE_ComiteAfil c)
    {
        return data.Es_ComiteVerificado(c);
    }



    public BL_ComiteAfil() { data = new DA_ComiteAfil(); }
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

