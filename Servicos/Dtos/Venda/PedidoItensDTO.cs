using AppWeb.Servicos.Dtos.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Dtos.Venda
{

    [DataContract]
    public class PedidoItensDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PedidoId { get; set; }
        [DataMember]
        public int ProdutoId { get; set; }
        [DataMember]
        public int QuantidadeProduto { get; set; }
        [DataMember]
        public decimal ValorUnitarioProduto { get; set; }
        [DataMember]
        public decimal ValorTotalProduto => QuantidadeProduto * ValorUnitarioProduto;
        [DataMember]
        public ProdutoGetDTO Produto { get; set; }
    }

    [DataContract]
    public class PedidoItensFiltroDTO
    {
        [DataMember]
        public int PedidoId { get; set; }
    }
}
