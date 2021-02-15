using AppWeb.Areas.Venda.ViewModel;
using AppWeb.Servicos.Dtos.Venda;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.AutoMapper.Venda
{
    public class PedidoMaper: Profile
    {
        public PedidoMaper()
        {
            CreateMap<PedidoDTO, PedidoViewModel>().ReverseMap();
            CreateMap<PedidoGetDTO, PedidoGetViewModel>().ReverseMap();
        }
    }
}
