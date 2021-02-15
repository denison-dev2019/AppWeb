using AppWeb.Areas.Cadastros.ViewModel;
using AppWeb.Servicos.Dtos.Cadastro;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.AutoMapper.Cadastro
{
    public class ClienteMapper: Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteDTO, ClienteViewModel>().ReverseMap();
        }
    }
}
