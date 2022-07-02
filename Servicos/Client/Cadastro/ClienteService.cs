using AppWeb.Configurations;
using AppWeb.Servicos.Client.Base;
using AppWeb.Servicos.Dtos.Cadastro;
using AppWeb.Servicos.Interface.Cadastro;
using AppWeb.Servicos.Interface.Notificador;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Client.Cadastro
{
    public class ClienteService: ApiClient, IClienteServico
    {
        protected string Path { get; set; }
        public ClienteService(IOptions<ApplicationSettings> appSettings,
            IHttpContextAccessor acessor,
            INotificador notificador
            ) : base(appSettings, acessor, notificador)
        {
            Path = "cadastros/clientes";
        }
        public async Task<bool> Adicionar(ClienteDTO produtoDTO)
        {
            await base.PostAsync(CreateRequestUri($"{Path}", null), produtoDTO);
            return true;
        }

        public async Task<bool> Atualizar(ClienteDTO produtoDTO)
        {
            await base.PutAsync(CreateRequestUri($"{Path}/{produtoDTO.Id}", null), produtoDTO);
            return true;
        }

        public async Task<IEnumerable<ClienteDTO>> ListarTodos()
        {
            return (await base.GetAsync<IEnumerable<ClienteDTO>>
                   (CreateRequestUri($"{Path}", null))).Data;
        }

        public async Task<ClienteDTO> ListarPorId(int id)
        {
            return (await base.GetAsync<ClienteDTO>
            (CreateRequestUri($"{Path}/{id}", null)))?.Data;
        }

        public async Task<bool> Remover(int id) =>
            await base.DeteleAsync<ClienteDTO>(CreateRequestUri($"{Path}/{id}", null));

    }
}
