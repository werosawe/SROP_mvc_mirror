using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

public class BL_Representantes : BL_BASE
{
    private DA_Representantes data;
    public List<BE_Representantes> Listar_Representantes(BE_Representantes c)
    {
        List<BE_Representantes> r = new List<BE_Representantes>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Representantes(cn, c);
            while (dr.Read())
            {
                BE_Representantes i = new BE_Representantes();
                i.Cod_OP = c.Cod_OP;
                i.DNI = dr.Text("cod_dni");
                i.ApePat_PE = dr.Text("apepat_pe");
                i.ApeMat_PE = dr.Text("apemat_pe");
                i.Nombres_PE = dr.Text("nombre_pe");
                i.Nombre_Completo = dr.Text("nombre_completo");
                i.Cod_Cargo = dr.Text("cod_cargo");
                i.Des_Cargo = dr.Text("des_cargo");
                i.Cod_Cargo_Comun = dr.Text("cod_cargo_comun");
                i.Des_Cargo_Comun = dr.Text("des_cargo_comun");
                i.Cod_Motivo_Baja = dr.Text("cod_motivo_baja");
                i.EsAfiliado = dr.Num("esafiliado") == 1 ? true : false;
                r.Add(i);
            }           
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public List<BE_Representantes> Listar_Personeros(BE_Representantes c)
    {
        List<BE_Representantes> r = new List<BE_Representantes>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Personeros(cn, c);
            while (dr.Read())
            {
                BE_Representantes i = new BE_Representantes();

                i.Cod_OP = c.Cod_OP;
                i.DNI = dr.Text("cod_dni");
                i.ApePat_PE = dr.Text("apepat_pe");
                i.ApeMat_PE = dr.Text("apemat_pe");
                i.Nombres_PE = dr.Text("nombre_pe");
                i.Nombre_Completo = dr.Text("nombre_completo");
                i.Cod_Cargo = dr.Text("cod_cargo");
                i.Des_Cargo = dr.Text("des_cargo");
                i.Cod_Cargo_Comun = dr.Text("cod_cargo_comun");
                i.Des_Cargo_Comun = dr.Text("des_cargo_comun");
                i.Cod_Motivo_Baja = dr.Text("cod_motivo_baja");
                i.EsAfiliado = bool.Parse(dr.Text("esafiliado"));

                r.Add(i);
            }           
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    private List<BE_Representantes> Listar_Repres_x_Cargos(BE_Representantes c)
    {
        List<BE_Representantes> r = new List<BE_Representantes>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Cargos_Repres(cn, c);
            while (dr.Read())
            {
                BE_Representantes i = new BE_Representantes();

                i.Cod_OP = dr.Num("cod_op");
                i.TXESTADOINSCRIPCION = dr.Text("des_estado_inscrip");
                i.Cod_Cargo = dr.Text("cod_cargo");
                i.Des_Cargo = dr.Text("des_cargo");
                i.Cod_Cargo_Comun = dr.Text("cod_cargo_comun");
                i.Des_Cargo_Comun = dr.Text("des_cargo_comun");
                i.COD_CORRELATIVO = dr.Text("cod_correl");
                i.DNI = dr.Text("cod_dni");
                i.Nombre_Completo = dr.Text("nombre_completo");
                i.ApePat_PE = dr.Text("apepat_pe");
                i.ApeMat_PE = dr.Text("apemat_pe");
                i.Nombres_PE = dr.Text("nombre_pe");
                i.EsAfiliado = bool.Parse(dr.Text("EsAfiliado"));
                i.Cod_Motivo_Baja = dr.Text("cod_motivo_baja");
                i.DES_MOTIVO = dr.Text("des_motivo");
                i.FEBAJA = dr.Fec("fec_baja");
                i.FECARGA = dr.Fec("fec_carga");
                i.TXOBSERVACION = dr.Text("observ");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public List<BE_Cargo> Listar_Cargos_Repres(BE_Representantes c)
    {
        List<BE_Cargo> r = new List<BE_Cargo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Cargos_Repres(cn, c);
            while (dr.Read())
            {
                BE_Cargo i = new BE_Cargo();
                i.Cod_OP = c.Cod_OP;
                i.Cod_Cargo = dr.Text("cod_cargo");
                i.Des_Cargo = dr.Text("des_cargo");
                c.Cod_Cargo = i.Cod_Cargo;
                i.RepresentanteCol = Listar_Repres_x_Cargos(c);
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }

    public BL_Representantes() { data = new DA_Representantes(); }
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

