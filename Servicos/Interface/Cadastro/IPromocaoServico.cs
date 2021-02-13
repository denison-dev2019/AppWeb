using AppWeb.Servicos.Dtos.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Interface.Cadastro
{
    public interface IPromocaoServico
    {
        Task<bool> Adicionar(PromocaoDTO promocaoDTO);
        Task<bool> Atualizar(PromocaoDTO promocaoDTO);
        Task<bool> Remover(int id);
        Task<IEnumerable<PromocaoDTO>> ListarTodos();
        Task<PromocaoDTO> ListarPorId(int id);
    }
}
