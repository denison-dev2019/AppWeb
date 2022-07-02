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
function Notificar(tipoMsg,textoTipoMsg ,textoMsg) {

    let vTipoMsg = "alert-success"
    switch (tipoMsg) {
        case tipoMsg = 2: vTipoMsg = "alert-info"
            break
        case tipoMsg = 3: vTipoMsg = "alert-danger"  
            break
        default:
            vTipoMsg = "alert-success"    
    }

    $("#tipoMsg").html(textoTipoMsg);
    $("#textoMsg").html(textoMsg);
    $('#notificador').addClass(vTipoMsg)

    $('#notificador').fadeIn(1000);
    setTimeout(function () {
        $('#notificador').fadeOut(1000);
    }, 5000);
}

function ConfigurarDataTable()
{
    let paginar = true;
    $('.tableGeral').DataTable({
        ordering: true,
        order: [],
        paging: paginar,
        info: true,
        searching: true,
        searchOnEnterKey: true,
        showButtonIcons: true,
        checkboxHeader: true,
        responsive: true,
        language: {
            decimal: ",",
            thousands: ".",
            sSearch: 'Filtrar:&nbsp;&nbsp;&nbsp;',
            sLengthMenu: '_MENU_ Registros por página',
            info: paginar ? '_MAX_ registro(s). Mostrando página _PAGE_ de _PAGES_' : '_MAX_ registro(s).',
            zeroRecords: 'Nenhum registro encontrado.',
            infoEmpty: 'Nenhum registro disponível.',
            infoFiltered: '(Filtrado de _MAX_ registro(s))',
            paginate: {
                previous: "Anterior",
                next: "Próximo"
            },
            buttons: {
                copyTitle: 'Adicionado à área de transferência',
                copyKeys: 'Pressione <i>ctrl</i> ou <i>\u2318</i> + <i>C</i> para copiar as informações da tabela à sua área de transferência. <br><br>Para cancelar, clique nesta mensagem ou pressione ESC.',
                copySuccess: {
                    _: '%d linhas copiadas',
                    1: '1 linha copiada'
                }
            }
        },
        select: {
            selector: 'td:first-child'
        },
        lengthMenu: [[50, 100, 250, 500, -1], [50, 100, 250, 500, "Todos"]],
    });
}

function Submit(nomeForm)
{
    $(`#${nomeForm}`).submit();
}

$(document).ready(function () {
    ConfigurarDataTable();
});




