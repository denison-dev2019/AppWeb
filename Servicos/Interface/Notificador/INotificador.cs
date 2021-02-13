using AppWeb.Servicos.Client.Notificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Interface.Notificador
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
        void ClearNotificacao();
    }
}
