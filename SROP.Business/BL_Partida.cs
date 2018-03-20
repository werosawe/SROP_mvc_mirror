using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

using System.IO;




public class BL_Partida : BL_BASE
{
    private DA_Partida data;

    public List<BE_Partida> Gets(BE_Partida c)
    {
        List<BE_Partida> r = new List<BE_Partida>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Gets(cn, c);
            while (dr.Read())
            {
                BE_Partida i = new BE_Partida();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_OP = dr.Text("Des_OP");
                i.Cod_Exp_Mtd = dr.Text("Cod_Exp_Mtd");
                i.Cod_Doc_Mtd = dr.Text("Cod_Doc_Mtd");
                i.Id_Correl = dr.Num("Id_Correl");
                i.Id_Correl_Show = dr.Num("Id_Correl_Show");
                i.Des_Tarea = dr.Text("Des_Tarea");
                i.Id_Asig_Abogado = dr.Num("Id_Asig_Abogado");
                i.Abogado = dr.Text("Abogado");
                i.Fec_Asig = dr.Fec("Fec_Asig");
                i.Fec_Recep = dr.Fec("Fec_Recep");
                i.Fec_Fin = dr.Fec("Fec_fin");
                i.Num_Dias_Est = dr.Num("Num_Dias_Est");
                i.Observaciones = dr.Text("Observaciones");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BE_Partida Get(BE_Partida c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Partida i = null;
        OracleDataReader dr = null;
        try
        {
            dr = data.Get(cn, c);
            if (dr.Read())
            {
                i = new BE_Partida();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_OP = dr.Text("Des_OP");
                i.Cod_Exp_Mtd = dr.Text("Cod_Exp_mtd");
                i.Cod_Doc_Mtd = dr.Text("Cod_doc_mtd");
                i.Id_Correl = dr.Num("Id_Correl");
                i.Id_Correl_Show = dr.Num("Id_Correl_Show");
                i.Id_Asig_Abogado = dr.Num("Id_Asig_Abogado");
                i.Abogado = dr.Text("Abogado");

                i.Fec_Asig = dr.Fec("Fec_Asig");
                i.Fec_Recep = dr.Fec("Fec_Recep");
                i.Fec_Fin = dr.Fec("Fec_Fin");
                i.Num_Dias_Est = dr.Num("Num_Dias_Est");
                i.Observaciones = dr.Text("Observaciones");
            }

            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_PartidaDetalle> Listar_Asignacion_Tareas(BE_Partida c)
    {
        List<BE_PartidaDetalle> r = new List<BE_PartidaDetalle>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Asignacion_Tareas(cn, c);

            while (dr.Read())
            {
                BE_PartidaDetalle i = new BE_PartidaDetalle();
                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_OP = dr.Text("Des_OP");
                i.Cod_Exp_Mtd = dr.Text("Cod_Exp_Mtd");
                i.Cod_Doc_Mtd = dr.Text("Cod_Doc_Mtd");
                i.Id_Correl = dr.Num("Id_Correl");
                i.Id_Asig_Abogado = dr.Num("Id_Asig_Abogado");
                i.Abogado = dr.Text("Abogado");
                i.Id_Asig_Tarea = dr.Num("Id_Asig_Tarea");
                i.Cod_Tarea = dr.Text("Cod_Tarea");
                i.Des_Tarea = dr.Text("Des_Tarea");

                i.Fec_Asig = dr.Fec("Fec_Asig");
                i.Fec_Fin = dr.Fec("Fec_fin");
                i.Num_Dias_Est = dr.Num("Num_dias_est");
                i.Observaciones = dr.Text("Observaciones");
                i.Resultado = dr.Text("Resultado");
                i.Des_Resultado = dr.Text("Des_Resultado");
                i.Tipo_Doc = dr.Text("Tipo_Doc");
                i.Des_Tipo_Doc = dr.Text("Des_Tipo_Doc");
                i.Num_Doc = dr.Text("Num_Doc");

                r.Add(i);
            }

            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_PartidaTarea> Listar_Tareas_Cbo()
    {
        List<BE_PartidaTarea> r = new List<BE_PartidaTarea>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Tareas_Cbo(cn);
            while (dr.Read())
            {
                BE_PartidaTarea i = new BE_PartidaTarea();

                var _with4 = i;
                _with4.Cod_Tarea = dr.Text("Cod_Tarea");
                _with4.Des_Tarea = dr.Text("Des_Tarea");
                r.Add(i);
            }

            BE_PartidaTarea i2 = new BE_PartidaTarea();

            i2.Cod_Tarea = "00";
            i2.Des_Tarea = "<Seleccione una opción>";

            r.Insert(0, i2);
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_PartidaTarea> Listar_TipoDocs_Cbo()
    {
        List<BE_PartidaTarea> r = new List<BE_PartidaTarea>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_TipoDocs_Cbo(cn);
        while (dr.Read())
        {
            BE_PartidaTarea i = new BE_PartidaTarea();
            i.Cod_Tipo_Doc = dr.Text("Cod_Tipo_Doc");
            i.Des_Tipo_Doc = dr.Text("Des_Tipo_Doc");
            r.Add(i);
        }

        BE_PartidaTarea i2 = new BE_PartidaTarea();

        i2.Cod_Tarea = "00";
        i2.Des_Tarea = "<Seleccione una opción>";

        r.Insert(0, i2);
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_PartidaTarea> Listar_Resultados_Cbo()
    {
        List<BE_PartidaTarea> r = new List<BE_PartidaTarea>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Resultados_Cbo(cn);
        while (dr.Read())
        {
            BE_PartidaTarea i = new BE_PartidaTarea();
            i.Cod_Resultado = dr.Text("Cod_Resultado");
            i.Des_Resultado = dr.Text("Des_Resultado");
            r.Add(i);
        }

        BE_PartidaTarea i2 = new BE_PartidaTarea();

        i2.Cod_Tarea = "00";
        i2.Des_Tarea = "<Seleccione una opción>";

        r.Insert(0, i2);
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Partida> Listar_Tareas_Pendientes_Abog(string ID_user)
    {
        List<BE_Partida> r = new List<BE_Partida>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Tareas_Pendientes_Abog(cn);
        while (dr.Read())
        {
            if (dr.Text("userid") == ID_user)
            {
                BE_Partida i = new BE_Partida();

                i.Cod_OP = dr.Num("Cod_OP");
                i.Des_OP = dr.Text("Des_OP");
                i.Cod_Exp_Mtd = dr.Text("Cod_Exp_Mtd");
                i.Cod_Doc_Mtd = dr.Text("Cod_Doc_Mtd");
                i.Id_Correl = dr.Num("Id_Correl");
                i.Id_Correl_Show = dr.Num("Id_Correl_show");
                i.Des_Tarea = dr.Text("Des_Tarea");
                i.Id_Asig_Abogado = dr.Num("Id_Asig_Abogado");
                i.Abogado = dr.Text("Abogado");

                i.Fec_Asig = dr.Fec("Fec_Asig");
                i.Fec_Recep = dr.Fec("Fec_Recep");
                i.Fec_Fin = dr.Fec("Fec_fin");
                i.Num_Dias_Est = dr.Num("Num_Dias_Est");
                i.Observaciones = dr.Text("Observaciones");
                r.Add(i);
            }

        }
        pCerrarDr(cn, dr);
        return r;

    }



    public int Agregar_Partida(BE_Partida c)
    {
        return data.Agregar_Partida(c);
    }

    public int Modificar_Partida(BE_Partida c)
    {
        return data.Modificar_Partida(c);
    }

    public int Eliminar_Partida(BE_Partida c)
    {

        return data.Eliminar_Partida(c);
    }

    public int Agregar_Detalle(BE_Partida c)
    {
        return data.Agregar_Detalle(c);
    }

    public int Modificar_Detalle(BE_PartidaDetalle c)
    {
        return data.Modificar_Detalle(c);
    }

    public int Eliminar_Detalle(BE_PartidaDetalle c)
    {
        return data.Eliminar_Detalle(c);
    }

    public BE_Partida GetSimbolo(BE_Partida c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        BE_Partida i = null;
        OracleDataReader dr = null;
        try
        {
            dr = data.GetSimbolo(cn, c);
            if (dr.Read())
            {
                i = new BE_Partida();
                i.Cod_OP = dr.Num("Cod_OP");
                i.BLARCHIVO = (byte[])dr["Img_Simbolo_Op"];
            }            
            return i;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public byte[] SimboloEnBytes(string ImgFilePath)
    {
        byte[] functionReturnValue = null;
        FileInfo jpgFile = null;

        if (Directory.Exists(ImgFilePath))
        {
            foreach (string InFile in Directory.GetFiles(ImgFilePath, "*.jpg"))
            {
                jpgFile = new FileInfo(InFile);
            }
            functionReturnValue = PutImage(ImgFilePath + jpgFile.Name);
        }
        else
        {
            functionReturnValue = null;
        }
        return functionReturnValue;
    }

    public void GuardarSimbolo(BE_Partida c)
    {
        data.GuardarSimbolo(c);
    }

    public byte[] PutImage(string sImageNamePath)
    {
        System.IO.FileStream oImg = null;
        System.IO.BinaryReader oBinaryReader = null;
        byte[] oImgByteArray = null;

        oImg = new System.IO.FileStream(sImageNamePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

        oBinaryReader = new System.IO.BinaryReader(oImg);
        oImgByteArray = oBinaryReader.ReadBytes((int)oImg.Length);

        oImg.Read(oImgByteArray, 0, (int)oImg.Length);

        oBinaryReader.Close();
        oImg.Close();

        return oImgByteArray;
    }


    public DateTime Add_Working_Days(System.DateTime start_Date, int nDays)
    {
        return data.Add_Working_Days(start_Date, nDays);
    }


    public BL_Partida() { data = new DA_Partida(); }
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

