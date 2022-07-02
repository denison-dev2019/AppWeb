using AppWeb.Servicos.Dtos.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Interface.Cadastro
{
    public interface IClienteServico
    {
        Task<bool> Adicionar(ClienteDTO produtoDTO);
        Task<bool> Atualizar(ClienteDTO produtoDTO);
        Task<bool> Remover(int id);
        Task<IEnumerable<ClienteDTO>> ListarTodos();
        Task<ClienteDTO> ListarPorId(int id);
    }
}
