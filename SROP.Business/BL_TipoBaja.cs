using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_TipoBaja : BL_BASE
	{
        private DA_TipoBaja data;
        public List<BE_TipoBaja> Listar_TipoMov()
		{
			List<BE_TipoBaja> r = new List<BE_TipoBaja>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_MotivoBaja(cn);
				while (dr.Read()) {
					BE_TipoBaja i = new BE_TipoBaja();

					i.Cod_Motivo = dr.Text("Cod_Motivo");
					i.Des_Motivo = dr.Text("Des_Motivo");

					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
			
		}

        public BL_TipoBaja() { data = new DA_TipoBaja(); }
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

