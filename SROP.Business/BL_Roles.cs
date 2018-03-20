using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_Roles : BL_BASE
	{
        private DA_Roles data;
        public List<BE_Roles> Listar_Roles()
		{
			List<BE_Roles> r = new List<BE_Roles>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Roles(cn);
				while (dr.Read()) {
					BE_Roles i = new BE_Roles();

					i.Cod_Rol = dr.Text("Cod_Rol");
					i.Des_Rol = dr.Text("Des_Rol");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

        public BL_Roles() { data = new DA_Roles(); }
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

