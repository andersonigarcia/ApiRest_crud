using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> Insert(Fornecedor fornecedor);
        Task<bool> Update(Fornecedor fornecedor);
        Task<bool> Delete(Guid id);

        Task UpdateAdress(Endereco endereco);
    }
}