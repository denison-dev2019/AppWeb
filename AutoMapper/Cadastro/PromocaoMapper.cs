using AppWeb.Areas.Cadastro.ViewModel;
using AppWeb.Servicos.Dtos.Cadastro;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.AutoMapper.Cadastro
{
    public class PromocaoMapper : Profile
    {
        public PromocaoMapper()
        {
            CreateMap<PromocaoDTO, PromocaoViewModel>().ReverseMap();
        }
    }
}
