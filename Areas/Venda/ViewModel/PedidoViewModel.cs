using AppWeb.Areas.Cadastros.ViewModel;
using AppWeb.Util.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Venda.ViewModel
{

    public class PedidoViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public EnumStatusPedido Status { get; set; }
        public int ClienteId { get; set; }
        public IEnumerable<PedidoItensViewModel> PedidoItens { get; set; }
    }
    public class PedidoGetViewModel
    {
        [DisplayName("Nº")]
        public int Id { get; set; }
        [DisplayName("Valor"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Valor { get; set; }
        public EnumStatusPedido Status { get; set; }
        [DisplayName("Forma de pagamento")]
        public EnumFormaPagamento FormaPagamento { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public IEnumerable<PedidoItensViewModel> PedidoItens { get; set; }
    }
}
