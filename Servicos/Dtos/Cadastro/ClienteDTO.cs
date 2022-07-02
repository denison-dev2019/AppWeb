using AppWeb.Util.Enuns;
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
        public string TelefoneFixo { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Endereco { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string Cep { get; set; }
        [DataMember]
        public EnumTipoPessoa TipoPessoa { get; set; }
    }
}
