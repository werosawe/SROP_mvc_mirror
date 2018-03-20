using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.Web.Mvc;
//using System.Web.WebPages;
//<HideModuleName()> <AttributeUsage(AttributeTargets.All)> _
public static partial class Glo
{
    private static int _QTREGISTROPORPAGINA = 10;
    private static int _QTPAGINAPORDEFECTO = 6;
    private static int _QTREGISTRO = 0;
    private static int _QTPAGINAENCONTRADA = 0;
    private static int _NUPAGINAACTUAL = -1;
    //private static bool FLSABANA = false;

    public static List<t> Paginar<t>(this List<t> source, int __NUPAGINAACTUAL)
    {
        _NUPAGINAACTUAL = __NUPAGINAACTUAL;
        if (_NUPAGINAACTUAL.Equals(-1) ) { _NUPAGINAACTUAL = 0; }  
        _QTREGISTRO = source.Count;
        if (FLSABANA == true) { return source.ToList(); }
        _QTPAGINAENCONTRADA = (int)Math.Ceiling((decimal)_QTREGISTRO / _QTREGISTROPORPAGINA);
        List<t> r = source.Skip((_NUPAGINAACTUAL) * _QTREGISTROPORPAGINA).Take(_QTREGISTROPORPAGINA).ToList();
        if (r.Count.Equals(0) & _NUPAGINAACTUAL > 0)
        {
            //_NUPAGINAACTUAL = NUPAGINAACTUAL - 1;
            return source.Skip((_NUPAGINAACTUAL) * _QTREGISTROPORPAGINA).Take(_QTREGISTROPORPAGINA).ToList();
            //return source.Skip(_NUPAGINAACTUAL * _QTREGISTROPORPAGINA).Take(_QTREGISTROPORPAGINA).ToList();
        }
        else
        {
            return r;
        }
    }

    public static List<BE_ORDEN> ORDEN_COL { get; set; }

    public static bool FLSABANA { get; set; } = false;
    //public static void SetParametroPaginador(List<BE_ORDEN> _ORDEN_COL, bool _FLSABANA =false)  {       
    //    ORDEN_COL = _ORDEN_COL;
    //    FLSABANA = _FLSABANA;
    //}
    //private static string NOCAMPOAPLICADOORDEN = null;
    public static HtmlString ColumnaTablaOrdena(string TXTEXTO, string _TXCAMPO, string _TXORDEN, int _NUPRIORIDAD)
    {
        string ICONOORDEN = "<span style='float:right;' class='glyphicon glyphicon-sort-by-attributes'></span>";
        if (ORDEN_COL.Count == 0)
        {
            if (_TXCAMPO == "DESC")
            {
                ICONOORDEN = "<span style='float:right;' class='glyphicon glyphicon-sort-by-attributes-alt'></span>";
            }
        }
        else
        {
            BE_ORDEN itemOrden = ORDEN_COL.Find(x => x.property == _TXCAMPO);
            if (itemOrden != null)
            {
                _TXORDEN = itemOrden.direction;
                ICONOORDEN = itemOrden.directionImage;
                _NUPRIORIDAD = itemOrden.priority;
            }
        }
        return new HtmlString(string.Concat("<th class='ordenatablafuncional' data-ordenatabla=\"{property:'", _TXCAMPO, "',direction:'", _TXORDEN, "',priority:", _NUPRIORIDAD, "}\" >", TXTEXTO, " ", ICONOORDEN, "</th>"));
        //return new HtmlString(string.Concat("<th class='ordenatablafuncional' data-ordenatabla=\"{property:'", _TXCAMPO, "',direction:'", _TXORDEN, "',priority:", _NUPRIORIDAD, "}\" style='cursor:pointer;' onclick =\"TablaJACH", "(this,2,'", NOFUNCION, "','", NOTABLA, "',1);\" >", TXTEXTO, " ", ICONOORDEN, "</th>"));
        //data - listarepresentante = '{ "CODOP" : @item.CODOP }'
        //return new HtmlString(string.Concat("<th style='cursor:pointer;' onclick=\"", NOFUNCION, "({propiedadordena:'", _TXCAMPO, "',direccionordena:'", _TXORDEN, "'});\" >", TXTEXTO, " ", ICONOORDEN, "</th>"));
    }

    //public static HtmlString onClickTableJACH()
    //{      
    //    return new HtmlString(string.Concat("onclick =\"TablaJACH(this,1,'", NOFUNCION, "','", NOTABLA, "',1);\""));
    //    //data - listarepresentante = '{ "CODOP" : @item.CODOP }'
    //    //return new HtmlString(string.Concat("<th style='cursor:pointer;' onclick=\"", NOFUNCION, "({propiedadordena:'", _TXCAMPO, "',direccionordena:'", _TXORDEN, "'});\" >", TXTEXTO, " ", ICONOORDEN, "</th>"));
    //}

    //onclick =\"TablaJACH(this,1,'", NOFUNCION, "','", IDTABLE, "',1);\"
    public static HtmlString Paginador(TableParam prm = null)
    {
        if (prm == null) { prm = new TableParam(); prm.Size = size.standart; }

        string Size = null;
        if (prm.Size == size.small) { Size = "pagination-sm"; }
        if (prm.Size == size.large) { Size = "pagination-lg"; }

        System.Text.StringBuilder s = new System.Text.StringBuilder("");
        if (FLSABANA == true)
        {
            if (_QTREGISTRO > 0)
            {

                s.Append(string.Concat("<pre>Se encontraron <mark>", _QTREGISTRO, "</mark> registros</pre>"));
                return new HtmlString(s.ToString());
            }
            else
            {
                s.Append(string.Concat("<div class='well well-sm' >No se encontraron registros</div>"));
                return new HtmlString(s.ToString());
            }
        }

        if (_QTREGISTRO.Equals(0))
        {
            s.Append(string.Concat("<div class='well well-sm' >No se encontraron registros</div>"));
            return new HtmlString(s.ToString());
        }
        else
        {
            s.Append(string.Concat("<pre>Pagina <mark>", _NUPAGINAACTUAL + 1, "</mark> de <mark>", _QTPAGINAENCONTRADA, "</mark>, N° registros: <mark>", _QTREGISTRO, "</mark></pre>"));
        }

        if (_QTPAGINAENCONTRADA > 1)
        {
            s.Append("<div class='text-xs-center'>");
            s.Append(string.Format("<ul class='pagination {0} pagination-flat pagination-round'>", Size));
            //_QTPAGINA
            int start = (_NUPAGINAACTUAL) - ((_NUPAGINAACTUAL) % _QTPAGINAPORDEFECTO);
            int end = (_NUPAGINAACTUAL) + (_QTPAGINAPORDEFECTO - ((_NUPAGINAACTUAL) % _QTPAGINAPORDEFECTO));

            string disabledFirst = null, disabledPrev = null;
            if (_NUPAGINAACTUAL == 0) { disabledFirst = " disabled"; }
            if (_NUPAGINAACTUAL == 0) { disabledPrev = " disabled"; }


            s.Append(string.Concat("<li class='first page-item", disabledFirst, "' title='Inicio' ><a href='#' class='page-link pagtablafuncional' data-paginatabla =\"{pagina:0}\" >&laquo;</a></li>"));
            s.Append(string.Concat("<li class='prev page-item", disabledPrev, "' title='Anterior' ><a href='#' class='page-link pagtablafuncional' data-paginatabla =\"{pagina:", _NUPAGINAACTUAL - 1, "}\" >&#8249;</a></li>"));


            if (_QTPAGINAENCONTRADA > _QTPAGINAPORDEFECTO)
            {
                if (start > _QTPAGINAPORDEFECTO - 1)
                {
                 
                }
            }



            int i = 0;
            for (i = start; i <= end - 1; i++)
            {
                if (i < _QTPAGINAENCONTRADA)
                {
                    if (i == _NUPAGINAACTUAL)
                    {
                       
                        s.Append(string.Concat("<li class='page active page-item'><a class='page-link' id='paginaactiva' data-paginaactiva =\"", i, "\"  href='#' >" + (i + 1) + "</a></li>"));
                    }
                    else
                    {
                        s.Append(string.Concat("<li class='page page-item' ><a  href='#' class='page-link pagtablafuncional' data-paginatabla =\"{pagina:", i, "}\"  >" + (i + 1) + "</a></li>"));
                        //s.Append("<li><a href=""#"">" & i + 1 & "</a></li>")
                    }
                  
                }
            }

            if (_QTPAGINAENCONTRADA > end)
            {
                //s.Append(string.Concat("<li class='page active page-item'><a class='page-link' id='paginaactiva' data-paginaactiva =\"", i, "\"  href='#' >" + (i + 1) + "</a></li>"));
                //s.Append(string.Concat("<li class='disabled PagedList-ellipses' ><a href='#' >..</a></li>"));


                //s.Append("<li><a href=""#"">..</a></li>")
                //Controls.Add(createButton("..", i))
                //Dim lnk_final As LinkButton = createButton("Final", i + 1)
                //'lnk_final.ValidationGroup = "Final"
                //Controls.Add(lnk_final) 'PageCount - 1)) '"&gt;&gt;"

                //s.Append("<li class=""PagedList-skipToLast""><a href=""#"">»»</a></li>")


            }

           string disabledNext = null, disabledLast = null;
            if (_NUPAGINAACTUAL == (_QTPAGINAENCONTRADA-1)) { disabledNext = " disabled"; }
            if (_NUPAGINAACTUAL == (_QTPAGINAENCONTRADA - 1)) { disabledLast = " disabled"; }
            s.Append(string.Concat("<li class='next page-item", disabledNext, "' title='Siguiente' ><a href='#' class='page-link pagtablafuncional' data-paginatabla =\"{pagina:", _NUPAGINAACTUAL + 1, "}\" rel='next'>&#8250;</a></li>"));
            s.Append(string.Concat("<li class='last page-item", disabledLast, "' title='Final' ><a href='#' class='page-link pagtablafuncional' data-paginatabla =\"{pagina:", _QTPAGINAENCONTRADA-1, "}\" >&raquo;</a></li>"));

            //Controls.Add(createButton(FirstPageText, 0))
            //Controls.Add(createButton("..", start - 1))
        }

        s.Append("</ul>");
        s.Append("</div>");
        //<div class="pagination-container"><ul class="pagination"><li class="PagedList-skipToFirst"><a href="/JNE.CAJA/Tramite/Index?page=1&amp;ID_PROCEDIMIENTO=1">««</a></li><li class="PagedList-skipToPrevious"><a href="/JNE.CAJA/Tramite/Index?page=6&amp;ID_PROCEDIMIENTO=1" rel="prev">«</a></li><li class="disabled PagedList-ellipses"><a>&#8230;</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=2&amp;ID_PROCEDIMIENTO=1">2</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=3&amp;ID_PROCEDIMIENTO=1">3</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=4&amp;ID_PROCEDIMIENTO=1">4</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=5&amp;ID_PROCEDIMIENTO=1">5</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=6&amp;ID_PROCEDIMIENTO=1">6</a></li><li class="active"><a>7</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=8&amp;ID_PROCEDIMIENTO=1">8</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=9&amp;ID_PROCEDIMIENTO=1">9</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=10&amp;ID_PROCEDIMIENTO=1">10</a></li><li><a href="/JNE.CAJA/Tramite/Index?page=11&amp;ID_PROCEDIMIENTO=1">11</a></li><li class="disabled PagedList-ellipses"><a>&#8230;</a></li><li class="PagedList-skipToNext"><a href="/JNE.CAJA/Tramite/Index?page=8&amp;ID_PROCEDIMIENTO=1" rel="next">»</a></li><li class="PagedList-skipToLast"><a href="/JNE.CAJA/Tramite/Index?page=21&amp;ID_PROCEDIMIENTO=1">»»</a></li></ul></div>

        return new HtmlString(s.ToString());
    }


    public class TableParam
    {
        public size Size { get; set; }

    }

    public enum size
    {
        standart = 1,
        large = 2,
        small = 3
    }

}

