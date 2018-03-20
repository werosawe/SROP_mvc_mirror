using System;
using System.Collections;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


	public class BL_Requisito : BL_BASE
	{
        private DA_Requisito data;
        public List<BE_Requisito> Listar_Requisitos(int Cod_OP)
		{
			List<BE_Requisito> r = new List<BE_Requisito>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_Requisitos(cn, Cod_OP);
				while (dr.Read()) {
					BE_Requisito i = new BE_Requisito();
					
					i.Cod_OP = dr.Num("Cod_OP");
					i.Cod_Tipo_OP = dr.Text("Cod_Tipo_OP");
					i.Des_OP = dr.Text("Des_OP");
					i.Des_Tipo_OP = dr.Text("Des_Tipo_OP");
					i.Des_Req = dr.Text("Des_Req");
					i.Cod_Req = dr.Text("Cod_Req");
					i.FLCUMPLE = dr.Num("Flg_Cumple");
					i.Wf = dr.Text("Wf");
					i.Observ = dr.Text("Observ");
					r.Add(i);
				}
            pCerrarDr(cn, dr);
            return r;
		}

        public BL_Requisito() { data = new DA_Requisito(); }
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

