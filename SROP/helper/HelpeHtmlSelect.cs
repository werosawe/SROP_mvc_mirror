using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MTD.BL;
using MTD.BE;
public  static partial class Input
{

    public static MvcHtmlString selectEstadoOP<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_EstadoOP b = new BL_EstadoOP();
        List<SelectListItem> r = b.GetsEstadoOrganizacionPolitica();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectTipoAsiento<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_TipoAsiento b = new BL_TipoAsiento();
        try
        {
            return select(helper, expression, htmlAttributes, customAtributes, b.Gets2(), flRequerido, msgSelecciona);
        }
        finally
        {
            b.Dispose(); b = null;
        }
    }

    public static MvcHtmlString selectMotivoCancelaInscripcionEtapa<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_TipoCancel b = new BL_TipoCancel();
        try
        {
            return select(helper, expression, htmlAttributes, customAtributes, b.Gets2(), flRequerido, msgSelecciona);
        }
        finally
        {
            b.Dispose(); b = null;
        }
    }

    public static MvcHtmlString selectTipoEtapa<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        if (customAtributes != null)
        {
            System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(customAtributes);
            KeyValuePair<string, object> k = attributos.First(x => x.Key == "CODTIPOMOV");

            if (k.Key != null)
            {
                BL_EstadoInsc b = new BL_EstadoInsc();
                string CODTIPOMOV = k.Value.Text();
                try
                {
                    r = b.Gets2(new BE_EstadoInsc(CODTIPOMOV));
                }
                finally
                {
                    b.Dispose(); b = null;
                }
            }
        }
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectTipoMovimientoEtapa<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_TipoMov b = new BL_TipoMov();
        try
        {            
            return select(helper, expression, htmlAttributes, customAtributes, b.Gets(), flRequerido, msgSelecciona);
        }
        finally
        {
            b.Dispose(); b = null;
        }
    }
    public static MvcHtmlString selectEnte<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Ente b = new BL_Ente();
        try
        {   
            return select(helper, expression, htmlAttributes, customAtributes, b.GetsEnte(), flRequerido, msgSelecciona);
        }
        finally
        {
            b.Dispose(); b = null;
        }
    }

    public static MvcHtmlString selectMTDExpedientePrefijo<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Ente b = new BL_Ente();
        BE_Ente e = new BE_Ente();
        try
        {
            //e.Cod_Ente = Yoo.CodEnte;
            e.Cod_Ente = "00";
            List<SelectListItem> r = b.GetsPrefijoExpedienteMTD(e);
            return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
        }
        finally
        {
            b.Dispose(); b = null;
        }
    }


    //public List<SelectListItem> GetsAnnoExpedienteMTD()
    //{
    //    List<SelectListItem> r = new List<SelectListItem>();
    //    for (int i = 2003; i <= DateTime.Now.Year; i++)
    //    {
    //        SelectListItem item = new SelectListItem();
    //        item.Value = i.Text();
    //        item.Text = i.Text();
    //        r.Add(item);
    //    }
    //    return r;
    //}

    public static MvcHtmlString selectMTDExpedienteAnno<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        List<SelectListItem> r = new List<SelectListItem>();
        for (int i = DateTime.Now.Year; i >= 2003; i--)
        {
            SelectListItem item = new SelectListItem();
            item.Value = i.Text();
            item.Text = i.Text();
            r.Add(item);
        }
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
       
    }


    public static MvcHtmlString selectMTDDocumentosExpediente<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {   
        List<SelectListItem> r = new List<SelectListItem>();
        if (customAtributes != null)
        {            
            System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(customAtributes);
            KeyValuePair<string, object> k = attributos.First(x => x.Key == "CODEXPEDIENTE");

            if (k.Key != null)
            {              
                string CODEXPEDIENTE = k.Value.Text();
                BL_Documento b = new BL_Documento();
                try
                {
                    List<BE_Documento> rDocumento = b.GetsDocumentos(new BE_Expediente(CODEXPEDIENTE));                    
                    foreach (BE_Documento item  in rDocumento)
                    {
                        SelectListItem i = new SelectListItem();
                        i.Value = item.CODDOCUMENTO;
                        i.Text = item.CODDOCUMENTO;
                        r.Add(i);
                    }                  
                }
                finally
                {
                    b.Dispose(); b = null;
                }              
            }
        }
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }


    public static MvcHtmlString selectAbogado<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Abogado b = new BL_Abogado();
        List<SelectListItem> r = b.GetsAbogado();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectDepartamento<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Ubigeo b = new BL_Ubigeo();
        List<SelectListItem> r = b.GetsDepartamento();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectProvincia<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        
        List<SelectListItem> r = null;
        if (customAtributes != null)
        {
            System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(customAtributes);
            KeyValuePair<string, object> k = attributos.First(x => x.Key == "UBIREGION");
            if (k.Key != null) {
                BL_Ubigeo b = new BL_Ubigeo();
                BE_UBIGEO i = new BE_UBIGEO();
                i.UBIREGION = k.Value.Text();
                r = b.GetsProvincia(i);
                b.Dispose();b = null;
            }
        }      
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectDistrito<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {

        List<SelectListItem> r = null;
        if (customAtributes != null)
        {
            System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(customAtributes);
            KeyValuePair<string, object> kRegion = attributos.First(x => x.Key == "UBIREGION");
            KeyValuePair<string, object> kProvincia = attributos.First(x => x.Key == "UBIPROVINCIA");
            if (kRegion.Key != null && kProvincia.Key != null)
            {
                BL_Ubigeo b = new BL_Ubigeo();
                BE_UBIGEO i = new BE_UBIGEO();
                i.UBIREGION = kRegion.Value.Text();
                i.UBIPROVINCIA = kProvincia.Value.Text();
                r = b.GetsDistrito(i);
                b.Dispose(); b = null;
            }
        }
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }


    public static MvcHtmlString selectTipoOrganizacionPolitica<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_TipoOP b = new BL_TipoOP();
        List<SelectListItem> r = b.GetsTipoOrganizacionPolitica();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectTipoLibro<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Tipo b = new BL_Tipo();
        List<SelectListItem> r = b.GetsTipoLibro();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectTipoZona<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Tipo b = new BL_Tipo();
        List<SelectListItem> r = b.GetsTipoZona();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectTipoVia<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Tipo b = new BL_Tipo();
        List<SelectListItem> r = b.GetsTipoVia();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

    public static MvcHtmlString selectAmbito<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flRequerido = false, string msgSelecciona = null)
    {
        BL_Ambito b = new BL_Ambito();
        List<SelectListItem> r = b.GetsAmbito();
        return select(helper, expression, htmlAttributes, customAtributes, r, flRequerido, msgSelecciona);
    }

}