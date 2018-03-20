using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utilitario;
public enum TipoControl 
{
    button = 1,
    checkbox=2,
    color = 3,
    date = 4,
    datetime_local = 5,
    email = 6,
    file = 7,
    hidden = 8,
    image = 9,
    month = 10,
    number = 11,
    password = 12,
    radio = 13,
    range = 14,
    reset = 15,
    search = 16,
    submit = 17,
    tel = 18,
    text = 19,
    time = 20,
    url = 21,
    week = 22
}


//new List<BE_PAGINA> { 
//                    new BE_PAGINA() { IDMENU = 1,IDPAGINA = 1, parentId = "menu1", id = "submenu1", qtip = "Registrar encuestadoras", text = "Encuestadora", TXCONTROLADOR = "Entidad", TXACCION = "Index", leaf = true, expanded = false, checkeds = true, },
//                    new BE_PAGINA() { IDMENU = 1,IDPAGINA = 2, parentId = "menu1", id = "submenu2", qtip = "Registrar encuestadoras informales", text = "Encuestadora informal", TXCONTROLADOR = "EntidadInformal", TXACCION = "Index", leaf = true, expanded = false,checkeds = true,  },
//                    new BE_PAGINA() { IDMENU = 1,IDPAGINA = 3, parentId = "menu1", id = "submenu3", qtip = "Registrar encuestas de intenci&oacute;n de voto", text = "Encuesta", TXCONTROLADOR = "Encuesta", TXACCION = "Index", leaf = true, expanded = false, checkeds = true,  },
//                }

public  static partial class Input
{
    static Dictionary<string, string> containerControl
                            = new Dictionary<string, string>() { {"normal","<div class='form-group position-relative'>{0}</div>"},
                                {"iconLeft","<div class='form-group position-relative has-icon-left'>{0}</div>"},
                                {"iconRight","<div class='form-group position-relative has-icon-right'>{0}</div>"},
                            };
    

    //En caso de error en el control, para danger, success, warning
    //<input type="text" class="form-control form-control-danger" id="inputDanger">
    //<p class="text-xs-right"><small class="danger text-muted">Use<code>.has-danger</code> class for danger state</small></p>

    static Dictionary<string, string> cssAttr
                             = new Dictionary<string, string>() { {"normal","font-weight-normal"}, {"bold","font-weight-bold"},  {"italic","font-weight-italic"}, {"lower","text-lowercase"},
                                 {"capital","text-capitalize"}, {"upper","text-uppercased"}, {"left","text-xs-left"}, {"center","text-xs-center"}, {"right","text-xs-right"},
                                 {"font-lg","font-size-large"}, {"font-sm","font-size-small"}, {"font-xs","font-size-xsmall"},
                                 {"xlarge","form-control-xl input-xl"},{"large","form-control-lg input-lg"},{"small","form-control-sm input-sm"},{"xsmall","form-control-xs input-xs"}                               
                             };



    // XLarge = .input-xl
    // Large = .input-lg
    // Small = .input-sm
    // XSmall = .input-xs

    // En caso de querer un grupo colocar el css, en la clase del form: 
    //'form-group form-group-xl' 
    //'form-group form-group-lg' 
    //'form-group form-group-sm' 
    //'form-group form-group-xs'

    public static MvcHtmlString button<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "button", flPlaceHolder, flRequerido); }
    public static MvcHtmlString checkbox<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "checkbox", flPlaceHolder, false); }
    public static MvcHtmlString color<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "color", flPlaceHolder, flRequerido); }
       
    public static MvcHtmlString date<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "date", flPlaceHolder, flRequerido); }
    public static MvcHtmlString datetime_local<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "datetime-local", flPlaceHolder, flRequerido); }
    public static MvcHtmlString time<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "time", flPlaceHolder, flRequerido); }

    public static MvcHtmlString email<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "email", flPlaceHolder, flRequerido); }

    public static MvcHtmlString file<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "file", flPlaceHolder, flRequerido); }
    public static MvcHtmlString hidden<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "hidden", flPlaceHolder, flRequerido); }
    public static MvcHtmlString image<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "image", flPlaceHolder, flRequerido); }
    public static MvcHtmlString month<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "month", flPlaceHolder, flRequerido); }

    public static MvcHtmlString number<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "number", flPlaceHolder, flRequerido); }
    public static MvcHtmlString password<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "password", flPlaceHolder, flRequerido); }

    public static MvcHtmlString radio<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "radio", flPlaceHolder, flRequerido); }
    public static MvcHtmlString range<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "range", flPlaceHolder, flRequerido); }
    public static MvcHtmlString reset<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "reset", flPlaceHolder, flRequerido); }
    public static MvcHtmlString search<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "search", flPlaceHolder, flRequerido); }
    public static MvcHtmlString submit<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "submit", flPlaceHolder, flRequerido); }

    public static MvcHtmlString tel<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "tel", flPlaceHolder, flRequerido); }
    public static MvcHtmlString text<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false)  { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "text", flPlaceHolder, flRequerido); }
    
    public static MvcHtmlString url<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "url", flPlaceHolder, flRequerido); }
    public static MvcHtmlString week<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false) { return setTag(helper, expression, htmlAttributes, customAtributes, "input", "week", flPlaceHolder, flRequerido); }

    public static MvcHtmlString textarea<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, bool flPlaceHolder = true, bool flRequerido = false, string OpcionalValor=null) { return setTag(helper, expression, htmlAttributes, customAtributes, "textarea", flPlaceHolder, flRequerido, OpcionalValor); }

    public static MvcHtmlString p<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null) { return setTag(helper, expression, htmlAttributes, customAtributes, "p", false, false); }

    public static MvcHtmlString select<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, IEnumerable<SelectListItem> selectList = null,  bool flRequerido = false, string msgSelecciona = null)
    {        
        var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        TagBuilder tag = general(helper, expression, htmlAttributes, customAtributes, tagSet("select", null), false, flRequerido);
        var value = metadata.Model.Text();

        if (msgSelecciona == null) {msgSelecciona = CO_Constante.menSeleccionHtmlSelect;}
            
        TagBuilder optionMen = new TagBuilder("option");
        optionMen.MergeAttribute("value", null);
        if (flRequerido == true) { optionMen.MergeAttribute("disabled", "disabled"); }  //
        if (value.EsNulo()) { optionMen.MergeAttribute("selected", "selected"); }
       
        optionMen.InnerHtml = msgSelecciona;
        tag.InnerHtml += optionMen.ToString();

        if (selectList != null)
        {
            foreach (SelectListItem item in selectList)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", item.Value);
                option.InnerHtml = item.Text;
                if (value.NoNulo())
                {
                    if (value.Text() == item.Value) {
                        option.MergeAttribute("selected", "selected");
                    }
                }
                else if (item.Selected)
                {
                    option.MergeAttribute("selected", "selected");
                }
                tag.InnerHtml += option.ToString();
            }
        }
        return new MvcHtmlString(tag.ToString());
    }

    private static TagBuilder tagSet(string tagName = null, string type = null) {
        TagBuilder tag = new TagBuilder(tagName);
        if (type != null) {
            tag.Attributes.Add("type", type);
        }
        return tag;
    }

    private static MvcHtmlString setTag<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, string tag = null, string type = null, bool flPlaceHolder = true, bool flRequerido = false, object valueNulo = null) { 
        TagBuilder inputTag = general(helper, expression, htmlAttributes, customAtributes, tagSet(tag, type), flPlaceHolder, flRequerido);
        return new MvcHtmlString(inputTag.ToString());
    }

    private static MvcHtmlString setTag<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, string tag = null, bool flPlaceHolder = true, bool flRequerido = false, string OpcionalValor = null) {
        TagBuilder inputTag = tagSet(tag, null);
        inputTag = general(helper, expression, htmlAttributes, customAtributes, inputTag, flPlaceHolder, flRequerido, OpcionalValor);
        return new MvcHtmlString(inputTag.ToString());
    }

    private static TagBuilder general<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, TagBuilder tag = null, bool flPlaceHolder = true, bool flRequerido = false, string OpcionalValor = null)
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        var validators = ModelValidatorProviders.Providers.GetValidators(metadata, helper.ViewContext);
        var rules = validators.SelectMany(v => v.GetClientValidationRules()).ToList();

        tag.Attributes.Add("name", metadata.PropertyName);
        tag.Attributes.Add("id", metadata.PropertyName);

        if (flRequerido == true)
        {
            tag.Attributes.Add("required", "required");
        }

        if (tag.TagName == "textarea")
        {
            if (flPlaceHolder == true && metadata.Watermark.NoNulo()) { tag.Attributes.Add("placeholder", metadata.Watermark); }
            if (metadata.Model.NoNulo()) { tag.InnerHtml = metadata.Model.Text(); } else if (OpcionalValor.NoNulo()) { tag.InnerHtml = OpcionalValor.Text(); }
            //tag.Attributes.Add("rows", "3");
        }
        else if (tag.TagName == "p")
        {
            if (metadata.Model.NoNulo()) { tag.InnerHtml = metadata.Model.Text(); } else if (OpcionalValor.NoNulo()) { tag.InnerHtml = OpcionalValor.Text(); }
        }
        else if (tag.TagName == "select")
        {
            if (metadata.Model.NoNulo()) { tag.Attributes.Add("value", metadata.Model.Text()); };
            if (flPlaceHolder == true) { tag.Attributes.Add("placeholder", metadata.Watermark); }
        }
        else if (tag.TagName == "input")
        {
            if (metadata.Model.NoNulo())
            {
                if (tag.Attributes["type"] == "date" || tag.Attributes["type"] == "datetime-local" || tag.Attributes["type"] == "time")
                {
                    tag.Attributes.Add("value", metadata.Fec().Value.ToString(CO_Constante.formatoFechaHTML5));
                }
                else if (tag.Attributes["type"] == "checkbox")
                {
                    string fl = metadata.Model.Text();
                    if (int.Parse(fl) == 1)
                    {
                        tag.Attributes.Add("checked", "checked");
                    }
                }
                else
                {
                    if (metadata.Model.NoNulo()) { tag.Attributes.Add("value", metadata.Model.Text()); } else if (OpcionalValor.NoNulo()) { tag.Attributes.Add("value", OpcionalValor.Text()); }
                }
            }
            if (flPlaceHolder == true && metadata.Watermark.NoNulo()) { tag.Attributes.Add("placeholder", metadata.Watermark); }
        }
        else
        {
            if (metadata.Model.NoNulo()) { tag.Attributes.Add("value", metadata.Model.Text()); };
            if (flPlaceHolder == true && metadata.Watermark.NoNulo()) { tag.Attributes.Add("placeholder", metadata.Watermark); }
        }

        foreach (ModelClientValidationRule r in rules)
        {
            foreach (KeyValuePair<string, object> k in r.ValidationParameters)
            {
                tag.Attributes.Add(k.Key, k.Value.Text());
            }
        }

        if (htmlAttributes != null)
        {
            System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            tag.MergeAttributes(attributos);
            //// desabilitar control
            //if (atributo.Key.Equals("disabled")) { input.Attributes.Add("disabled", "true"); ; }
            //// Solo lectura
            //if (atributo.Key.Equals("readonly")) { input.Attributes.Add("readonly", "true"); ; }
            //// Autocompletar
            //if (atributo.Key.Equals("autocomplete")) { input.Attributes.Add("autocomplete", atributo.Value.Text()); ; }
        }
        //StringBuilder s = new StringBuilder("");
        //s.Append(string.Concat("type='", tipo, "' name='", metadata.PropertyName,"' id='", metadata.PropertyName, "' value='", metadata.Model.Text(),"'"));

        //if (flRequerido == true) { s.Append(" required "); }
        //if (flPlaceHolder == true) { s.Append(string.Concat(" placeholder='", metadata.Watermark, "' ")); }

        //foreach (ModelClientValidationRule r in rules)
        //{
        //    foreach (KeyValuePair<string, object> k in r.ValidationParameters)
        //    {
        //        s.Append(string.Concat(" ", k.Key, "='", k.Value.Text(), "'"));
        //    }
        //}
        ////return new MvcHtmlString(s.ToString());
        //return s.ToString();
        return tag;
    }

    //public static MvcHtmlString textarea<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null, string tipo = "text", bool flPlaceHolder = true, bool flRequerido = false)
    //{
    //    //var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    //    //var validators = ModelValidatorProviders.Providers.GetValidators(metadata, helper.ViewContext);
    //    //var rules = validators.SelectMany(v => v.GetClientValidationRules()).ToList();

    //    //string propertyName = metadata.PropertyName;

    //    TagBuilder input = new TagBuilder("textarea");
    //    input.Attributes.Add("name", propertyName);
    //    input.Attributes.Add("id", propertyName);
    //    input.Attributes.Add("rows", "3");

    //    if (metadata.Watermark != null) { input.Attributes.Add("placeholder", metadata.Watermark); }

    //    StringBuilder sClass = new StringBuilder("form-control");
    //    string ayuda = null;

    //    if (htmlAttributes != null)
    //    {
    //        System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

    //        foreach (KeyValuePair<string, object> atributo in attributos)
    //        {
    //            // Tamaño del input control
    //            // XLarge = .input-xl
    //            // Large = .input-lg
    //            // Small = .input-sm
    //            // XSmall = .input-xs
    //            if (atributo.Key.Equals("size")) { sClass.Append(" input-" + atributo.Value); }
    //            // una pequeña ayuda
    //            if (atributo.Key.Equals("help")) { ayuda = "<small class='text-muted'><i>" + atributo.Value + "</i></small>"; }
    //            // desabilitar control
    //            if (atributo.Key.Equals("disabled")) { input.Attributes.Add("disabled", "true"); ; }
    //            // Solo lectura
    //            if (atributo.Key.Equals("readonly")) { input.Attributes.Add("readonly", "true"); ; }
    //            // Autocompletar
    //            if (atributo.Key.Equals("autocomplete")) { input.Attributes.Add("autocomplete", atributo.Value.Text()); ; }

    //            //attributes.Value = "";

    //        }

    //        //input.MergeAttributes(attributos);
    //    }

    //    input.Attributes.Add("class", sClass.ToString());

    //    //input.Attributes.Add("data-something", "something");

    //    //foreach (ModelClientValidationRule r in rules)
    //    //{
    //    //    input.Attributes.Add("data-val-" + r.ValidationType, r.ErrorMessage);
    //    //    foreach (KeyValuePair<string, object> k in r.ValidationParameters)
    //    //    {
    //    //        input.Attributes.Add("data-val-" + r.ValidationType + "-" + k.Key, k.Value.Text());
    //    //    }

    //    //    //                string wd = r.ValidationParameters["ee"].Text();
    //    //}




    //    return new MvcHtmlString(ayuda + input.ToString());
    //}

    //private static MvcHtmlString input<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string tipoControl,  object htmlAttributes = null,object customAtributes = null)
    //{
    //    var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    //    var validators = ModelValidatorProviders.Providers.GetValidators(metadata, helper.ViewContext);
    //    var rules = validators.SelectMany(v => v.GetClientValidationRules()).ToList();

    //        string propertyName = metadata.PropertyName;
    //    TagBuilder input = new TagBuilder("input");
    //    input.Attributes.Add("type", tipoControl);
    //    input.Attributes.Add("name", propertyName);
    //    input.Attributes.Add("id", propertyName);
    //    input.Attributes.Add("value", metadata.Model.Text());

    //    if (metadata.Watermark != null) { input.Attributes.Add("placeholder", metadata.Watermark); }

    //    foreach (ModelClientValidationRule r in rules)
    //    {
    //        input.Attributes.Add("data-val-" + r.ValidationType, r.ErrorMessage);
    //        foreach (KeyValuePair<string, object> k in r.ValidationParameters)
    //        {
    //            input.Attributes.Add("data-val-" + r.ValidationType + "-" + k.Key, k.Value.Text());
    //        }
    //    }

    //    if (htmlAttributes != null)
    //    {
    //        System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
    //        input.MergeAttributes(attributos);
    //        //// desabilitar control
    //        //if (atributo.Key.Equals("disabled")) { input.Attributes.Add("disabled", "true"); ; }
    //        //// Solo lectura
    //        //if (atributo.Key.Equals("readonly")) { input.Attributes.Add("readonly", "true"); ; }
    //        //// Autocompletar
    //        //if (atributo.Key.Equals("autocomplete")) { input.Attributes.Add("autocomplete", atributo.Value.Text()); ; }
    //    }

    //    StringBuilder sClass = new StringBuilder("form-control");

    //    string keyContainer = "normal";
    //    string helpTop = null;
    //    string helpBotom = null;
    //    string icon = null;
    //    string iconSize = null;

    //    if (customAtributes != null)
    //    {
    //        System.Web.Routing.RouteValueDictionary customAttributos = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

    //        foreach (KeyValuePair<string, object> atributo in customAttributos)
    //        {


    //           if (atributo.Key.Equals("class").NoNulo())
    //            {
    //                foreach (string key in atributo.Key.Equals("class").Text().Split(Convert.ToChar(" ")))
    //                {
    //                    sClass.Append(string.Concat(" ", cssAttr[key].Text()));

    //                    if (cssAttr[key].Text().Equals("xlarge")) { iconSize = "font-medium-4"; }
    //                    if (cssAttr[key].Text().Equals("large")) { iconSize = "font-medium-4"; }
    //                    if (cssAttr[key].Text().Equals("small")) { iconSize = "font-small-4"; }
    //                    if (cssAttr[key].Text().Equals("xsmall")) { iconSize = "font-small-2"; }
    //                }
    //            }

    //            if (atributo.Key.Equals("helpTopLeft")) { helpTop = "<small class='text-muted'><i>" + atributo.Value + "</i></small>"; }
    //            if (atributo.Key.Equals("helpBottomLeft")) { helpBotom = "<p class='text-xs-left'><small class='text-muted'>" + atributo.Value + "</small></p>"; }
    //            if (atributo.Key.Equals("helpBottomCenter")) { helpBotom = "<p class='text-xs-center'><small class='text-muted'>" + atributo.Value + "</small></p>"; }
    //            if (atributo.Key.Equals("helpTopRigth")) { helpBotom = "<p class='text-xs-right'><small class='text-muted'>" + atributo.Value + "</small></p>"; }

    //            if (atributo.Key.Equals("iconLeft")) { keyContainer = "iconLeft"; icon = string.Concat( "<div class='form-control-position'><i class='" , atributo.Value , " " + iconSize , "></i></div>"); }
    //            if (atributo.Key.Equals("iconRigth")) { keyContainer = "iconRigth"; icon = string.Concat("<div class='form-control-position'><i class='", atributo.Value, " " + iconSize, "></i></div>"); }

    //        }

    //    }


    //    input.Attributes.Add("class", sClass.ToString());

    //    return new MvcHtmlString(string.Format(containerControl[keyContainer].Text(), string.Concat(helpTop, input.ToString(),icon, helpBotom)));
    //}

    // public static MvcHtmlString select<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, object customAtributes = null)
    //{
    //    var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    //    var validators = ModelValidatorProviders.Providers.GetValidators(metadata, helper.ViewContext);
    //    var rules = validators.SelectMany(v => v.GetClientValidationRules()).ToList();

    //    //< textarea class="form-control input-lg" id="placeTextarea" rows="3" placeholder="Simple Textarea"></textarea>

    //    string propertyName = metadata.PropertyName;

    //    //< input type = "text" class="form-control input-lg" id="TXUSUARIO" placeholder="Usuario" tabindex="1">
    //    TagBuilder input = new TagBuilder("select");
    //    input.Attributes.Add("name", propertyName);       
    //    input.Attributes.Add("id", propertyName);

    //    StringBuilder sClass = new StringBuilder("form-control");
    //    string ayuda = null;

    //    if (htmlAttributes != null)
    //    {
    //        System.Web.Routing.RouteValueDictionary attributos = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

    //        foreach (KeyValuePair<string, object> atributo in attributos)
    //        {
    //            // Tamaño del input control
    //            // XLarge = .input-xl
    //            // Large = .input-lg
    //            // Small = .input-sm
    //            // XSmall = .input-xs
    //            if (atributo.Key.Equals("size")) { sClass.Append(" input-" + atributo.Value); }
    //            // una pequeña ayuda
    //            if (atributo.Key.Equals("help")) { ayuda = "<small class='text-muted'><i>" + atributo.Value + "</i></small>"; }
    //            // desabilitar control
    //            if (atributo.Key.Equals("disabled")) { input.Attributes.Add("disabled", "true"); ; }
    //            // Solo lectura
    //            if (atributo.Key.Equals("readonly")) { input.Attributes.Add("readonly", "true"); ; }
    //            //attributes.Value = "";
    //        }

    //        //input.MergeAttributes(attributos);
    //    }

    //    input.Attributes.Add("class", sClass.ToString());

    //    //input.Attributes.Add("data-something", "something");

    //    foreach (ModelClientValidationRule r in rules)
    //    {
    //        input.Attributes.Add("data-val-" + r.ValidationType, r.ErrorMessage);
    //        foreach (KeyValuePair<string, object> k in r.ValidationParameters)
    //        {
    //            input.Attributes.Add("data-val-" + r.ValidationType + "-" + k.Key, k.Value.Text());
    //        }

    //        //                string wd = r.ValidationParameters["ee"].Text();
    //    }




    //    return new MvcHtmlString(ayuda + input.ToString());
    //}



    //public static MvcHtmlString GetsErrores(this HtmlHelper helper)
    //{
    //    //< div class="alert alert-icon-left alert-danger alert-dismissible fade in mb-2" role="alert">
    //    //									<button type = "button" class="close" data-dismiss="alert" aria-label="Close">
    //    //										<span aria-hidden="true">×</span>
    //    //									</button>
    //    //									<strong>Oh snap!</strong> Change a<a href= "#" class="alert-link">few things up</a> and try submitting again.
    //    //                                </div>
    //    //StringBuilder s = new StringBuilder("<div class='alert alert-warning round alert-icon-right alert-dismissible fade in mb-2' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button>");

    //    StringBuilder s = new StringBuilder("");
    //    //s.Append("<i class='icon-warning'></i>"); 
    //    string TXTIPOERROR = null;
    //    foreach (var item in helper.ViewData.ModelState)
    //    {
    //        if (item.Value.Errors.Any())
    //        {
    //            foreach (ModelError e in item.Value.Errors)
    //            {
    //                if (item.Key == enumTipoMensaje.Exito.ToString()) { TXTIPOERROR = "success"; }
    //                if (item.Key == enumTipoMensaje.Informacion.ToString()) { TXTIPOERROR = "info"; }
    //                if (item.Key == enumTipoMensaje.Advertencia.ToString()) { TXTIPOERROR = "warning"; }
    //                if (item.Key == enumTipoMensaje.Peligro.ToString()) { TXTIPOERROR = "danger"; }

    //                s.Append("<div class='alert alert-" + TXTIPOERROR + " alert-dismissible alert-icon-left fade in mb-2' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button>");
    //                s.Append(e.ErrorMessage);
    //                s.Append("</div>");
    //            }
    //        }
    //    }
    //    //s.Append("</div>");
    //    return MvcHtmlString.Create(s.ToString());
    //}


}