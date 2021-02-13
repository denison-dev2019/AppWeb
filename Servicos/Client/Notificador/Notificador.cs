using AppWeb.Servicos.Interface.Notificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Client.Notificador
{
    [DataContract]
    public class Notificador: INotificador
    {
        private readonly List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public void ClearNotificacao()
        {
            _notificacoes.Clear();
        }
    }
}
