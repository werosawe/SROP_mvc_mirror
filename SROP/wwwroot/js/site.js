var TXRUTAAPP = null;
function pRutaApp(uri) {
    TXRUTAAPP = uri;
    console.log(uri);
}

$.fn.Espera = function () {
    $(this).data('oldText', $(this).html());
    $(this).html('<img class="loading" src="' + TXRUTAAPP + '/wwwroot/lib/fonts/spinner.svg" />')
    $(this).prop("disabled", "true");
    //$el.data('oldText', $el.html());
    //$el.html('<img class="loading" src="/wwwroot/lib/fonts/spinner.svg" />');
    //$el.prop("disabled", "true");
};

$.fn.TerminaEspera = function () {
    $(this).removeAttr("disabled");
    if ($el != null) {
        $(this).html($el.data('oldText'));
    }
};

var $el = null;
$(document).ajaxStart(function (e) { 
    $el = $(e.target.activeElement);
    var isButton = $el.hasClass('btn');
    if (!isButton) {
        $el = null;
        $body = $("body");
        $body.addClass("loading");
    } else { $($el).Espera();}   
});

$(document).ajaxComplete(function (e, request, settings) {
    if ($el != null) {
        $($el).TerminaEspera();
        $el = null;
    } else {
        $body = $("body");
        $body.removeClass("loading");
    }
});

$(document).ajaxSuccess(function (event, xhr, settings) {
    if (settings.url == "ajax/test.html") {
        $(".log").text("Triggered ajaxSuccess handler. The Ajax response was: " +
            xhr.responseText);
    }
});

$(document).ajaxError(function (event, jqXHR, ajaxSettings, thrownError) {
    var r = toJson(jqXHR.responseText);
    var Message = null, isjson = true;
    if (r.IsJson==true) {
        r = toJson(r.Json.Message);
        if (r.IsJson == true) {
            Message = r.Json;
        } else { isjson = false; }       
    }
    else { 
        Message = thrownError;
    }  
    MostrarMensaje(Message);   
});

$.ajaxSetup({    
    cache: false
});


function msgExito(msg, IDMENSAJE) { MostrarMensaje('{ "IDTIPOMENSAJE": 1, "TXMENSAJE": "' + msg + '" }', IDMENSAJE); }
function msgInformacion(msg, IDMENSAJE) { MostrarMensaje('{ "IDTIPOMENSAJE": 2, "TXMENSAJE": "' + msg + '" }', IDMENSAJE); }
function msgAdvertencia(msg, IDMENSAJE) { MostrarMensaje('{ "IDTIPOMENSAJE": 3, "TXMENSAJE": "' + msg + '" }', IDMENSAJE); }
function msgPeligro(msg, IDMENSAJE) { MostrarMensaje('{ "IDTIPOMENSAJE": 4, "TXMENSAJE": "' + msg + '" }', IDMENSAJE); }


function MostrarMensaje(MENSAJE, IDMENSAJE) {

    var MENSAJE_COL = isJSON(MENSAJE);
    if (MENSAJE_COL == null) { return null; }
    var TXMENSAJES = '', TXTIPOMENSAJE = '', TXTIPO = '';
    $.each(MENSAJE_COL, function (i, item) {
        if (toInt(item.IDTIPOMENSAJE) == 1) {//EXITO = 1
            TXTIPOMENSAJE = 'bg-success', TXTIPO = '!Exito! ';
        } else if (toInt(item.IDTIPOMENSAJE) == 2) {//INFORMACION = 2
            TXTIPOMENSAJE = 'bg-info', TXTIPO = '!Información! ';
        } else if (toInt(item.IDTIPOMENSAJE) == 3) {//ADVERTENCIA = 3
            TXTIPOMENSAJE = 'bg-warning', TXTIPO = '!Advertencia! ';
        } else if (toInt(item.IDTIPOMENSAJE) == 4 || toInt(item.IDTIPOMENSAJE) == 0) {//PELIGRO = 4
            TXTIPOMENSAJE = 'bg-danger', TXTIPO = '!Peligro! ';
        }
        TXMENSAJES = TXMENSAJES + '<div class="alert alert-icon-left  alert-arrow-left ' + TXTIPOMENSAJE + ' alert-dismissible fade in mb-1" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button><strong>' + TXTIPO + '</strong>' + trim(item.TXMENSAJE) + '</div>';
    });
  
    if (typeof IDMENSAJE !== 'undefined') { IDMENSAJE = $('#' + IDMENSAJE).get(0); $(IDMENSAJE).html(TXMENSAJES); }

    var WinMensaje = $('#WinMensaje').get(0);
    if (typeof WinMensaje !== 'undefined') { $("#WinMensaje").html(TXMENSAJES); }
   
    $("#pMensaje").html(TXMENSAJES);
    setTimeout(function () { $(".alert").fadeOut(4000); }, 4000);
    
}


function isJSON(TXJSON) {
    var MEN = {};
    try {
        if (typeof (TXJSON) == "string") {
            MEN = JSON.parse(TXJSON);
        } else {
            MEN = TXJSON;
        }
    }
    catch (e) {
        if (typeof (TXJSON) == 'string') {
            if (TXJSON.length == 0) {
                return null;
            }
            else {
                MEN = {};
                MEN.IDTIPOMENSAJE = 4;
                MEN.TXMENSAJE = TXJSON;
            }
        }
        else {
            return null;
        }
    }
    if (Object.prototype.toString.call(MEN) === '[object Array]') {
        return MEN;
    }
    else {
        var MEN_COL = [];
        MEN_COL.push(MEN);
        return MEN_COL;
    }
    //return MEN_COL;
}

function SelectNulo(obj) {
    if ($(obj).val() == '' || $(obj).val() == null) { $(obj).css("color", "#b7b3b3"); }
    else { $(obj).css("color", ""); }
}

$.fn.SelectNulo = function () { $(this).val(null); SelectNulo(this); };

function onloadFunction() {   
    $("select").change(function () {
        SelectNulo(this);        
    });
    $("select").change();    
}

$(document).ready(onloadFunction);


$.fn.confirmar = function (prm) {  
    tplConfirma = '<div class="btn-group btn-group-sm" role="group">' +
        '<button type="button" class="btn btn-outline-primary btn-square conAcepta"><i class="icon-check"></i> Si</button>' +
        '<button type="button" class="btn btn-outline-secondary btn-square conCancela"><i class="icon-close2"></i> No</button>' +
        '</div >';

    var config = { trigger: 'focus', placement: 'top', content: tplConfirma, html: true, funcion:'Confirma'}
    $.extend(config, prm);
    $(this).popover(config).on('shown.bs.popover', function () {
       var mee = $(this);   
        $(this).not(mee).popover('hide');
        $('.conCancela').click(function () { $(mee).popover('hide'); });
        $('.conAcepta').click(function () {
            $(mee).popover('hide');
            if (config.funcion != null) {
                window[config.funcion]($(mee).data('codigo'));
            }
        });
    });
    $('body').on('click', function (e) {
        $(this).each(function () {
            if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
            }
        });
    });
};

function toJson(obj) {
    var d = {
        IsJson: true,
        Json: null
    }
    if (typeof obj == 'object') { d.Json = obj; return d;}
    try {
        d.Json = $.parseJSON(obj);
    }
    catch (err) {
        d.IsJson = false;
    }
    return d;
}

function toInt(numero) {
    if (numero == undefined) { return 0; }
    if (numero == null) { return 0; }
    numero = parseInt(numero, 10);
    if (isNaN(numero)) { return 0; }
    return parseInt(numero, 10);
}

function toFloat(numero, FL_ORIGINAL) {
    if (numero == undefined) { return 0; }
    if (numero == null) { return 0; }
    numero = parseFloat(numero, 10);
    if (isNaN(numero)) { return 0; }
    if (FL_ORIGINAL == true) { return parseFloat(numero, 10); } else { return parseFloat(numero, 10).toFixed(2); }
}

function trim(cadena) {
    if (cadena == null) { return ''; }
    for (i = 0; i < cadena.length;) {
        if (cadena.charAt(i) == " ")
            cadena = cadena.substring(i + 1, cadena.length);
        else
            break;
    }
    for (i = cadena.length - 1; i >= 0; i = cadena.length - 1) {
        if (cadena.charAt(i) == " ")
            cadena = cadena.substring(0, i);
        else
            break;
    }
    return cadena;
}


$.fn.addHidden = function (name, value) {
    return this.each(function () {
        $(this).find("#" + name).remove();
        var input = $("<input>").attr("type", "hidden").attr("name", name).attr("id", name).val(value);
        $(this).append($(input));
    });
};


$.fn.fecha = function (prm) {
    prm.TXFECHAENTRADA = $(this).val();
    console.log(TXRUTAAPP);
    console.log(prm.TXFECHAENTRADA);
    var TXFECHAENTRADA = null;
    $.ajax({
        url: TXRUTAAPP + 'api/FuncionesApi/GetFecha',
        type: "GET",
        data: prm,
        contentType: "application/json;chartset=utf-8",
        cache: false,
        async: false,
        success: function (result) {
            TXFECHAENTRADA = result.data;
        },
    });
    return TXFECHAENTRADA;
};


$.fn.prmDisabled = function () {
    var frm = this;
    var hidden = $(this).find('input[type = "hidden"]');
    $(this).find("select[disabled='disabled'], input[disabled='disabled']").each(function () {
        $(frm).find('#' + $(this).attr('name')).remove();
        var input = $("<input>").attr("type", "hidden").attr("name", $(this).attr('name')).attr("id", $(this).attr('name')).val($(this).attr('value'));
        $(frm).append($(input));
    });
};

$.fn.LeftPad = function (l, s) {

    var o = $(this).val().toString();
    if (!s) { s = '0'; }
    while (o.length < l) {
        o = s + o;
    }
    $(this).val(o);

};

//** Funcion DatePicker para que IE reconoza los campos input tipo date
function Setea_DatePicker() {
    if ($('[type="date"]').prop('type') != 'date') {
        $('[type="date"]').datepicker();
    }

}


//***Paginar***//
$.fn.tablaFuncional = function (parametros) {
    var configuracion = {
        pagina: 1,
        tabla: null
    }
    $.extend(configuracion, parametros);
    configuracion.tabla = $(this).attr('id');
    $(this).find('.ordenatablafuncional').click(configuracion, onClickOrdenaTablaFuncional);
    $('.pagination').find('.pagtablafuncional').click(configuracion, onClickPaginaTablaFuncional);

    //if (configuracion.tabla == undefined || configuracion.tabla == null) {
    //    window[configuracion.funcion]('NUPAGINAACTUAL=' + configuracion.pagina);
    //} 

}


function fPaginaActual() {
    var NUPAGINAACTUAL = 1;
    var paginaactiva = $("#paginaactiva").get(0);
    if (paginaactiva != undefined) {
        NUPAGINAACTUAL = DameEntero($(paginaactiva).data("paginaactiva"));
    }
    return NUPAGINAACTUAL;
}


function onClickOrdenaTablaFuncional(prm) {
    var pr = prm.data;
    var txtpagina = '&NUPAGINAACTUAL=' + fPaginaActual();
    var ordena = [];
    var itemOrdenaSeleccionado = eval('(' + $(this).data('ordenatabla') + ')');
    var priority = 1;
    $('#' + pr.tabla + ' .ordenatablafuncional').each(function () {
        var itemOrdena = eval('(' + $(this).data('ordenatabla') + ')');
        //Actualizar el orden seleccionado
        if (itemOrdenaSeleccionado.property == itemOrdena.property) {
            if (itemOrdena.direction == 'ASC') { itemOrdena.direction = 'DESC'; } else { itemOrdena.direction = 'ASC'; }
            itemOrdena.priority = 0;
        } else {
            itemOrdena.priority = priority;
            priority = priority + 1;
        }
        ordena.push(itemOrdena);
    });

    var criterioOrden = '';
    if (ordena.length > 0) {
        criterioOrden = 'sort=' + JSON.stringify(ordena);
    }

    window[pr.funcion](criterioOrden + txtpagina);
}

function onClickPaginaTablaFuncional(prm) {
    var pr = prm.data;
    var ordena = [];
    var itemPaginaSeleccionado = eval('(' + $(this).data('paginatabla') + ')');
    var txtpagina = '&NUPAGINAACTUAL=' + itemPaginaSeleccionado.pagina;
    $('#' + pr.tabla + ' .ordenatablafuncional').each(function () {
        var itemOrdena = eval('(' + $(this).data('ordenatabla') + ')');
        ordena.push(itemOrdena);
    });

    var criterioOrden = '';
    if (ordena.length > 0) {
        criterioOrden = 'sort=' + JSON.stringify(ordena);
    }

    window[pr.funcion](criterioOrden + txtpagina);
}
//***Fin Paginar***//