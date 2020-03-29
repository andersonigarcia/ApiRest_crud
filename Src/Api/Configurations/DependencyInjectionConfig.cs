using Business.Intefaces;
using Data.Context;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services) {
            
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
