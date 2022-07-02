using AppWeb.Configurations;
using AppWeb.Servicos.Client.Base;
using AppWeb.Servicos.Dtos.Venda;
using AppWeb.Servicos.Interface.Notificador;
using AppWeb.Servicos.Interface.Venda;
using AppWeb.Util.Enuns;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Client.Venda
{
    public class PedidoServico : ApiClient, IPedidoServico
    {
        protected string Path { get; set; }
        public PedidoServico(IOptions<ApplicationSettings> appSettings,
            IHttpContextAccessor acessor,
            INotificador notificador
            ) : base(appSettings, acessor, notificador)
        {
            Path = "vendas/pedidos";
        }
        public async Task<bool> Adicionar(PedidoDTO pedidoDTO)
        {
            await base.PostAsync(CreateRequestUri($"{Path}/adicionar", null), pedidoDTO);
            return true;
        }

        public async Task<bool> Atualizar(PedidoDTO pedidoDTO)
        {
            await base.PutAsync(CreateRequestUri($"{Path}/{pedidoDTO.Id}", null), pedidoDTO);
            return true;
        }

        public async Task<PedidoGetDTO> ListarPorId(int id)
        {
            return (await base.GetAsync<PedidoGetDTO>
            (CreateRequestUri($"{Path}/{id}", null)))?.Data;
        }

        public async Task<IEnumerable<PedidoGetDTO>> ListarTodos()
        {
            var retorno = (await base.GetAsync<IEnumerable<PedidoGetDTO>>
                   (CreateRequestUri($"{Path}", null))).Data;
            retorno.ToList().ForEach(x=>x.CorStatus = GetCorStatus(x.Status));
            
            return retorno;
        }

        public async Task<bool> Remover(int id) =>
            await base.DeteleAsync<PedidoGetDTO>(CreateRequestUri($"{Path}/excluir/{id}", null));

        public async Task<int> GetNovoNumero()
        {
            var retorno = (await base.GetAsync<int>(CreateRequestUri($"{Path}/novo-numero", null))).Data;
            return retorno;
            
        }

        private string GetCorStatus(EnumStatusPedido status) 
        {
            var retorno = "";
            switch (status)
            {
                case EnumStatusPedido.Aberto: 
                    retorno = "text-warning";
                    break;
                case EnumStatusPedido.Producao:
                    retorno = "text-info";
                    break;
                case EnumStatusPedido.Cancelado:
                    retorno = "text-danger";
                    break;
                case EnumStatusPedido.Finalizado:
                    retorno = "text-success";
                    break;
                case EnumStatusPedido.Entregue:
                    retorno = "text-primary";
                    break;
                default:
                        retorno = "text-warning";
                    break;
            }
            return retorno;



        }

       
    }
}
