using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;
using System.Linq;
using MTD.BE;
using SROP.Business.wsMTD;
/// Project	 : BL
/// Class	 : BL_PAGINA
///
/// ----------------------------------------------------------------------------- 
/// <summary>
///
/// </summary>
/// <remarks>
/// </remarks>
/// <history>
/// 	[Jonatan Abregu Chalco]	07/06/2017	Created
/// </history>
namespace MTD.BL
{
    public partial class BL_Documento : BL_BASE
    {

        public List<BE_Documento> GetsDocumentos(BE_Expediente c)
        {
            List<BE_Documento> r = new List<BE_Documento>();

            ws_MTD w = new ws_MTD();
            try
            {
                DataSet ds = w.ds_ListarDocumentosExp(c.CODEXPEDIENTE);
                DataTable dt = ds.Tables[0];
                foreach (DataRow rw in dt.Rows)
                {
                    BE_Documento i = new BE_Documento();
                    i.CODDOCUMENTO = rw["Cod_Documento"].Text();
                    r.Add(i);
                }
                return r;
            }
            finally
            {
                w.Dispose(); w = null;
            }
        }


        public BE_Documento GetDocumento(BE_Documento c)
        {
            List<BE_Documento> r = new List<BE_Documento>();
            ws_MTD w = new ws_MTD();
            try
            {
                DataSet ds = w.ds_ListarDocumentosExp(c.CODEXPEDIENTE);
                DataTable dt = ds.Tables[0];
                foreach (DataRow rw in dt.Rows)
                {
                    BE_Documento i = new BE_Documento();
                    i.CODDOCUMENTO = rw["Cod_Documento"].Text();
                    i.FERECEPCION = rw["Fec_Doc"].Text().fecha(new BE_PARAMETRO_FORMATOFECHA() { TXFORMATOENTRADA = "dd/MM/yyyy", TXFORMATOSALIDA = "yyyy-MM-dd" });
                    i.DESASUNTO = rw["Des_Asunto"].Text();
                    r.Add(i);
                }
                return r.Find(x => x.CODDOCUMENTO == c.CODDOCUMENTO);
            }
            finally
            {
                w.Dispose(); w = null;
                r.Clear();
            }
        }



        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
               
            }
            disposed = true;
            base.Dispose(disposing);
        }
        ~BL_Documento() { Dispose(false); }
    }
}