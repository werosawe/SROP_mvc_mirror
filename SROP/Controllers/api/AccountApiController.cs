using System.Linq;
using System.Web.Http;
using System.Web;
namespace SROP.Controllers.api
{
    public class AccountApiController : BaseApiController
    {

        //[HttpPost]
        //public IHttpActionResult Login([FromBody] BE_USUARIO c)
        //{
        //    if (c.UserName.EsNulo()) {msgAdvertencia("Ingrese usuario"); }
        //    if (c.PasswordInDB.EsNulo()) { msgAdvertencia("Ingrese clave."); }
        //    if (HttpContext.Current.Request.Form["TXCAPCHA"].EsNulo()) { msgAdvertencia("Ingrese codigo de la imagen."); }
        //    if (ModelState.IsValid)
        //    {
        //        BL_PAGINA bPagina = new BL_PAGINA();
        //        BL_USUARIO bUsuario = new BL_USUARIO();              
        //        c = bPagina.Get(c);
        //        return Json(new
        //        {
        //            data = c,
        //            success = true,
        //            mensaje = CO_Constante.menRegistroModificacion
        //        });
        //    }
        //    else {

        //        return Json(new
        //        {
        //            success = false,
        //            data = c,
        //            errors = ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).First())
        //        });
              
        //    }
          
        //}

        //[HttpPost]
        //public IHttpActionResult Edita([FromBody] BE_PAGINA c)
        //{
        //    if (c.TXTITULO.EsNulo()) { ModelState.AddModelError("TXTITULO", "Ingrese nombre del menú."); }
        //    if (ModelState.IsValid)
        //    {
        //        BL_PAGINA b = new BL_PAGINA();
        //    b.EDIT(c);
        //    c = b.Get(c);
        //    return Json(new
        //    {
        //        data = c,
        //        success = true,
        //        mensaje = CO_Constante.menRegistroModificacion
        //    });
        //    }
        //    else
        //    {

        //        return Json(new
        //        {
        //            success = false,
        //            data = c,
        //            errors = ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).First())
        //        });

        //    }
        //}


        //[HttpPost]
        //public IHttpActionResult Elimina([FromBody] BE_PAGINA c)
        //{
        //    BL_PAGINA b = new BL_PAGINA();
        //    b.DEL(c);
        //    return Json(new
        //    {
        //        data = c,
        //        success = true,
        //        mensaje = CO_Constante.menRegistroElimino
        //    });
        //}


    }
}
