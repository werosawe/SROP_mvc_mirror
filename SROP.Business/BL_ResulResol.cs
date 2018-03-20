using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_ResulResol : BL_BASE
	{
        private DA_ResulResol data;
        public List<BE_ResulResol> Listar_ResulResol()
		{
			List<BE_ResulResol> r = new List<BE_ResulResol>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Resul_Resoluciones(cn);
				while (dr.Read()) {
					BE_ResulResol i = new BE_ResulResol();

					i.Cod_Resultado = dr.Text("Cod_Resultado");
					i.Des_Resultado = dr.Text("Des_Resultado");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

        public BL_ResulResol() { data = new DA_ResulResol(); }
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

