using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;


	public class BL_Constancia : BL_BASE
	{
        private DA_Constancia data;

        public BE_Constancia Emisor_Constancia(BE_Constancia c)
		{

			BE_Constancia i = new BE_Constancia();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Emisor_Constancia(cn, c);
				if (dr.Read()) {
					//i.Cod_DNI = dr.Item("cod_dni").ToString()
					i.Cod_Ente_Emisor = dr.Text("cod_ente_emisor");
					i.Des_Ente_Emisor = dr.Text("des_ente_emisor");
					i.Emite_Constancia_Afil = dr.Num("Emite_Constancia_Afil");
					//_num_const = CInt(dr.Item("num_constancia_afil"))
					i.Responsable_Constancia = dr["Responsable_Constancia"].ToString();
					i.txCargo_Responsable = dr["txCargo_Responsable"].ToString();
					i.txCargo_Responsable_A = dr["pronombre"].ToString() + " " + dr["txCargo_Responsable"].ToString();
					i.logo1 = dr["logo1"].ToString();
					i.logo2 = dr["logo2"].ToString();


				}
            pCerrarDr(cn, dr);
            return i;			
		}

		public DataTable Get_Constancia_Afil(BE_Constancia c)
		{
						OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			DataTable dt = new DataTable();
			OracleDataReader dr = data.Get_Constancia_Afil(cn, c);
				dt.Load(dr);
			
        pCerrarDr(cn, dr);
        return dt;
		}

		public List<BE_Constancia> Listar_Constancias_Afil(BE_Constancia c)
		{
			List<BE_Constancia> r = new List<BE_Constancia>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Constancias_Afil(cn, c);
     				while (dr.Read()) {
					BE_Constancia i = new BE_Constancia();

					i.Num_Const = dr.Num("num_const");
					i.Solicitante = dr.Text("solicitante");
					i.FileName = dr.Text("FileName");
					i.Cod_Ente_Emisor = dr.Text("cod_ente_constancia");
					i.Cod_Ente_Constancia = i.Cod_Ente_Emisor;
					i.Des_Ente_Emisor = dr.Text("ente");
					i.Ente = i.Des_Ente_Emisor;
					i.URL = dr.Text("url_");
					i.url_ = i.URL;
					i.Fecha = (dr["fec_const"] == null ? null : dr.Text("fec_const"));
					i.fec_const = dr.Fec("fec_const"); 

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

		public string Delete_Constancia_Afil(BE_Constancia c)
		{
        return data.Eliminar(c);
    }

		public BE_Constancia.Constancia_Afil Update_Constancia_Afil(BE_Constancia c)
		{
        return data.Update(c);
    }

		public BE_Constancia.Constancia_Afil Insert_Constancia_Afil(BE_Constancia c)
		{
        return data.Insert(c);
    }


		public List<BE_Constancia> Listar_Constancias_OP(BE_Constancia c)
		{
			List<BE_Constancia> r = new List<BE_Constancia>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Constancias_OP(cn, c);       
				while (dr.Read()) {
					BE_Constancia i = new BE_Constancia();

					i.Num_Const = dr.Num("num_const");
					i.Solicitante = dr.Text("solicitante");
					i.FileName = dr.Text("FileName");
					i.Cod_Ente_Emisor = dr.Text("cod_ente_constancia");
					i.Cod_Ente_Constancia = i.Cod_Ente_Emisor;
					//i.Des_Ente_Emisor = Dame_Texto(dr("ente"))
					//i.Ente = i.Des_Ente_Emisor
					i.URL = dr.Text("url_");
					i.url_ = i.URL;
					i.Fecha = (dr["fec_const"] == null ? null : dr.Text("fec_const"));
					i.fec_const = dr.Fec("fec_const");  

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}


		public DataTable Get_Constancia_OP(BE_Constancia c)
		{		
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			DataTable dt = new DataTable();
			OracleDataReader dr = data.Get_Constancia_OP(cn, c);
      				dt.Load(dr);			
        pCerrarDr(cn, dr);
        return dt;
		}

		public string Delete_Constancia_OP(BE_Constancia c)
		{
        return data.Eliminar_Const_OP(c);
    }

		public BE_Constancia.Constancia_OP Update_Constancia_OP(BE_Constancia c)
		{

        return data.Update_Constancia_OP(c);
    }

		public BE_Constancia.Constancia_OP Insert_Constancia_OP(BE_Constancia c)
		{
        return data.Insert_Constancia_OP(c);
    }

        public BL_Constancia() { data = new DA_Constancia(); }
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

