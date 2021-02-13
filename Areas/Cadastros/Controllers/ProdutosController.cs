using AppWeb.Areas.Cadastro.ViewModel;
using AppWeb.Controllers;
using AppWeb.Servicos.Dtos.Cadastro;
using AppWeb.Servicos.Interface.Cadastro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Cadastros.Controllers
{
    [Area("cadastros")]
    [Route("produtos")]
    [Route("admin/cadastros/produtos")]
    public class ProdutosController : CustomController
    {
        private readonly IProdutoServico _produtoServico;
        private readonly IPromocaoServico _promocaoServico;
        private readonly IHttpContextAccessor _acessor;
        public ProdutosController(IServiceProvider serviceProvider,
            IProdutoServico produtoServico, IPromocaoServico promocaoServico,
            IHttpContextAccessor acessor) : base(serviceProvider)
        {
            _produtoServico = produtoServico;
            _promocaoServico = promocaoServico;
            _acessor = acessor;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("carregar-formulario")]
        public ActionResult LoadFormCadastro()
        {
            return View("~/Areas/Cadastros/Views/Produtos/Criar.cshtml");
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<ProdutoGetViewModel>>> Listar()
        {
            var produtos = _mapper.Map<List<ProdutoGetViewModel>>(await _produtoServico.ListarTodos());
            if (!OperacaoValida()) return ReturnNotification();
            if (_acessor.HttpContext.Request.Path.ToString().Contains("admin")) 
                return View("~/Areas/Cadastros/Views/Produtos/ListarAdmin.cshtml", produtos);
            else
                return View("~/Areas/Cadastros/Views/Produtos/Listar.cshtml", produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoGetViewModel>> ListarPorId(int id)
        {
            var produto = _mapper.Map<ProdutoGetViewModel>(await _produtoServico.ListarPorId(id));
            await MontarListaPromocao(produto.PromocaoID);
            return View("~/Areas/Cadastros/Views/Produtos/Editar.cshtml", produto);
        }

        [HttpPost("criar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<bool>> Criar([FromForm] ProdutoPostViewModel produtoViewModel)
        {
            return await _produtoServico.Adicionar(_mapper.Map<ProdutoDTO>(produtoViewModel));
        }
       
        [HttpPost,Route("editar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ProdutoGetViewModel>> Editar([FromForm] ProdutoViewModel produtoViewModel)
        {
            await _produtoServico.Atualizar(_mapper.Map<ProdutoDTO>(produtoViewModel));
            return ReturnNotification();
        }

        [HttpPost, Route("excluir/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _produtoServico.Remover(id);
            return ReturnNotification();

        }
        private  async Task  MontarListaPromocao(int id)
        {
            @ViewBag.ListaPromocoes = _mapper.Map<List<PromocaoViewModel>>(
                    await _promocaoServico.ListarTodos())
                    .Select(p => new SelectListItem() { Text = p.Descricao, Value = p.Id.ToString(),
                        Selected = p.Id == id? true:false })
                    .ToList();
        }
    }
}
