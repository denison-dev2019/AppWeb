using AppWeb.Servicos.Dtos.Cadastro;
using AppWeb.Util.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Dtos.Venda
{
    [DataContract]
    public class PedidoGetDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public decimal Valor { get; set; }
        [DataMember]
        public EnumStatusPedido Status { get; set; }
        [DataMember]
        public EnumFormaPagamento FormaPagamento { get; set; }
        [DataMember]
        public ClienteDTO Cliente { get; set; }
        [DataMember]
        public IEnumerable<PedidoItensDTO> PedidoItens { get; set; }
        [DataMember]
        public string CorStatus { get; set; }
        [DataMember]
        public DateTime DataPedido { get; set; }
        [DataMember]
        public DateTime DataPagamento { get; set; }

    }
    
    [DataContract]
    public class PedidoDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public decimal Valor { get; set; }
        [DataMember]
        public EnumStatusPedido Status { get; set; }
        [DataMember]
        public int ClienteId { get; set; }
        [DataMember]
        public IEnumerable<PedidoItensDTO> PedidoItens { get; set; }
        [DataMember]
        public string CorStatus { get; set; }
        [DataMember]
        public DateTime DataPedido { get; set; }
        [DataMember]
        public DateTime DataPagamento { get; set; }

    }
}
