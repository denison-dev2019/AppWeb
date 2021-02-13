using AppWeb.Servicos.Client.Cadastro;
using AppWeb.Servicos.Client.Notificador;
using AppWeb.Servicos.Interface.Cadastro;
using AppWeb.Servicos.Interface.Notificador;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppWeb.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<HttpClient>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoServico, ProdutoService>();
            services.AddScoped<IProdutoServico, ProdutoService>();
            services.AddScoped<IPromocaoServico, PromocaoServico>();

            return services;
        }
    }
}
