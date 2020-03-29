using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Intefaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> GetProviderAdressById(Guid id);
        Task<Fornecedor> GetProviderProductAdressById(Guid id);
    }
}