using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_Cargo : BL_BASE
	{

        private DA_Cargo data;
    public List<BE_Cargo> Listar_Cargos(string Condicion_Busq = "")
    {
        List<BE_Cargo> r = new List<BE_Cargo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Listar_Cargos(cn, Condicion_Busq);
            while (dr.Read())
            {
                BE_Cargo i = new BE_Cargo();
                i.Cod_Cargo = dr.Text("Cod_Cargo");
                i.Des_Cargo = dr.Text("Des_Cargo");
                r.Add(i);
            }
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


    public List<BE_Cargo> Cargar_Cargos_Internauta(BE_Cargo c)
    {
        List<BE_Cargo> r = new List<BE_Cargo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Cargar_Cargos_Internauta(cn, c);
            while (dr.Read())
            {
                BE_Cargo i = new BE_Cargo();

                i.Cod_Cargo = dr.Text("cod_cargo");
                i.Des_Cargo = dr.Text("des_cargo");
                i.DesMotivo = dr.Text("des_motivo");
                i.Fec_Carga = string.Format("{0:dd/MM/yyyy}", dr.Text("fec_carga"));
                i.Fec_Baja = string.Format("{0:dd/MM/yyyy}", dr.Text("fec_carga"));
                i.Cod_Motivo_Baja = dr.Text("cod_motivo_baja");

                r.Add(i);
            }            
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }

    }

    public List<BE_Cargo> Cargar_Cargos(BE_Cargo c)
    {
        List<BE_Cargo> r = new List<BE_Cargo>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = null;
        try
        {
            dr = data.Cargar_Cargos(cn, c);
            while (dr.Read())
            {
                BE_Cargo i = new BE_Cargo();

                i.Cod_Cargo = dr.Text("cod_cargo");
                i.Des_Cargo = dr.Text("des_cargo");
                i.DesMotivo = dr.Text("des_motivo");
                i.Fec_Carga = string.Format("{0:dd/MM/yyyy}", dr.Text("fec_carga"));
                i.Fec_Baja = string.Format("{0:dd/MM/yyyy}", dr.Text("fec_carga"));
                i.Cod_Motivo_Baja = dr.Text("cod_motivo_baja");
                r.Add(i);
            }
            Agruparr(ref r);
            return r;
        }
        finally
        {
            pCerrarDr(cn, dr);
        }
    }


		private void Agruparr(ref List<BE_Cargo> r)
		{
			string xDes_Cargo = "x";


			foreach (BE_Cargo i in r) {
				if (xDes_Cargo != i.Des_Cargo) {
					i.IsFirstRowWithThisCargo = true;
					xDes_Cargo = i.Des_Cargo;
				} else {
					i.IsFirstRowWithThisCargo = false;
				}

				i.CountOfWithThisCargo = Count_Cargos(xDes_Cargo, r);
			}

		}

		private int Count_Cargos(string xDes_Cargo, List<BE_Cargo> r)
		{
			int n = 0;
			foreach (BE_Cargo i in r) {
				if (xDes_Cargo == i.Des_Cargo) {
					n = n + 1;
				}
			}
			return n;
		}

    public List<string> Agregar(BE_Cargo c)
    {
        return data.Agregar(c);
    }

        public BL_Cargo() { data = new DA_Cargo(); }
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

