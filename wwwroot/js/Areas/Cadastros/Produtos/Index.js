const prefixo = "produtos"

function BuscarProduto(id) {
    $.ajax({
        url: `${prefixo}/${id}`,
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
        url: `${prefixo}/editar`,
        data: form.serialize(),
        type: "POST",
        success: function (xhr) {
            Notificar(1, 'Tudo Certo!', 'Pedido Atualizado com sucesso!');
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
        url: `produtos/carregar-formulario`,
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
    //window.open(`listar`, "_self");
    
    $.ajax({
        url: `${prefixo}/listar`,
        data: ``,
        type: "GET",
        success: function (xhr) {
            $('#idListagemProdutos').html("");
            $('#idListagemProdutos').html(xhr);
           //Notificar(1, 'Tudo Certo!', 'Lista Atualizada com sucesso!');
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}

function ExcluirProduto(id) {
    var data = { __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()}
    $.ajax({
        url: `${prefixo}/excluir/${id}`,
        data: data,
        type: "POST",
        success: function (xhr) {
            Notificar(1, 'Tudo Certo!', 'Produto Excluído com sucesso!');
            AtualizarLista();
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}

function CriarProduto(formName)
{
    let form = $(`#${formName}`);
    $.ajax({
        url: `produtos/criar`,
        data: form.serialize(),
        type: "POST",
        success: function (xhr) {
            FecharModal();
            AtualizarLista();
            Notificar(1, 'Tudo Certo!', 'Produto Cadastrado com sucesso!');
            
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}



