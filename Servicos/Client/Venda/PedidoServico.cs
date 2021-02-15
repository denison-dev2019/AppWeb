using AppWeb.Configurations;
using AppWeb.Servicos.Client.Base;
using AppWeb.Servicos.Dtos.Venda;
using AppWeb.Servicos.Interface.Notificador;
using AppWeb.Servicos.Interface.Venda;
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
            return (await base.GetAsync<IEnumerable<PedidoGetDTO>>
                   (CreateRequestUri($"{Path}", null))).Data;
        }

        public async Task<bool> Remover(int id) =>
            await base.DeteleAsync<PedidoGetDTO>(CreateRequestUri($"{Path}/{id}", null));
    }
}
