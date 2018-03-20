using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SROP.Controllers.api
{
    public class UbigeoApiController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetsProvincia([FromUri] BE_UBIGEO c)//(int CO_GRUPO)
        {
            BL_Ubigeo b = new BL_Ubigeo();
            try {
                List<BE_UBIGEO> r = b.Listar_Provincias(c);
                return Json(new
                {
                    data = r,
                    total = r.Count,
                    success = true,

                });
            }
            catch (Exception ex)
            {
                throw ex;
            } finally {
                b.Dispose();b = null;
            }
            //r.Sort(new Sorter<BE_Ubigeo>("TXPROVINCIA ASC"));
        }

        [HttpGet]
        public IHttpActionResult GetsDistrito([FromUri] BE_UBIGEO c)//(int CO_GRUPO)
        {
            BL_Ubigeo b = new BL_Ubigeo();
            try
            {
                List<BE_UBIGEO> r = b.Listar_Distritos(c);
                //r.Sort(new Sorter<BE_Ubigeo>("TXDISTRITO ASC"));
                return Json(new
                {
                    data = r,
                    total = r.Count,
                    success = true,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }


    }
}
