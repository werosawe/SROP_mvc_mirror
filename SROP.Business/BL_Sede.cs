using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_Sede : BL_BASE
	{
        private DA_Sede data;
        public List<BE_Sede> Listar_Sedes(string UserId)
		{
			List<BE_Sede> r = new List<BE_Sede>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Sedes(cn, UserId.ToLower());
				while (dr.Read()) {
					BE_Sede i = new BE_Sede();

					i.Cod_Ente = dr.Text("Cod_Ente");
					i.Des_Ente = dr.Text("Des_Ente");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
		
		}


        public BL_Sede() { data = new DA_Sede(); }
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

