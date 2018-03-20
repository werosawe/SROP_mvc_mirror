using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;


	public class BL_DocLegales : BL_BASE
	{
        private DA_DocLegales data;
    public List<BE_DocLegales> Listar_DocLeg_Cab(BE_DocLegales c)
    {
        string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
        List<BE_DocLegales> r = new List<BE_DocLegales>();
        OracleConnection cn = new OracleConnection(TX_ESQUEMA);
        OracleDataReader dr = data.Listar_DocLeg_Cab(cn, c);
        while (dr.Read())
        {
            BE_DocLegales i = new BE_DocLegales();
            i.Cod_Pri = dr.Text("cod_pri");
            i.TX_Titulo = dr.Text("titulo");
            i.TX_Folder = dr.Text("folder");
            i.TX_Archivo = dr.Text("archivo");
            i.URL_archivo = _URL + dr.Text("url_archivo");
            i.DocLegDetalle = data.Listar_DocLeg_Det(i);
            foreach (DataRow oRow in i.DocLegDetalle.Rows)
            {
                oRow["url_archivo"] = _URL + oRow["url_archivo"].ToString();
            }
            r.Add(i);
        }
        pCerrarDr(cn, dr);
        return r;
    }

		public List<BE_DocLegales> Listar_DocLeg(BE_DocLegales c)
		{

			string _URL = Funciones.Dame_Valor_WebConfig("URL_SROP");
			List<BE_DocLegales> r = new List<BE_DocLegales>();
			OracleConnection cn = new OracleConnection(TX_ESQUEMA);
			OracleDataReader dr = data.Listar_DocLeg(cn, c);
      				while (dr.Read()) {
					BE_DocLegales i = new BE_DocLegales();

					i.Cod_Pri = dr.Text("cod_pri");
					i.Cod_Sec = dr.Text("cod_sec");
					i.Cod_Ter = dr.Text("cod_ter");
					i.TX_Titulo = dr.Text("titulo");
					i.TX_Archivo = dr.Text("archivo");
					i.TX_Folder = dr.Text("folder");
					i.URL_archivo = dr.Text("url_docum");
					i.FLVISIBLE = dr.Num("flg_visible");
					i.fec_solic = dr.Fec("fec_solic");  
					i.sub_items = dr.Num("sub_items");

					//SELECT d1.cod_pri,
					//       d1.cod_sec,
					//       d1.cod_ter,
					//       d1.titulo titulo,
					//       d1.archivo,
					//       d1.folder,
					//       d1.folder || d1.archivo url_docum,
					//       d1.flg_visible,
					//       d1.fec_solic,
					//       (SELECT COUNT ('x')
					//          FROM tbl_docs_legales d2
					//         WHERE d2.cod_pri = d1.cod_pri)
					//          subis

					r.Add(i);
				}
pCerrarDr(cn, dr);
				return r;			
		}

        public BL_DocLegales() { data = new DA_DocLegales(); }
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

