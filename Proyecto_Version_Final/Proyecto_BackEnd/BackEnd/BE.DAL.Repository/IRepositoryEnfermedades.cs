using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryEnfermedades : IRepository<data.Enfermedades>
    {
        Task<IEnumerable<data.Enfermedades>> GetAllAsync();
        Task<data.Enfermedades> GetOneByIdAsync(int id);
    }
}
