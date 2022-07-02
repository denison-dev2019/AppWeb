using AppWeb.Areas.Cadastros.ViewModel;
using AppWeb.Areas.Venda.ViewModel;
using AppWeb.Controllers;
using AppWeb.Servicos.Dtos.Venda;
using AppWeb.Servicos.Interface.Cadastro;
using AppWeb.Servicos.Interface.Venda;
using AppWeb.Util.Enuns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Venda.Controller
{
    [Area("venda")]
    [Route("pedidos")]
    public class PedidosController : CustomController
    {
        private readonly IPedidoServico _pedidoServico;
        private readonly IProdutoServico _produtoServico;
        private readonly IClienteServico _clienteServico;
        //private readonly IPromocaoServico _promocaoServico;
        public PedidosController(IServiceProvider serviceProvider,
            IPedidoServico pedidoServico,
            IProdutoServico produtoServico,
            IClienteServico clienteServico
            ) : base(serviceProvider)
        {
            _pedidoServico = pedidoServico;
            _produtoServico = produtoServico;
            _clienteServico = clienteServico;
        }

        [HttpGet("novo")]
        public async Task<ActionResult<PedidoGetViewModel>> Index()
        {
            var numero = await _pedidoServico.GetNovoNumero();
            await MontarListaCliente();
            return View("~/Areas/Venda/Views/Pedidos/Index.cshtml", new PedidoGetViewModel { Id = numero });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoGetViewModel>> Detalhar(int id)
        {
            var pedido = _mapper.Map<PedidoGetViewModel>(await _pedidoServico.ListarPorId(id));
            return View("~/Areas/Venda/Views/Pedidos/Detalhe.cshtml", pedido);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoGetViewModel>>> Listar()
        {
            var pedido = _mapper.Map<List<PedidoGetViewModel>>(await _pedidoServico.ListarTodos());
            return View("~/Areas/Venda/Views/Pedidos/Lista.cshtml", pedido);
        }

        [HttpPost, Route("adicionar/{id}")]
        public async Task<ActionResult<PedidoGetViewModel>> Create(int id, [FromForm] PedidoDTO pedido)
        {
            /*var produto = await _produtoServico.ListarPorId(id);
            var itens = new List<PedidoItensDTO>();
            var item = new PedidoItensDTO
            {
                PedidoId = 0,
                ProdutoId = id,
                QuantidadeProduto = 1,
                ValorUnitarioProduto = produto.Preco
            };
            itens.Add(item); 
            
            var Pedido = new PedidoDTO {
                ClienteId = 1,
                Status = EnumStatusPedido.Aberto,
                Valor = produto.Preco,
                PedidoItens = itens
            };*/
            var result = await _pedidoServico.Adicionar(pedido);
            return  _mapper.Map< PedidoGetViewModel >(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("editar/{id}")]
        public async Task<ActionResult<PedidoGetViewModel>> Editar(int id)
        {
            var pedido = _mapper.Map<PedidoGetViewModel>(await _pedidoServico.ListarPorId(id));
            return View("~/Areas/Venda/Views/Pedidos/Editar.cshtml", pedido);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost, Route("excluir/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _pedidoServico.Remover(id);
            return ReturnNotification();
        }

        private async Task MontarListaCliente()
        {
            @ViewBag.ListagemClientes = _mapper.Map<List<ClienteViewModel>>(
                    await _clienteServico.ListarTodos())
                    .Select(p => new SelectListItem()
                    {
                        Text = p.Nome,
                        Value = p.Id.ToString()
                    })
                    .ToList();
        }


    }
}
