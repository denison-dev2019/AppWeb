using AppWeb.Servicos.Dtos.Cadastro;
using AppWeb.Servicos.Dtos.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Servicos.Interface.Venda
{
    public interface IPedidoServico
    {
        Task<bool> Adicionar(PedidoDTO pedidoDTO);

        Task<bool> Atualizar(PedidoDTO pedidoDTO);
        Task<bool> Remover(int id);
        Task<IEnumerable<PedidoGetDTO>> ListarTodos();
        Task<PedidoGetDTO> ListarPorId(int id);
        Task<int> GetNovoNumero();
    }
}
