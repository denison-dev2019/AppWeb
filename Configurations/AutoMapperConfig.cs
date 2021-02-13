using AppWeb.AutoMapper.Cadastro;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperCustomizado(this IServiceCollection servicos)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullDestinationValues = true;
                mc.AddProfile(new ProdutoMapper());
                mc.AddProfile(new PromocaoMapper());
            });
            var mapper = mappingConfig.CreateMapper();
            servicos.AddSingleton(mapper);
        }
    }
}
