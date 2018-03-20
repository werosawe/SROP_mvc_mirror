using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


public static class MenuHtml

{
    public static IHtmlString Cargar(this string url, HttpContext c)
    {
        //BL_PAGINA b = new BL_PAGINA();
        //List<BE_PAGINA> r = b.GetsActivo(new BE_PAGINA());
        //List<BE_PAGINA> r = Yoo.Paginas;
        //c.Request.RequestContext.RouteData <span class='tag tag tag-primary tag-pill float-xs-right mr-2'>1</span>

        string Area = c.Request.RequestContext.RouteData.DataTokens["Area"].Mayuscula();
        string controller = c.Request.RequestContext.RouteData.Values["Controller"].Mayuscula();
        string Action = c.Request.RequestContext.RouteData.Values["Action"].Mayuscula();
        List<BE_PAGINA> r = Yoo.Paginas;
        BE_PAGINA i =  r.Find(x => x.TXAREA.Mayuscula() == Area & x.TXCONTROLADOR.Mayuscula() == controller & x.TXACCION.Mayuscula() == Action );
        return Generar(Yoo.Paginas, url, i);
    }

    private static List<BE_PAGINA> _origen;
    private static List<BE_PAGINA> _origenChildren;
  
    private static StringBuilder s ;
    private static IHtmlString Generar(this List<BE_PAGINA> origen, string url, BE_PAGINA PaginaSeleccionada)
    {
        s = new StringBuilder("");
      
        _origen = origen;

        s.Append("<li class='nav-item'>");
        s.Append( string.Concat("<a href='",string.Format(url, "Home/Index"), "'><i class='icon-home3'></i><span data-i18n='nav.Home.Index' class='menu-title'>Inicio</span></a>"));
        s.Append("</li>");


        var newList = _origen.GroupBy(x => new { x.IDAREA, x.TXAREA, x.TXAREADESCRIPCION })
                     .Select(y => new BE_PAGINA()
                     {
                         IDAREA = y.Key.IDAREA,
                         TXAREA = y.Key.TXAREA,
                         TXAREADESCRIPCION = y.Key.TXAREADESCRIPCION,
                         children = y.ToList()
                     }
                     );

        foreach (var i in newList)
        {
            //s.Append("<li class='navigation-header'>");
            //s.Append(string.Concat("<span data-i18n='nav.category.layouts'>", i.TXAREADESCRIPCION, "</span><i data-toggle='tooltip' data-placement='right' data-original-title='", i.TXAREADESCRIPCION, "' class='icon-ellipsis icon-ellipsis'></i>"));
            //s.Append("</li>");
         
            _origenChildren = i.children;
            Carguito(i, url,true, PaginaSeleccionada);
        }


        return new HtmlString(s.ToString());
    }


    private static void Carguito(BE_PAGINA doc, string url, bool flprimero, BE_PAGINA PaginaSeleccionada)
    {
        int IDPAGINA = 0;
        if (doc != null) { IDPAGINA = doc.IDPAGINA; }
        doc.children = _origenChildren.FindAll(x => x.IDPAGINAPADRE == IDPAGINA);
        doc.children.Sort(new Sorter<BE_PAGINA>("NUORDEN"));

        if (flprimero == false)
        {
            if (doc.children.Count > 0)
            {
                s.Append("<ul class='menu-content'>");
            }
        }
        //if (r.Count > 0)
        //{
        //    // Verficar el primer y el ultimo elemento de cada grupo
        //    BE_PAGINA docFirst = r.First();
        //    if (docFirst != null) { docFirst.isFirst = true; }
        //    BE_PAGINA docLast = r.Last();
        //    if (docLast != null) { docLast.isLast = true; }            
        //}

        //c.Request.RequestContext.RouteData

        foreach (BE_PAGINA i in doc.children)
        {
            if (flprimero == true)
            {
                if (PaginaSeleccionada != null)
                {
                    if (i.IDPAGINA == PaginaSeleccionada.IDPAGINAPADRE)
                    {
                        s.Append("<li class='nav-item open'>");
                    }
                    else {
                        s.Append("<li class='nav-item'>");
                    }                     
                }
                else {
                    s.Append("<li class='nav-item'>");
                }
                
                //s.Append("<li class='nav-item open'>");
                s.Append(string.Concat("<a href='", (i.TXCONTROLADOR.EsNulo() ? "#" : string.Format(url,string.Concat( i.TXAREA,"/", i.TXCONTROLADOR,"/", i.TXACCION))), "'><i class='icon-note'></i><span data-i18n='nav.", i.TXAREA, ".", i.TXCONTROLADOR, ".", i.TXACCION, "' class='menu-title'>", i.TXTITULO, "</span></a>"));
                Carguito(i, url, false, PaginaSeleccionada);
                s.Append("</li>");

            }
            else
            {                
                if (PaginaSeleccionada != null)
                {
                    if (i.IDPAGINA == PaginaSeleccionada.IDPAGINA) { s.Append("<li class='active' >");}
                    else { s.Append("<li>"); }
                }
                else
                {
                    s.Append("<li>");                   
                }

                s.Append(string.Concat("<a href='", (i.TXCONTROLADOR.EsNulo() ? "#" : string.Format(url, string.Concat(i.TXAREA, "/", i.TXCONTROLADOR, "/", i.TXACCION))), "' data-i18n='nav.", i.TXAREA, ".", i.TXCONTROLADOR, ".", i.TXACCION, "' class='menu-item'>", i.TXTITULO, "</a>"));

                Carguito(i, url,false, PaginaSeleccionada);
                s.Append("</li>");
                
            }
        }
        if (flprimero == false)
        {

            if (doc.children.Count > 0)
            {
                s.Append("</ul>");
            }
        }
        //var roots = groups.FirstOrDefault().ToList();

    }


}