using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryExpediente : IRepository<data.Expediente>
    {
        Task<IEnumerable<data.Expediente>> GetAllAsync();
        Task<data.Expediente> GetOneByIdAsync(int id);
    }
}
