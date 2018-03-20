using System;
using System.Collections.Generic;
using System.Data;

using Oracle.DataAccess.Client;


public class BL_Archivo : BL_BASE
{
    private DA_Archivo data;


    public List<BE_Archivo> Listar_Pendientes()
    {
        List<BE_Archivo> r = new List<BE_Archivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);

        BE_Archivo i = default(BE_Archivo);

        OracleDataReader dr = data.Listar_Pendientes(cn);
        while (dr.Read())
        {
            i = new BE_Archivo();
            var _with1 = i;
            _with1.Cod_OP = dr.Num("Cod_OP");
            _with1.Des_OP = dr.Text("Des_OP");
            _with1.Cod_Tipo_OP = dr.Text("Cod_Tipo_OP");
            _with1.Des_Tipo_OP = dr.Text("Des_Tipo_OP");

            _with1.Fec_Solic = dr.Fec("Fec_Solic"); 
            _with1.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
            _with1.Fec_Estado = dr.Fec("Fec_Estado");  
            _with1.Region = dr.Text("Region");
            _with1.Provincia = dr.Text("Provincia");
            _with1.Distrito = dr.Text("Distrito");
            _with1.Tx_Ubic_Arc = dr.Text("Tx_Ubic_Arc");
            _with1.Cod_Arc = dr.Num("Cod_Arc");
            _with1.Num_Tom_Leg = dr.Num("Num_Tom_Leg");
            _with1.Num_Tom_Pla = dr.Num("Num_Tom_Pla");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public BE_Archivo Obtener_Archivo(int Cod_OP)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);

        BE_Archivo i = new BE_Archivo();


        OracleDataReader dr = data.Obtener_Archivo(cn, Cod_OP);
        while (dr.Read())
        {
            var _with2 = i;
            _with2.Cod_OP = dr.Num("Cod_OP");
            _with2.Des_OP = dr.Text("Des_OP");
            _with2.Cod_Tipo_OP = dr.Text("Cod_Tipo_OP");
            _with2.Des_Tipo_OP = dr.Text("Des_Tipo_OP");

            _with2.Fec_Solic = dr.Fec("Fec_Solic"); 
            _with2.Des_Estado_Inscrip = dr.Text("Des_Estado_Inscrip");
            _with2.Fec_Estado = dr.Fec("Fec_Estado"); 
            _with2.Region = dr.Text("Region");
            _with2.Provincia = dr.Text("Provincia");
            _with2.Distrito = dr.Text("Distrito");
            _with2.Tx_Ubic_Arc = dr.Text("Tx_Ubic_Arc");
            _with2.Cod_Arc = dr.Num("Cod_Arc");
            _with2.Num_Tom_Leg = dr.Num("Num_Tom_Leg");
            _with2.Num_Tom_Pla = dr.Num("Num_Tom_Pla");
        }
        pCerrarDr(cn, dr);
        return i;

    }



    public int Modificar(BE_Archivo c)
    {
        return data.Modificar(c);
    }



    public void Generar_PDF(string CodTipoOP, int Cod_OP, string strFilePath, string PDFName, string Tipo_Caratula)
    {
        if (System.IO.Directory.Exists(strFilePath) == false)
        {
            System.IO.Directory.CreateDirectory(strFilePath);
        }

        DataTable dt = new DataTable();
        object oRpt = new object();

        switch (Tipo_Caratula)
        {
            case "Legajos":
                dt = data.Obtener_Caratula_Legajos(CodTipoOP, Cod_OP);
                //oRpt = new Reportes.cr_cara_legajos();
                break;
            case "Planillones":
                dt = data.Obtener_Caratula_Planillones(CodTipoOP, Cod_OP);
                //oRpt = new Reportes.cr_cara_plani();
                break;
            case "Lomos":
                dt = data.Obtener_Caratula_Lomos(CodTipoOP, Cod_OP);
                //oRpt = new Reportes.cr_cara_lomos();
                break;
            case "Padrones":
                dt = data.Obtener_Caratula_Padrones(CodTipoOP, Cod_OP);
                //oRpt = new Reportes.cr_cara_padron();
                break;
        }

        //oRpt.SetDataSource(dt);
        //dt.Dispose();

        //ExportOptions exportOpts = oRpt.ExportOptions;

        //var _with3 = oRpt.ExportOptions;
        //_with3.ExportFormatType = ExportFormatType.PortableDocFormat;
        //_with3.ExportDestinationType = ExportDestinationType.DiskFile;
        //_with3.DestinationOptions = new DiskFileDestinationOptions();
        //((DiskFileDestinationOptions)_with3.DestinationOptions).DiskFileName = strFilePath + "\\" + PDFName;

        //oRpt.Export();
        //oRpt.Close();
        //oRpt.Dispose();
    }

    public BL_Archivo() { data = new DA_Archivo(); }
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

