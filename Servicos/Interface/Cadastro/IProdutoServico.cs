using AppWeb.Servicos.Dtos.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Interface.Cadastro
{
    public interface IProdutoServico
    {
        Task<bool> Adicionar(ProdutoDTO produtoDTO);
        Task<bool> Atualizar(ProdutoDTO produtoDTO);
        Task<bool> Remover(int id);
        Task<IEnumerable<ProdutoGetDTO>> ListarTodos();
        Task<ProdutoGetDTO> ListarPorId(int id);
    }
}
