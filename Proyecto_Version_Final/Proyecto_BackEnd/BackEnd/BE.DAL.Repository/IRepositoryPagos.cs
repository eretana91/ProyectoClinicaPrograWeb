using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;
namespace BE.DAL.Repository
{
    public interface IRepositoryPagos : IRepository<data.Pagos>
    {
        Task<IEnumerable<data.Pagos>> GetAllAsync();
        Task<data.Pagos> GetOneByIdAsync(int id);
    }
}
