using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

using System.IO;


	public class BL_ReqTipoOP : BL_BASE
	{
        private DA_Req_TipoOP data;
        public List<BE_ReqTipoOP> Listar_RequisitoTipo_OP(BE_ReqTipoOP c)
        {
            List<BE_ReqTipoOP> r = new List<BE_ReqTipoOP>();
            OracleConnection cn = new OracleConnection(TX_ESQUEMA);
            OracleDataReader dr = data.Listar_RequisitoTipo_OP(cn, c);       
                while (dr.Read())
                {
                    BE_ReqTipoOP i = new BE_ReqTipoOP();
                    i.Cod_Req = dr.Text("Cod_Req");
                    i.Des_Req = dr.Text("Des_Req");
                    r.Add(i);
                }
            pCerrarDr(cn, dr);
            return r;
           
        }

        public BL_ReqTipoOP() { data = new DA_Req_TipoOP(); }
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

