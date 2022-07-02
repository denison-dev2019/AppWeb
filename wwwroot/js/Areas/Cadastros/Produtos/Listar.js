
function BuscarProduto(id) {
    $.ajax({
        url: `admin/cadastros/produtos/${id}`,
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
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
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
            
            Notificar(1, 'Tudo Certo!', 'Pedido Atualizado com sucesso!')
            FecharModal();
            AtualizarLista();
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
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
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
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
            Notificar(1, 'Tudo Certo!', 'Pedido excluido com sucesso!')
            AtualizarLista();
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}

function CriarProduto(formName)
{
    //alert(id)
    let form = $(`#${formName}`);
    $.ajax({
        url: `admin/cadastros/produtos/criar`,
        data: form.serialize(),
        type: "POST",
        success: function (xhr) {
            FecharModal();
            Notificar(1, 'Tudo Certo!', 'Pedido cadastrado com sucesso!')
            
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}



function AddPedidoItem(id) {


    var data = JSON.parse('{"Id": 0,"Valor":48.00,"Status":"Aberto","ClienteId": 1,"PedidoItens": [{"ProdutoId": 21, "QuantidadeProduto": 2, "ValorUnitarioProduto": 24.00, "ValorTotalProduto": 0 }] } ')
    
    $.ajax({
        url: `../pedidos/adicionar/${id}`,
        data: data,
        type: "POST",
        success: function (xhr) {

            FecharModal();
            Notificar(1, 'Tudo Certo!', 'Pedido cadastrado com sucesso!')

        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}




