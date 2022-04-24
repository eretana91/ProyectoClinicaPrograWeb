using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryExpedientes : IRepository<data.Expedientes>
    {
        Task<IEnumerable<data.Expedientes>> GetAllAsync();
        Task<data.Expedientes> GetOneByIdAsync(int id);
    }
}
