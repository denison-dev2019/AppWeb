using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Dtos.Cadastro
{
    [DataContract]
    public sealed class PromocaoDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descricao { get; set; }
    }
}
