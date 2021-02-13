using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Client.Notificador
{
    public class Notificacao
    {
        [DataMember]
        public string Mensagem { get; }
        [DataMember]
        public int TypeMessage { get; }
        [DataMember]
        public int Sucesso { get { return TypeMessage; } }
        public Notificacao(string message, int type = 1)
        {
            Mensagem = message;
            TypeMessage = type;
        }
    }
}
