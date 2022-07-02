function GerarNovoPedido() {
    $.ajax({
        url: `pedidos/novo`,
        data: '',
        type: "GET",
        success: function (xhr) {
            FecharModal();
            window.open(`pedidos/novo`, "_self");
            //Notificar(1, 'Tudo Certo!', 'Pedido cadastrado com sucesso!');

        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}
function AdicionarPedido(formName) {
    let form = $(`#${formName}`);
    $.ajax({
        url: `pedidos/adicionar`,
        data: form.serialize(),
        type: "POST",
        success: function (xhr) {
            FecharModal();
            Notificar(1, 'Tudo Certo!', 'Pedido cadastrado com sucesso!');

        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });
}

function DetalharPedido(id) {
    window.open(`pedidos/${id}`, "_self");
}

function EditarPedido(id) {
    window.open(`pedidos/editar/${id}`, "_self");
}

function ExcluirPedido(id) {
    //var data = { __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() }
    $('#conteudoModalGenerico').html('');
    $('#conteudoModalGenerico').html(`Confirma exclusão do pediod nº ${id}?`);
    $('#modalGenerico').modal('show');


    $.ajax({
        url: `pedidos/excluir/${id}`,
        data: "",
        type: "POST",
        success: function (xhr) {
            Notificar(1, 'Tudo Certo!', 'Pedido Excluído com sucesso!');
            window.open(`pedidos`, "_self");
            //AtualizarLista();
        },
        error: function (xhr) {
            Notificar(3, 'Ops! Algo deu errado.', 'Motivo' + xhr)
        }
    });

}




