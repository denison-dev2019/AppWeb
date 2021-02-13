function BuscarProduto(id) {
    $.ajax({
        url: `${id}`,
        data: ``,
        type: "GET",
        success: function (xhr) {

            $('#conteudoModalGenerico').html('');
            $('#conteudoModalGenerico').html(xhr);
            $('#modalGenerico').modal('show');


            /*if (VerificarSeTemRetornoDeNotificacao(xhr))
                return;
            OpenModal("Editar Feriado", xhr, true, editSubmit, "Atualizar", "Atualizar este registro com os valores informados acima");
            $('#btn-modal-submit').addClass("submit-button-formEditFeriados");
            */
        },
        error: function (xhr) {
            $('#conteudoModalGenerico').html("Algo deu errado!" + xhr);
            $('#modalGenerico').modal('show');
        }
    });
}

function AtualizarProduto(formName) {
    let form = $(`#${formName}`);
    $.ajax({
        url: `editar`,
        data: form.serialize(),
        type: "POST",
        success: function (xhr) {
            alert('ok')
            FecharModal();
            AtualizarLista();
        },
        error: function (xhr) {
            alert('nao - ok')
        }
    });
}


function LoadFormProduto() {
    $.ajax({
        url: `admin/cadastros/produtos/carregar-formulario`,
        data: ``,
        type: "GET",
        success: function (xhr) {
            $('#conteudoModalGenerico').html(xhr);
            $('#modalGenerico').modal('show');
        },
        error: function (xhr) {
            $('#conteudoModalGenerico').html("Algo deu errado!" + xhr);
            $('#modalGenerico').modal('show');
        }
    });
}


function AtualizarLista() {
    window.open(`listar`, "_self");
}

function ExcluirProduto(id) {
    var data = { __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()}
    $.ajax({
        url: `excluir/${id}`,
        data: data,
        type: "POST",
        success: function (xhr) {
            alert('Produto excluído com sucesso')
            AtualizarLista();
        },
        error: function (xhr) {
            alert(xhr)
        }
    });
}

function CriarProduto(formName)
{
    let form = $(`#${formName}`);
    $.ajax({
        url: `admin/cadastros/produtos/criar`,
        data: form.serialize(),
        type: "POST",
        success: function (xhr) {
            FecharModal();
            alert('Produto cadastrado com sucesso!')
            
        },
        error: function (xhr) {
            $('#conteudoModalGenerico').html("Algo deu errado!" + xhr);
            $('#modalGenerico').modal('show');
        }
    });
}