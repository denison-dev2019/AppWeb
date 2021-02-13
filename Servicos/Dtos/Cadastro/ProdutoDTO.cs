using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Dtos.Cadastro
{
    [DataContract]
    public class ProdutoBaseDTO
    {
        [DataMember]
        public PromocaoDTO Promocao { get; set; }
    }

    [DataContract]
    public class ProdutoDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public decimal Preco { get; set; }
        [DataMember]
        public int PromocaoId { get; set; }

    }

    [DataContract]
    public class ProdutoGetDTO : ProdutoBaseDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public decimal Preco { get; set; }
        [DataMember]
        public int PromocaoId { get; set; }
    }

    [DataContract]
    public class ProdutoGetFiltroDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }
}
