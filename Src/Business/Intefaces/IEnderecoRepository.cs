using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> GetAdressByProvider(Guid fornecedorId);
    }
}