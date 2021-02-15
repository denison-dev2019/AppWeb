using AppWeb.Areas.Cadastro.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Venda.ViewModel
{
    public class PedidoItensViewModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        [DisplayName("Qtde")]
        public int QuantidadeProduto { get; set; }
        [DisplayName("Preço"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ValorUnitarioProduto { get; set; }
        [DisplayName("Total do Produto"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal ValorTotalProduto => QuantidadeProduto * ValorUnitarioProduto;
        public ProdutoGetViewModel Produto { get; set; }
    }

    public class PedidoItensFiltroViewModel
    {
        public int PedidoId { get; set; }
    }
}
