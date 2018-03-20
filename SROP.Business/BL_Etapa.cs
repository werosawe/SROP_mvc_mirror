using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Linq;
using MTD.BL;
using MTD.BE;

public class BL_Etapa : BL_BASE
{
    private DA_Etapa data;

    public BE_Etapa GetQTEtapa(BE_Etapa c)
    {
        BE_Etapa i = null;
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.GetQTEtapa(cn, c);
            while (dr.Read())
            {
                i = new BE_Etapa();
                i.QTEtapa = dr.Num("QTEtapa");
                i.Cod_Correlativo = dr.Num("COD_CORRELATIVO");
            }
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public List<BE_Etapa> Gets(BE_Etapa c)
    {
        List<BE_Etapa> r = new List<BE_Etapa>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        
           

        try
        {
            dr = data.Gets(cn, c);
            while (dr.Read())
            {
                BE_Etapa i = new BE_Etapa();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Cod_Correlativo = dr.Num("Cod_Correlativo");
                i.Cod_Est_Insc = dr.Text("Cod_Estado_Inscrip");
                i.Des_Estado_Inscrip = dr.Text("Des_estado_inscrip");
                i.Flg_Consulta = dr.Text("Flg_Consulta");
                i.Des_Observ = dr.Text("Des_Observ");
                i.Cod_Ente = dr.Text("Cod_Ente");
                i.Des_Ente = dr.Text("Des_Ente");
                i.Fec_Estado_Insc = dr.Fec("Fec_Estado_Insc");
                i.Hora_AM = dr.Text("Hora_AM");
                i.Des_Num_Resol = dr.Text("Des_Num_Resol");
                i.Cod_Tipo_Cancel = dr.Text("Cod_Tipo_Cancel");
                i.Hor = dr.Text("Hora");
                i.Min = dr.Text("MIN");
                i.Seg = dr.Text("Seg");
                i.AmPm = dr.Text("AmPm");
                i.MTDCODEXPEDIENTE = dr.Text("Cod_Exp_MTD"); i.pDividirCodigoExpediente();
                i.MTDCODDOCUMENTO = dr.Text("Cod_Doc_MTD");

               
             
                
                i.Des_Observ = dr.Text("Des_Observ");

                if (dr.NoNulo("Des_Observ"))
                {
                    if (dr.Text("Des_Observ").ToString().Length > 17)
                    {
                        i.Des_Observ_Corta = dr.Text("Des_Observ").Substring(0, 17) + "...";
                    }
                    else
                    {
                        i.Des_Observ_Corta = dr.Text("Des_Observ");
                    }
                }

                i.FLVISIBLE = 1;


                r.Add(i);
            }

            if (r.Count > 0)
            {
                r.First().FLVISIBLE = 0;
            }

            return r;
        }
        finally {
            pCerrarDr(cn, dr); 
        }

    }

    public BE_Etapa Get(BE_Etapa c)
    {
        BE_Documento Documento = new BE_Documento();
        BL_Documento bDocumento = new BL_Documento();

        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Etapa i = null;
        OracleDataReader dr = null;
        try
        {
            //if (c.QTEtapa == 0) { c.Cod_Correlativo = 1; }
            dr = data.Get(cn, c);
            if (dr.Read())
            {
                i = new BE_Etapa();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Cod_Correlativo = dr.Num("Cod_Correlativo");
                i.Cod_Est_Insc = dr.Text("Cod_Estado_Inscrip");
                i.Cod_Tipo_Etapa = dr.Text("Cod_Tipo_Etapa");
                i.Des_Estado_Inscrip = dr.Text("Des_estado_inscrip");
                i.Flg_Consulta = dr.Text("Flg_Consulta");
                i.Des_Observ = dr.Text("Des_Observ");
                i.Cod_Ente = dr.Text("Cod_Ente");
                i.Des_Ente = dr.Text("Des_Ente");

                i.Fec_Estado_Insc = dr.Fec("Fec_Estado_Insc");
              
                i.Des_Num_Resol = dr.Text("Des_Num_Resol");
                i.Cod_Tipo_Cancel = dr.Text("Cod_Tipo_Cancel");
                i.Hor = dr.Text("Hora");
                i.Min = dr.Text("MIN");
                i.Seg = dr.Text("Seg");

                i.AmPm = dr.Text("AmPm");
                i.Hora_AM = dr.Text("Hora_AM");

                i.MTDCODEXPEDIENTE = dr.Text("Cod_Exp_MTD");i.pDividirCodigoExpediente();
                i.MTDCODDOCUMENTO = dr.Text("Cod_Doc_MTD");

                Documento.CODEXPEDIENTE = i.MTDCODEXPEDIENTE;
                Documento.CODDOCUMENTO = i.MTDCODDOCUMENTO;
                Documento = bDocumento.GetDocumento(Documento);
                if (Documento != null)
                {
                    i.MTDDESASUNTO = Documento.DESASUNTO;
                }




                i.FLESTADOOP = dr.Num("Flg_estado_OP");
            }

            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
            bDocumento.Dispose(); bDocumento = null; Documento = null;
        }
    }
   
    public int Insertar(BE_Etapa c)
    {    
        return data.Insertar(c);
    }

    public int Agregar(BE_Etapa c)
    {        
        return data.Agregar(c);
    }

    public int Actualizar(BE_Etapa c)
    {        
        return data.Actualizar(c);
    }

    public int Eliminar(BE_Etapa c)
    {
        return data.Eliminar(c);
    }


    public string Armar_Cod_Expediente_MTD( string Prefijo, string Anho, string NumExp)
    {
        if ((Prefijo=="") || (Anho=="") || (NumExp == ""))
           { return ""; };
        
        var array = new[] { Prefijo, Anho, NumExp };
        string Cod_Exp_MTD = string.Join("-", array.Where(s => !string.IsNullOrEmpty(s)));
        return Cod_Exp_MTD;
    }

    public BL_Etapa() { data = new DA_Etapa(); }
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

