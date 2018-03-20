var menSeleccionHtmlSelect = "-Seleccionar-";
function SetMensajeSeleccion(_menSeleccionHtmlSelect) {
    menSeleccionHtmlSelect = _menSeleccionHtmlSelect;
}

CargaProvincia = function () {
    $('#UBIPROVINCIA').empty(); $('#UBIDISTRITO').empty();
    $('#UBIPROVINCIA').append('<option disabled="disabled" value="" >' + menSeleccionHtmlSelect + '</option>');
    $('#UBIDISTRITO').append('<option disabled="disabled" value="" >' + menSeleccionHtmlSelect + '</option>');
    $('#UBIPROVINCIA').SelectNulo(); $('#UBIDISTRITO').SelectNulo();
    var UBIREGION = $(this).val();
    $.ajax({
        url: $(this).data('url'),
        type: "GET",
        data: { "UBIREGION": UBIREGION },
        contentType: "application/json;chartset=utf-8",
        success: function (result) {
            $.each(result.data, function (i, item) {
                $("#UBIPROVINCIA").append("<option value=" + item.UBIPROVINCIA + ">" + item.TXPROVINCIA + "</option>");
            });
        },
    });
}

CargaProvinciaLegal = function () {
    $("#UBIPROVINCIADOMLEGAL").empty(); $("#UBIDISTRITODOMLEGAL").empty();
    $('#UBIPROVINCIADOMLEGAL').append('<option disabled="disabled" value="" >' + menSeleccionHtmlSelect + '</option>');
    $('#UBIDISTRITODOMLEGAL').append('<option disabled="disabled" value="" >' + menSeleccionHtmlSelect + '</option>');
    $("#UBIPROVINCIADOMLEGAL").SelectNulo(); $("#UBIDISTRITODOMLEGAL").SelectNulo();
    var UBIREGION = $(this).val();
    $.ajax({
        url: $(this).data('url'),
        type: "GET",
        data: { "UBIREGION": UBIREGION },
        contentType: "application/json;chartset=utf-8",
        success: function (result) {
            $.each(result.data, function (i, item) {
                $("#UBIPROVINCIADOMLEGAL").append("<option value=" + item.UBIPROVINCIA + ">" + item.TXPROVINCIA + "</option>");
            });
        },
    });
}

CargaDistrito = function () {
    $("#UBIDISTRITO").empty();
    $('#UBIDISTRITO').append('<option disabled="disabled" value="" >' + menSeleccionHtmlSelect + '</option>');
    $('#UBIDISTRITO').SelectNulo();
    var UBIREGION = $("#UBIREGION").val();
    var UBIPROVINCIA = $(this).val();
    $.ajax({
        url: $(this).data('url'),
        type: "GET",
        data: { "UBIREGION": UBIREGION, "UBIPROVINCIA": UBIPROVINCIA },
        contentType: "application/json;chartset=utf-8",
        cache: false,
        success: function (result) {
            $.each(result.data, function (i, item) {
                $("#UBIDISTRITO").append("<option value=" + item.UBIDISTRITO + ">" + item.TXDISTRITO + "</option>");
            });
        },
    });
}

CargaDistritoLegal = function () {
    $("#UBIDISTRITODOMLEGAL").empty();
    $('#UBIDISTRITODOMLEGAL').append('<option disabled="disabled" value="" >' + menSeleccionHtmlSelect + '</option>');
    $("#UBIDISTRITODOMLEGAL").SelectNulo();
    var UBIREGION = $("#UBIREGIONDOMLEGAL").val();
    var UBIPROVINCIA = $(this).val();
    $.ajax({
        url: $(this).data('url'),
        type: "GET",
        data: { "UBIREGION": UBIREGION, "UBIPROVINCIA": UBIPROVINCIA },
        contentType: "application/json;chartset=utf-8",
        cache: false,
        success: function (result) {
            $.each(result.data, function (i, item) {
                $("#UBIDISTRITODOMLEGAL").append("<option value=" + item.UBIDISTRITO + ">" + item.TXDISTRITO + "</option>");
            });
        },
    });
}

CargaAmbito = function () {
    if ($(this).val() == '01' || $(this).val() == null) { //Nacional
        $("#divRegion").hide();
        $("#divProvincia").hide();
        $("#divDistrito").hide();
    } else if ($(this).val() == '02') {//Regional
        $("#divRegion").show();
        $("#divProvincia").hide();
        $("#divDistrito").hide();
    } else if ($(this).val() == '03') {//Local Provincial
        $("#divRegion").show();
        $("#divProvincia").show();
        $("#divDistrito").hide();
    } else if ($(this).val() == '04') {//Local Distrital
        $("#divRegion").show();
        $("#divProvincia").show();
        $("#divDistrito").show();
    };
}

$(function () {
    $('#UBIREGION').bind('change', CargaProvincia);
    $('#UBIREGIONDOMLEGAL').bind('change', CargaProvinciaLegal);
    $('#UBIPROVINCIA').bind('change', CargaDistrito);
    $('#UBIPROVINCIADOMLEGAL').bind('change', CargaDistritoLegal);
    $('#Cod_Ambito').bind('change', CargaAmbito);
    $("#Cod_Ambito").change();

    $("#frmExpediente").validate({
        errorClass: "text-danger",
        validClass: "text-success",
        errorElement: "p",
        ignoreTitle: true,
        highlight: function (element) { $(element).addClass('border-danger'); },
        unhighlight: function (element) { $(element).removeClass('border-danger'); },
        submitHandler: function (form, event) {
            $(form).prmDisabled();
            $(form).addHidden('Cod_OP', $('#Cod_OP').val());
            $('#btnGraba').Espera();
            return true;
        }
    });

});



    function CargarSimbolo() {
        var d = new Date(); $('#imgSimbolo').attr('src', $('#imgSimbolo').data('url') + '&d=' + d.getTime() );
    }

    function CargarSimboloTmp(FileName) {
            $('#TXARCHIVONOMBRE').val(FileName);
            var d = new Date(); $('#imgSimbolo').attr('src', $('#imgSimbolo').data('url-tmp') + '?FileName=' + FileName + '&d=' + d.getTime() );
    }


