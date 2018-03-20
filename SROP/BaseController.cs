using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.SessionState;

public class BaseApiController : ApiController
{
    public void msgExito(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Exito)); }
    public void msgInformacion(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Informacion)); }
    public void msgPeligro(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Peligro)); }
    public void msgAdvertencia(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Advertencia)); }

    public void AnadirMensaje(BE_MENSAJE i)
    {
        List<BE_MENSAJE> r = new List<BE_MENSAJE>();
        if (HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] != null) { r = HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje].Text().DesSerializarLista<BE_MENSAJE>(); }
        r.Add(i);
        HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] = r.Serializar();
    }
    public bool ModeloValido
    {
        get
        {
            if (HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] == null) { return true; }
            else { return false; }

        }
    }
    private List<BE_MENSAJE> MensajeCol()
    {
        List<BE_MENSAJE> r = new List<BE_MENSAJE>();
        if (HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] != null) { r = HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje].Text().DesSerializarLista<BE_MENSAJE>(); }
        return r;
    }

    public List<BE_MENSAJE> Mensajee()
    {
        return  MensajeCol();
    }
    //public void msgExito(string _msg)
    //{
    //    ModelState.AddModelError("", new BE_MENSAJE(null, _msg, enumTipoMensaje.Exito).Serializar());
    //}
    //public void msgPeligro(string _msg)
    //{
    //    ModelState.AddModelError("", new BE_MENSAJE(null, _msg, enumTipoMensaje.Advertencia).Serializar());
    //}
    //public void msgInformacion(string _msg)
    //{
    //    ModelState.AddModelError("", new BE_MENSAJE(null, _msg, enumTipoMensaje.Informacion).Serializar());
    //}
    //public void msgAdvertencia(string _msg)
    //{
    //    ModelState.AddModelError("", new BE_MENSAJE(null, _msg, enumTipoMensaje.Peligro).Serializar());
    //}


}

public class BaseController : Controller, IRequiresSessionState
{  
    public void msgExito(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Exito)); }
    public void msgInformacion(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Informacion)); }
    public void msgPeligro(string _msg) { AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Peligro)); }
    public void msgAdvertencia(string _msg){ AnadirMensaje(new BE_MENSAJE(null, _msg, enumTipoMensaje.Advertencia));}

    public void AnadirMensaje(BE_MENSAJE i) {
        List<BE_MENSAJE> r = new List<BE_MENSAJE>();        
        if (HttpContext.Session[CO_Constante.VariableGlobalMensaje] != null) { r = Session[CO_Constante.VariableGlobalMensaje].Text().DesSerializarLista<BE_MENSAJE>(); }
        r.Add(i);
        HttpContext.Session[CO_Constante.VariableGlobalMensaje] = r.Serializar();
    }

    public bool ModeloValido
    {
        get
        {
            if (Session[CO_Constante.VariableGlobalMensaje] == null) { return true; }
            else { return false; }

        }
    }

   private List<BE_MENSAJE> MensajeCol()
    {
        List<BE_MENSAJE> r = new List<BE_MENSAJE>();
        if (HttpContext.Session[CO_Constante.VariableGlobalMensaje] != null) { r = Session[CO_Constante.VariableGlobalMensaje].Text().DesSerializarLista<BE_MENSAJE>(); }
        return r;
    }

    public PartialViewResult Mensajee()
    {
        return PartialView(Url.Content(CO_Constante.RutaVistaMensaje), MensajeCol());
    }

}




