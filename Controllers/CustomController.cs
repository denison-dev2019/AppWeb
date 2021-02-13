using AppWeb.Servicos.Client.Notificador;
using AppWeb.Servicos.Interface.Notificador;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Controllers
{
    [ApiController]
    public abstract class CustomController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotificador _notificador;

        protected CustomController(IServiceProvider serviceProvider)
        {
            _notificador = (INotificador)serviceProvider.GetService(typeof(INotificador));
            _mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao() || _notificador.ObterNotificacoes().TrueForAll(x => x.Sucesso == 2);
        }
        protected bool MensagemSucesso()
        {
            return _notificador.ObterNotificacoes().Any(x => x.TypeMessage == 2);
        }

        protected IEnumerable<Notificacao> GetErros()
        {
            return _notificador.ObterNotificacoes();
        }

        protected void InsereErro(string erro, int typeError = 1)
        {
            _notificador.Handle(new Notificacao(erro, typeError));
        }

        protected void InsereErrosModelState(IEnumerable<ModelError> erros)
        {
            foreach (var erro in erros)
                _notificador.Handle(new Notificacao(erro.ErrorMessage));
        }

        protected void GetErrorsModelState(ModelStateDictionary modelState)
        {
            foreach (var value in modelState.Values)
            {
                InsereErrosModelState(value.Errors);
            }
        }

        protected ActionResult ReturnNotification(bool onlyMessage = false)
        {
            if (!onlyMessage)
            {
                if (_notificador.ObterNotificacoes().Select(n => n.TypeMessage).FirstOrDefault().ToString().Length == 3)
                    return Redirect($"/erro/{_notificador.ObterNotificacoes().Select(n => n.TypeMessage).FirstOrDefault()}");
            }

            return Json(new { Mensagem = string.Join("<br>", _notificador.ObterNotificacoes().Select(n => n.Mensagem)), Sucesso = _notificador.ObterNotificacoes().Select(n => n.TypeMessage).FirstOrDefault() });
        }
        protected object GetNotification()
        {
            return JsonConvert.SerializeObject(Json(new { Mensagem = _notificador.ObterNotificacoes().Select(n => n.Mensagem).FirstOrDefault(), Sucesso = _notificador.ObterNotificacoes().Select(n => n.TypeMessage).FirstOrDefault() }).Value);
        }

        protected ActionResult ReturnStatusOrMessage() => !MensagemSucesso() ? ReturnNotification() : Ok();
        
    }
}
