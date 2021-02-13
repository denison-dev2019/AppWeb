using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppWeb.Configurations;
using AppWeb.Servicos.Client.Base;
using AppWeb.Servicos.Dtos.Cadastro;
using AppWeb.Servicos.Interface.Cadastro;
using AppWeb.Servicos.Interface.Notificador;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AppWeb.Servicos.Client.Cadastro
{
    public class PromocaoServico : ApiClient, IPromocaoServico
    {
        protected string Path { get; set; }
        public PromocaoServico(IOptions<ApplicationSettings> appSettings,
            IHttpContextAccessor acessor,
            INotificador notificador
            ) : base(appSettings, acessor, notificador)
        {
            Path = "cadastros/promocoes";
        }
        public async Task<bool> Adicionar(PromocaoDTO promocaoDTO)
        {
            await base.PostAsync(CreateRequestUri($"{Path}", null), promocaoDTO);
            return true;
        }

        public async Task<bool> Atualizar(PromocaoDTO promocaoDTO)
        {
            await base.PutAsync(CreateRequestUri($"{Path}/{promocaoDTO.Id}", null), promocaoDTO);
            return true;
        }

        public async Task<IEnumerable<PromocaoDTO>> ListarTodos()
        {
            return (await base.GetAsync<IEnumerable<PromocaoDTO>>
                   (CreateRequestUri($"{Path}", null))).Data;
        }

        public async Task<PromocaoDTO> ListarPorId(int id)
        {
            return (await base.GetAsync<PromocaoDTO>
            (CreateRequestUri($"{Path}/{id}",null)))?.Data;
        }

        public async Task<bool>Remover(int id) => 
            await base.DeteleAsync<PromocaoDTO>(CreateRequestUri($"{Path}/{id}",null));

    }
}
