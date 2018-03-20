using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;

	public class BL_ComiteLista : BL_BASE
	{

        private DA_ComiteLista data;
     
		public List<BE_ComiteLista> Listar_Comites(int Cod_OP, int Nro_Entrega)
		{
			List<BE_ComiteLista> r = new List<BE_ComiteLista>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Comites(cn, Cod_OP, Nro_Entrega);
        
				while (dr.Read()) {
					BE_ComiteLista i = new BE_ComiteLista();

					i.Cod_OP = dr.Num("Cod_OP");
					i.Cod_Tipo_OP = dr.Text("Cod_Tipo_OP");
					i.Des_OP = dr.Text("Des_Op");
					i.Num_Afil_Val = dr.Num("Num_Afil_Val");
                    i.Fec_Carga = dr.Text("Fec_Carga").Substring(0, 10);
					i.Region = dr.Text("Region");
					i.Provincia = dr.Text("Provincia");
					i.Distrito = dr.Text("Distrito");
					i.UBIREGION = dr.Text("UbiRegion");
					i.UBIPROVINCIA = dr.Text("UbiProv");
					i.UBIDISTRITO = dr.Text("UbiDist");
					i.FLCUMPLE = dr.Num("Flg_Cumple");
					i.Nro_Entrega = dr.Num("Nro_Entrega");
					i.Dir_Comite = dr.Text("Dir_Comite");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;			
		}


		public List<BE_ComiteLista> Listar_Comites_Uniq(int Cod_OP, string str_entregas)
		{
			List<BE_ComiteLista> r = new List<BE_ComiteLista>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Comites_Uniq(cn, Cod_OP, str_entregas);     
				while (dr.Read()) {
					BE_ComiteLista i = new BE_ComiteLista();
					i.Orden = dr.Num("Orden");
					i.Cod_OP = dr.Num("Cod_OP");
					i.Des_OP = dr.Text("Des_Op");
					i.Region = dr.Text("Region");
					i.Provincia = dr.Text("Provincia");
					i.Distrito = dr.Text("Distrito");
					i.UBIREGION = dr.Text("UbiRegion");
					i.UBIPROVINCIA = dr.Text("UbiProv");
					i.UBIDISTRITO = dr.Text("UbiDist");
					i.Dir_Comite = dr.Text("Dir_Comite");
					i.Num_Afil_Val = dr.Num("num_afil_val");
					i.Num_Comites_Dist = dr.Num("num_comites_dist");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

    public DataTable DT_Comites(int Cod_OP, int Nro_Entrega)
    {
        DA_ComiteLista data = new DA_ComiteLista();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Listar_Comites(cn, Cod_OP, Nro_Entrega);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;
    }

    public DataTable DT_Comites_Uniq(int Cod_OP, string str_entregas)
    {

        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        DataTable dt = new DataTable();
        OracleDataReader dr = data.Listar_Comites_Uniq(cn, Cod_OP, str_entregas);
        dt.Load(dr);
        pCerrarDr(cn, dr);
        return dt;

    }

		public List<BE_ComiteLista> Listar_Comites_Dist(BE_ComiteLista c)
		{
			List<BE_ComiteLista> r = new List<BE_ComiteLista>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Comites_Dist(cn, c);
				while (dr.Read()) {
					BE_ComiteLista i = new BE_ComiteLista();
					i.Cod_OP = dr.Num("Cod_OP");
					i.Des_OP = dr.Text("Des_Op");
					i.Region = dr.Text("Region");
					i.Provincia = dr.Text("Provincia");
					i.Distrito = dr.Text("Distrito");
					i.UBIREGION = dr.Text("UbiRegion");
					i.UBIPROVINCIA = dr.Text("UbiProv");
					i.UBIDISTRITO = dr.Text("UbiDist");
					i.Dir_Comite = dr.Text("Dir_Comite");
					i.Num_Afil_Val = dr.Num("num_afil_val");
					i.Nro_Entrega = dr.Num("nro_entrega");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

		public int Numero_Provincias(BE_ComiteLista c)
		{
        return data.Numero_Provincias(c);
    }


		public int Numero_Distritos(BE_ComiteLista c)
		{
        return data.Numero_Distritos(c);

    }

		public int Agregar(BE_ComiteLista c)
		{
        return data.Agregar(c);
    }

		public int Modificar(BE_ComiteLista c)
		{
        return data.Modificar(c);
    }


		public int EliminarComite(BE_ComiteLista c)
		{
        return data.Eliminar(c);
    }

        public BL_ComiteLista() { data = new DA_ComiteLista(); }
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

