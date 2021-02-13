// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})


$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

$(document).ready(function () {
    
});

function FecharModal() {
    $('#conteudoModalGenerico').html('');
    $('#modalGenerico').modal('hide');
}

function ConverterParaDecimalSelf(campo) {
    $(`#${campo}`).val($(`#${campo}`).val().toString().replace(",", "."))
}

function SetHeaderAntiForgeryToken() {
    return {
        "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val()
    };
};


function SendAjaxWithHeader(method, url, data, header, functionSuccess) {
    $.ajax({
        method: method,
        url: url,
        data: data,
        headers: header,
        success: function (xhr) {
            functionSuccess(xhr, virtualPath + url);
        },
        //error: function (xhr) {
        //    AjaxComplete(xhr);
        //}
    });
}

function SendAjax(method, url, data, functionSuccess) {
    $.ajax({
        method: method,
        url: url,
        data: data,
        success: function (data) { functionSuccess(data, url) },
        //error: function (data) {
        //    AjaxComplete(data);
        //}
    });
}


