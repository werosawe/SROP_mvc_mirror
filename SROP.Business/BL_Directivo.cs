using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


public class BL_Directivo : BL_BASE
{
    private DA_Directivo data;

    public List<BE_Directivo> Listar_Activos(int Cod_OP)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Activos(cn, Cod_OP);
        if (dr.Read())
        {
            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public BE_Directivo Obtener_Directivo(BE_Directivo c)
    {
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Obtener_Directivo(cn, c);
        BE_Directivo i = null;
        if (dr.Read())
        {
            i = Llenar_BE_Directivo(dr);
        }
        pCerrarDr(cn, dr);
        return i;
    }

    public List<BE_Directivo> Listar_IncluyeBajas(int Cod_OP)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_IncluyeBajas(cn, Cod_OP);
        while (dr.Read())
        {
            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Listar_Vigencia_Mayor(int Cod_OP, int AnosVigencia)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Vigencia_Mayor(cn, Cod_OP, AnosVigencia);
        while (dr.Read())
        {
            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Listar_Vigencia_Menor(int Cod_OP, int AnosVigencia)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Vigencia_Menor(cn, Cod_OP, AnosVigencia);
        while (dr.Read())
        {

            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Listar_Vigencia_Cerca(int Cod_OP, int AnosVigencia)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Vigencia_Cerca(cn, Cod_OP, AnosVigencia);
        while (dr.Read())
        {

            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Buscar_NombreDni(int Cod_OP, string NombreDni)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Buscar_NombreDni(cn, Cod_OP, NombreDni);
        while (dr.Read())
        {
            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Buscar_NombreDni_IncluyeBajas(int Cod_OP, string NombreDni)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Buscar_NombreDni_IncluyeBajas(cn, Cod_OP, NombreDni);
        while (dr.Read())
        {
            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Buscar_NombreDni_Vigencia_Mayor(int Cod_OP, int AnosVigencia, string NombreDni)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Buscar_NombreDni_Vigencia_Mayor(cn, Cod_OP, AnosVigencia, NombreDni);
        while (dr.Read())
        {

            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;
    }

    public List<BE_Directivo> Buscar_NombreDni_Vigencia_Menor(int Cod_OP, int AnosVigencia, string NombreDni)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Buscar_NombreDni_Vigencia_Menor(cn, Cod_OP, AnosVigencia, NombreDni);
        while (dr.Read())
        {

            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Buscar_NombreDni_Vigencia_Cerca(int Cod_OP, int AnosVigencia, string NombreDni)
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Buscar_NombreDni_Vigencia_Cerca(cn, Cod_OP, AnosVigencia, NombreDni);
        while (dr.Read())
        {

            r.Add(Llenar_BE_Directivo(dr));
        }
        pCerrarDr(cn, dr);
        return r;

    }

    private BE_Directivo Llenar_BE_Directivo(OracleDataReader dr)
    {
        BE_Directivo i = new BE_Directivo();
        i.Cod_OP = dr.Num("Cod_OP");
        i.Cod_Cargo = dr.Text("Cod_Cargo");
        i.Des_Cargo = dr.Text("Des_Cargo");
        i.Cod_Cargo_Comun = dr.Text("Cod_Cargo_Comun");
        i.Des_Cargo_Comun = dr.Text("Des_Cargo_Comun");
        i.Cod_Correl = dr.Text("Cod_Correl");
        i.Cod_Dni = dr.Text("Cod_Dni");
        i.Nombre_Completo = dr.Text("Nombre_Completo");
        i.ApePat_Pe = dr.Text("ApePat_Pe");
        i.ApeMat_Pe = dr.Text("ApeMat_Pe");
        i.Nombre_Pe = dr.Text("Nombre_Pe");
        i.EsAfiliado = (dr.Text("EsAfiliado") == "1" ? "SI" : "NO");
        i.Cod_Motivo_Baja = dr.Text("Cod_Motivo_Baja");
        i.Des_motivo = dr.Text("Des_motivo");
        i.Fec_Baja = dr.Fec("Fec_Baja"); 
        i.Fec_Carga = dr.Fec("Fec_Carga"); 
        i.Observ = dr.Text("Observ");
        i.anos_vigencia_cargo = dr.Num("anos_vigencia");
        i.Fec_Insc_OP = dr.Text("Fec_Insc_OP");
        return i;
    }

    public List<BE_Directivo> Listar_Directivos_Por_Vencer()
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Directivos_Por_Vencer(cn);
        while (dr.Read())
        {
            BE_Directivo i = new BE_Directivo();
            i.Cod_OP = dr.Num("Cod_OP");
            i.Des_Tipo_OP = dr.Text("des_tipo_op");
            i.Des_OP = dr.Text("des_OP");
            i.Abogado_OP = dr.Text("Asistente");
            i.num_repres_proxfin = dr.Num("num_directivos");
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }

    public List<BE_Directivo> Listar_Directivos_Vencidos()
    {
        List<BE_Directivo> r = new List<BE_Directivo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_Directivos_Vencidos(cn);
        while (dr.Read())
        {
            BE_Directivo i = new BE_Directivo();
            i.Cod_OP = dr.Num("Cod_OP");
            i.Des_Tipo_OP = dr.Text("des_tipo_op");
            i.Des_OP = dr.Text("des_OP");
            i.Abogado_OP = dr.Text("Asistente");
            i.num_repres_proxfin = dr.Num("num_directivos");

            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;

    }



   
    public int Baja_Directivo(BE_Directivo c)
    {
        return data.Baja_Directivo(c);
    }

    public string Agregar(BE_Directivo c)
    {
        return data.Agregar(c);
    }

    public int Modificar(BE_Directivo c)
    {
        return data.Modificar(c);
    }
   

    public BL_Directivo() { data = new DA_Directivo(); }
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

