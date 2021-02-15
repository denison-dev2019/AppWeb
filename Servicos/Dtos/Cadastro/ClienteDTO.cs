using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Dtos.Cadastro
{
    [DataContract]
    public class ClienteDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cep { get; set; }
    }
}
