using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTD.BL;
using MTD.BE;
using System.Web.Mvc;

namespace SROP.Controllers.api
{
    public class MTDApiController : BaseApiController
    {


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetsDocumentos([FromUri]  BE_Expediente c)
        {
            List<BE_Documento> r = new List<BE_Documento>();
            BL_Documento b = new BL_Documento();
            try
            {
                c.pCODEXPEDIENTE();
                r = b.GetsDocumentos(c);
                return Json(new
                {
                    data = r,
                    total = r.Count,
                    success = true
                });
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetDocumento([FromUri] BE_Documento c)
        {
            BE_Documento i = null;
            BL_Documento b = new BL_Documento();
            try
            {
                c.pCODEXPEDIENTE();
                i = b.GetDocumento(c);
                return Json(new
                {
                    data = i,
                    success = true,
                });
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }


    }
}
