using Api.Dtos;
using AutoMapper;
using Business.Models;

namespace Api.Configurations
{
    //Essa classe não precisa de inicialização pois será chamada automaticamnete no momento da incialização do AutoMapper dentro do startup
    public class AutoMapperConfig : Profile 
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
