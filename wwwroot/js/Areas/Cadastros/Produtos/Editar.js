
function Initialize() {
   
    $("#PrecoFinal").attr("disabled", "disabled");
}

$("#PercentualVenda").blur(function () {
    
    $("#PrecoFinal").val(CalcularValorVenda());
})

function CalcularValorVenda() {
    return (parseFloat($("#Preco").val()) * parseFloat($("#PercentualVenda").val()) / 100) + parseFloat($("#Preco").val());
}

Initialize();


