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
    public class ProdutoService : ApiClient, IProdutoServico
    {
        protected string Path { get; set; }
        public ProdutoService(IOptions<ApplicationSettings> appSettings,
            IHttpContextAccessor acessor,
            INotificador notificador
            ) : base(appSettings, acessor, notificador)
        {
            Path = "cadastros/produtos";
        }
        public async Task<bool> Adicionar(ProdutoDTO produtoDTO)
        {
            await base.PostAsync(CreateRequestUri($"{Path}", null), produtoDTO);
            return true;
        }

        public async Task<bool> Atualizar(ProdutoDTO produtoDTO)
        {
            await base.PutAsync(CreateRequestUri($"{Path}/{produtoDTO.Id}", null), produtoDTO);
            return true;
        }

        public async Task<IEnumerable<ProdutoGetDTO>> ListarTodos()
        {
            return (await base.GetAsync<IEnumerable<ProdutoGetDTO>>
                   (CreateRequestUri($"{Path}", null))).Data;
        }

        public async Task<ProdutoGetDTO> ListarPorId(int id)
        {
            return (await base.GetAsync<ProdutoGetDTO>
            (CreateRequestUri($"{Path}/{id}",null)))?.Data;
        }

        public async Task<bool>Remover(int id) => 
            await base.DeteleAsync<ProdutoDTO>(CreateRequestUri($"{Path}/{id}",null));
    }
}
