using AppWeb.Areas.Cadastros.ViewModel;
using AppWeb.Controllers;
using AppWeb.Servicos.Dtos.Cadastro;
using AppWeb.Servicos.Interface.Cadastro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Cadastros.Controllers
{
    public class ClientesController : CustomController
    {
        private readonly IClienteServico _clienteServico;

        public ClientesController(IServiceProvider serviceProvider, IClienteServico clienteServico ):base(serviceProvider)
        {
            _clienteServico = clienteServico;
        }
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Index()


        {
            var cliente = _mapper.Map<List<ClienteViewModel>>(await _clienteServico.ListarTodos());
            return View("~/Areas/Cadastros/Views/Clientes/IndexAdmin.cshtml", cliente);
        }

        [HttpGet("carregar-formulario")]
        public ActionResult LoadFormCadastro()
        {
            return View("~/Areas/Cadastros/Views/Clientes/Criar.cshtml");
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> Listar()
        {
            var produtos = _mapper.Map<List<ClienteViewModel>>(await _clienteServico.ListarTodos());
            if (!OperacaoValida()) return ReturnNotification();
            return View("~/Areas/Cadastros/Views/Clientes/Listar.cshtml", produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewModel>> ListarPorId(int id)
        {
            var produto = _mapper.Map<ClienteViewModel>(await _clienteServico.ListarPorId(id));
            return View("~/Areas/Cadastros/Views/Clientes/Editar.cshtml", produto);
        }

        [HttpPost("criar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<bool>> Criar([FromForm] ClienteViewModel produtoViewModel)
        {
            return await _clienteServico.Adicionar(_mapper.Map<ClienteDTO>(produtoViewModel));
        }

        [HttpPost, Route("editar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ClienteViewModel>> Editar([FromForm] ClienteViewModel produtoViewModel)
        {
            await _clienteServico.Atualizar(_mapper.Map<ClienteDTO>(produtoViewModel));
            return ReturnNotification();
        }

        [HttpPost, Route("excluir/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _clienteServico.Remover(id);
            return ReturnNotification();

        }
       
    }
}
