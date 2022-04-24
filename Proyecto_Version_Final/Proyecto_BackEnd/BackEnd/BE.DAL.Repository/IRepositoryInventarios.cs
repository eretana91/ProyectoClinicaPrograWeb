using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryInventarios : IRepository<data.Inventarios>
    {
        Task<IEnumerable<data.Inventarios>> GetAllAsync();
        Task<data.Inventarios> GetOneByIdAsync(int id);
    }
}
